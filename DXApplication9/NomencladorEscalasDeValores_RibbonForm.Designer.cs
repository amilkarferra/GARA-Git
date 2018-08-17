namespace DXApplication9
{
    partial class NomencladorEscalasDeValores_RibbonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NomencladorEscalasDeValores_RibbonForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.Nuevo_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.Edit_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.Eliminar_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.Refrescar_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.Preview_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.Add_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteMaximo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImporteMax_repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colImporteMinimo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImporteMin_repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ImporteMin_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImporteMax_repositoryItemTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImporteMin_repositoryItemTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImporteMin_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.Nuevo_barButtonItem,
            this.Edit_barButtonItem,
            this.Eliminar_barButtonItem,
            this.Refrescar_barButtonItem,
            this.Preview_barButtonItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(442, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
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
            // Eliminar_barButtonItem
            // 
            this.Eliminar_barButtonItem.Caption = "Eliminar";
            this.Eliminar_barButtonItem.Id = 3;
            this.Eliminar_barButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar_barButtonItem.ImageOptions.Image")));
            this.Eliminar_barButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Eliminar_barButtonItem.ImageOptions.LargeImage")));
            this.Eliminar_barButtonItem.Name = "Eliminar_barButtonItem";
            this.Eliminar_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Eliminar_barButtonItem_ItemClick);
            // 
            // Refrescar_barButtonItem
            // 
            this.Refrescar_barButtonItem.Caption = "Refrescar";
            this.Refrescar_barButtonItem.Id = 4;
            this.Refrescar_barButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Refrescar_barButtonItem.ImageOptions.Image")));
            this.Refrescar_barButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Refrescar_barButtonItem.ImageOptions.LargeImage")));
            this.Refrescar_barButtonItem.Name = "Refrescar_barButtonItem";
            this.Refrescar_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Refrescar_barButtonItem_ItemClick);
            // 
            // Preview_barButtonItem
            // 
            this.Preview_barButtonItem.Caption = "Previsualizar Lista";
            this.Preview_barButtonItem.Id = 5;
            this.Preview_barButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Preview_barButtonItem.ImageOptions.Image")));
            this.Preview_barButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Preview_barButtonItem.ImageOptions.LargeImage")));
            this.Preview_barButtonItem.Name = "Preview_barButtonItem";
            this.Preview_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Preview_barButtonItem_ItemClick);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.Eliminar_barButtonItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.Refrescar_barButtonItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Principal";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.Preview_barButtonItem);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 426);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(442, 23);
            // 
            // Add_barButtonItem
            // 
            this.Add_barButtonItem.Caption = "Nuevo";
            this.Add_barButtonItem.Id = 1;
            this.Add_barButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Add_barButtonItem.ImageOptions.Image")));
            this.Add_barButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Add_barButtonItem.ImageOptions.LargeImage")));
            this.Add_barButtonItem.Name = "Add_barButtonItem";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 147);
            this.gridControl1.MainView = this.gridView;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ImporteMax_repositoryItemTextEdit,
            this.ImporteMin_repositoryItemLookUpEdit,
            this.ImporteMin_repositoryItemTextEdit});
            this.gridControl1.Size = new System.Drawing.Size(442, 279);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescripcion,
            this.colImporteMaximo,
            this.colImporteMinimo});
            this.gridView.GridControl = this.gridControl1;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridView_RowDeleted);
            this.gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView_RowUpdated);
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 0;
            this.colDescripcion.Width = 60;
            // 
            // colImporteMaximo
            // 
            this.colImporteMaximo.Caption = "Importe Máximo";
            this.colImporteMaximo.ColumnEdit = this.ImporteMax_repositoryItemTextEdit;
            this.colImporteMaximo.FieldName = "ImporteMaximo";
            this.colImporteMaximo.Name = "colImporteMaximo";
            this.colImporteMaximo.Visible = true;
            this.colImporteMaximo.VisibleIndex = 1;
            this.colImporteMaximo.Width = 60;
            // 
            // ImporteMax_repositoryItemTextEdit
            // 
            this.ImporteMax_repositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ImporteMax_repositoryItemTextEdit.AutoHeight = false;
            this.ImporteMax_repositoryItemTextEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ImporteMax_repositoryItemTextEdit.Mask.BeepOnError = true;
            this.ImporteMax_repositoryItemTextEdit.Mask.EditMask = "n2";
            this.ImporteMax_repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ImporteMax_repositoryItemTextEdit.Name = "ImporteMax_repositoryItemTextEdit";
            // 
            // colImporteMinimo
            // 
            this.colImporteMinimo.Caption = "Importe Mínimo";
            this.colImporteMinimo.ColumnEdit = this.ImporteMin_repositoryItemTextEdit;
            this.colImporteMinimo.FieldName = "ImporteMinimo";
            this.colImporteMinimo.Name = "colImporteMinimo";
            this.colImporteMinimo.Visible = true;
            this.colImporteMinimo.VisibleIndex = 2;
            this.colImporteMinimo.Width = 62;
            // 
            // ImporteMin_repositoryItemTextEdit
            // 
            this.ImporteMin_repositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.ImporteMin_repositoryItemTextEdit.AutoHeight = false;
            this.ImporteMin_repositoryItemTextEdit.Mask.EditMask = "n2";
            this.ImporteMin_repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ImporteMin_repositoryItemTextEdit.Name = "ImporteMin_repositoryItemTextEdit";
            // 
            // ImporteMin_repositoryItemLookUpEdit
            // 
            this.ImporteMin_repositoryItemLookUpEdit.AutoHeight = false;
            this.ImporteMin_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImporteMin_repositoryItemLookUpEdit.Name = "ImporteMin_repositoryItemLookUpEdit";
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(DXApplication9.NomencladorEscalasDeIngreso);
            // 
            // NomencladorEscalasDeValores_RibbonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "NomencladorEscalasDeValores_RibbonForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "NomencladorEscalasDeValores_RibbonForm";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImporteMax_repositoryItemTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImporteMin_repositoryItemTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImporteMin_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem Add_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem Nuevo_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem Edit_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem Eliminar_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem Refrescar_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem Preview_barButtonItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteMaximo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ImporteMax_repositoryItemTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteMinimo;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ImporteMin_repositoryItemTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ImporteMin_repositoryItemLookUpEdit;
    }
}