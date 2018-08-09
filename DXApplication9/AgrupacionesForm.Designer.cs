namespace DXApplication9
{
    partial class AgrupacionesForm
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAgrupacionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NumericTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBitmapImagen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre_de_Persona_Recibe_Cheque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcientoContratado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerteneceACatalogo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDobleVinculo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cobra_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.AgrupacionDeArtista_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cobra_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtista_bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.bindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.NumericTextEdit,
            this.Cobra_repositoryItemLookUpEdit});
            this.gridControl1.Size = new System.Drawing.Size(694, 478);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DXApplication9.Agrupacion);
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
            this.colAgrupacionID,
            this.colLogo,
            this.colNombre,
            this.colCodigo,
            this.colBitmapImagen,
            this.colNombre_de_Persona_Recibe_Cheque,
            this.colPorcientoContratado,
            this.colPerteneceACatalogo,
            this.colDobleVinculo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Clic aquí Para insertar nuevo registro";
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsEditForm.EditFormColumnCount = 1;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.EditFormShowing += new DevExpress.XtraGrid.Views.Grid.EditFormShowingEventHandler(this.gridView1_EditFormShowing);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // colAgrupacionID
            // 
            this.colAgrupacionID.FieldName = "AgrupacionID";
            this.colAgrupacionID.Name = "colAgrupacionID";
            this.colAgrupacionID.OptionsColumn.AllowEdit = false;
            this.colAgrupacionID.OptionsColumn.ReadOnly = true;
            this.colAgrupacionID.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colLogo
            // 
            this.colLogo.FieldName = "Logo";
            this.colLogo.Name = "colLogo";
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            // 
            // colCodigo
            // 
            this.colCodigo.ColumnEdit = this.NumericTextEdit;
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 6;
            // 
            // NumericTextEdit
            // 
            this.NumericTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NumericTextEdit.AutoHeight = false;
            this.NumericTextEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NumericTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NumericTextEdit.Name = "NumericTextEdit";
            this.NumericTextEdit.ShowNullValuePromptWhenFocused = true;
            // 
            // colBitmapImagen
            // 
            this.colBitmapImagen.Caption = "gridColumn1";
            this.colBitmapImagen.FieldName = "BitmapImagen";
            this.colBitmapImagen.Name = "colBitmapImagen";
            // 
            // colNombre_de_Persona_Recibe_Cheque
            // 
            this.colNombre_de_Persona_Recibe_Cheque.Caption = "Cobra:";
            this.colNombre_de_Persona_Recibe_Cheque.FieldName = "Nombre_de_Persona_Recibe_Cheque";
            this.colNombre_de_Persona_Recibe_Cheque.Name = "colNombre_de_Persona_Recibe_Cheque";
            this.colNombre_de_Persona_Recibe_Cheque.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colNombre_de_Persona_Recibe_Cheque.Visible = true;
            this.colNombre_de_Persona_Recibe_Cheque.VisibleIndex = 2;
            // 
            // colPorcientoContratado
            // 
            this.colPorcientoContratado.FieldName = "PorcientoContratado";
            this.colPorcientoContratado.Name = "colPorcientoContratado";
            this.colPorcientoContratado.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colPorcientoContratado.Visible = true;
            this.colPorcientoContratado.VisibleIndex = 3;
            // 
            // colPerteneceACatalogo
            // 
            this.colPerteneceACatalogo.Caption = "Del Catálogo";
            this.colPerteneceACatalogo.FieldName = "PerteneceACatalogo";
            this.colPerteneceACatalogo.Name = "colPerteneceACatalogo";
            this.colPerteneceACatalogo.Visible = true;
            this.colPerteneceACatalogo.VisibleIndex = 4;
            // 
            // colDobleVinculo
            // 
            this.colDobleVinculo.FieldName = "DobleVinculo";
            this.colDobleVinculo.Name = "colDobleVinculo";
            this.colDobleVinculo.Visible = true;
            this.colDobleVinculo.VisibleIndex = 5;
            // 
            // Cobra_repositoryItemLookUpEdit
            // 
            this.Cobra_repositoryItemLookUpEdit.AutoHeight = false;
            this.Cobra_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Cobra_repositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreCompleto", "Nombre")});
            this.Cobra_repositoryItemLookUpEdit.DisplayMember = "NombreCompleto";
            this.Cobra_repositoryItemLookUpEdit.Name = "Cobra_repositoryItemLookUpEdit";
            this.Cobra_repositoryItemLookUpEdit.NullText = "-Seleccione-";
            this.Cobra_repositoryItemLookUpEdit.ValueMember = "NombreCompleto";
            // 
            // AgrupacionDeArtista_bindingSource
            // 
            this.AgrupacionDeArtista_bindingSource.AllowNew = false;
            this.AgrupacionDeArtista_bindingSource.DataSource = typeof(DXApplication9.AgrupacionDeArtista);
            // 
            // AgrupacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 478);
            this.Controls.Add(this.gridControl1);
            this.Name = "AgrupacionesForm";
            this.Text = "Unidades Artísticas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AgrupacionesForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cobra_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgrupacionDeArtista_bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupacionID;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit NumericTextEdit;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colPerteneceACatalogo;
        private DevExpress.XtraGrid.Columns.GridColumn colBitmapImagen;
        private DevExpress.XtraGrid.Columns.GridColumn colLogo;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre_de_Persona_Recibe_Cheque;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcientoContratado;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Cobra_repositoryItemLookUpEdit;
        private System.Windows.Forms.BindingSource AgrupacionDeArtista_bindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDobleVinculo;
    }
}