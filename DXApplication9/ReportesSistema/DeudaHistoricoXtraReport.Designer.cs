namespace DXApplication9.ReportesSistema
{
    partial class DeudaHistoricoXtraReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.RangoFecha_xrLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Agrupacion_xrLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.linqServerModeSource1 = new DevExpress.Data.Linq.LinqServerModeSource();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.Acción_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Fecha_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Importe_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Descripcion_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Acumulado_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.DatosContactoxrRichText)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 41.04169F;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.RangoFecha_xrLabel,
            this.xrLabel2,
            this.Agrupacion_xrLabel,
            this.xrLabel1});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 168.9167F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable1.Dpi = 100F;
            this.xrTable1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 122.9167F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.xrTable1.SizeF = new System.Drawing.SizeF(650F, 25.00001F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5});
            this.xrTableRow10.Dpi = 100F;
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Acción";
            this.xrTableCell1.Weight = 1.1875D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Fecha";
            this.xrTableCell2.Weight = 0.8125D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 100F;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Importe";
            this.xrTableCell3.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 100F;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Descripción";
            this.xrTableCell4.Weight = 2.4062493896484378D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 100F;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Acumulado";
            this.xrTableCell5.Weight = 1.0937506103515629D;
            // 
            // RangoFecha_xrLabel
            // 
            this.RangoFecha_xrLabel.Dpi = 100F;
            this.RangoFecha_xrLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic);
            this.RangoFecha_xrLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80.45832F);
            this.RangoFecha_xrLabel.Name = "RangoFecha_xrLabel";
            this.RangoFecha_xrLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.RangoFecha_xrLabel.SizeF = new System.Drawing.SizeF(650F, 23F);
            this.RangoFecha_xrLabel.StylePriority.UseFont = false;
            this.RangoFecha_xrLabel.StylePriority.UseTextAlignment = false;
            this.RangoFecha_xrLabel.Text = "17/7/2017 - 31/7/2017";
            this.RangoFecha_xrLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TipoMoneda.Abreviatura")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 57.45831F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(650F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Agrupacion_xrLabel
            // 
            this.Agrupacion_xrLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Agrupacion.Nombre")});
            this.Agrupacion_xrLabel.Dpi = 100F;
            this.Agrupacion_xrLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic);
            this.Agrupacion_xrLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34.45832F);
            this.Agrupacion_xrLabel.Name = "Agrupacion_xrLabel";
            this.Agrupacion_xrLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Agrupacion_xrLabel.SizeF = new System.Drawing.SizeF(650F, 23F);
            this.Agrupacion_xrLabel.StylePriority.UseFont = false;
            this.Agrupacion_xrLabel.StylePriority.UseTextAlignment = false;
            this.Agrupacion_xrLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(650F, 34.45832F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Reporte de Historico de Deuda ";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // linqServerModeSource1
            // 
            this.linqServerModeSource1.ElementType = typeof(DXApplication9.HistoricoDeuda);
            this.linqServerModeSource1.KeyExpression = "[HistoricoDeudaID]";
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 100F;
            this.xrTable2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
            this.xrTable2.SizeF = new System.Drawing.SizeF(650F, 41.04169F);
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.Acción_xrTableCell,
            this.Fecha_xrTableCell,
            this.Importe_xrTableCell,
            this.Descripcion_xrTableCell,
            this.Acumulado_xrTableCell});
            this.xrTableRow11.Dpi = 100F;
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.StylePriority.UseBorders = false;
            this.xrTableRow11.Weight = 0.80408202586076749D;
            // 
            // Acción_xrTableCell
            // 
            this.Acción_xrTableCell.Dpi = 100F;
            this.Acción_xrTableCell.Name = "Acción_xrTableCell";
            this.Acción_xrTableCell.Text = "Acción";
            this.Acción_xrTableCell.Weight = 1.1875D;
            // 
            // Fecha_xrTableCell
            // 
            this.Fecha_xrTableCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Fecha", "{0:dd/MM/yyyy}")});
            this.Fecha_xrTableCell.Dpi = 100F;
            this.Fecha_xrTableCell.Name = "Fecha_xrTableCell";
            this.Fecha_xrTableCell.Weight = 0.8125D;
            // 
            // Importe_xrTableCell
            // 
            this.Importe_xrTableCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "importe", "{0:n2}")});
            this.Importe_xrTableCell.Dpi = 100F;
            this.Importe_xrTableCell.Name = "Importe_xrTableCell";
            this.Importe_xrTableCell.Weight = 1D;
            // 
            // Descripcion_xrTableCell
            // 
            this.Descripcion_xrTableCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Descripcion")});
            this.Descripcion_xrTableCell.Dpi = 100F;
            this.Descripcion_xrTableCell.Name = "Descripcion_xrTableCell";
            this.Descripcion_xrTableCell.StylePriority.UseTextAlignment = false;
            this.Descripcion_xrTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Descripcion_xrTableCell.Weight = 2.4062493896484378D;
            // 
            // Acumulado_xrTableCell
            // 
            this.Acumulado_xrTableCell.Dpi = 100F;
            this.Acumulado_xrTableCell.Name = "Acumulado_xrTableCell";
            this.Acumulado_xrTableCell.Text = "Acumulado";
            this.Acumulado_xrTableCell.Weight = 1.0937506103515629D;
            // 
            // DeudaHistoricoXtraReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.GroupHeader1});
            //this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            //this.Configuracion_objectDataSource});
            this.DataSource = this.linqServerModeSource1;
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
 
            this.Scripts.OnFillEmptySpace = "XtraReport1_FillEmptySpace";
            this.Version = "16.2";
            this.Controls.SetChildIndex(this.GroupHeader1, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DatosContactoxrRichText)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel RangoFecha_xrLabel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel Agrupacion_xrLabel;
        private System.ServiceProcess.ServiceController serviceController1;
        private DevExpress.Data.Linq.LinqServerModeSource linqServerModeSource1;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow11;
        private DevExpress.XtraReports.UI.XRTableCell Acción_xrTableCell;
        private DevExpress.XtraReports.UI.XRTableCell Fecha_xrTableCell;
        private DevExpress.XtraReports.UI.XRTableCell Importe_xrTableCell;
        private DevExpress.XtraReports.UI.XRTableCell Descripcion_xrTableCell;
        private DevExpress.XtraReports.UI.XRTableCell Acumulado_xrTableCell;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;



    }
}
