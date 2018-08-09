namespace DXApplication9
{
    partial class PopupDescuentosXtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupDescuentosXtraForm));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.descuentoPorActividadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescuentoPorActividadID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentoReferenciaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Importe_repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDescuentoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoDescuento_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tipoDescuentoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Del_gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tipoDescuentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoPorActividadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Importe_repositoryItemTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoDescuento_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDescuentoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDescuentoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(339, 63, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(533, 314);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(356, 266);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(165, 36);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Salir";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.descuentoPorActividadBindingSource;
            this.gridControl1.EmbeddedNavigator.Enabled = false;
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TipoDescuento_repositoryItemLookUpEdit,
            this.repositoryItemButtonEdit1,
            this.Importe_repositoryItemTextEdit});
            this.gridControl1.Size = new System.Drawing.Size(509, 250);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // descuentoPorActividadBindingSource
            // 
            this.descuentoPorActividadBindingSource.DataSource = typeof(DXApplication9.DescuentoPorActividad);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescuentoPorActividadID,
            this.colDocumentoReferenciaId,
            this.colImporte,
            this.colDescripcion,
            this.colTipoDescuentoId,
            this.Del_gridColumn});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "CLIC AQUI PARA INSERTAR NUEVO DESCUENTO";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView1.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            // 
            // colDescuentoPorActividadID
            // 
            this.colDescuentoPorActividadID.FieldName = "DescuentoPorActividadID";
            this.colDescuentoPorActividadID.Name = "colDescuentoPorActividadID";
            this.colDescuentoPorActividadID.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colDescuentoPorActividadID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            // 
            // colDocumentoReferenciaId
            // 
            this.colDocumentoReferenciaId.FieldName = "DocumentoReferenciaId";
            this.colDocumentoReferenciaId.Name = "colDocumentoReferenciaId";
            this.colDocumentoReferenciaId.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colImporte
            // 
            this.colImporte.ColumnEdit = this.Importe_repositoryItemTextEdit;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "Total:{0:n2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 0;
            this.colImporte.Width = 122;
            // 
            // Importe_repositoryItemTextEdit
            // 
            this.Importe_repositoryItemTextEdit.AutoHeight = false;
            this.Importe_repositoryItemTextEdit.Mask.EditMask = "#,###########.00";
            this.Importe_repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Importe_repositoryItemTextEdit.Name = "Importe_repositoryItemTextEdit";
            this.Importe_repositoryItemTextEdit.ValidateOnEnterKey = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 122;
            // 
            // colTipoDescuentoId
            // 
            this.colTipoDescuentoId.Caption = "Tipo";
            this.colTipoDescuentoId.ColumnEdit = this.TipoDescuento_repositoryItemLookUpEdit;
            this.colTipoDescuentoId.FieldName = "TipoDescuentoId";
            this.colTipoDescuentoId.Name = "colTipoDescuentoId";
            this.colTipoDescuentoId.Visible = true;
            this.colTipoDescuentoId.VisibleIndex = 2;
            this.colTipoDescuentoId.Width = 122;
            // 
            // TipoDescuento_repositoryItemLookUpEdit
            // 
            this.TipoDescuento_repositoryItemLookUpEdit.AutoHeight = false;
            this.TipoDescuento_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TipoDescuento_repositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abreviatura", "Abreviatura", 67, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.TipoDescuento_repositoryItemLookUpEdit.DataSource = this.tipoDescuentoBindingSource1;
            this.TipoDescuento_repositoryItemLookUpEdit.DisplayMember = "Abreviatura";
            this.TipoDescuento_repositoryItemLookUpEdit.Name = "TipoDescuento_repositoryItemLookUpEdit";
            this.TipoDescuento_repositoryItemLookUpEdit.ValueMember = "TIpoDescuentoID";
            // 
            // tipoDescuentoBindingSource1
            // 
            this.tipoDescuentoBindingSource1.DataSource = typeof(DXApplication9.TipoDescuento);
            // 
            // Del_gridColumn
            // 
            this.Del_gridColumn.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("Del_gridColumn.AppearanceCell.Image")));
            this.Del_gridColumn.AppearanceCell.Options.UseImage = true;
            this.Del_gridColumn.ColumnEdit = this.repositoryItemButtonEdit1;
            this.Del_gridColumn.Image = ((System.Drawing.Image)(resources.GetObject("Del_gridColumn.Image")));
            this.Del_gridColumn.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.Del_gridColumn.Name = "Del_gridColumn";
            this.Del_gridColumn.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.Del_gridColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.Del_gridColumn.Visible = true;
            this.Del_gridColumn.VisibleIndex = 3;
            this.Del_gridColumn.Width = 30;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            toolTipTitleItem1.Text = "Eliminar";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Elimina el descuento seleccionado";
            toolTipTitleItem2.LeftIndent = 6;
            toolTipTitleItem2.Text = " esta acción es irreversible";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            superToolTip1.Items.Add(toolTipSeparatorItem1);
            superToolTip1.Items.Add(toolTipTitleItem2);
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)), serializableAppearanceObject1, "", null, superToolTip1)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(533, 314);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(513, 254);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(344, 254);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(169, 40);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 254);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(344, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tipoDescuentoBindingSource
            // 
            this.tipoDescuentoBindingSource.DataSource = typeof(DXApplication9.TipoDescuento);
            // 
            // PopupDescuentosXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 314);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PopupDescuentosXtraForm";
            this.Text = "Añadiendo Descuentos";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoPorActividadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Importe_repositoryItemTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoDescuento_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDescuentoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDescuentoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource descuentoPorActividadBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescuentoPorActividadID;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentoReferenciaId;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDescuentoId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit TipoDescuento_repositoryItemLookUpEdit;
        private System.Windows.Forms.BindingSource tipoDescuentoBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource tipoDescuentoBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn Del_gridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit Importe_repositoryItemTextEdit;
    }
}