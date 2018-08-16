namespace DXApplication9
{
    partial class CargosXtraForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Cargos_gridControl = new DevExpress.XtraGrid.GridControl();
            this.nomencladorCargoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Cargos_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomencladorCargoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoCargo_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colPesoDeCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.colTipoNomencladorCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tipoNomencladorCargoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cargos_gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomencladorCargoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cargos_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoCargo_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoNomencladorCargoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Cargos_gridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(539, 286);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Cargos_gridControl
            // 
            this.Cargos_gridControl.DataSource = this.nomencladorCargoBindingSource;
            this.Cargos_gridControl.Location = new System.Drawing.Point(12, 12);
            this.Cargos_gridControl.MainView = this.Cargos_gridView;
            this.Cargos_gridControl.Name = "Cargos_gridControl";
            this.Cargos_gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TipoCargo_repositoryItemLookUpEdit});
            this.Cargos_gridControl.Size = new System.Drawing.Size(515, 262);
            this.Cargos_gridControl.TabIndex = 4;
            this.Cargos_gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Cargos_gridView});
            // 
            // nomencladorCargoBindingSource
            // 
            this.nomencladorCargoBindingSource.DataSource = typeof(DXApplication9.NomencladorCargo);
            // 
            // Cargos_gridView
            // 
            this.Cargos_gridView.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Cargos_gridView.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cargos_gridView.Appearance.TopNewRow.ForeColor = System.Drawing.Color.White;
            this.Cargos_gridView.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Cargos_gridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.Cargos_gridView.Appearance.TopNewRow.Options.UseFont = true;
            this.Cargos_gridView.Appearance.TopNewRow.Options.UseForeColor = true;
            this.Cargos_gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescripcion,
            this.colNomencladorCargoID,
            this.colPesoDeCargo,
            this.colTipoNomencladorCargo});
            this.Cargos_gridView.GridControl = this.Cargos_gridControl;
            this.Cargos_gridView.Name = "Cargos_gridView";
            this.Cargos_gridView.NewItemRowText = "Clic aquí Para insertar nuevo registro";
            this.Cargos_gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.Cargos_gridView.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.Cargos_gridView.OptionsEditForm.EditFormColumnCount = 1;
            this.Cargos_gridView.OptionsFind.AlwaysVisible = true;
            this.Cargos_gridView.OptionsSelection.MultiSelect = true;
            this.Cargos_gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.Cargos_gridView.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.Cargos_gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.Cargos_gridView.OptionsView.ShowDetailButtons = false;
            this.Cargos_gridView.OptionsView.ShowGroupPanel = false;
            this.Cargos_gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Cargos_gridView_RowUpdated);
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colNomencladorCargoID
            // 
            this.colNomencladorCargoID.FieldName = "NomencladorCargoID";
            this.colNomencladorCargoID.Name = "colNomencladorCargoID";
            // 
            // TipoCargo_repositoryItemLookUpEdit
            // 
            this.TipoCargo_repositoryItemLookUpEdit.AutoHeight = false;
            this.TipoCargo_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TipoCargo_repositoryItemLookUpEdit.DataSource = this.tipoNomencladorCargoBindingSource;
            this.TipoCargo_repositoryItemLookUpEdit.DisplayMember = "Abreviatura";
            this.TipoCargo_repositoryItemLookUpEdit.KeyMember = "TipoNomencladorCargoID";
            this.TipoCargo_repositoryItemLookUpEdit.Name = "TipoCargo_repositoryItemLookUpEdit";
            this.TipoCargo_repositoryItemLookUpEdit.ValueMember = "TipoNomencladorCargoID";
            // 
            // colPesoDeCargo
            // 
            this.colPesoDeCargo.FieldName = "PesoDeCargo";
            this.colPesoDeCargo.Name = "colPesoDeCargo";
            this.colPesoDeCargo.Visible = true;
            this.colPesoDeCargo.VisibleIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(539, 286);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Cargos_gridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(519, 266);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            // 
            // colTipoNomencladorCargo
            // 
            this.colTipoNomencladorCargo.ColumnEdit = this.TipoCargo_repositoryItemLookUpEdit;
            this.colTipoNomencladorCargo.FieldName = "TipoNomencladorCargo.Abreviatura";
            this.colTipoNomencladorCargo.Name = "colTipoNomencladorCargo";
            this.colTipoNomencladorCargo.Visible = true;
            this.colTipoNomencladorCargo.VisibleIndex = 3;
            // 
            // tipoNomencladorCargoBindingSource
            // 
            this.tipoNomencladorCargoBindingSource.DataSource = typeof(DXApplication9.TipoNomencladorCargo);
            // 
            // CargosXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 286);
            this.Controls.Add(this.layoutControl1);
            this.Name = "CargosXtraForm";
            this.Text = "Nomenclador de Cargos";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cargos_gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomencladorCargoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cargos_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoCargo_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoNomencladorCargoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl Cargos_gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Cargos_gridView;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private System.Windows.Forms.BindingSource nomencladorCargoBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn colNomencladorCargoID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit TipoCargo_repositoryItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colPesoDeCargo;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoNomencladorCargo;
        private System.Windows.Forms.BindingSource tipoNomencladorCargoBindingSource;
    }
}