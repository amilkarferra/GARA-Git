namespace DXApplication9
{
    partial class TrayectoriaArtistaXtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrayectoriaArtistaXtraForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.TrayectoriaArtista_gridControl = new DevExpress.XtraGrid.GridControl();
            this.trayectoriaArtistaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TrayectoriaArtista_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTrayectoriaArtistaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArtistaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesempeño = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHasta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArtista = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgrupacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrayectoriaArtista_gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trayectoriaArtistaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayectoriaArtista_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.TrayectoriaArtista_gridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(497, 261);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // TrayectoriaArtista_gridControl
            // 
            this.TrayectoriaArtista_gridControl.DataSource = this.trayectoriaArtistaBindingSource;
            this.TrayectoriaArtista_gridControl.Location = new System.Drawing.Point(12, 12);
            this.TrayectoriaArtista_gridControl.MainView = this.TrayectoriaArtista_gridView;
            this.TrayectoriaArtista_gridControl.Name = "TrayectoriaArtista_gridControl";
            this.TrayectoriaArtista_gridControl.Size = new System.Drawing.Size(473, 237);
            this.TrayectoriaArtista_gridControl.TabIndex = 4;
            this.TrayectoriaArtista_gridControl.UseEmbeddedNavigator = true;
            this.TrayectoriaArtista_gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TrayectoriaArtista_gridView});
            // 
            // trayectoriaArtistaBindingSource
            // 
            this.trayectoriaArtistaBindingSource.DataSource = typeof(DXApplication9.TrayectoriaArtista);
            // 
            // TrayectoriaArtista_gridView
            // 
            this.TrayectoriaArtista_gridView.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TrayectoriaArtista_gridView.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TrayectoriaArtista_gridView.Appearance.TopNewRow.ForeColor = System.Drawing.Color.White;
            this.TrayectoriaArtista_gridView.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.TrayectoriaArtista_gridView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.TrayectoriaArtista_gridView.Appearance.TopNewRow.Options.UseFont = true;
            this.TrayectoriaArtista_gridView.Appearance.TopNewRow.Options.UseForeColor = true;
            this.TrayectoriaArtista_gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTrayectoriaArtistaID,
            this.colArtistaId,
            this.colCentro,
            this.colDesempeño,
            this.colDesde,
            this.colHasta,
            this.colArtista,
            this.colAgrupacion});
            this.TrayectoriaArtista_gridView.GridControl = this.TrayectoriaArtista_gridControl;
            this.TrayectoriaArtista_gridView.Name = "TrayectoriaArtista_gridView";
            this.TrayectoriaArtista_gridView.NewItemRowText = "Clic aquí Para insertar nuevo registro";
            this.TrayectoriaArtista_gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.TrayectoriaArtista_gridView.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.TrayectoriaArtista_gridView.OptionsEditForm.EditFormColumnCount = 1;
            this.TrayectoriaArtista_gridView.OptionsSelection.MultiSelect = true;
            this.TrayectoriaArtista_gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.TrayectoriaArtista_gridView.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.TrayectoriaArtista_gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.TrayectoriaArtista_gridView.OptionsView.ShowGroupPanel = false;
            this.TrayectoriaArtista_gridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.TrayectoriaArtista_gridView_RowDeleted);
            this.TrayectoriaArtista_gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.TrayectoriaArtista_gridView_RowUpdated);
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
            // colDesempeño
            // 
            this.colDesempeño.FieldName = "Desempeño";
            this.colDesempeño.Name = "colDesempeño";
            this.colDesempeño.Visible = true;
            this.colDesempeño.VisibleIndex = 3;
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
            // colArtista
            // 
            this.colArtista.FieldName = "Artista";
            this.colArtista.Name = "colArtista";
            // 
            // colAgrupacion
            // 
            this.colAgrupacion.FieldName = "Agrupacion";
            this.colAgrupacion.Name = "colAgrupacion";
            this.colAgrupacion.Visible = true;
            this.colAgrupacion.VisibleIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(497, 261);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TrayectoriaArtista_gridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(477, 241);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // TrayectoriaArtistaXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 261);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "TrayectoriaArtistaXtraForm";
            this.Text = "Editando Trayectoria de Integrante";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrayectoriaArtista_gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trayectoriaArtistaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayectoriaArtista_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl TrayectoriaArtista_gridControl;
        private System.Windows.Forms.BindingSource trayectoriaArtistaBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView TrayectoriaArtista_gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colTrayectoriaArtistaID;
        private DevExpress.XtraGrid.Columns.GridColumn colArtistaId;
        private DevExpress.XtraGrid.Columns.GridColumn colCentro;
        private DevExpress.XtraGrid.Columns.GridColumn colDesempeño;
        private DevExpress.XtraGrid.Columns.GridColumn colDesde;
        private DevExpress.XtraGrid.Columns.GridColumn colHasta;
        private DevExpress.XtraGrid.Columns.GridColumn colArtista;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupacion;
    }
}