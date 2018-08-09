namespace DXApplication9
{
    partial class EditIntegranteXtraForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditIntegranteXtraForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule6 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule7 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table2 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column6 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression6 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Join join1 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.LimpiarAval_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.FechaAlta_dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.TipoVinculo_lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.EnsennanzaEsp_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.FechaAval_dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.CodigoAval_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.AnnoOtraProfesion_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.OtraProfesion_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.FechaEvaluacion_dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.CodigoEvaluacionArt_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.NivelEvaluacion_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.EvaluacionArtistica_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.TipoContrato_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.ServicioSocial_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.AnnoGraduadoEnseGral_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.FuenteProcedencia_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.Direccion_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.Trayectoria_gridControl = new DevExpress.XtraGrid.GridControl();
            this.trayectoriaArtistaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Trayectoria_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTrayectoriaArtistaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArtistaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesempenno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHasta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgrupacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEsUbicacionActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Desempenno_lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.nomencladorCargoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DesempeñoAbrev_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.Cancel_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.SplitName_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Aceptar_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Agencia_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.Escolaridad_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.AgrupacionDeArtistagridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.AgrupacionDeArtista_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAgrupacionDeArtistaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgrupacionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Agrupacion_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colFechaAlta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaBaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoVinculo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoVinculo_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.statusLaboralTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fechaIngresoSectorDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.NumeroCarnet_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.Municipio_treeListLookUpEdit = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.Municipio_treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EstadoCivil_comboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.SegundoApellido_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.PrimerApellicod_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.Nombre_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.annoGraduadoEnsEsp_TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.AvalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup7 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Organismo_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Personales_layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Municipio_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Escolaridad_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Agrupaciones_layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Trayectoria_layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.escalaSalarialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agrupacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.artistaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.sqlDataSource2 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FechaAlta_dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaAlta_dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoVinculo_lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnsennanzaEsp_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaAval_dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaAval_dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodigoAval_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnoOtraProfesion_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtraProfesion_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEvaluacion_dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEvaluacion_dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodigoEvaluacionArt_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NivelEvaluacion_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluacionArtistica_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoContrato_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicioSocial_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnoGraduadoEnseGral_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuenteProcedencia_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Direccion_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trayectoria_gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trayectoriaArtistaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trayectoria_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desempenno_lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomencladorCargoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesempeñoAbrev_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agencia_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Escolaridad_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtistagridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtista_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoVinculo_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLaboralTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaIngresoSectorDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaIngresoSectorDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroCarnet_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Municipio_treeListLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Municipio_treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoCivil_comboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegundoApellido_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimerApellicod_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nombre_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.annoGraduadoEnsEsp_TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Organismo_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Personales_layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Municipio_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Escolaridad_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupaciones_layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trayectoria_layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escalaSalarialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.artistaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.LimpiarAval_simpleButton);
            this.layoutControl1.Controls.Add(this.FechaAlta_dateEdit);
            this.layoutControl1.Controls.Add(this.TipoVinculo_lookUpEdit);
            this.layoutControl1.Controls.Add(this.EnsennanzaEsp_textEdit);
            this.layoutControl1.Controls.Add(this.FechaAval_dateEdit);
            this.layoutControl1.Controls.Add(this.CodigoAval_textEdit);
            this.layoutControl1.Controls.Add(this.AnnoOtraProfesion_textEdit);
            this.layoutControl1.Controls.Add(this.OtraProfesion_textEdit);
            this.layoutControl1.Controls.Add(this.FechaEvaluacion_dateEdit);
            this.layoutControl1.Controls.Add(this.CodigoEvaluacionArt_textEdit);
            this.layoutControl1.Controls.Add(this.NivelEvaluacion_textEdit);
            this.layoutControl1.Controls.Add(this.EvaluacionArtistica_textEdit);
            this.layoutControl1.Controls.Add(this.TipoContrato_textEdit);
            this.layoutControl1.Controls.Add(this.ServicioSocial_textEdit);
            this.layoutControl1.Controls.Add(this.AnnoGraduadoEnseGral_textEdit);
            this.layoutControl1.Controls.Add(this.FuenteProcedencia_textEdit);
            this.layoutControl1.Controls.Add(this.Direccion_textEdit);
            this.layoutControl1.Controls.Add(this.Trayectoria_gridControl);
            this.layoutControl1.Controls.Add(this.Desempenno_lookUpEdit);
            this.layoutControl1.Controls.Add(this.DesempeñoAbrev_textEdit);
            this.layoutControl1.Controls.Add(this.Cancel_simpleButton);
            this.layoutControl1.Controls.Add(this.SplitName_simpleButton);
            this.layoutControl1.Controls.Add(this.Aceptar_simpleButton);
            this.layoutControl1.Controls.Add(this.Agencia_textEdit);
            this.layoutControl1.Controls.Add(this.Escolaridad_textEdit);
            this.layoutControl1.Controls.Add(this.AgrupacionDeArtistagridControl);
            this.layoutControl1.Controls.Add(this.pictureEdit1);
            this.layoutControl1.Controls.Add(this.statusLaboralTextEdit);
            this.layoutControl1.Controls.Add(this.fechaIngresoSectorDateEdit);
            this.layoutControl1.Controls.Add(this.NumeroCarnet_textEdit);
            this.layoutControl1.Controls.Add(this.Municipio_treeListLookUpEdit);
            this.layoutControl1.Controls.Add(this.EstadoCivil_comboBoxEdit);
            this.layoutControl1.Controls.Add(this.SegundoApellido_textEdit);
            this.layoutControl1.Controls.Add(this.PrimerApellicod_textEdit);
            this.layoutControl1.Controls.Add(this.Nombre_textEdit);
            this.layoutControl1.Controls.Add(this.annoGraduadoEnsEsp_TextEdit);
            this.layoutControl1.Controls.Add(this.AvalLookUpEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(405, 368, 484, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1106, 655);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // LimpiarAval_simpleButton
            // 
            this.LimpiarAval_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("LimpiarAval_simpleButton.ImageOptions.Image")));
            this.LimpiarAval_simpleButton.Location = new System.Drawing.Point(975, 387);
            this.LimpiarAval_simpleButton.Name = "LimpiarAval_simpleButton";
            this.LimpiarAval_simpleButton.Size = new System.Drawing.Size(95, 22);
            this.LimpiarAval_simpleButton.StyleController = this.layoutControl1;
            this.LimpiarAval_simpleButton.TabIndex = 54;
            this.LimpiarAval_simpleButton.Text = "Vaciar valor";
            this.LimpiarAval_simpleButton.Click += new System.EventHandler(this.LimpiarAval_simpleButton_Click);
            // 
            // FechaAlta_dateEdit
            // 
            this.FechaAlta_dateEdit.EditValue = null;
            this.FechaAlta_dateEdit.Location = new System.Drawing.Point(345, 73);
            this.FechaAlta_dateEdit.Name = "FechaAlta_dateEdit";
            this.FechaAlta_dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaAlta_dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaAlta_dateEdit.Size = new System.Drawing.Size(737, 20);
            this.FechaAlta_dateEdit.StyleController = this.layoutControl1;
            this.FechaAlta_dateEdit.TabIndex = 53;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.FechaAlta_dateEdit, conditionValidationRule1);
            // 
            // TipoVinculo_lookUpEdit
            // 
            this.TipoVinculo_lookUpEdit.Location = new System.Drawing.Point(345, 217);
            this.TipoVinculo_lookUpEdit.Name = "TipoVinculo_lookUpEdit";
            this.TipoVinculo_lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TipoVinculo_lookUpEdit.Properties.NullText = "-Seleccione-";
            this.TipoVinculo_lookUpEdit.Size = new System.Drawing.Size(737, 20);
            this.TipoVinculo_lookUpEdit.StyleController = this.layoutControl1;
            this.TipoVinculo_lookUpEdit.TabIndex = 52;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.TipoVinculo_lookUpEdit, conditionValidationRule2);
            // 
            // EnsennanzaEsp_textEdit
            // 
            this.EnsennanzaEsp_textEdit.Location = new System.Drawing.Point(357, 547);
            this.EnsennanzaEsp_textEdit.Name = "EnsennanzaEsp_textEdit";
            this.EnsennanzaEsp_textEdit.Size = new System.Drawing.Size(273, 20);
            this.EnsennanzaEsp_textEdit.StyleController = this.layoutControl1;
            this.EnsennanzaEsp_textEdit.TabIndex = 51;
            // 
            // FechaAval_dateEdit
            // 
            this.FechaAval_dateEdit.EditValue = null;
            this.FechaAval_dateEdit.Location = new System.Drawing.Point(786, 413);
            this.FechaAval_dateEdit.Name = "FechaAval_dateEdit";
            this.FechaAval_dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaAval_dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaAval_dateEdit.Size = new System.Drawing.Size(284, 20);
            this.FechaAval_dateEdit.StyleController = this.layoutControl1;
            this.FechaAval_dateEdit.TabIndex = 50;
            this.FechaAval_dateEdit.ToolTip = "Fecha del Aval";
            // 
            // CodigoAval_textEdit
            // 
            this.CodigoAval_textEdit.Location = new System.Drawing.Point(357, 413);
            this.CodigoAval_textEdit.Name = "CodigoAval_textEdit";
            this.CodigoAval_textEdit.Size = new System.Drawing.Size(273, 20);
            this.CodigoAval_textEdit.StyleController = this.layoutControl1;
            this.CodigoAval_textEdit.TabIndex = 49;
            this.CodigoAval_textEdit.ToolTip = "Código Aval de Profesionalidad";
            // 
            // AnnoOtraProfesion_textEdit
            // 
            this.AnnoOtraProfesion_textEdit.Location = new System.Drawing.Point(786, 480);
            this.AnnoOtraProfesion_textEdit.Name = "AnnoOtraProfesion_textEdit";
            this.AnnoOtraProfesion_textEdit.Properties.Mask.EditMask = "f0";
            this.AnnoOtraProfesion_textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AnnoOtraProfesion_textEdit.Size = new System.Drawing.Size(284, 20);
            this.AnnoOtraProfesion_textEdit.StyleController = this.layoutControl1;
            this.AnnoOtraProfesion_textEdit.TabIndex = 47;
            this.AnnoOtraProfesion_textEdit.ToolTip = "Año Graduado Otra Profesión";
            // 
            // OtraProfesion_textEdit
            // 
            this.OtraProfesion_textEdit.Location = new System.Drawing.Point(357, 480);
            this.OtraProfesion_textEdit.Name = "OtraProfesion_textEdit";
            this.OtraProfesion_textEdit.Size = new System.Drawing.Size(273, 20);
            this.OtraProfesion_textEdit.StyleController = this.layoutControl1;
            this.OtraProfesion_textEdit.TabIndex = 46;
            // 
            // FechaEvaluacion_dateEdit
            // 
            this.FechaEvaluacion_dateEdit.EditValue = null;
            this.FechaEvaluacion_dateEdit.Location = new System.Drawing.Point(859, 320);
            this.FechaEvaluacion_dateEdit.Name = "FechaEvaluacion_dateEdit";
            this.FechaEvaluacion_dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaEvaluacion_dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaEvaluacion_dateEdit.Size = new System.Drawing.Size(211, 20);
            this.FechaEvaluacion_dateEdit.StyleController = this.layoutControl1;
            this.FechaEvaluacion_dateEdit.TabIndex = 44;
            // 
            // CodigoEvaluacionArt_textEdit
            // 
            this.CodigoEvaluacionArt_textEdit.Location = new System.Drawing.Point(691, 320);
            this.CodigoEvaluacionArt_textEdit.Name = "CodigoEvaluacionArt_textEdit";
            this.CodigoEvaluacionArt_textEdit.Size = new System.Drawing.Size(99, 20);
            this.CodigoEvaluacionArt_textEdit.StyleController = this.layoutControl1;
            this.CodigoEvaluacionArt_textEdit.TabIndex = 43;
            this.CodigoEvaluacionArt_textEdit.ToolTip = "Código Evalaución Artística";
            // 
            // NivelEvaluacion_textEdit
            // 
            this.NivelEvaluacion_textEdit.EditValue = "";
            this.NivelEvaluacion_textEdit.Location = new System.Drawing.Point(357, 320);
            this.NivelEvaluacion_textEdit.Name = "NivelEvaluacion_textEdit";
            this.NivelEvaluacion_textEdit.Size = new System.Drawing.Size(265, 20);
            this.NivelEvaluacion_textEdit.StyleController = this.layoutControl1;
            this.NivelEvaluacion_textEdit.TabIndex = 42;
            // 
            // EvaluacionArtistica_textEdit
            // 
            this.EvaluacionArtistica_textEdit.EditValue = "";
            this.EvaluacionArtistica_textEdit.Location = new System.Drawing.Point(357, 296);
            this.EvaluacionArtistica_textEdit.Name = "EvaluacionArtistica_textEdit";
            this.EvaluacionArtistica_textEdit.Size = new System.Drawing.Size(713, 20);
            this.EvaluacionArtistica_textEdit.StyleController = this.layoutControl1;
            this.EvaluacionArtistica_textEdit.TabIndex = 40;
            // 
            // TipoContrato_textEdit
            // 
            this.TipoContrato_textEdit.EditValue = "Representación";
            this.TipoContrato_textEdit.Location = new System.Drawing.Point(345, 241);
            this.TipoContrato_textEdit.Name = "TipoContrato_textEdit";
            this.TipoContrato_textEdit.Size = new System.Drawing.Size(737, 20);
            this.TipoContrato_textEdit.StyleController = this.layoutControl1;
            this.TipoContrato_textEdit.TabIndex = 39;
            // 
            // ServicioSocial_textEdit
            // 
            this.ServicioSocial_textEdit.Location = new System.Drawing.Point(345, 145);
            this.ServicioSocial_textEdit.Name = "ServicioSocial_textEdit";
            this.ServicioSocial_textEdit.Size = new System.Drawing.Size(737, 20);
            this.ServicioSocial_textEdit.StyleController = this.layoutControl1;
            this.ServicioSocial_textEdit.TabIndex = 38;
            // 
            // AnnoGraduadoEnseGral_textEdit
            // 
            this.AnnoGraduadoEnseGral_textEdit.Location = new System.Drawing.Point(774, 219);
            this.AnnoGraduadoEnseGral_textEdit.Name = "AnnoGraduadoEnseGral_textEdit";
            this.AnnoGraduadoEnseGral_textEdit.Size = new System.Drawing.Size(308, 20);
            this.AnnoGraduadoEnseGral_textEdit.StyleController = this.layoutControl1;
            this.AnnoGraduadoEnseGral_textEdit.TabIndex = 37;
            this.AnnoGraduadoEnseGral_textEdit.ToolTip = "Año de graduado de la enseñanza General";
            // 
            // FuenteProcedencia_textEdit
            // 
            this.FuenteProcedencia_textEdit.Location = new System.Drawing.Point(345, 121);
            this.FuenteProcedencia_textEdit.Name = "FuenteProcedencia_textEdit";
            this.FuenteProcedencia_textEdit.Size = new System.Drawing.Size(277, 20);
            this.FuenteProcedencia_textEdit.StyleController = this.layoutControl1;
            this.FuenteProcedencia_textEdit.TabIndex = 35;
            this.FuenteProcedencia_textEdit.ToolTip = "Fuente de procedencia antes de vincularse al sector artístico: ";
            // 
            // Direccion_textEdit
            // 
            this.Direccion_textEdit.Location = new System.Drawing.Point(345, 171);
            this.Direccion_textEdit.Name = "Direccion_textEdit";
            this.Direccion_textEdit.Size = new System.Drawing.Size(737, 20);
            this.Direccion_textEdit.StyleController = this.layoutControl1;
            this.Direccion_textEdit.TabIndex = 34;
            // 
            // Trayectoria_gridControl
            // 
            this.Trayectoria_gridControl.DataSource = this.trayectoriaArtistaBindingSource;
            this.Trayectoria_gridControl.Location = new System.Drawing.Point(193, 49);
            this.Trayectoria_gridControl.MainView = this.Trayectoria_gridView;
            this.Trayectoria_gridControl.Name = "Trayectoria_gridControl";
            this.Trayectoria_gridControl.Size = new System.Drawing.Size(889, 542);
            this.Trayectoria_gridControl.TabIndex = 33;
            this.Trayectoria_gridControl.UseEmbeddedNavigator = true;
            this.Trayectoria_gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Trayectoria_gridView});
            // 
            // trayectoriaArtistaBindingSource
            // 
            this.trayectoriaArtistaBindingSource.DataSource = typeof(DXApplication9.TrayectoriaArtista);
            // 
            // Trayectoria_gridView
            // 
            this.Trayectoria_gridView.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Trayectoria_gridView.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Trayectoria_gridView.Appearance.TopNewRow.ForeColor = System.Drawing.Color.White;
            this.Trayectoria_gridView.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Trayectoria_gridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.Trayectoria_gridView.Appearance.TopNewRow.Options.UseFont = true;
            this.Trayectoria_gridView.Appearance.TopNewRow.Options.UseForeColor = true;
            this.Trayectoria_gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTrayectoriaArtistaID,
            this.colArtistaId,
            this.colCentro,
            this.colDesempenno,
            this.colDesde,
            this.colHasta,
            this.colAgrupacion,
            this.colEsUbicacionActual});
            this.Trayectoria_gridView.GridControl = this.Trayectoria_gridControl;
            this.Trayectoria_gridView.Name = "Trayectoria_gridView";
            this.Trayectoria_gridView.NewItemRowText = "Clic aquí Para insertar nuevo registro";
            this.Trayectoria_gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.Trayectoria_gridView.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.Trayectoria_gridView.OptionsEditForm.EditFormColumnCount = 1;
            this.Trayectoria_gridView.OptionsSelection.MultiSelect = true;
            this.Trayectoria_gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.Trayectoria_gridView.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.Trayectoria_gridView.OptionsView.ShowGroupPanel = false;
            this.Trayectoria_gridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.Trayectoria_gridView_InvalidRowException);
            this.Trayectoria_gridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.Trayectoria_gridView_RowDeleted);
            this.Trayectoria_gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.Trayectoria_gridView_ValidateRow);
            this.Trayectoria_gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Trayectoria_gridView_RowUpdated);
            // 
            // colTrayectoriaArtistaID
            // 
            this.colTrayectoriaArtistaID.FieldName = "TrayectoriaArtistaID";
            this.colTrayectoriaArtistaID.Name = "colTrayectoriaArtistaID";
            // 
            // colArtistaId
            // 
            this.colArtistaId.FieldName = "ArtistaId";
            this.colArtistaId.Name = "colArtistaId";
            // 
            // colCentro
            // 
            this.colCentro.FieldName = "Centro";
            this.colCentro.Name = "colCentro";
            this.colCentro.Visible = true;
            this.colCentro.VisibleIndex = 1;
            // 
            // colDesempenno
            // 
            this.colDesempenno.FieldName = "Desempenno";
            this.colDesempenno.Name = "colDesempenno";
            this.colDesempenno.Visible = true;
            this.colDesempenno.VisibleIndex = 3;
            // 
            // colDesde
            // 
            this.colDesde.FieldName = "Desde";
            this.colDesde.Name = "colDesde";
            this.colDesde.Visible = true;
            this.colDesde.VisibleIndex = 4;
            // 
            // colHasta
            // 
            this.colHasta.FieldName = "Hasta";
            this.colHasta.Name = "colHasta";
            this.colHasta.Visible = true;
            this.colHasta.VisibleIndex = 5;
            // 
            // colAgrupacion
            // 
            this.colAgrupacion.FieldName = "Agrupacion";
            this.colAgrupacion.Name = "colAgrupacion";
            this.colAgrupacion.Visible = true;
            this.colAgrupacion.VisibleIndex = 2;
            // 
            // colEsUbicacionActual
            // 
            this.colEsUbicacionActual.FieldName = "EsUbicacionActual";
            this.colEsUbicacionActual.Name = "colEsUbicacionActual";
            this.colEsUbicacionActual.Visible = true;
            this.colEsUbicacionActual.VisibleIndex = 6;
            // 
            // Desempenno_lookUpEdit
            // 
            this.Desempenno_lookUpEdit.Location = new System.Drawing.Point(345, 169);
            this.Desempenno_lookUpEdit.Name = "Desempenno_lookUpEdit";
            this.Desempenno_lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Desempenno_lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripción")});
            this.Desempenno_lookUpEdit.Properties.DataSource = this.nomencladorCargoBindingSource;
            this.Desempenno_lookUpEdit.Properties.DisplayMember = "Descripcion";
            this.Desempenno_lookUpEdit.Properties.NullText = "-Seleccione-";
            this.Desempenno_lookUpEdit.Properties.ValueMember = "NomencladorCargoID";
            this.Desempenno_lookUpEdit.Size = new System.Drawing.Size(737, 20);
            this.Desempenno_lookUpEdit.StyleController = this.layoutControl1;
            this.Desempenno_lookUpEdit.TabIndex = 32;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.Desempenno_lookUpEdit, conditionValidationRule3);
            this.Desempenno_lookUpEdit.EditValueChanged += new System.EventHandler(this.Desempenno_lookUpEdit_EditValueChanged);
            // 
            // nomencladorCargoBindingSource
            // 
            this.nomencladorCargoBindingSource.DataSource = typeof(DXApplication9.NomencladorCargo);
            // 
            // DesempeñoAbrev_textEdit
            // 
            this.DesempeñoAbrev_textEdit.Location = new System.Drawing.Point(345, 193);
            this.DesempeñoAbrev_textEdit.Name = "DesempeñoAbrev_textEdit";
            this.DesempeñoAbrev_textEdit.Size = new System.Drawing.Size(737, 20);
            this.DesempeñoAbrev_textEdit.StyleController = this.layoutControl1;
            this.DesempeñoAbrev_textEdit.TabIndex = 31;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.DesempeñoAbrev_textEdit, conditionValidationRule4);
            // 
            // Cancel_simpleButton
            // 
            this.Cancel_simpleButton.CausesValidation = false;
            this.Cancel_simpleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_simpleButton.ImageOptions.Image")));
            this.Cancel_simpleButton.Location = new System.Drawing.Point(973, 607);
            this.Cancel_simpleButton.Name = "Cancel_simpleButton";
            this.Cancel_simpleButton.Size = new System.Drawing.Size(121, 36);
            this.Cancel_simpleButton.StyleController = this.layoutControl1;
            this.Cancel_simpleButton.TabIndex = 30;
            this.Cancel_simpleButton.Text = "Salir";
            // 
            // SplitName_simpleButton
            // 
            this.SplitName_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SplitName_simpleButton.ImageOptions.Image")));
            this.SplitName_simpleButton.Location = new System.Drawing.Point(1004, 49);
            this.SplitName_simpleButton.Name = "SplitName_simpleButton";
            this.SplitName_simpleButton.Size = new System.Drawing.Size(78, 22);
            this.SplitName_simpleButton.StyleController = this.layoutControl1;
            this.SplitName_simpleButton.TabIndex = 30;
            this.SplitName_simpleButton.ToolTip = "Dividir Nombre";
            this.SplitName_simpleButton.Click += new System.EventHandler(this.SplitName_simpleButton_Click);
            // 
            // Aceptar_simpleButton
            // 
            this.Aceptar_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Aceptar_simpleButton.ImageOptions.Image")));
            this.Aceptar_simpleButton.Location = new System.Drawing.Point(856, 607);
            this.Aceptar_simpleButton.Name = "Aceptar_simpleButton";
            this.Aceptar_simpleButton.Size = new System.Drawing.Size(113, 36);
            this.Aceptar_simpleButton.StyleController = this.layoutControl1;
            this.Aceptar_simpleButton.TabIndex = 28;
            this.Aceptar_simpleButton.Text = "Aceptar";
            this.Aceptar_simpleButton.Click += new System.EventHandler(this.Salvar_simpleButton_Click);
            // 
            // Agencia_textEdit
            // 
            this.Agencia_textEdit.Location = new System.Drawing.Point(345, 49);
            this.Agencia_textEdit.Name = "Agencia_textEdit";
            this.Agencia_textEdit.Size = new System.Drawing.Size(737, 20);
            this.Agencia_textEdit.StyleController = this.layoutControl1;
            this.Agencia_textEdit.TabIndex = 26;
            conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule5.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.Agencia_textEdit, conditionValidationRule5);
            // 
            // Escolaridad_textEdit
            // 
            this.Escolaridad_textEdit.Location = new System.Drawing.Point(345, 219);
            this.Escolaridad_textEdit.Name = "Escolaridad_textEdit";
            this.Escolaridad_textEdit.Size = new System.Drawing.Size(273, 20);
            this.Escolaridad_textEdit.StyleController = this.layoutControl1;
            this.Escolaridad_textEdit.TabIndex = 25;
            // 
            // AgrupacionDeArtistagridControl
            // 
            this.AgrupacionDeArtistagridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.AgrupacionDeArtistagridControl.DataSource = this.bindingSource1;
            this.AgrupacionDeArtistagridControl.Location = new System.Drawing.Point(193, 75);
            this.AgrupacionDeArtistagridControl.MainView = this.AgrupacionDeArtista_gridView;
            this.AgrupacionDeArtistagridControl.Name = "AgrupacionDeArtistagridControl";
            this.AgrupacionDeArtistagridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Agrupacion_repositoryItemLookUpEdit,
            this.TipoVinculo_repositoryItemLookUpEdit});
            this.AgrupacionDeArtistagridControl.Size = new System.Drawing.Size(889, 516);
            this.AgrupacionDeArtistagridControl.TabIndex = 23;
            this.AgrupacionDeArtistagridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.AgrupacionDeArtista_gridView});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DXApplication9.AgrupacionDeArtista);
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
            this.AgrupacionDeArtista_gridView.OptionsBehavior.Editable = false;
            this.AgrupacionDeArtista_gridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.AgrupacionDeArtista_gridView_InitNewRow);
            this.AgrupacionDeArtista_gridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.AgrupacionDeArtista_gridView_RowDeleted);
            this.AgrupacionDeArtista_gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.AgrupacionDeArtista_gridView_RowUpdated);
            // 
            // colAgrupacionDeArtistaID
            // 
            this.colAgrupacionDeArtistaID.FieldName = "AgrupacionDeArtistaID";
            this.colAgrupacionDeArtistaID.Name = "colAgrupacionDeArtistaID";
            // 
            // colAgrupacionId
            // 
            this.colAgrupacionId.Caption = "Agrupacion";
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
            this.Agrupacion_repositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AgrupacionID", "Name3"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Agrupación")});
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
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 28);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(153, 214);
            this.pictureEdit1.StyleController = this.layoutControl1;
            this.pictureEdit1.TabIndex = 19;
            this.pictureEdit1.ImageChanged += new System.EventHandler(this.pictureEdit1_ImageChanged);
            // 
            // statusLaboralTextEdit
            // 
            this.statusLaboralTextEdit.Location = new System.Drawing.Point(345, 97);
            this.statusLaboralTextEdit.Name = "statusLaboralTextEdit";
            this.statusLaboralTextEdit.Size = new System.Drawing.Size(737, 20);
            this.statusLaboralTextEdit.StyleController = this.layoutControl1;
            this.statusLaboralTextEdit.TabIndex = 14;
            this.statusLaboralTextEdit.Validating += new System.ComponentModel.CancelEventHandler(this.TextEdit_Validating);
            // 
            // fechaIngresoSectorDateEdit
            // 
            this.fechaIngresoSectorDateEdit.EditValue = null;
            this.fechaIngresoSectorDateEdit.Location = new System.Drawing.Point(778, 121);
            this.fechaIngresoSectorDateEdit.Name = "fechaIngresoSectorDateEdit";
            this.fechaIngresoSectorDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaIngresoSectorDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaIngresoSectorDateEdit.Size = new System.Drawing.Size(304, 20);
            this.fechaIngresoSectorDateEdit.StyleController = this.layoutControl1;
            this.fechaIngresoSectorDateEdit.TabIndex = 13;
            // 
            // NumeroCarnet_textEdit
            // 
            this.NumeroCarnet_textEdit.EditValue = "";
            this.NumeroCarnet_textEdit.Location = new System.Drawing.Point(345, 123);
            this.NumeroCarnet_textEdit.Name = "NumeroCarnet_textEdit";
            this.NumeroCarnet_textEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NumeroCarnet_textEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NumeroCarnet_textEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NumeroCarnet_textEdit.Properties.Mask.BeepOnError = true;
            this.NumeroCarnet_textEdit.Properties.Mask.EditMask = "\\d\\d\\d\\d\\d\\d\\d\\d\\d\\d\\d";
            this.NumeroCarnet_textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.NumeroCarnet_textEdit.Properties.Mask.ShowPlaceHolders = false;
            this.NumeroCarnet_textEdit.Size = new System.Drawing.Size(737, 20);
            this.NumeroCarnet_textEdit.StyleController = this.layoutControl1;
            this.NumeroCarnet_textEdit.TabIndex = 11;
            conditionValidationRule6.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule6.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.NumeroCarnet_textEdit, conditionValidationRule6);
            // 
            // Municipio_treeListLookUpEdit
            // 
            this.Municipio_treeListLookUpEdit.EditValue = "";
            this.Municipio_treeListLookUpEdit.Location = new System.Drawing.Point(345, 195);
            this.Municipio_treeListLookUpEdit.Name = "Municipio_treeListLookUpEdit";
            this.Municipio_treeListLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Municipio_treeListLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Municipio_treeListLookUpEdit.Properties.DisplayMember = "Descripcion";
            this.Municipio_treeListLookUpEdit.Properties.TreeList = this.Municipio_treeListLookUpEdit1TreeList;
            this.Municipio_treeListLookUpEdit.Properties.ValueMember = "Id";
            this.Municipio_treeListLookUpEdit.Size = new System.Drawing.Size(737, 20);
            this.Municipio_treeListLookUpEdit.StyleController = this.layoutControl1;
            this.Municipio_treeListLookUpEdit.TabIndex = 10;
            this.Municipio_treeListLookUpEdit.ToolTip = "Seleccione Municipio de Recidencia";
            this.Municipio_treeListLookUpEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.Municipio_treeListLookUpEdit_EditValueChanging);
            // 
            // Municipio_treeListLookUpEdit1TreeList
            // 
            this.Municipio_treeListLookUpEdit1TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn6});
            this.Municipio_treeListLookUpEdit1TreeList.KeyFieldName = "Id";
            this.Municipio_treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.Municipio_treeListLookUpEdit1TreeList.Name = "Municipio_treeListLookUpEdit1TreeList";
            this.Municipio_treeListLookUpEdit1TreeList.OptionsBehavior.PopulateServiceColumns = true;
            this.Municipio_treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.Municipio_treeListLookUpEdit1TreeList.ParentFieldName = "ParentId";
            this.Municipio_treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.Municipio_treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "ID";
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Nombre";
            this.treeListColumn2.FieldName = "Descripcion";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "treeListColumn6";
            this.treeListColumn6.FieldName = "ParentID";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // EstadoCivil_comboBoxEdit
            // 
            this.EstadoCivil_comboBoxEdit.EditValue = "";
            this.EstadoCivil_comboBoxEdit.Location = new System.Drawing.Point(345, 147);
            this.EstadoCivil_comboBoxEdit.Name = "EstadoCivil_comboBoxEdit";
            this.EstadoCivil_comboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EstadoCivil_comboBoxEdit.Properties.Items.AddRange(new object[] {
            "Soltero",
            "Casado"});
            this.EstadoCivil_comboBoxEdit.Properties.NullText = "-Seleccione-";
            this.EstadoCivil_comboBoxEdit.Size = new System.Drawing.Size(737, 20);
            this.EstadoCivil_comboBoxEdit.StyleController = this.layoutControl1;
            this.EstadoCivil_comboBoxEdit.TabIndex = 8;
            // 
            // SegundoApellido_textEdit
            // 
            this.SegundoApellido_textEdit.Location = new System.Drawing.Point(345, 99);
            this.SegundoApellido_textEdit.Name = "SegundoApellido_textEdit";
            this.SegundoApellido_textEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.SegundoApellido_textEdit.Size = new System.Drawing.Size(737, 20);
            this.SegundoApellido_textEdit.StyleController = this.layoutControl1;
            this.SegundoApellido_textEdit.TabIndex = 7;
            this.SegundoApellido_textEdit.Validating += new System.ComponentModel.CancelEventHandler(this.TextEdit_Validating);
            // 
            // PrimerApellicod_textEdit
            // 
            this.PrimerApellicod_textEdit.Location = new System.Drawing.Point(345, 75);
            this.PrimerApellicod_textEdit.Name = "PrimerApellicod_textEdit";
            this.PrimerApellicod_textEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.PrimerApellicod_textEdit.Size = new System.Drawing.Size(737, 20);
            this.PrimerApellicod_textEdit.StyleController = this.layoutControl1;
            this.PrimerApellicod_textEdit.TabIndex = 6;
            this.PrimerApellicod_textEdit.Validating += new System.ComponentModel.CancelEventHandler(this.TextEdit_Validating);
            // 
            // Nombre_textEdit
            // 
            this.Nombre_textEdit.Location = new System.Drawing.Point(305, 49);
            this.Nombre_textEdit.Name = "Nombre_textEdit";
            this.Nombre_textEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.Nombre_textEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Nombre_textEdit.Size = new System.Drawing.Size(695, 20);
            this.Nombre_textEdit.StyleController = this.layoutControl1;
            this.Nombre_textEdit.TabIndex = 0;
            conditionValidationRule7.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule7.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.Nombre_textEdit, conditionValidationRule7);
            this.Nombre_textEdit.Validating += new System.ComponentModel.CancelEventHandler(this.TextEdit_Validating);
            // 
            // annoGraduadoEnsEsp_TextEdit
            // 
            this.annoGraduadoEnsEsp_TextEdit.EditValue = "0";
            this.annoGraduadoEnsEsp_TextEdit.Location = new System.Drawing.Point(786, 547);
            this.annoGraduadoEnsEsp_TextEdit.Name = "annoGraduadoEnsEsp_TextEdit";
            this.annoGraduadoEnsEsp_TextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.annoGraduadoEnsEsp_TextEdit.Properties.Mask.EditMask = "f0";
            this.annoGraduadoEnsEsp_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.annoGraduadoEnsEsp_TextEdit.Size = new System.Drawing.Size(284, 20);
            this.annoGraduadoEnsEsp_TextEdit.StyleController = this.layoutControl1;
            this.annoGraduadoEnsEsp_TextEdit.TabIndex = 16;
            // 
            // AvalLookUpEdit
            // 
            this.AvalLookUpEdit.Location = new System.Drawing.Point(357, 387);
            this.AvalLookUpEdit.Name = "AvalLookUpEdit";
            this.AvalLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.AvalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AvalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Cargo")});
            this.AvalLookUpEdit.Properties.DataSource = this.nomencladorCargoBindingSource;
            this.AvalLookUpEdit.Properties.DisplayMember = "Descripcion";
            this.AvalLookUpEdit.Properties.NullText = "";
            this.AvalLookUpEdit.Properties.NullValuePrompt = "-Seleccione-";
            this.AvalLookUpEdit.Properties.ValueMember = "NomencladorCargoID";
            this.AvalLookUpEdit.Size = new System.Drawing.Size(614, 20);
            this.AvalLookUpEdit.StyleController = this.layoutControl1;
            this.AvalLookUpEdit.TabIndex = 48;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.tabbedControlGroup1,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1106, 655);
            this.layoutControlGroup1.Hidden += new System.EventHandler(this.layoutControlGroup1_Hidden);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem11,
            this.splitterItem1,
            this.emptySpaceItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(169, 595);
            this.layoutControlGroup2.TextLocation = DevExpress.Utils.Locations.Left;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.pictureEdit1;
            this.layoutControlItem11.CustomizationFormText = "Foto";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(157, 234);
            this.layoutControlItem11.Text = "Foto";
            this.layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(149, 13);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(157, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(12, 595);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 234);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(157, 361);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(169, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup3;
            this.tabbedControlGroup1.SelectedTabPageIndex = 1;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(917, 595);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Personales_layoutControlGroup,
            this.layoutControlGroup3,
            this.Agrupaciones_layoutControlGroup,
            this.Trayectoria_layoutControlGroup});
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Datos Laborales";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem23,
            this.layoutControlItem19,
            this.emptySpaceItem5,
            this.layoutControlGroup5,
            this.layoutControlGroup6,
            this.layoutControlGroup7,
            this.Organismo_layoutControlItem,
            this.layoutControlItem22,
            this.layoutControlGroup8,
            this.layoutControlItem29,
            this.layoutControlItem34});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(893, 546);
            this.layoutControlGroup3.Text = "Datos Laborales";
            this.layoutControlGroup3.TextLocation = DevExpress.Utils.Locations.Left;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.fechaIngresoSectorDateEdit;
            this.layoutControlItem7.CustomizationFormText = "Fecha Ingreso Sector:";
            this.layoutControlItem7.Location = new System.Drawing.Point(433, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(460, 24);
            this.layoutControlItem7.Text = "Fecha Ingreso Sector:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.statusLaboralTextEdit;
            this.layoutControlItem8.CustomizationFormText = "Status Laboral: *";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem8.Text = "Status Laboral: *";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.DesempeñoAbrev_textEdit;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem15.Text = "Abreviatura de Desempeño *";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.Desempenno_lookUpEdit;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem16.Text = "Desempeño *";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.TipoContrato_textEdit;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem23.Text = "Tipo Contrato Artístico";
            this.layoutControlItem23.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.FuenteProcedencia_textEdit;
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(433, 24);
            this.layoutControlItem19.Text = "Fuente de Procedencia";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(149, 13);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 534);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(893, 12);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem24,
            this.layoutControlItem26,
            this.layoutControlItem27,
            this.layoutControlItem28});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 216);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(893, 91);
            this.layoutControlGroup5.Text = "Evaluación Artística";
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.EvaluacionArtistica_textEdit;
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(869, 24);
            this.layoutControlItem24.Text = "Evaluación Artística";
            this.layoutControlItem24.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.NivelEvaluacion_textEdit;
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(421, 24);
            this.layoutControlItem26.Text = "Nivel";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.CodigoEvaluacionArt_textEdit;
            this.layoutControlItem27.Location = new System.Drawing.Point(421, 24);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(168, 24);
            this.layoutControlItem27.Text = "Código";
            this.layoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem27.TextToControlDistance = 5;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.FechaEvaluacion_dateEdit;
            this.layoutControlItem28.Location = new System.Drawing.Point(589, 24);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(280, 24);
            this.layoutControlItem28.Text = "Fecha";
            this.layoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem28.TextToControlDistance = 5;
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem20,
            this.layoutControlItem32,
            this.layoutControlItem33,
            this.layoutControlItem35});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 307);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(893, 93);
            this.layoutControlGroup6.Text = "Aval de Profesionalidad";
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.AvalLookUpEdit;
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(770, 26);
            this.layoutControlItem20.Text = "Aval de Profesionalidad";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.CodigoAval_textEdit;
            this.layoutControlItem32.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(429, 24);
            this.layoutControlItem32.Text = "Código";
            this.layoutControlItem32.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.FechaAval_dateEdit;
            this.layoutControlItem33.Location = new System.Drawing.Point(429, 26);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItem33.Text = "Fecha";
            this.layoutControlItem33.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.LimpiarAval_simpleButton;
            this.layoutControlItem35.Location = new System.Drawing.Point(770, 0);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(99, 26);
            this.layoutControlItem35.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem35.TextVisible = false;
            // 
            // layoutControlGroup7
            // 
            this.layoutControlGroup7.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem30,
            this.layoutControlItem31});
            this.layoutControlGroup7.Location = new System.Drawing.Point(0, 400);
            this.layoutControlGroup7.Name = "layoutControlGroup7";
            this.layoutControlGroup7.Size = new System.Drawing.Size(893, 67);
            this.layoutControlGroup7.Text = "Otra Profesión";
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.OtraProfesion_textEdit;
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(429, 24);
            this.layoutControlItem30.Text = "Otra Profesión";
            this.layoutControlItem30.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.AnnoOtraProfesion_textEdit;
            this.layoutControlItem31.Location = new System.Drawing.Point(429, 0);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItem31.Text = "Año Graduado";
            this.layoutControlItem31.TextSize = new System.Drawing.Size(149, 13);
            // 
            // Organismo_layoutControlItem
            // 
            this.Organismo_layoutControlItem.Control = this.Agencia_textEdit;
            this.Organismo_layoutControlItem.CustomizationFormText = "Agencia";
            this.Organismo_layoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.Organismo_layoutControlItem.Name = "Organismo_layoutControlItem";
            this.Organismo_layoutControlItem.Size = new System.Drawing.Size(893, 24);
            this.Organismo_layoutControlItem.Text = "Agencia *";
            this.Organismo_layoutControlItem.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.ServicioSocial_textEdit;
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem22.Text = "Cump.  Servicio Social";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem25,
            this.layoutControlItem10});
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 467);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.Size = new System.Drawing.Size(893, 67);
            this.layoutControlGroup8.Text = "Enseñanza Especializada";
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.EnsennanzaEsp_textEdit;
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(429, 24);
            this.layoutControlItem25.Text = "Enseñanza Especializada";
            this.layoutControlItem25.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.annoGraduadoEnsEsp_TextEdit;
            this.layoutControlItem10.CustomizationFormText = "Anno Graduado:";
            this.layoutControlItem10.Location = new System.Drawing.Point(429, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItem10.Text = "Año Graduado:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.TipoVinculo_lookUpEdit;
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem29.Text = "Tipo de Vinculo *";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.FechaAlta_dateEdit;
            this.layoutControlItem34.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem34.Text = "Fecha De Firma del Contrato *";
            this.layoutControlItem34.TextSize = new System.Drawing.Size(149, 13);
            // 
            // Personales_layoutControlGroup
            // 
            this.Personales_layoutControlGroup.CustomizationFormText = "Datos Personales";
            this.Personales_layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.Municipio_layoutControlItem,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.Escolaridad_layoutControlItem,
            this.layoutControlItem14,
            this.layoutControlItem18,
            this.layoutControlItem21});
            this.Personales_layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.Personales_layoutControlGroup.Name = "Personales_layoutControlGroup";
            this.Personales_layoutControlGroup.Size = new System.Drawing.Size(893, 546);
            this.Personales_layoutControlGroup.Text = "Datos Personales";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Nombre_textEdit;
            this.layoutControlItem1.CustomizationFormText = "Nombre *";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(166, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(811, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Nombre *";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(107, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.PrimerApellicod_textEdit;
            this.layoutControlItem2.CustomizationFormText = "Primer Apellido";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem2.Text = "Primer Apellido";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.SegundoApellido_textEdit;
            this.layoutControlItem3.CustomizationFormText = "Segundo Apellido";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem3.Text = "Segundo Apellido";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.EstadoCivil_comboBoxEdit;
            this.layoutControlItem4.CustomizationFormText = "Estado Civil";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem4.Text = "Estado Civil";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(149, 13);
            // 
            // Municipio_layoutControlItem
            // 
            this.Municipio_layoutControlItem.Control = this.Municipio_treeListLookUpEdit;
            this.Municipio_layoutControlItem.CustomizationFormText = "Municipio";
            this.Municipio_layoutControlItem.Location = new System.Drawing.Point(0, 146);
            this.Municipio_layoutControlItem.Name = "Municipio_layoutControlItem";
            this.Municipio_layoutControlItem.Size = new System.Drawing.Size(893, 24);
            this.Municipio_layoutControlItem.Text = "Municipio";
            this.Municipio_layoutControlItem.TextSize = new System.Drawing.Size(149, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 194);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(893, 352);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.NumeroCarnet_textEdit;
            this.layoutControlItem5.CustomizationFormText = "No. Carnet Identidad *";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem5.Text = "No. Carnet Identidad *";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(149, 13);
            // 
            // Escolaridad_layoutControlItem
            // 
            this.Escolaridad_layoutControlItem.Control = this.Escolaridad_textEdit;
            this.Escolaridad_layoutControlItem.CustomizationFormText = "Escolaridad";
            this.Escolaridad_layoutControlItem.Location = new System.Drawing.Point(0, 170);
            this.Escolaridad_layoutControlItem.Name = "Escolaridad_layoutControlItem";
            this.Escolaridad_layoutControlItem.Size = new System.Drawing.Size(429, 24);
            this.Escolaridad_layoutControlItem.Text = "Escolaridad Enseñanza General";
            this.Escolaridad_layoutControlItem.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.SplitName_simpleButton;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new System.Drawing.Point(811, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.Direccion_textEdit;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 122);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(893, 24);
            this.layoutControlItem18.Text = "Dirección";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(149, 13);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.AnnoGraduadoEnseGral_textEdit;
            this.layoutControlItem21.Location = new System.Drawing.Point(429, 170);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(464, 24);
            this.layoutControlItem21.Text = "Año Graduado ";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(149, 13);
            // 
            // Agrupaciones_layoutControlGroup
            // 
            this.Agrupaciones_layoutControlGroup.CustomizationFormText = "Agrupaciones";
            this.Agrupaciones_layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.emptySpaceItem2});
            this.Agrupaciones_layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.Agrupaciones_layoutControlGroup.Name = "Agrupaciones_layoutControlGroup";
            this.Agrupaciones_layoutControlGroup.Size = new System.Drawing.Size(893, 546);
            this.Agrupaciones_layoutControlGroup.Text = "Agrupaciones";
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.AgrupacionDeArtistagridControl;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(893, 520);
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(893, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Trayectoria_layoutControlGroup
            // 
            this.Trayectoria_layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem17});
            this.Trayectoria_layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.Trayectoria_layoutControlGroup.Name = "Trayectoria_layoutControlGroup";
            this.Trayectoria_layoutControlGroup.Size = new System.Drawing.Size(893, 546);
            this.Trayectoria_layoutControlGroup.Text = "Trayectoria";
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.Trayectoria_gridControl;
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(893, 546);
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.Aceptar_simpleButton;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new System.Drawing.Point(844, 595);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(117, 40);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.Cancel_simpleButton;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new System.Drawing.Point(961, 595);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(125, 40);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 595);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(844, 40);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // escalaSalarialBindingSource
            // 
            this.escalaSalarialBindingSource.DataSource = typeof(DXApplication9.EscalaSalarial);
            // 
            // agrupacionBindingSource
            // 
            this.agrupacionBindingSource.DataMember = "Agrupacion";
            // 
            // artistaBindingSource
            // 
            this.artistaBindingSource.DataSource = typeof(DXApplication9.Artista);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 144);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(818, 66);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "artistasConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            columnExpression1.ColumnName = "ProvinciaID";
            table1.Name = "Provincia";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "Descripcion";
            columnExpression2.Table = table1;
            column2.Expression = columnExpression2;
            column3.Alias = "Municipio_Descripcion";
            columnExpression3.ColumnName = "Descripcion";
            table2.Name = "Municipio";
            columnExpression3.Table = table2;
            column3.Expression = columnExpression3;
            column4.Alias = "Municipio_ProvinciaID";
            columnExpression4.ColumnName = "ProvinciaID";
            columnExpression4.Table = table2;
            column4.Expression = columnExpression4;
            columnExpression5.ColumnName = "MunicipioID";
            columnExpression5.Table = table2;
            column5.Expression = columnExpression5;
            columnExpression6.ColumnName = "CodigoMunicipio";
            columnExpression6.Table = table2;
            column6.Expression = columnExpression6;
            selectQuery1.Columns.Add(column1);
            selectQuery1.Columns.Add(column2);
            selectQuery1.Columns.Add(column3);
            selectQuery1.Columns.Add(column4);
            selectQuery1.Columns.Add(column5);
            selectQuery1.Columns.Add(column6);
            selectQuery1.Name = "Provincia";
            relationColumnInfo1.NestedKeyColumn = "ProvinciaID";
            relationColumnInfo1.ParentKeyColumn = "ProvinciaID";
            join1.KeyColumns.Add(relationColumnInfo1);
            join1.Nested = table2;
            join1.Parent = table1;
            selectQuery1.Relations.Add(join1);
            selectQuery1.Tables.Add(table1);
            selectQuery1.Tables.Add(table2);
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.Name = "sqlDataSource2";
            // 
            // EditIntegranteXtraForm
            // 
            this.AcceptButton = this.Aceptar_simpleButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 655);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditIntegranteXtraForm";
            this.Load += new System.EventHandler(this.EditIntegrante_XtraUserControl_Load);
            this.Enter += new System.EventHandler(this.EditIntegrante_XtraUserControl_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FechaAlta_dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaAlta_dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoVinculo_lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnsennanzaEsp_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaAval_dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaAval_dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodigoAval_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnoOtraProfesion_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtraProfesion_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEvaluacion_dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEvaluacion_dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodigoEvaluacionArt_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NivelEvaluacion_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluacionArtistica_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoContrato_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServicioSocial_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnoGraduadoEnseGral_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuenteProcedencia_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Direccion_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trayectoria_gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trayectoriaArtistaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trayectoria_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desempenno_lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomencladorCargoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DesempeñoAbrev_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agencia_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Escolaridad_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtistagridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtista_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoVinculo_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLaboralTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaIngresoSectorDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaIngresoSectorDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroCarnet_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Municipio_treeListLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Municipio_treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoCivil_comboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegundoApellido_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimerApellicod_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nombre_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.annoGraduadoEnsEsp_TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Organismo_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Personales_layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Municipio_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Escolaridad_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupaciones_layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trayectoria_layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escalaSalarialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.artistaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ComboBoxEdit EstadoCivil_comboBoxEdit;
        private DevExpress.XtraEditors.TextEdit SegundoApellido_textEdit;
        private DevExpress.XtraEditors.TextEdit PrimerApellicod_textEdit;
        private DevExpress.XtraEditors.TextEdit Nombre_textEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
       // private ArtistasDataSet artistasDataSet;
      //  private ArtistasDataSetTableAdapters.MunicipioTableAdapter municipioTableAdapter;
        private DevExpress.XtraEditors.TreeListLookUpEdit Municipio_treeListLookUpEdit;
        private DevExpress.XtraTreeList.TreeList Municipio_treeListLookUpEdit1TreeList;
       // private ArtistasDataSetTableAdapters.ArtistaTableAdapter artistaTableAdapter;
        private DevExpress.XtraEditors.TextEdit NumeroCarnet_textEdit;
        private DevExpress.XtraEditors.TextEdit statusLaboralTextEdit;
        private DevExpress.XtraEditors.DateEdit fechaIngresoSectorDateEdit;
       // private ArtistasDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource agrupacionBindingSource;
      //  private ArtistasDataSetTableAdapters.AgrupacionTableAdapter agrupacionTableAdapter;
        private System.Windows.Forms.BindingSource artistaBindingSource;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.TextEdit annoGraduadoEnsEsp_TextEdit;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlGroup Agrupaciones_layoutControlGroup;
        private DevExpress.XtraGrid.GridControl AgrupacionDeArtistagridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView AgrupacionDeArtista_gridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupacionDeArtistaID;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupacionId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAlta;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaBaja;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Agrupacion_repositoryItemLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Personales_layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem Municipio_layoutControlItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoVinculo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit TipoVinculo_repositoryItemLookUpEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit Escolaridad_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem Escolaridad_layoutControlItem;
        private DevExpress.XtraEditors.TextEdit Agencia_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem Organismo_layoutControlItem;
        private DevExpress.XtraEditors.SimpleButton Aceptar_simpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraEditors.SimpleButton SplitName_simpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraEditors.SimpleButton Cancel_simpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraEditors.TextEdit DesempeñoAbrev_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraEditors.LookUpEdit Desempenno_lookUpEdit;
        private System.Windows.Forms.BindingSource nomencladorCargoBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraGrid.GridControl Trayectoria_gridControl;
        private System.Windows.Forms.BindingSource trayectoriaArtistaBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView Trayectoria_gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colTrayectoriaArtistaID;
        private DevExpress.XtraGrid.Columns.GridColumn colArtistaId;
        private DevExpress.XtraGrid.Columns.GridColumn colCentro;
        private DevExpress.XtraGrid.Columns.GridColumn colDesempenno;
        private DevExpress.XtraGrid.Columns.GridColumn colDesde;
        private DevExpress.XtraGrid.Columns.GridColumn colHasta;
        private DevExpress.XtraLayout.LayoutControlGroup Trayectoria_layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupacion;
        private DevExpress.XtraGrid.Columns.GridColumn colEsUbicacionActual;
        private DevExpress.XtraEditors.TextEdit FuenteProcedencia_textEdit;
        private DevExpress.XtraEditors.TextEdit Direccion_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraEditors.TextEdit AnnoGraduadoEnseGral_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraEditors.DateEdit FechaEvaluacion_dateEdit;
        private DevExpress.XtraEditors.TextEdit CodigoEvaluacionArt_textEdit;
        private DevExpress.XtraEditors.TextEdit NivelEvaluacion_textEdit;
        private DevExpress.XtraEditors.TextEdit EvaluacionArtistica_textEdit;
        private DevExpress.XtraEditors.TextEdit TipoContrato_textEdit;
        private DevExpress.XtraEditors.TextEdit ServicioSocial_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraEditors.TextEdit AnnoOtraProfesion_textEdit;
        private DevExpress.XtraEditors.TextEdit OtraProfesion_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraEditors.DateEdit FechaAval_dateEdit;
        private DevExpress.XtraEditors.TextEdit CodigoAval_textEdit;
        private DevExpress.XtraEditors.LookUpEdit AvalLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraEditors.TextEdit EnsennanzaEsp_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraEditors.LookUpEdit TipoVinculo_lookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraEditors.DateEdit FechaAlta_dateEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraEditors.SimpleButton LimpiarAval_simpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.BindingSource escalaSalarialBindingSource;

    }
}
