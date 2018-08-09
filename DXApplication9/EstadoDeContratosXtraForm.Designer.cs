namespace DXApplication9
{
    partial class EstadoDeContratosXtraForm
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstadoDeContratosXtraForm));
            this.EstadosDeContratos_gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.EstadosDeContratos_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEstadoContratoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripción = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbreviatura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvalidaContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.Nuevo_barLargeButtonItem = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.EstadosDeContratos_gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadosDeContratos_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // EstadosDeContratos_gridControl
            // 
            this.EstadosDeContratos_gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.EstadosDeContratos_gridControl.DataSource = this.bindingSource1;
            this.EstadosDeContratos_gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EstadosDeContratos_gridControl.Location = new System.Drawing.Point(0, 66);
            this.EstadosDeContratos_gridControl.MainView = this.EstadosDeContratos_gridView;
            this.EstadosDeContratos_gridControl.Name = "EstadosDeContratos_gridControl";
            this.EstadosDeContratos_gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit1});
            this.EstadosDeContratos_gridControl.Size = new System.Drawing.Size(464, 219);
            this.EstadosDeContratos_gridControl.TabIndex = 0;
            this.EstadosDeContratos_gridControl.UseEmbeddedNavigator = true;
            this.EstadosDeContratos_gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.EstadosDeContratos_gridView});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DXApplication9.EstadoContrato);
            // 
            // EstadosDeContratos_gridView
            // 
            this.EstadosDeContratos_gridView.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EstadosDeContratos_gridView.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.EstadosDeContratos_gridView.Appearance.TopNewRow.ForeColor = System.Drawing.Color.White;
            this.EstadosDeContratos_gridView.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.EstadosDeContratos_gridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.EstadosDeContratos_gridView.Appearance.TopNewRow.Options.UseFont = true;
            this.EstadosDeContratos_gridView.Appearance.TopNewRow.Options.UseForeColor = true;
            this.EstadosDeContratos_gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEstadoContratoID,
            this.colDescripción,
            this.colAbreviatura,
            this.colInvalidaContrato,
            this.colColor});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format0";
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.EstadosDeContratos_gridView.FormatRules.Add(gridFormatRule2);
            this.EstadosDeContratos_gridView.GridControl = this.EstadosDeContratos_gridControl;
            this.EstadosDeContratos_gridView.Name = "EstadosDeContratos_gridView";
            this.EstadosDeContratos_gridView.NewItemRowText = "Clic aquí Para insertar nuevo registro";
            this.EstadosDeContratos_gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.EstadosDeContratos_gridView.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.EstadosDeContratos_gridView.OptionsEditForm.EditFormColumnCount = 1;
            this.EstadosDeContratos_gridView.OptionsSelection.MultiSelect = true;
            this.EstadosDeContratos_gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.EstadosDeContratos_gridView.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.EstadosDeContratos_gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.EstadosDeContratos_gridView.OptionsView.ShowGroupPanel = false;
            this.EstadosDeContratos_gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.EstadosDeContratos_gridView_CellValueChanged);
            this.EstadosDeContratos_gridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.EstadosDeContratos_gridView_RowDeleted);
            this.EstadosDeContratos_gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.EstadosDeContratos_gridView_RowUpdated);
            this.EstadosDeContratos_gridView.DoubleClick += new System.EventHandler(this.EstadosDeContratos_gridView_DoubleClick);
            // 
            // colEstadoContratoID
            // 
            this.colEstadoContratoID.FieldName = "EstadoContratoID";
            this.colEstadoContratoID.Name = "colEstadoContratoID";
            // 
            // colDescripción
            // 
            this.colDescripción.FieldName = "Descripción";
            this.colDescripción.Name = "colDescripción";
            this.colDescripción.Visible = true;
            this.colDescripción.VisibleIndex = 2;
            // 
            // colAbreviatura
            // 
            this.colAbreviatura.FieldName = "Abreviatura";
            this.colAbreviatura.Name = "colAbreviatura";
            this.colAbreviatura.Visible = true;
            this.colAbreviatura.VisibleIndex = 1;
            // 
            // colInvalidaContrato
            // 
            this.colInvalidaContrato.FieldName = "InvalidaContrato";
            this.colInvalidaContrato.Name = "colInvalidaContrato";
            this.colInvalidaContrato.Visible = true;
            this.colInvalidaContrato.VisibleIndex = 3;
            // 
            // colColor
            // 
            this.colColor.ColumnEdit = this.repositoryItemColorPickEdit1;
            this.colColor.FieldName = "Color";
            this.colColor.Name = "colColor";
            this.colColor.Visible = true;
            this.colColor.VisibleIndex = 4;
            // 
            // repositoryItemColorPickEdit1
            // 
            this.repositoryItemColorPickEdit1.AutoHeight = false;
            this.repositoryItemColorPickEdit1.AutomaticColor = System.Drawing.Color.Black;
            this.repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit1.ColorText = DevExpress.XtraEditors.Controls.ColorText.Integer;
            this.repositoryItemColorPickEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            this.repositoryItemColorPickEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.Nuevo_barLargeButtonItem});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Nuevo_barLargeButtonItem)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // Nuevo_barLargeButtonItem
            // 
            this.Nuevo_barLargeButtonItem.Caption = "Nuevo";
            this.Nuevo_barLargeButtonItem.Id = 0;
            this.Nuevo_barLargeButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Nuevo_barLargeButtonItem.ImageOptions.Image")));
            this.Nuevo_barLargeButtonItem.Name = "Nuevo_barLargeButtonItem";
            this.Nuevo_barLargeButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Nuevo_barLargeButtonItem_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(464, 66);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 285);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(464, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 66);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 219);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(464, 66);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 219);
            // 
            // EstadoDeContratosXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 307);
            this.Controls.Add(this.EstadosDeContratos_gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "EstadoDeContratosXtraForm";
            this.Text = "Posibles estados de los contratos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EstadoDeContratosXtraForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.EstadosDeContratos_gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadosDeContratos_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl EstadosDeContratos_gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView EstadosDeContratos_gridView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colEstadoContratoID;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripción;
        private DevExpress.XtraGrid.Columns.GridColumn colAbreviatura;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colInvalidaContrato;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarLargeButtonItem Nuevo_barLargeButtonItem;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn colColor;
    }
}