namespace DXApplication9
{
    partial class EmpresariosForm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpresarioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreYApellidos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresaQueRepresenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFoto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnCondicionDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjetoSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.bindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            gridLevelNode3.RelationName = "DescuentoPorActividad";
            gridLevelNode4.RelationName = "ParticipantesDeAcividad";
            gridLevelNode5.RelationName = "ImportesDeFacturaEnFrontera";
            gridLevelNode6.RelationName = "Nomina";
            gridLevelNode2.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3,
            gridLevelNode4,
            gridLevelNode5,
            gridLevelNode6});
            gridLevelNode2.RelationName = "OrdenDeTrabajo";
            gridLevelNode7.RelationName = "CuentasBancariasDeCliente";
            gridLevelNode10.RelationName = "DocumentosInvitados";
            gridLevelNode9.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode10});
            gridLevelNode9.RelationName = "ParticipantesDeProyectos";
            gridLevelNode11.RelationName = "Presentacion";
            gridLevelNode12.RelationName = "CartasDeInvitacion";
            gridLevelNode13.RelationName = "Repertorio";
            gridLevelNode8.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode9,
            gridLevelNode11,
            gridLevelNode12,
            gridLevelNode13});
            gridLevelNode8.RelationName = "Proyectos";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2,
            gridLevelNode7,
            gridLevelNode8});
            gridLevelNode1.RelationName = "ControlClientes";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(615, 412);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DXApplication9.Empresarios);
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
            this.colEmpresarioID,
            this.colNombreYApellidos,
            this.colEmpresaQueRepresenta,
            this.colObjetoSocial,
            this.colFoto,
            this.colTelefono,
            this.colEmail,
            this.colDireccion,
            this.colEnCondicionDe});
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
            this.gridView1.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridView1_RowDeleted);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colEmpresarioID
            // 
            this.colEmpresarioID.FieldName = "EmpresarioID";
            this.colEmpresarioID.Name = "colEmpresarioID";
            // 
            // colNombreYApellidos
            // 
            this.colNombreYApellidos.FieldName = "NombreYApellidos";
            this.colNombreYApellidos.Name = "colNombreYApellidos";
            this.colNombreYApellidos.Visible = true;
            this.colNombreYApellidos.VisibleIndex = 1;
            // 
            // colEmpresaQueRepresenta
            // 
            this.colEmpresaQueRepresenta.FieldName = "EmpresaQueRepresenta";
            this.colEmpresaQueRepresenta.Name = "colEmpresaQueRepresenta";
            this.colEmpresaQueRepresenta.Visible = true;
            this.colEmpresaQueRepresenta.VisibleIndex = 2;
            // 
            // colFoto
            // 
            this.colFoto.FieldName = "Foto";
            this.colFoto.Name = "colFoto";
            this.colFoto.Visible = true;
            this.colFoto.VisibleIndex = 7;
            // 
            // colTelefono
            // 
            this.colTelefono.FieldName = "Telefono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.Visible = true;
            this.colTelefono.VisibleIndex = 4;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 6;
            // 
            // colDireccion
            // 
            this.colDireccion.FieldName = "Direccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.Visible = true;
            this.colDireccion.VisibleIndex = 5;
            // 
            // colEnCondicionDe
            // 
            this.colEnCondicionDe.FieldName = "EnCondicionDe";
            this.colEnCondicionDe.Name = "colEnCondicionDe";
            this.colEnCondicionDe.Visible = true;
            this.colEnCondicionDe.VisibleIndex = 3;
            // 
            // colObjetoSocial
            // 
            this.colObjetoSocial.FieldName = "ObjetoSocial";
            this.colObjetoSocial.Name = "colObjetoSocial";
            this.colObjetoSocial.Visible = true;
            this.colObjetoSocial.VisibleIndex = 8;
            // 
            // EmpresariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 412);
            this.Controls.Add(this.gridControl1);
            this.Name = "EmpresariosForm";
            this.Text = "Lista de Empresarios";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresarioID;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreYApellidos;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresaQueRepresenta;
        private DevExpress.XtraGrid.Columns.GridColumn colFoto;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn colEnCondicionDe;
        private DevExpress.XtraGrid.Columns.GridColumn colObjetoSocial;
    }
}