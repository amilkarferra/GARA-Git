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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargosXtraForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Cargos_gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomencladorCargoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPesoDeCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoNomencladorCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoCargo_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tipoNomencladorCargoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.Nuevo_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.Edit_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.Delete_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.Refresh_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cargos_gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoCargo_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoNomencladorCargoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Cargos_gridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 147);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(702, 415);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Cargos_gridControl
            // 
            this.Cargos_gridControl.DataSource = this.bindingSource;
            this.Cargos_gridControl.Location = new System.Drawing.Point(12, 12);
            this.Cargos_gridControl.MainView = this.gridView;
            this.Cargos_gridControl.Name = "Cargos_gridControl";
            this.Cargos_gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TipoCargo_repositoryItemLookUpEdit});
            this.Cargos_gridControl.Size = new System.Drawing.Size(678, 391);
            this.Cargos_gridControl.TabIndex = 4;
            this.Cargos_gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(DXApplication9.NomencladorCargo);
            // 
            // gridView
            // 
            this.gridView.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gridView.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.TopNewRow.ForeColor = System.Drawing.Color.White;
            this.gridView.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView.Appearance.TopNewRow.Options.UseForeColor = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescripcion,
            this.colNomencladorCargoID,
            this.colPesoDeCargo,
            this.colTipoNomencladorCargo});
            this.gridView.GridControl = this.Cargos_gridControl;
            this.gridView.Name = "gridView";
            this.gridView.NewItemRowText = "Clic aquí Para insertar nuevo registro";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.gridView.OptionsEditForm.EditFormColumnCount = 1;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ShowDetailButtons = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gridView_RowDeleting);
            this.gridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridView_RowDeleted);
            this.gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Cargos_gridView_RowUpdated);
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
            // colPesoDeCargo
            // 
            this.colPesoDeCargo.FieldName = "PesoDeCargo";
            this.colPesoDeCargo.Name = "colPesoDeCargo";
            this.colPesoDeCargo.ToolTip = "Las listas se organizan de menor a mayor peso (el director es el de menor peso)";
            this.colPesoDeCargo.Visible = true;
            this.colPesoDeCargo.VisibleIndex = 2;
            // 
            // colTipoNomencladorCargo
            // 
            this.colTipoNomencladorCargo.Caption = "Tipo";
            this.colTipoNomencladorCargo.ColumnEdit = this.TipoCargo_repositoryItemLookUpEdit;
            this.colTipoNomencladorCargo.FieldName = "TipoNomencladorCargoId";
            this.colTipoNomencladorCargo.Name = "colTipoNomencladorCargo";
            this.colTipoNomencladorCargo.Visible = true;
            this.colTipoNomencladorCargo.VisibleIndex = 3;
            // 
            // TipoCargo_repositoryItemLookUpEdit
            // 
            this.TipoCargo_repositoryItemLookUpEdit.AutoHeight = false;
            this.TipoCargo_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TipoCargo_repositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abreviatura", "Abreviatura", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.TipoCargo_repositoryItemLookUpEdit.DataSource = this.tipoNomencladorCargoBindingSource;
            this.TipoCargo_repositoryItemLookUpEdit.DisplayMember = "Abreviatura";
            this.TipoCargo_repositoryItemLookUpEdit.KeyMember = "TipoNomencladorCargoID";
            this.TipoCargo_repositoryItemLookUpEdit.Name = "TipoCargo_repositoryItemLookUpEdit";
            this.TipoCargo_repositoryItemLookUpEdit.ValueMember = "TipoNomencladorCargoID";
            // 
            // tipoNomencladorCargoBindingSource
            // 
            this.tipoNomencladorCargoBindingSource.DataSource = typeof(DXApplication9.TipoNomencladorCargo);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(702, 415);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Cargos_gridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(682, 395);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.Nuevo_barButtonItem,
            this.Edit_barButtonItem,
            this.Delete_barButtonItem,
            this.Refresh_barButtonItem,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(702, 147);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // Nuevo_barButtonItem
            // 
            this.Nuevo_barButtonItem.Caption = "Nuevo";
            this.Nuevo_barButtonItem.Id = 1;
            this.Nuevo_barButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Nuevo_barButtonItem.ImageOptions.Image")));
            this.Nuevo_barButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Nuevo_barButtonItem.ImageOptions.LargeImage")));
            this.Nuevo_barButtonItem.Name = "Nuevo_barButtonItem";
            this.Nuevo_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Nuevo_barButtonItem_ItemClick);
            // 
            // Edit_barButtonItem
            // 
            this.Edit_barButtonItem.Caption = "Editar";
            this.Edit_barButtonItem.Id = 2;
            this.Edit_barButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Edit_barButtonItem.ImageOptions.Image")));
            this.Edit_barButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Edit_barButtonItem.ImageOptions.LargeImage")));
            this.Edit_barButtonItem.Name = "Edit_barButtonItem";
            this.Edit_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Edit_barButtonItem_ItemClick);
            // 
            // Delete_barButtonItem
            // 
            this.Delete_barButtonItem.Caption = "Eliminar";
            this.Delete_barButtonItem.Id = 3;
            this.Delete_barButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Delete_barButtonItem.ImageOptions.Image")));
            this.Delete_barButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Delete_barButtonItem.ImageOptions.LargeImage")));
            this.Delete_barButtonItem.Name = "Delete_barButtonItem";
            this.Delete_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Delete_barButtonItem_ItemClick);
            // 
            // Refresh_barButtonItem
            // 
            this.Refresh_barButtonItem.Caption = "Refrescar";
            this.Refresh_barButtonItem.Id = 4;
            this.Refresh_barButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Refresh_barButtonItem.ImageOptions.Image")));
            this.Refresh_barButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Refresh_barButtonItem.ImageOptions.LargeImage")));
            this.Refresh_barButtonItem.Name = "Refresh_barButtonItem";
            this.Refresh_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Refresh_barButtonItem_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Previsualizar Lista";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Principal";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.Nuevo_barButtonItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.Edit_barButtonItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.Delete_barButtonItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.Refresh_barButtonItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Principal";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Ver";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 562);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(702, 23);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Principal";
            // 
            // defaultToolTipController1
            // 
            // 
            // 
            // 
            this.defaultToolTipController1.DefaultController.Rounded = true;
            // 
            // CargosXtraForm
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 585);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "CargosXtraForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Nomenclador de Cargos";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cargos_gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoCargo_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoNomencladorCargoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl Cargos_gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn colNomencladorCargoID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit TipoCargo_repositoryItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colPesoDeCargo;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoNomencladorCargo;
        private System.Windows.Forms.BindingSource tipoNomencladorCargoBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.Utils.DefaultToolTipController defaultToolTipController1;
        private DevExpress.XtraBars.BarButtonItem Nuevo_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem Edit_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem Delete_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem Refresh_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}