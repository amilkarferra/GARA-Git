namespace DXApplication9
{
    partial class CargosDeFirmantesXtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargosDeFirmantesXtraForm));
            this.Firmantes_gridControl = new DevExpress.XtraGrid.GridControl();
            this.personasQueFirmanReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Firmantes_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreCompleto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroQuePertenece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonaQueFirmaReporteID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Del_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Firmantes_gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasQueFirmanReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Firmantes_gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Firmantes_gridControl
            // 
            this.Firmantes_gridControl.DataSource = this.personasQueFirmanReporteBindingSource;
            this.Firmantes_gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Firmantes_gridControl.Location = new System.Drawing.Point(0, 0);
            this.Firmantes_gridControl.MainView = this.Firmantes_gridView;
            this.Firmantes_gridControl.Name = "Firmantes_gridControl";
            this.Firmantes_gridControl.Size = new System.Drawing.Size(620, 364);
            this.Firmantes_gridControl.TabIndex = 0;
            this.Firmantes_gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Firmantes_gridView});
            // 
            // personasQueFirmanReporteBindingSource
            // 
            this.personasQueFirmanReporteBindingSource.DataSource = typeof(DXApplication9.PersonasQueFirmanReporte);
            // 
            // Firmantes_gridView
            // 
            this.Firmantes_gridView.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Firmantes_gridView.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Firmantes_gridView.Appearance.TopNewRow.ForeColor = System.Drawing.Color.White;
            this.Firmantes_gridView.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Firmantes_gridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.Firmantes_gridView.Appearance.TopNewRow.Options.UseFont = true;
            this.Firmantes_gridView.Appearance.TopNewRow.Options.UseForeColor = true;
            this.Firmantes_gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCargo,
            this.colNombreCompleto,
            this.colCentroQuePertenece,
            this.colPersonaQueFirmaReporteID});
            this.Firmantes_gridView.GridControl = this.Firmantes_gridControl;
            this.Firmantes_gridView.Name = "Firmantes_gridView";
            this.Firmantes_gridView.NewItemRowText = "Clic aquí Para insertar nueva persona que puede firmar reportes";
            this.Firmantes_gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.Firmantes_gridView.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.Firmantes_gridView.OptionsEditForm.EditFormColumnCount = 1;
            this.Firmantes_gridView.OptionsFind.AlwaysVisible = true;
            this.Firmantes_gridView.OptionsFind.SearchInPreview = true;
            this.Firmantes_gridView.OptionsSelection.MultiSelect = true;
            this.Firmantes_gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.Firmantes_gridView.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.Firmantes_gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.Firmantes_gridView.OptionsView.ShowGroupPanel = false;
            this.Firmantes_gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.Firmantes_gridView_SelectionChanged);
            this.Firmantes_gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Firmantes_gridView_RowUpdated);
            // 
            // colCargo
            // 
            this.colCargo.FieldName = "Cargo";
            this.colCargo.Name = "colCargo";
            this.colCargo.Visible = true;
            this.colCargo.VisibleIndex = 1;
            // 
            // colNombreCompleto
            // 
            this.colNombreCompleto.FieldName = "NombreCompleto";
            this.colNombreCompleto.Name = "colNombreCompleto";
            this.colNombreCompleto.Visible = true;
            this.colNombreCompleto.VisibleIndex = 2;
            // 
            // colCentroQuePertenece
            // 
            this.colCentroQuePertenece.FieldName = "CentroQuePertenece";
            this.colCentroQuePertenece.Name = "colCentroQuePertenece";
            this.colCentroQuePertenece.Visible = true;
            this.colCentroQuePertenece.VisibleIndex = 3;
            // 
            // colPersonaQueFirmaReporteID
            // 
            this.colPersonaQueFirmaReporteID.FieldName = "PersonaQueFirmaReporteID";
            this.colPersonaQueFirmaReporteID.Name = "colPersonaQueFirmaReporteID";
            this.colPersonaQueFirmaReporteID.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            // 
            // Del_simpleButton
            // 
            this.Del_simpleButton.Image = ((System.Drawing.Image)(resources.GetObject("Del_simpleButton.Image")));
            this.Del_simpleButton.Location = new System.Drawing.Point(585, 12);
            this.Del_simpleButton.Name = "Del_simpleButton";
            this.Del_simpleButton.Size = new System.Drawing.Size(23, 21);
            this.Del_simpleButton.TabIndex = 1;
            this.Del_simpleButton.ToolTip = "Elimina el firmante seleccionado";
            this.Del_simpleButton.ToolTipTitle = "Eliminar";
            this.Del_simpleButton.Click += new System.EventHandler(this.Del_simpleButton_Click);
            // 
            // CargosDeFirmantesXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 364);
            this.Controls.Add(this.Del_simpleButton);
            this.Controls.Add(this.Firmantes_gridControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CargosDeFirmantesXtraForm";
            this.Text = "Nomenclador de Firmantes de Reportes";
            this.Load += new System.EventHandler(this.CargosDeFirmantesXtraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Firmantes_gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasQueFirmanReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Firmantes_gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl Firmantes_gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Firmantes_gridView;
        private System.Windows.Forms.BindingSource personasQueFirmanReporteBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCargo;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreCompleto;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroQuePertenece;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonaQueFirmaReporteID;
        private DevExpress.XtraEditors.SimpleButton Del_simpleButton;

    }
}