namespace DXApplication9.UserControls
{
    partial class DescontarActividadXtraUserControl
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.descuentoPorActividadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colDescuentoPorActividadID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentoReferenciaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrdenDeTrabajo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDescuento1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoPorActividadBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.descuentoPorActividadBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(452, 299);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescuentoPorActividadID,
            this.colDocumentoReferenciaId,
            this.colImporte,
            this.colDescripcion,
            this.colTipoDescuento,
            this.colOrdenDeTrabajo,
            this.colTipoDescuento1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // descuentoPorActividadBindingSource
            // 
            this.descuentoPorActividadBindingSource.DataSource = typeof(DXApplication9.DescuentoPorActividad);
            // 
            // colDescuentoPorActividadID
            // 
            this.colDescuentoPorActividadID.FieldName = "DescuentoPorActividadID";
            this.colDescuentoPorActividadID.Name = "colDescuentoPorActividadID";
            this.colDescuentoPorActividadID.Visible = true;
            this.colDescuentoPorActividadID.VisibleIndex = 0;
            // 
            // colDocumentoReferenciaId
            // 
            this.colDocumentoReferenciaId.FieldName = "DocumentoReferenciaId";
            this.colDocumentoReferenciaId.Name = "colDocumentoReferenciaId";
            this.colDocumentoReferenciaId.Visible = true;
            this.colDocumentoReferenciaId.VisibleIndex = 1;
            // 
            // colImporte
            // 
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 2;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 3;
            // 
            // colTipoDescuento
            // 
            this.colTipoDescuento.FieldName = "TipoDescuento";
            this.colTipoDescuento.Name = "colTipoDescuento";
            this.colTipoDescuento.Visible = true;
            this.colTipoDescuento.VisibleIndex = 4;
            // 
            // colOrdenDeTrabajo
            // 
            this.colOrdenDeTrabajo.FieldName = "OrdenDeTrabajo";
            this.colOrdenDeTrabajo.Name = "colOrdenDeTrabajo";
            this.colOrdenDeTrabajo.Visible = true;
            this.colOrdenDeTrabajo.VisibleIndex = 5;
            // 
            // colTipoDescuento1
            // 
            this.colTipoDescuento1.FieldName = "TipoDescuento1";
            this.colTipoDescuento1.Name = "colTipoDescuento1";
            this.colTipoDescuento1.Visible = true;
            this.colTipoDescuento1.VisibleIndex = 6;
            // 
            // DescontarActividadXtraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "DescontarActividadXtraUserControl";
            this.Size = new System.Drawing.Size(452, 299);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoPorActividadBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource descuentoPorActividadBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDescuentoPorActividadID;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentoReferenciaId;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colOrdenDeTrabajo;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDescuento1;
    }
}
