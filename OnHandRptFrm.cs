using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace RBOS
{
    public partial class OnHandRptFrm : Form
    {
        #region Private variables

        private string selectedSubCategoryIDFrom = "";
        private string selectedSubCategoryDescFrom = "";
        private string selectedSubCategoryIDTo = "";
        private string selectedSubCategoryDescTo = "";        
        #endregion

        #region Constructor
        public OnHandRptFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Print
        private void Print(bool Preview)
        {
            // check for needed values before allowing print
            if ((selectedSubCategoryIDTo == "") || (selectedSubCategoryIDFrom == ""))
            {
                MessageBox.Show(db.GetLangString("OnHandRptFrm.PlsSelectSubCatInterval"));
                return;
            }

            // prepare and show progress form
            ProgressForm progress = new ProgressForm(db.GetLangString("OnHandRptFrm.PerformingCalculations"));
            progress.StatusText = db.GetLangString("OnHandRptFrm.PreparingData");
            progress.Show();

            // create dataset
            ReportDataSet dsReport = new ReportDataSet();

            // variables used in query parameter
            string SubCatFrom = "";
            string SubCatTo = "";
            if (selectedSubCategoryIDFrom != "")
                SubCatFrom = " and (SubCategoryID >= '" + selectedSubCategoryIDFrom + "') ";
            if (selectedSubCategoryIDTo != "")
                SubCatTo = " and (SubCategoryID <= '" + selectedSubCategoryIDTo + "') ";

            // build query
            // (any fields defined here not in xsd file definition, is autogenerated)
            string sql = string.Format(@"
                select
                  Item.SubCategory,
                  SubCategory.Description as SubCatDesc,
                  Item.ItemID,
                  Item.ItemName,
                  Item.CostPriceLatest,
                  Item.SubCategory + ' (' +  SubCategory.Description +  ')' as GroupingDisplay
                from (Item
                inner join SubCategory
                  on Item.SubCategory = SubCategory.SubCategoryID)
                where (1=1) {0} {1}
                group by
                  Item.SubCategory,
                  SubCategory.Description,
                  Item.ItemID,
                  Item.ItemName,
                  Item.CostPriceLatest                  
                order by 1,3
                ",
                 SubCatFrom,
                 SubCatTo);

            // load data
            db.FillDataTable(sql, dsReport.OnHandReport, true);

            // now we know how many records are loaded, setup the progress bar
            progress.ProgressMax = dsReport.OnHandReport.Rows.Count;

            // variable needed for detecting if any records were not skipped
            bool ARecordNeedsToPrint = false;

            // perform various calculations on each record
            foreach (DataRow row in dsReport.OnHandReport.Rows)
            {
                // show the subcategory on the progress form
                progress.StatusText = db.GetLangString("OnHandRptFrm.SubCategory") + ": " + tools.object2string(row["SubCatDesc"]);

                // get the ItemID for the current record
                int ItemID = tools.object2int(row["ItemID"]);

                // get short references to date from/to
                DateTime PostingDateFrom = dtPostingDateFrom.Value.Date;
                DateTime PostingDateTo = dtPostingDateTo.Value.Date;

                // calculate primo stock
                // (primo stock is calculated up until the day before PostingDateFrom)
                //DateTime DateForPrimoStock = PostingDateFrom.Subtract(new TimeSpan(1, 0, 0, 0, 0));
                //row["OnHandPrimo"] = ItemDataSet.ItemTransactionDataTable.CalcItemOnHandPerDateNoLimit(
                //    ItemID, DateForPrimoStock);
                row["OnHandPrimo"] = ItemDataSet.ItemTransactionDataTable.CalculateStock(ItemID, PostingDateFrom.AddDays(-1));

                // calculate NoOfSellingUnits for the different types
                row["Sales"] = ItemDataSet.ItemTransactionDataTable.CalcItemOnHandPerDateNoLimit(
                    ItemID, PostingDateFrom, PostingDateTo, db.TransactionTypes.Sales);
                row["Purchase"] = ItemDataSet.ItemTransactionDataTable.CalcItemOnHandPerDateNoLimit(
                    ItemID, PostingDateFrom, PostingDateTo, db.TransactionTypes.Purchase);
                row["Waste"] = ItemDataSet.ItemTransactionDataTable.CalcItemOnHandPerDateNoLimit(
                    ItemID, PostingDateFrom, PostingDateTo, db.TransactionTypes.Waste);
                row["Adjustment"] = ItemDataSet.ItemTransactionDataTable.CalcItemOnHandPerDateNoLimit(
                    ItemID, PostingDateFrom, PostingDateTo, db.TransactionTypes.Adjustment);
                row["CountAdjustment"] = ItemDataSet.ItemTransactionDataTable.CalcItemOnHandPerDateNoLimit(
                    ItemID, PostingDateFrom, PostingDateTo, db.TransactionTypes.CountAdjustment);
                row["Receive"] = ItemDataSet.ItemTransactionDataTable.CalcItemOnHandPerDateNoLimit(
                    ItemID, PostingDateFrom, PostingDateTo, db.TransactionTypes.Receive);
                row["Transfer"] = ItemDataSet.ItemTransactionDataTable.CalcItemOnHandPerDateNoLimit(
                    ItemID, PostingDateFrom, PostingDateTo, db.TransactionTypes.Transfer);

                // calculate ultimo stock
                row["OnHandUltimo"] = ItemDataSet.ItemTransactionDataTable.CalculateStock(ItemID, PostingDateTo);
                //row["OnHandUltimo"] = ItemDataSet.ItemTransactionDataTable.CalcItemOnHandPerDateNoLimit(
                //    ItemID, PostingDateTo);

                // calculate selling unit cost ex. VAT
                double CostPriceLatest = tools.object2double(row["CostPriceLatest"]);
                string SubCategoryID = tools.object2string(row["SubCategory"]);
                double VAT = tools.GetSubCategoryVAT(SubCategoryID);
                row["SellingUnitCostExVAT"] = tools.DeductVAT(CostPriceLatest, VAT);

                // calculate stock value (OnHandUltimo * SellingUnitCostExVAT)
                row["StockValueExVAT"] = tools.object2int(row["OnHandUltimo"]) * tools.object2double(row["SellingUnitCostExVAT"]);

                // if all calculated values are 0, do not display the record in print
                if ((tools.object2int(row["OnHandPrimo"]) == 0) &&
                    (tools.object2int(row["Sales"]) == 0) &&
                    (tools.object2int(row["Purchase"]) == 0) &&
                    (tools.object2int(row["Waste"]) == 0) &&
                    (tools.object2int(row["Adjustment"]) == 0) &&
                    (tools.object2int(row["CountAdjustment"]) == 0) &&
                    (tools.object2int(row["Receive"]) == 0) &&
                    (tools.object2int(row["Transfer"]) == 0) &&
                    (tools.object2int(row["OnHandUltimo"]) == 0))
                {
                    row["Skipped"] = true;
                }
                else
                {
                    // this tells us that at least one record were not skipped
                    ARecordNeedsToPrint = true;
                }
            }

            progress.StatusText = db.GetLangString("OnHandRptFrm.FinishingCalculations");

            // check that we have valid data to print
            if (!ARecordNeedsToPrint)
            {
                progress.Hide();
                MessageBox.Show(db.GetLangString("OnHandRptFrm.NoDataToBePrinted"));
                return;
            }

            // if export file has been checked, generate OPT export file.
            // NOTE: do it before setting the report's datasource,
            // so some changes to the table in the method is reflected in the print.
            if (chkGenerateAccountingFile.Checked)
                ExportAccounting.GenerateOPTFile(dsReport.OnHandReport, dtPostingDateFrom.Value, dtPostingDateTo.Value);
           
            // set report's data source
            DataView dv = dsReport.DefaultViewManager.CreateDataView(dsReport.OnHandReport);
            if (chkSortBySale.Checked)
                dv.Sort = "GroupingDisplay desc,Sales ASC";            
            else
                dv.Sort = "GroupingDisplay desc,ItemName ASC";            
            DataTable sortedDT = dv.ToTable();            
            // rptOnHand.SetDataSource(dsReport);
            rptOnHand.SetDataSource(sortedDT);     
                        
            // suppress detail sections if user has selected to only view subcategories
            rptOnHand.Section3.SectionFormat.EnableSuppress = chkOnlySubCats.Checked;
            rptOnHand.GroupHeaderSection1.SectionFormat.EnableSuppress = chkOnlySubCats.Checked;

            // build string for inserting criteria into report
            string printSubCategoryFrom = selectedSubCategoryIDFrom + " (" + selectedSubCategoryDescFrom + ")";
            string printSubCategoryTo = selectedSubCategoryIDTo + " (" + selectedSubCategoryDescTo + ")";
            string printDateFrom = dtPostingDateFrom.Value.ToString("dd-MM-yyyy");
            string printDateTo = dtPostingDateTo.Value.ToString("dd-MM-yyyy");

            // insert criteria information into report
            tools.SetReportObjectText(rptOnHand, "SubCategoryFrom", printSubCategoryFrom);
            tools.SetReportObjectText(rptOnHand, "SubCategoryTo", printSubCategoryTo);
            tools.SetReportObjectText(rptOnHand, "DateFrom", printDateFrom);
            tools.SetReportObjectText(rptOnHand, "DateTo", printDateTo);

            // insert site information into report
            tools.SetReportSiteInformation(rptOnHand);

            progress.Hide();

            // print the report in landscape
            tools.Print(rptOnHand, Preview, false);
        }
        #endregion

        #region SelectSubCategoryFrom
        private void SelectSubCategoryFrom()
        {
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.OrderBySubCategoryID();
            subcat.SelectedSubCategoryID = selectedSubCategoryIDFrom;
            if (subcat.ShowDialog() == DialogResult.OK)
            {
                // did user select a new subcategory?
                if (selectedSubCategoryIDFrom != subcat.SelectedSubCategoryID)
                {
                    // set selected subcategory from information
                    selectedSubCategoryIDFrom = subcat.SelectedSubCategoryID;
                    selectedSubCategoryDescFrom = subcat.SelectedSubCategoryDesc;
                    if (selectedSubCategoryDescFrom == null) selectedSubCategoryDescFrom = "";
                    txtSubCategoryFrom.Text = selectedSubCategoryDescFrom;

                    // ensure correct subcategory interval
                    if (tools.object2int(selectedSubCategoryIDTo) < tools.object2int(selectedSubCategoryIDFrom))
                    {
                        // fix the to subcategory
                        selectedSubCategoryIDTo = selectedSubCategoryIDFrom;
                        selectedSubCategoryDescTo = selectedSubCategoryDescFrom;
                        txtSubCategoryTo.Text = selectedSubCategoryDescTo;
                    }
                }
            }
        }
        #endregion

        #region SelectSubCategoryTo
        private void SelectSubCategoryTo()
        {
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.OrderBySubCategoryID();
            subcat.SelectedSubCategoryID = selectedSubCategoryIDTo;
            if (subcat.ShowDialog() == DialogResult.OK)
            {
                // did user select a new subcategory?
                if (selectedSubCategoryIDTo != subcat.SelectedSubCategoryID)
                {
                    // set selected subcategory to information
                    selectedSubCategoryIDTo = subcat.SelectedSubCategoryID;
                    selectedSubCategoryDescTo = subcat.SelectedSubCategoryDesc;
                    if (selectedSubCategoryDescTo == null) selectedSubCategoryDescTo = "";
                    txtSubCategoryTo.Text = selectedSubCategoryDescTo;

                    // ensure correct subcategory interval
                    if (tools.object2int(selectedSubCategoryIDTo) < tools.object2int(selectedSubCategoryIDFrom))
                    {
                        // fix the from subcategory
                        selectedSubCategoryIDFrom = selectedSubCategoryIDTo;
                        selectedSubCategoryDescFrom = selectedSubCategoryDescTo;
                        txtSubCategoryFrom.Text = selectedSubCategoryDescFrom;
                    }
                }
            }
        }
        #endregion

        #region PreSelectDates
        private void PreSelectDates()
        {
            DateTime EndDate = DateTime.Now.Subtract(new TimeSpan(DateTime.Now.Day, 0, 0, 0)).Date;
            DateTime StartDate = new DateTime(EndDate.Year, EndDate.Month, 1);
            dtPostingDateFrom.Value = StartDate;
            dtPostingDateTo.Value = EndDate;
        }
        #endregion

        #region EnsureCorrectDateIntervalWhenChangingDateFrom
        /// <summary>
        /// Ensures correct date interval (from is before to)
        /// when changing from date
        /// </summary>
        private void EnsureCorrectDateIntervalWhenChangingDateFrom()
        {
            // ensure correct date interval
            if (dtPostingDateTo.Value < dtPostingDateFrom.Value)
            {
                // fix posting date to
                dtPostingDateTo.Value = dtPostingDateFrom.Value;
            }
        }
        #endregion

        #region EnsureCorrectDateIntervalWhenChangingDateTo
        /// <summary>
        /// Ensures correct date interval (from is before to)
        /// when changing to date
        /// </summary>
        private void EnsureCorrectDateIntervalWhenChangingDateTo()
        {
            // ensure correct date interval
            if (dtPostingDateTo.Value < dtPostingDateFrom.Value)
            {
                // fix posting date from
                dtPostingDateFrom.Value = dtPostingDateTo.Value;
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void btnSubCategoryFrom_Click(object sender, EventArgs e)
        {
            SelectSubCategoryFrom();
        }

        private void btnSubCategoryTo_Click(object sender, EventArgs e)
        {
            SelectSubCategoryTo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnHandRptFrm_Load(object sender, EventArgs e)
        {
            // Localize
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbSubCategoryFrom.Text = db.GetLangString("OnHandRptFrm.lbSubCategoryFrom");
            lbSubCategoryTo.Text = db.GetLangString("OnHandRptFrm.lbSubCategoryTo");
            lbPostingDateStart.Text = db.GetLangString("OnHandRptFrm.lbPostingDateStart");
            lbPostingDateEnd.Text = db.GetLangString("OnHandRptFrm.lbPostingDateEnd");
            chkOnlySubCats.Text = db.GetLangString("OnHandRptFrm.chkOnlySubCats");
            chkGenerateAccountingFile.Text = db.GetLangString("OnHandRptForm.GenerateAccFile");

            // toggle visibility of export file checkbox
            chkGenerateAccountingFile.Visible = (ExportAccounting.GetOutputDir() != "");

            PreSelectDates();
        }

        private void dtPostingDateFrom_Validated(object sender, EventArgs e)
        {
            EnsureCorrectDateIntervalWhenChangingDateFrom();
        }

        private void dtPostingDateFrom_CloseUp(object sender, EventArgs e)
        {
            EnsureCorrectDateIntervalWhenChangingDateFrom();
        }

        private void dtPostingDateTo_CloseUp(object sender, EventArgs e)
        {
            EnsureCorrectDateIntervalWhenChangingDateTo();
        }

        private void dtPostingDateTo_Validated(object sender, EventArgs e)
        {
            EnsureCorrectDateIntervalWhenChangingDateTo();
        }
    }
}