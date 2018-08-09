namespace DXApplication9
{
    partial class RepertoriosLista_XtraForm
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.cancionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCancionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Titulo_repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSociedad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgrupacionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgrupacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Edit_gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Edit_repositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.del_gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Del_repositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.agrupacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Agrupacion_lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Titulo_repositoryItemTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_repositoryItemButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Del_repositoryItemButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.cancionBindingSource;
            this.gridControl.Location = new System.Drawing.Point(12, 36);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Del_repositoryItemButtonEdit,
            this.Edit_repositoryItemButtonEdit,
            this.Titulo_repositoryItemTextEdit});
            this.gridControl.Size = new System.Drawing.Size(1103, 545);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // cancionBindingSource
            // 
            this.cancionBindingSource.DataSource = typeof(DXApplication9.Cancion);
            // 
            // gridView
            // 
            this.gridView.Appearance.TopNewRow.BackColor = System.Drawing.Color.Silver;
            this.gridView.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.TopNewRow.ForeColor = System.Drawing.Color.Black;
            this.gridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView.Appearance.TopNewRow.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCancionID,
            this.colTitulo,
            this.colAutor,
            this.colSociedad,
            this.colAgrupacionId,
            this.colAgrupacion,
            this.Edit_gridColumn,
            this.del_gridColumn});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.NewItemRowText = "Pulse aquí para insertar nuevo tema";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_InitNewRow);
            this.gridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridView_RowDeleted);
            this.gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView_RowUpdated);
            this.gridView.Click += new System.EventHandler(this.gridView_Click);
            // 
            // colCancionID
            // 
            this.colCancionID.FieldName = "CancionID";
            this.colCancionID.Name = "colCancionID";
            // 
            // colTitulo
            // 
            this.colTitulo.ColumnEdit = this.Titulo_repositoryItemTextEdit;
            this.colTitulo.FieldName = "Titulo";
            this.colTitulo.Name = "colTitulo";
            this.colTitulo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Titulo", "{0}")});
            this.colTitulo.Visible = true;
            this.colTitulo.VisibleIndex = 0;
            this.colTitulo.Width = 343;
            // 
            // Titulo_repositoryItemTextEdit
            // 
            this.Titulo_repositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.Titulo_repositoryItemTextEdit.AutoHeight = false;
            this.Titulo_repositoryItemTextEdit.Name = "Titulo_repositoryItemTextEdit";
            // 
            // colAutor
            // 
            this.colAutor.FieldName = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 1;
            this.colAutor.Width = 343;
            // 
            // colSociedad
            // 
            this.colSociedad.FieldName = "Sociedad";
            this.colSociedad.Name = "colSociedad";
            this.colSociedad.Visible = true;
            this.colSociedad.VisibleIndex = 2;
            this.colSociedad.Width = 323;
            // 
            // colAgrupacionId
            // 
            this.colAgrupacionId.FieldName = "AgrupacionId";
            this.colAgrupacionId.Name = "colAgrupacionId";
            // 
            // colAgrupacion
            // 
            this.colAgrupacion.FieldName = "Agrupacion";
            this.colAgrupacion.Name = "colAgrupacion";
            // 
            // Edit_gridColumn
            // 
            this.Edit_gridColumn.ColumnEdit = this.Edit_repositoryItemButtonEdit;
            this.Edit_gridColumn.Name = "Edit_gridColumn";
            this.Edit_gridColumn.Width = 35;
            // 
            // Edit_repositoryItemButtonEdit
            // 
            this.Edit_repositoryItemButtonEdit.AutoHeight = false;
            this.Edit_repositoryItemButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.Edit_repositoryItemButtonEdit.Name = "Edit_repositoryItemButtonEdit";
            this.Edit_repositoryItemButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // del_gridColumn
            // 
            this.del_gridColumn.ColumnEdit = this.Del_repositoryItemButtonEdit;
            this.del_gridColumn.Name = "del_gridColumn";
            this.del_gridColumn.OptionsColumn.AllowEdit = false;
            this.del_gridColumn.OptionsColumn.ShowInExpressionEditor = false;
            this.del_gridColumn.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.del_gridColumn.Visible = true;
            this.del_gridColumn.VisibleIndex = 3;
            this.del_gridColumn.Width = 40;
            // 
            // Del_repositoryItemButtonEdit
            // 
            this.Del_repositoryItemButtonEdit.AutoHeight = false;
            editorButtonImageOptions3.Image = global::DXApplication9.Properties.Resources.removepivotfield_16x16;
            this.Del_repositoryItemButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions3, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.Del_repositoryItemButtonEdit.Name = "Del_repositoryItemButtonEdit";
            this.Del_repositoryItemButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // agrupacionBindingSource
            // 
            this.agrupacionBindingSource.DataSource = typeof(DXApplication9.Agrupacion);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Agrupacion_lookUpEdit);
            this.layoutControl1.Controls.Add(this.gridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1127, 593);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Agrupacion_lookUpEdit
            // 
            this.Agrupacion_lookUpEdit.Location = new System.Drawing.Point(520, 12);
            this.Agrupacion_lookUpEdit.Name = "Agrupacion_lookUpEdit";
            this.Agrupacion_lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Agrupacion_lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AgrupacionID", "Agrupacion ID", 91, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 47, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.Agrupacion_lookUpEdit.Properties.DataSource = this.agrupacionBindingSource;
            this.Agrupacion_lookUpEdit.Properties.DisplayMember = "Nombre";
            this.Agrupacion_lookUpEdit.Properties.NullText = "-Seleccione-";
            this.Agrupacion_lookUpEdit.Properties.ValueMember = "AgrupacionID";
            this.Agrupacion_lookUpEdit.Size = new System.Drawing.Size(177, 20);
            this.Agrupacion_lookUpEdit.StyleController = this.layoutControl1;
            this.Agrupacion_lookUpEdit.TabIndex = 4;
            this.Agrupacion_lookUpEdit.EditValueChanged += new System.EventHandler(this.Agrupaciones_barEditItem_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1127, 593);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1107, 549);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.Agrupacion_lookUpEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(430, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(259, 24);
            this.layoutControlItem2.Text = "Unidad Artística";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(689, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(418, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(430, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // RepertoriosLista_XtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 593);
            this.Controls.Add(this.layoutControl1);
            this.Name = "RepertoriosLista_XtraForm";
            this.Text = "Listado de Temas";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Titulo_repositoryItemTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_repositoryItemButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Del_repositoryItemButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.BindingSource cancionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCancionID;
        private DevExpress.XtraGrid.Columns.GridColumn colTitulo;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colSociedad;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupacionId;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupacion;
        private System.Windows.Forms.BindingSource agrupacionBindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit Agrupacion_lookUpEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn Edit_gridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Edit_repositoryItemButtonEdit;
        private DevExpress.XtraGrid.Columns.GridColumn del_gridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Del_repositoryItemButtonEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit Titulo_repositoryItemTextEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}