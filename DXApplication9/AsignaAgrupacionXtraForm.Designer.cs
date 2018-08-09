namespace DXApplication9
{
    partial class AsignaAgrupacionXtraForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.Nombre_simpleLabelItem = new DevExpress.XtraLayout.SimpleLabelItem();
            this.linqInstantFeedbackSource1 = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.AgrupacionDeArtistagridControl = new DevExpress.XtraGrid.GridControl();
            this.AgrupacionDeArtista_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAgrupacionDeArtistaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgrupacionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Agrupacion_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colFechaAlta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaBaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoVinculo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoVinculo_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nombre_simpleLabelItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtistagridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtista_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoVinculo_repositoryItemLookUpEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(284, 251);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleSeparator1,
            this.Nombre_simpleLabelItem});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(284, 251);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 17);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(264, 214);
            // 
            // Nombre_simpleLabelItem
            // 
            this.Nombre_simpleLabelItem.AllowHotTrack = false;
            this.Nombre_simpleLabelItem.CustomizationFormText = "LabelNombre_simpleLabelItem";
            this.Nombre_simpleLabelItem.Location = new System.Drawing.Point(0, 0);
            this.Nombre_simpleLabelItem.Name = "Nombre_simpleLabelItem";
            this.Nombre_simpleLabelItem.Size = new System.Drawing.Size(264, 17);
            this.Nombre_simpleLabelItem.TextSize = new System.Drawing.Size(144, 13);
            // 
            // linqInstantFeedbackSource1
            // 
            this.linqInstantFeedbackSource1.DefaultSorting = "AgrupacionId ASC";
            this.linqInstantFeedbackSource1.DesignTimeElementType = typeof(DXApplication9.AgrupacionDeArtista);
            this.linqInstantFeedbackSource1.KeyExpression = "AgrupacionDeArtistaID";
            // 
            // AgrupacionDeArtistagridControl
            // 
            this.AgrupacionDeArtistagridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.AgrupacionDeArtistagridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AgrupacionDeArtistagridControl.Location = new System.Drawing.Point(0, 0);
            this.AgrupacionDeArtistagridControl.MainView = this.AgrupacionDeArtista_gridView;
            this.AgrupacionDeArtistagridControl.Name = "AgrupacionDeArtistagridControl";
            this.AgrupacionDeArtistagridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Agrupacion_repositoryItemLookUpEdit,
            this.TipoVinculo_repositoryItemLookUpEdit});
            this.AgrupacionDeArtistagridControl.Size = new System.Drawing.Size(284, 251);
            this.AgrupacionDeArtistagridControl.TabIndex = 24;
            this.AgrupacionDeArtistagridControl.UseEmbeddedNavigator = true;
            this.AgrupacionDeArtistagridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.AgrupacionDeArtista_gridView});
            // 
            // AgrupacionDeArtista_gridView
            // 
            this.AgrupacionDeArtista_gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAgrupacionDeArtistaID,
            this.colAgrupacionId,
            this.colFechaAlta,
            this.colFechaBaja,
            this.colTipoVinculo});
            this.AgrupacionDeArtista_gridView.GridControl = this.AgrupacionDeArtistagridControl;
            this.AgrupacionDeArtista_gridView.Name = "AgrupacionDeArtista_gridView";
            // 
            // colAgrupacionDeArtistaID
            // 
            this.colAgrupacionDeArtistaID.FieldName = "AgrupacionDeArtistaID";
            this.colAgrupacionDeArtistaID.Name = "colAgrupacionDeArtistaID";
            // 
            // colAgrupacionId
            // 
            this.colAgrupacionId.ColumnEdit = this.Agrupacion_repositoryItemLookUpEdit;
            this.colAgrupacionId.FieldName = "AgrupacionId";
            this.colAgrupacionId.Name = "colAgrupacionId";
            this.colAgrupacionId.Visible = true;
            this.colAgrupacionId.VisibleIndex = 0;
            // 
            // Agrupacion_repositoryItemLookUpEdit
            // 
            this.Agrupacion_repositoryItemLookUpEdit.AutoHeight = false;
            this.Agrupacion_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Agrupacion_repositoryItemLookUpEdit.DisplayMember = "Nombre";
            this.Agrupacion_repositoryItemLookUpEdit.Name = "Agrupacion_repositoryItemLookUpEdit";
            this.Agrupacion_repositoryItemLookUpEdit.ValueMember = "AgrupacionID";
            // 
            // colFechaAlta
            // 
            this.colFechaAlta.FieldName = "FechaAlta";
            this.colFechaAlta.Name = "colFechaAlta";
            this.colFechaAlta.Visible = true;
            this.colFechaAlta.VisibleIndex = 1;
            // 
            // colFechaBaja
            // 
            this.colFechaBaja.FieldName = "FechaBaja";
            this.colFechaBaja.Name = "colFechaBaja";
            this.colFechaBaja.Visible = true;
            this.colFechaBaja.VisibleIndex = 2;
            // 
            // colTipoVinculo
            // 
            this.colTipoVinculo.ColumnEdit = this.TipoVinculo_repositoryItemLookUpEdit;
            this.colTipoVinculo.FieldName = "TipoVinculo";
            this.colTipoVinculo.Name = "colTipoVinculo";
            this.colTipoVinculo.Visible = true;
            this.colTipoVinculo.VisibleIndex = 3;
            // 
            // TipoVinculo_repositoryItemLookUpEdit
            // 
            this.TipoVinculo_repositoryItemLookUpEdit.AutoHeight = false;
            this.TipoVinculo_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TipoVinculo_repositoryItemLookUpEdit.DisplayMember = "Tipo";
            this.TipoVinculo_repositoryItemLookUpEdit.Name = "TipoVinculo_repositoryItemLookUpEdit";
            this.TipoVinculo_repositoryItemLookUpEdit.ValueMember = "Valor";
            // 
            // AsignaAgrupacionXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 251);
            this.Controls.Add(this.AgrupacionDeArtistagridControl);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AsignaAgrupacionXtraForm";
            this.Text = "AsignaAgrupacionXtraForm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nombre_simpleLabelItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtistagridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtista_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoVinculo_repositoryItemLookUpEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.SimpleLabelItem Nombre_simpleLabelItem;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource linqInstantFeedbackSource1;
        private DevExpress.XtraGrid.GridControl AgrupacionDeArtistagridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView AgrupacionDeArtista_gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupacionDeArtistaID;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupacionId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Agrupacion_repositoryItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAlta;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaBaja;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoVinculo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit TipoVinculo_repositoryItemLookUpEdit;
    }
}