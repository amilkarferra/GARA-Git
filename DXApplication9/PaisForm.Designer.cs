namespace DXApplication9
{
    partial class PaisForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode5 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode6 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode7 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode8 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode9 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode10 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode11 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode12 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode13 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode14 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode15 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode16 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode17 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode18 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode19 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode20 = new DevExpress.XtraGrid.GridLevelNode();
            this.PaisgridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombrePais1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.paisesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombrePais2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Continentes_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Paises_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContinenteId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombrePais = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaisID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.PaisgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paisesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Continentes_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paises_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // PaisgridView
            // 
            this.PaisgridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombrePais1});
            this.PaisgridView.GridControl = this.gridControl1;
            this.PaisgridView.Name = "PaisgridView";
            this.PaisgridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.PaisgridView_RowUpdated);
            // 
            // colNombrePais1
            // 
            this.colNombrePais1.FieldName = "NombrePais";
            this.colNombrePais1.Name = "colNombrePais1";
            this.colNombrePais1.Visible = true;
            this.colNombrePais1.VisibleIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.paisesBindingSource;
            gridLevelNode4.RelationName = "DescuentoPorActividad";
            gridLevelNode5.RelationName = "ParticipantesDeAcividad";
            gridLevelNode6.RelationName = "ImportesDeFacturaEnFrontera";
            gridLevelNode7.RelationName = "Nomina";
            gridLevelNode3.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode4,
            gridLevelNode5,
            gridLevelNode6,
            gridLevelNode7});
            gridLevelNode3.RelationName = "OrdenDeTrabajo";
            gridLevelNode8.RelationName = "CuentasBancariasDeCliente";
            gridLevelNode11.RelationName = "DocumentosInvitados";
            gridLevelNode10.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode11});
            gridLevelNode10.RelationName = "ParticipantesDeProyectos";
            gridLevelNode12.RelationName = "Presentacion";
            gridLevelNode13.RelationName = "CartasDeInvitacion";
            gridLevelNode14.RelationName = "Repertorio";
            gridLevelNode9.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode10,
            gridLevelNode12,
            gridLevelNode13,
            gridLevelNode14});
            gridLevelNode9.RelationName = "Proyectos";
            gridLevelNode2.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3,
            gridLevelNode8,
            gridLevelNode9});
            gridLevelNode2.RelationName = "ControlClientes";
            gridLevelNode17.RelationName = "DocumentosInvitados";
            gridLevelNode16.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode17});
            gridLevelNode16.RelationName = "ParticipantesDeProyectos";
            gridLevelNode18.RelationName = "Presentacion";
            gridLevelNode19.RelationName = "CartasDeInvitacion";
            gridLevelNode20.RelationName = "Repertorio";
            gridLevelNode15.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode16,
            gridLevelNode18,
            gridLevelNode19,
            gridLevelNode20});
            gridLevelNode15.RelationName = "Proyectos";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2,
            gridLevelNode15});
            gridLevelNode1.RelationName = "Paises";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Continentes_repositoryItemLookUpEdit});
            this.gridControl1.Size = new System.Drawing.Size(585, 349);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.Paises_gridView,
            this.PaisgridView});
            // 
            // paisesBindingSource
            // 
            this.paisesBindingSource.DataSource = typeof(DXApplication9.Paises);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.TopNewRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView1.Appearance.TopNewRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombrePais2,
            this.colCodigo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Clic aquí Para insertar nuevo registro";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.gridView1.OptionsEditForm.EditFormColumnCount = 1;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colNombrePais2
            // 
            this.colNombrePais2.FieldName = "NombrePais";
            this.colNombrePais2.Name = "colNombrePais2";
            this.colNombrePais2.Visible = true;
            this.colNombrePais2.VisibleIndex = 1;
            // 
            // colCodigo
            // 
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 2;
            // 
            // Continentes_repositoryItemLookUpEdit
            // 
            this.Continentes_repositoryItemLookUpEdit.AutoHeight = false;
            this.Continentes_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Continentes_repositoryItemLookUpEdit.Name = "Continentes_repositoryItemLookUpEdit";
            // 
            // Paises_gridView
            // 
            this.Paises_gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContinenteId1,
            this.colNombrePais,
            this.colPaisID});
            this.Paises_gridView.GridControl = this.gridControl1;
            this.Paises_gridView.Name = "Paises_gridView";
            this.Paises_gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colContinenteId1
            // 
            this.colContinenteId1.FieldName = "ContinenteId";
            this.colContinenteId1.Name = "colContinenteId1";
            // 
            // colNombrePais
            // 
            this.colNombrePais.FieldName = "NombrePais";
            this.colNombrePais.Name = "colNombrePais";
            this.colNombrePais.Visible = true;
            this.colNombrePais.VisibleIndex = 0;
            // 
            // colPaisID
            // 
            this.colPaisID.FieldName = "PaisID";
            this.colPaisID.Name = "colPaisID";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(609, 373);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(609, 373);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(589, 353);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // PaisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 373);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PaisForm";
            this.Text = "Lista de Paises";
            this.Load += new System.EventHandler(this.PaisForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaisgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paisesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Continentes_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paises_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1; private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView Paises_gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colContinenteId1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombrePais;
        private DevExpress.XtraGrid.Columns.GridColumn colPaisID;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView PaisgridView;
        private DevExpress.XtraGrid.Columns.GridColumn colNombrePais1;
        private System.Windows.Forms.BindingSource paisesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombrePais2;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Continentes_repositoryItemLookUpEdit;
    }
}