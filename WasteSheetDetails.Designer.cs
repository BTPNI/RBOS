namespace RBOS
{
    partial class WasteSheetDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WasteSheetDetails));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.bindingWasteSheetHeader = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.bindingWasteSheetDetailsLookups = new System.Windows.Forms.BindingSource(this.components);
            this.bindingWasteSheetDetails = new System.Windows.Forms.BindingSource(this.components);
            this.adapterWasteSheetDetails = new RBOS.ItemDataSetTableAdapters.WasteSheetDetailsTableAdapter();
            this.adapterWasteSheetDetailsLookups = new RBOS.ItemDataSetTableAdapters.WasteSheetDetailsLookupsTableAdapter();
            this.adapterWasteSheetHeader = new RBOS.ItemDataSetTableAdapters.WasteSheetHeaderTableAdapter();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colLookupItemButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPackTypeName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCostPriceLatest = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSalesPrice = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetDetailsLookups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(451, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "[Annuller]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(340, 346);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(105, 23);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "[Gem og luk]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(12, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 13);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "[Navn]";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWasteSheetHeader, "Name", true));
            this.txtName.Location = new System.Drawing.Point(70, 12);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 20);
            this.txtName.TabIndex = 3;
            // 
            // bindingWasteSheetHeader
            // 
            this.bindingWasteSheetHeader.DataMember = "WasteSheetHeader";
            this.bindingWasteSheetHeader.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingWasteSheetDetailsLookups
            // 
            this.bindingWasteSheetDetailsLookups.DataMember = "WasteSheetDetailsLookups";
            this.bindingWasteSheetDetailsLookups.DataSource = this.dsItem;
            // 
            // bindingWasteSheetDetails
            // 
            this.bindingWasteSheetDetails.DataMember = "WasteSheetDetails";
            this.bindingWasteSheetDetails.DataSource = this.dsItem;
            // 
            // adapterWasteSheetDetails
            // 
            this.adapterWasteSheetDetails.ClearBeforeFill = true;
            // 
            // adapterWasteSheetDetailsLookups
            // 
            this.adapterWasteSheetDetailsLookups.ClearBeforeFill = true;
            // 
            // adapterWasteSheetHeader
            // 
            this.adapterWasteSheetHeader.ClearBeforeFill = true;
            // 
            // grid
            // 
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLookupItemButton,
            this.colPackTypeName,
            this.colCostPriceLatest,
            this.colItemName,
            this.colSalesPrice,
            this.colBarcode});
            this.grid.DataSource = this.bindingWasteSheetDetails;
            this.grid.Location = new System.Drawing.Point(12, 38);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(514, 302);
            this.grid.TabIndex = 4;
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // colLookupItemButton
            // 
            this.colLookupItemButton.HeaderText = "";
            this.colLookupItemButton.Name = "colLookupItemButton";
            this.colLookupItemButton.Width = 25;
            // 
            // colPackTypeName
            // 
            this.colPackTypeName.DataPropertyName = "Barcode";
            this.colPackTypeName.DataSource = this.bindingWasteSheetDetailsLookups;
            this.colPackTypeName.DisplayMember = "PackTypeName";
            this.colPackTypeName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colPackTypeName.HeaderText = "PackType";
            this.colPackTypeName.Name = "colPackTypeName";
            this.colPackTypeName.ReadOnly = true;
            this.colPackTypeName.ValueMember = "Barcode";
            this.colPackTypeName.Width = 70;
            // 
            // colCostPriceLatest
            // 
            this.colCostPriceLatest.DataPropertyName = "Barcode";
            this.colCostPriceLatest.DataSource = this.bindingWasteSheetDetailsLookups;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.colCostPriceLatest.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCostPriceLatest.DisplayMember = "CostPriceLatest";
            this.colCostPriceLatest.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colCostPriceLatest.HeaderText = "CostPrice";
            this.colCostPriceLatest.Name = "colCostPriceLatest";
            this.colCostPriceLatest.ReadOnly = true;
            this.colCostPriceLatest.ValueMember = "Barcode";
            this.colCostPriceLatest.Width = 70;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "Barcode";
            this.colItemName.DataSource = this.bindingWasteSheetDetailsLookups;
            this.colItemName.DisplayMember = "ItemName";
            this.colItemName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colItemName.HeaderText = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.ValueMember = "Barcode";
            // 
            // colSalesPrice
            // 
            this.colSalesPrice.DataPropertyName = "Barcode";
            this.colSalesPrice.DataSource = this.bindingWasteSheetDetailsLookups;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colSalesPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSalesPrice.DisplayMember = "SalesPrice";
            this.colSalesPrice.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colSalesPrice.HeaderText = "SalesPrice";
            this.colSalesPrice.Name = "colSalesPrice";
            this.colSalesPrice.ReadOnly = true;
            this.colSalesPrice.ValueMember = "Barcode";
            this.colSalesPrice.Width = 70;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // WasteSheetDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 381);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WasteSheetDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WasteSheetDetails";
            this.Load += new System.EventHandler(this.WasteSheetDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetDetailsLookups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingWasteSheetDetails;
        private RBOS.ItemDataSetTableAdapters.WasteSheetDetailsTableAdapter adapterWasteSheetDetails;
        private System.Windows.Forms.BindingSource bindingWasteSheetDetailsLookups;
        private System.Windows.Forms.BindingSource bindingWasteSheetHeader;
        private RBOS.ItemDataSetTableAdapters.WasteSheetHeaderTableAdapter adapterWasteSheetHeader;
        private System.Windows.Forms.DataGridViewButtonColumn colLookupItemButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackTypeName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCostPriceLatest;
        private System.Windows.Forms.DataGridViewComboBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private RBOS.ItemDataSetTableAdapters.WasteSheetDetailsLookupsTableAdapter adapterWasteSheetDetailsLookups;
    }
}