namespace DXApplication9
{
    partial class CuentasDeClienteXtraForm
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
            this.cuentasBancariasDeClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCuentaBancariaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoMoneda_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tipoMonedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colTitular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.cuentasBancariasDeClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoMoneda_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // cuentasBancariasDeClienteBindingSource
            // 
            this.cuentasBancariasDeClienteBindingSource.DataSource = typeof(DXApplication9.CuentasBancariasDeCliente);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(584, 260);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.cuentasBancariasDeClienteBindingSource;
            this.gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TipoMoneda_repositoryItemLookUpEdit});
            this.gridControl1.Size = new System.Drawing.Size(560, 236);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCuentaBancariaID,
            this.colNumeroCuenta,
            this.colTipoMoneda,
            this.colTitular,
            this.colBanco});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "CLICK PARA INSERTAR CUENTA";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colCuentaBancariaID
            // 
            this.colCuentaBancariaID.FieldName = "CuentaBancariaID";
            this.colCuentaBancariaID.Name = "colCuentaBancariaID";
            // 
            // colNumeroCuenta
            // 
            this.colNumeroCuenta.FieldName = "NumeroCuenta";
            this.colNumeroCuenta.Name = "colNumeroCuenta";
            this.colNumeroCuenta.Visible = true;
            this.colNumeroCuenta.VisibleIndex = 1;
            // 
            // colTipoMoneda
            // 
            this.colTipoMoneda.Caption = "Moneda";
            this.colTipoMoneda.ColumnEdit = this.TipoMoneda_repositoryItemLookUpEdit;
            this.colTipoMoneda.FieldName = "TipoMoneda";
            this.colTipoMoneda.Name = "colTipoMoneda";
            this.colTipoMoneda.OptionsEditForm.Caption = "Moneda:";
            this.colTipoMoneda.Visible = true;
            this.colTipoMoneda.VisibleIndex = 0;
            // 
            // TipoMoneda_repositoryItemLookUpEdit
            // 
            this.TipoMoneda_repositoryItemLookUpEdit.AutoHeight = false;
            this.TipoMoneda_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TipoMoneda_repositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abreviatura", "Moneda")});
            this.TipoMoneda_repositoryItemLookUpEdit.DataSource = this.tipoMonedaBindingSource;
            this.TipoMoneda_repositoryItemLookUpEdit.DisplayMember = "Abreviatura";
            this.TipoMoneda_repositoryItemLookUpEdit.Name = "TipoMoneda_repositoryItemLookUpEdit";
            // 
            // tipoMonedaBindingSource
            // 
            this.tipoMonedaBindingSource.DataSource = typeof(DXApplication9.TipoMoneda);
            // 
            // colTitular
            // 
            this.colTitular.FieldName = "Titular";
            this.colTitular.Name = "colTitular";
            this.colTitular.Visible = true;
            this.colTitular.VisibleIndex = 2;
            // 
            // colBanco
            // 
            this.colBanco.FieldName = "Banco";
            this.colBanco.Name = "colBanco";
            this.colBanco.Visible = true;
            this.colBanco.VisibleIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(584, 260);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(564, 240);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // CuentasDeClienteXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 260);
            this.Controls.Add(this.layoutControl1);
            this.Name = "CuentasDeClienteXtraForm";
            this.Text = "Cuentas";
            ((System.ComponentModel.ISupportInitialize)(this.cuentasBancariasDeClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoMoneda_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource cuentasBancariasDeClienteBindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentaBancariaID;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMoneda;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit TipoMoneda_repositoryItemLookUpEdit;
        private System.Windows.Forms.BindingSource tipoMonedaBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTitular;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colBanco;
    }
}