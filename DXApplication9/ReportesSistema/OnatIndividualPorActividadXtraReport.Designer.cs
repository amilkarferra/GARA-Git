namespace DXApplication9.ReportesSistema
{
    partial class OnatIndividualPorActXtraReport
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
            this.linqServerModeSource1 = new DevExpress.Data.Linq.LinqServerModeSource();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.NombreCompleto_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Importe_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Onat_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.DatosContactoxrRichText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 25F;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // linqServerModeSource1
            // 
            this.linqServerModeSource1.ElementType = typeof(DXApplication9.Artista);
            this.linqServerModeSource1.KeyExpression = "[ArtistaID]";
            // 
            // xrTable1
            // 
            this.xrTable1.Dpi = 100F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.xrTable1.SizeF = new System.Drawing.SizeF(419.7918F, 25F);
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.NombreCompleto_xrTableCell,
            this.Importe_xrTableCell,
            this.Onat_xrTableCell});
            this.xrTableRow10.Dpi = 100F;
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1D;
            // 
            // NombreCompleto_xrTableCell
            // 
            this.NombreCompleto_xrTableCell.Dpi = 100F;
            this.NombreCompleto_xrTableCell.Name = "NombreCompleto_xrTableCell";
            this.NombreCompleto_xrTableCell.Text = "Nombre Completo";
            this.NombreCompleto_xrTableCell.Weight = 1.9583332824707032D;
            // 
            // Importe_xrTableCell
            // 
            this.Importe_xrTableCell.Dpi = 100F;
            this.Importe_xrTableCell.Name = "Importe_xrTableCell";
            this.Importe_xrTableCell.Weight = 1.0937502156771237D;
            // 
            // Onat_xrTableCell
            // 
            this.Onat_xrTableCell.Dpi = 100F;
            this.Onat_xrTableCell.Name = "Onat_xrTableCell";
            this.Onat_xrTableCell.Text = "Onat_xrTableCell";
            this.Onat_xrTableCell.Weight = 1.1458344845894493D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 100F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 100F;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
            this.xrTable2.SizeF = new System.Drawing.SizeF(419.7918F, 25F);
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3});
            this.xrTableRow11.Dpi = 100F;
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Nombre ";
            this.xrTableCell1.Weight = 1.9583332824707032D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Ingresos\t";
            this.xrTableCell2.Weight = 1.0937502156771237D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 100F;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Aportado a Onat";
            this.xrTableCell3.Weight = 1.1458344845894493D;
            // 
            // OnatIndividualPorActividadXtraReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.Configuracion_objectDataSource});
            this.DataSource = this.linqServerModeSource1;
 
            this.Scripts.OnFillEmptySpace = "XtraReport1_FillEmptySpace";
            this.Version = "16.2";
            this.Controls.SetChildIndex(this.GroupHeader1, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DatosContactoxrRichText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.Data.Linq.LinqServerModeSource linqServerModeSource1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell NombreCompleto_xrTableCell;
        private DevExpress.XtraReports.UI.XRTableCell Importe_xrTableCell;
        private DevExpress.XtraReports.UI.XRTableCell Onat_xrTableCell;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;


    }
}
