namespace DXApplication9
{
    partial class ResponsabilidadEmpresarioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResponsabilidadEmpresarioForm));
            this.Responsabildad_gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Responsabilidad_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colResponsabilidadEmpresarioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.Eliminar_barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.Responsabildad_gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Responsabilidad_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // Responsabildad_gridControl
            // 
            this.Responsabildad_gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.Responsabildad_gridControl.DataSource = this.bindingSource1;
            this.Responsabildad_gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Responsabildad_gridControl.Location = new System.Drawing.Point(0, 62);
            this.Responsabildad_gridControl.MainView = this.Responsabilidad_gridView;
            this.Responsabildad_gridControl.Name = "Responsabildad_gridControl";
            this.Responsabildad_gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.Responsabildad_gridControl.Size = new System.Drawing.Size(460, 231);
            this.Responsabildad_gridControl.TabIndex = 4;
            this.Responsabildad_gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Responsabilidad_gridView});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DXApplication9.ResponsabilidadEmpresario);
            // 
            // Responsabilidad_gridView
            // 
            this.Responsabilidad_gridView.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Responsabilidad_gridView.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Responsabilidad_gridView.Appearance.TopNewRow.ForeColor = System.Drawing.Color.White;
            this.Responsabilidad_gridView.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Responsabilidad_gridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.Responsabilidad_gridView.Appearance.TopNewRow.Options.UseFont = true;
            this.Responsabilidad_gridView.Appearance.TopNewRow.Options.UseForeColor = true;
            this.Responsabilidad_gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colResponsabilidadEmpresarioID,
            this.colDescripcion});
            this.Responsabilidad_gridView.GridControl = this.Responsabildad_gridControl;
            this.Responsabilidad_gridView.Name = "Responsabilidad_gridView";
            this.Responsabilidad_gridView.NewItemRowText = "Clic aquí Para insertar nuevo registro";
            this.Responsabilidad_gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.Responsabilidad_gridView.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.Responsabilidad_gridView.OptionsEditForm.EditFormColumnCount = 1;
            this.Responsabilidad_gridView.OptionsSelection.MultiSelect = true;
            this.Responsabilidad_gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.Responsabilidad_gridView.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.Responsabilidad_gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.Responsabilidad_gridView.OptionsView.ShowGroupPanel = false;
            this.Responsabilidad_gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.Responsabilidad_gridView_SelectionChanged);
            this.Responsabilidad_gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Responsabilidad_gridView_RowUpdated);
            // 
            // colResponsabilidadEmpresarioID
            // 
            this.colResponsabilidadEmpresarioID.FieldName = "ResponsabilidadEmpresarioID";
            this.colResponsabilidadEmpresarioID.Name = "colResponsabilidadEmpresarioID";
            // 
            // colDescripcion
            // 
            this.colDescripcion.ColumnEdit = this.repositoryItemTextEdit1;
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.Eliminar_barLargeButtonItem1});
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Eliminar_barLargeButtonItem1)});
            this.bar1.Text = "Tools";
            // 
            // Eliminar_barLargeButtonItem1
            // 
            this.Eliminar_barLargeButtonItem1.Caption = "Eliminar";
            this.Eliminar_barLargeButtonItem1.Enabled = false;
            this.Eliminar_barLargeButtonItem1.Id = 0;
            this.Eliminar_barLargeButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar_barLargeButtonItem1.ImageOptions.Image")));
            this.Eliminar_barLargeButtonItem1.Name = "Eliminar_barLargeButtonItem1";
            this.Eliminar_barLargeButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.Eliminar_barLargeButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Eliminar_barLargeButtonItem1_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(460, 62);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 293);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(460, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 62);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 231);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(460, 62);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 231);
            // 
            // ResponsabilidadEmpresarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 315);
            this.Controls.Add(this.Responsabildad_gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ResponsabilidadEmpresarioForm";
            this.Text = "Configurando responsabilidades de Empresarios";
            ((System.ComponentModel.ISupportInitialize)(this.Responsabildad_gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Responsabilidad_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl Responsabildad_gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Responsabilidad_gridView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsabilidadEmpresarioID;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem Eliminar_barLargeButtonItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}