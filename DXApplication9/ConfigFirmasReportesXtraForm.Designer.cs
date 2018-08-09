namespace DXApplication9
{
    partial class ConfigFirmasReportesXtraForm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.reportesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReporteID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentificadorReporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreReporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirmaIzquierdaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirmaIzq_repositoryItemSearchLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.personasQueFirmanReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombreCompleto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroQuePertenece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonaQueFirmaReporteID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirmaCentroId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirmaCentro_repositoryItemSearchLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCargo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreCompleto2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroQuePertenece2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirmaDerechaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirmaDerecha_repositoryItemSearchLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombreCompleto1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroQuePertenece1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonaQueFirmaReporteID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirmaIzq_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaIzq_repositoryItemSearchLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasQueFirmanReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaCentro_repositoryItemSearchLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaDerecha_repositoryItemSearchLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaIzq_repositoryItemLookUpEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.reportesBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.FirmaIzq_repositoryItemLookUpEdit,
            this.FirmaIzq_repositoryItemSearchLookUpEdit,
            this.FirmaCentro_repositoryItemSearchLookUpEdit,
            this.FirmaDerecha_repositoryItemSearchLookUpEdit});
            this.gridControl1.Size = new System.Drawing.Size(676, 347);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // reportesBindingSource
            // 
            this.reportesBindingSource.DataSource = typeof(DXApplication9.Reportes);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReporteID,
            this.colIdentificadorReporte,
            this.colNombreReporte,
            this.colDescripcion,
            this.colFirmaIzquierdaId,
            this.colFirmaCentroId,
            this.colFirmaDerechaId});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colReporteID
            // 
            this.colReporteID.FieldName = "ReporteID";
            this.colReporteID.Name = "colReporteID";
            // 
            // colIdentificadorReporte
            // 
            this.colIdentificadorReporte.FieldName = "IdentificadorReporte";
            this.colIdentificadorReporte.Name = "colIdentificadorReporte";
            // 
            // colNombreReporte
            // 
            this.colNombreReporte.FieldName = "NombreReporte";
            this.colNombreReporte.Name = "colNombreReporte";
            this.colNombreReporte.Visible = true;
            this.colNombreReporte.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colFirmaIzquierdaId
            // 
            this.colFirmaIzquierdaId.Caption = "Firma Izquierda";
            this.colFirmaIzquierdaId.ColumnEdit = this.FirmaIzq_repositoryItemSearchLookUpEdit;
            this.colFirmaIzquierdaId.FieldName = "FirmaIzquierdaId";
            this.colFirmaIzquierdaId.Name = "colFirmaIzquierdaId";
            this.colFirmaIzquierdaId.Visible = true;
            this.colFirmaIzquierdaId.VisibleIndex = 2;
            // 
            // FirmaIzq_repositoryItemSearchLookUpEdit
            // 
            this.FirmaIzq_repositoryItemSearchLookUpEdit.AutoHeight = false;
            this.FirmaIzq_repositoryItemSearchLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FirmaIzq_repositoryItemSearchLookUpEdit.DataSource = this.personasQueFirmanReporteBindingSource;
            this.FirmaIzq_repositoryItemSearchLookUpEdit.DisplayMember = "NombreCompleto";
            this.FirmaIzq_repositoryItemSearchLookUpEdit.Name = "FirmaIzq_repositoryItemSearchLookUpEdit";
            this.FirmaIzq_repositoryItemSearchLookUpEdit.ValueMember = "PersonaQueFirmaReporteID";
            this.FirmaIzq_repositoryItemSearchLookUpEdit.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // personasQueFirmanReporteBindingSource
            // 
            this.personasQueFirmanReporteBindingSource.DataSource = typeof(DXApplication9.PersonasQueFirmanReporte);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombreCompleto,
            this.colCargo,
            this.colCentroQuePertenece,
            this.colPersonaQueFirmaReporteID});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colNombreCompleto
            // 
            this.colNombreCompleto.FieldName = "NombreCompleto";
            this.colNombreCompleto.Name = "colNombreCompleto";
            this.colNombreCompleto.Visible = true;
            this.colNombreCompleto.VisibleIndex = 1;
            // 
            // colCargo
            // 
            this.colCargo.FieldName = "Cargo";
            this.colCargo.Name = "colCargo";
            this.colCargo.Visible = true;
            this.colCargo.VisibleIndex = 0;
            // 
            // colCentroQuePertenece
            // 
            this.colCentroQuePertenece.FieldName = "CentroQuePertenece";
            this.colCentroQuePertenece.Name = "colCentroQuePertenece";
            this.colCentroQuePertenece.Visible = true;
            this.colCentroQuePertenece.VisibleIndex = 2;
            // 
            // colPersonaQueFirmaReporteID
            // 
            this.colPersonaQueFirmaReporteID.FieldName = "PersonaQueFirmaReporteID";
            this.colPersonaQueFirmaReporteID.Name = "colPersonaQueFirmaReporteID";
            // 
            // colFirmaCentroId
            // 
            this.colFirmaCentroId.Caption = "Firma Centro";
            this.colFirmaCentroId.ColumnEdit = this.FirmaCentro_repositoryItemSearchLookUpEdit;
            this.colFirmaCentroId.FieldName = "FirmaCentroId";
            this.colFirmaCentroId.Name = "colFirmaCentroId";
            this.colFirmaCentroId.Visible = true;
            this.colFirmaCentroId.VisibleIndex = 3;
            // 
            // FirmaCentro_repositoryItemSearchLookUpEdit
            // 
            this.FirmaCentro_repositoryItemSearchLookUpEdit.AutoHeight = false;
            this.FirmaCentro_repositoryItemSearchLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FirmaCentro_repositoryItemSearchLookUpEdit.DataSource = this.personasQueFirmanReporteBindingSource;
            this.FirmaCentro_repositoryItemSearchLookUpEdit.DisplayMember = "NombreCompleto";
            this.FirmaCentro_repositoryItemSearchLookUpEdit.Name = "FirmaCentro_repositoryItemSearchLookUpEdit";
            this.FirmaCentro_repositoryItemSearchLookUpEdit.ValueMember = "PersonaQueFirmaReporteID";
            this.FirmaCentro_repositoryItemSearchLookUpEdit.View = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCargo2,
            this.colNombreCompleto2,
            this.colCentroQuePertenece2});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colCargo2
            // 
            this.colCargo2.FieldName = "Cargo";
            this.colCargo2.Name = "colCargo2";
            this.colCargo2.Visible = true;
            this.colCargo2.VisibleIndex = 0;
            // 
            // colNombreCompleto2
            // 
            this.colNombreCompleto2.FieldName = "NombreCompleto";
            this.colNombreCompleto2.Name = "colNombreCompleto2";
            this.colNombreCompleto2.Visible = true;
            this.colNombreCompleto2.VisibleIndex = 1;
            // 
            // colCentroQuePertenece2
            // 
            this.colCentroQuePertenece2.FieldName = "CentroQuePertenece";
            this.colCentroQuePertenece2.Name = "colCentroQuePertenece2";
            this.colCentroQuePertenece2.Visible = true;
            this.colCentroQuePertenece2.VisibleIndex = 2;
            // 
            // colFirmaDerechaId
            // 
            this.colFirmaDerechaId.Caption = "Firma Derecha";
            this.colFirmaDerechaId.ColumnEdit = this.FirmaDerecha_repositoryItemSearchLookUpEdit;
            this.colFirmaDerechaId.FieldName = "FirmaDerechaId";
            this.colFirmaDerechaId.Name = "colFirmaDerechaId";
            this.colFirmaDerechaId.Visible = true;
            this.colFirmaDerechaId.VisibleIndex = 4;
            // 
            // FirmaDerecha_repositoryItemSearchLookUpEdit
            // 
            this.FirmaDerecha_repositoryItemSearchLookUpEdit.AutoHeight = false;
            this.FirmaDerecha_repositoryItemSearchLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FirmaDerecha_repositoryItemSearchLookUpEdit.DataSource = this.personasQueFirmanReporteBindingSource;
            this.FirmaDerecha_repositoryItemSearchLookUpEdit.DisplayMember = "NombreCompleto";
            this.FirmaDerecha_repositoryItemSearchLookUpEdit.Name = "FirmaDerecha_repositoryItemSearchLookUpEdit";
            this.FirmaDerecha_repositoryItemSearchLookUpEdit.ValueMember = "PersonaQueFirmaReporteID";
            this.FirmaDerecha_repositoryItemSearchLookUpEdit.View = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombreCompleto1,
            this.colCargo1,
            this.colCentroQuePertenece1,
            this.colPersonaQueFirmaReporteID1});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsFind.AlwaysVisible = true;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // colNombreCompleto1
            // 
            this.colNombreCompleto1.FieldName = "NombreCompleto";
            this.colNombreCompleto1.Name = "colNombreCompleto1";
            this.colNombreCompleto1.Visible = true;
            this.colNombreCompleto1.VisibleIndex = 1;
            // 
            // colCargo1
            // 
            this.colCargo1.FieldName = "Cargo";
            this.colCargo1.Name = "colCargo1";
            this.colCargo1.Visible = true;
            this.colCargo1.VisibleIndex = 0;
            // 
            // colCentroQuePertenece1
            // 
            this.colCentroQuePertenece1.FieldName = "CentroQuePertenece";
            this.colCentroQuePertenece1.Name = "colCentroQuePertenece1";
            this.colCentroQuePertenece1.Visible = true;
            this.colCentroQuePertenece1.VisibleIndex = 2;
            // 
            // colPersonaQueFirmaReporteID1
            // 
            this.colPersonaQueFirmaReporteID1.FieldName = "PersonaQueFirmaReporteID";
            this.colPersonaQueFirmaReporteID1.Name = "colPersonaQueFirmaReporteID1";
            // 
            // FirmaIzq_repositoryItemLookUpEdit
            // 
            this.FirmaIzq_repositoryItemLookUpEdit.AutoHeight = false;
            this.FirmaIzq_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FirmaIzq_repositoryItemLookUpEdit.DataSource = this.personasQueFirmanReporteBindingSource;
            this.FirmaIzq_repositoryItemLookUpEdit.Name = "FirmaIzq_repositoryItemLookUpEdit";
            this.FirmaIzq_repositoryItemLookUpEdit.ValueMember = "PersonaQueFirmaReporteID";
            // 
            // ConfigFirmasReportesXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 347);
            this.Controls.Add(this.gridControl1);
            this.Name = "ConfigFirmasReportesXtraForm";
            this.Text = "ConfigFirmasReportesXtraForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaIzq_repositoryItemSearchLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasQueFirmanReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaCentro_repositoryItemSearchLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaDerecha_repositoryItemSearchLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirmaIzq_repositoryItemLookUpEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource reportesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colReporteID;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentificadorReporte;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreReporte;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colFirmaIzquierdaId;
        private DevExpress.XtraGrid.Columns.GridColumn colFirmaCentroId;
        private DevExpress.XtraGrid.Columns.GridColumn colFirmaDerechaId;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit FirmaIzq_repositoryItemSearchLookUpEdit;
        private System.Windows.Forms.BindingSource personasQueFirmanReporteBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreCompleto;
        private DevExpress.XtraGrid.Columns.GridColumn colCargo;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroQuePertenece;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonaQueFirmaReporteID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit FirmaCentro_repositoryItemSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colCargo2;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreCompleto2;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroQuePertenece2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit FirmaDerecha_repositoryItemSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreCompleto1;
        private DevExpress.XtraGrid.Columns.GridColumn colCargo1;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroQuePertenece1;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonaQueFirmaReporteID1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit FirmaIzq_repositoryItemLookUpEdit;
    }
}