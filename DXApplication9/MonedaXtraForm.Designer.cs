namespace DXApplication9
{
    partial class MonedaXtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonedaXtraForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.linqInstantFeedbackSource1 = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTipoMonedaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbreviatura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrdenDeTrabajo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obligatory_repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Obligatory_repositoryItemTextEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.linqInstantFeedbackSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Obligatory_repositoryItemTextEdit});
            this.gridControl1.Size = new System.Drawing.Size(407, 261);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // linqInstantFeedbackSource1
            // 
            this.linqInstantFeedbackSource1.DefaultSorting = "Abreviatura ASC";
            this.linqInstantFeedbackSource1.DesignTimeElementType = typeof(DXApplication9.TipoMoneda);
            this.linqInstantFeedbackSource1.KeyExpression = "TipoMonedaID";
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
            this.colTipoMonedaID,
            this.colMoneda,
            this.colAbreviatura,
            this.colOrdenDeTrabajo});
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
            // colTipoMonedaID
            // 
            this.colTipoMonedaID.FieldName = "TipoMonedaID";
            this.colTipoMonedaID.Name = "colTipoMonedaID";
            // 
            // colMoneda
            // 
            this.colMoneda.FieldName = "Moneda";
            this.colMoneda.Name = "colMoneda";
            this.colMoneda.ToolTip = "se podran realizar ordenes de trabajo con las monedas seleccioanadas solamente";
            this.colMoneda.Visible = true;
            this.colMoneda.VisibleIndex = 1;
            // 
            // colAbreviatura
            // 
            this.colAbreviatura.FieldName = "Abreviatura";
            this.colAbreviatura.Name = "colAbreviatura";
            this.colAbreviatura.Visible = true;
            this.colAbreviatura.VisibleIndex = 2;
            // 
            // colOrdenDeTrabajo
            // 
            this.colOrdenDeTrabajo.FieldName = "OrdenDeTrabajo";
            this.colOrdenDeTrabajo.Name = "colOrdenDeTrabajo";
            this.colOrdenDeTrabajo.Visible = true;
            this.colOrdenDeTrabajo.VisibleIndex = 3;
            // 
            // Obligatory_repositoryItemTextEdit
            // 
            this.Obligatory_repositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.Obligatory_repositoryItemTextEdit.AutoHeight = false;
            this.Obligatory_repositoryItemTextEdit.Name = "Obligatory_repositoryItemTextEdit";
            this.Obligatory_repositoryItemTextEdit.NullText = "Obligatorio";
            // 
            // MonedaXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 261);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonedaXtraForm";
            this.Text = "Administración de Tipos de Monedas";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Obligatory_repositoryItemTextEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource linqInstantFeedbackSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMonedaID;
        private DevExpress.XtraGrid.Columns.GridColumn colMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn colAbreviatura;
        private DevExpress.XtraGrid.Columns.GridColumn colOrdenDeTrabajo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit Obligatory_repositoryItemTextEdit;
    }
}