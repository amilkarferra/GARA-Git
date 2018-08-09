namespace DXApplication9.ReportesSistema
{
    partial class CatalogoXtraReport
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
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Agrupacion_linqServerModeSource = new DevExpress.Data.Linq.LinqServerModeSource();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.DobleVinculo_calculatedField = new DevExpress.XtraReports.UI.CalculatedField();
            this.Integrantes_xrLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_linqServerModeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.Integrantes_xrLabel,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail.HeightF = 16.74999F;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLabel4});
            this.PageHeader.HeightF = 173.8333F;
            this.PageHeader.Controls.SetChildIndex(this.xrLabel4, 0);
            this.PageHeader.Controls.SetChildIndex(this.xrLine2, 0);
            // 
            // Agrupacion_linqServerModeSource
            // 
            this.Agrupacion_linqServerModeSource.ElementType = typeof(DXApplication9.Agrupacion);
            this.Agrupacion_linqServerModeSource.KeyExpression = "[AgrupacionID]";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Nombre")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Italic);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(41.66667F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(291.6667F, 13F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AgrupacionID")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Italic);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(29.16667F, 13F);
            this.xrLabel2.StylePriority.UseFont = false;
            xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel2.Summary = xrSummary2;
            // 
            // DobleVinculo_calculatedField
            // 
            this.DobleVinculo_calculatedField.Expression = "Iif([DobleVinculo],\'Doble Vínculo\',\'\')";
            this.DobleVinculo_calculatedField.Name = "DobleVinculo_calculatedField";
            // 
            // Integrantes_xrLabel
            // 
            this.Integrantes_xrLabel.Dpi = 100F;
            this.Integrantes_xrLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.Integrantes_xrLabel.LocationFloat = new DevExpress.Utils.PointFloat(482.7084F, 0F);
            this.Integrantes_xrLabel.Name = "Integrantes_xrLabel";
            this.Integrantes_xrLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Integrantes_xrLabel.SizeF = new System.Drawing.SizeF(100F, 13.00001F);
            this.Integrantes_xrLabel.StylePriority.UseFont = false;
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            this.Integrantes_xrLabel.Summary = xrSummary1;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DobleVinculo_calculatedField")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Italic);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(347.9167F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 13.00001F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(217.5F, 140.8333F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(207.2917F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "CATÁLOGO";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(201.0417F, 163.8332F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(246.875F, 10.00005F);
            // 
            // CatalogoXtraReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.DobleVinculo_calculatedField});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.Configuracion_objectDataSource});
            this.DataSource = this.Agrupacion_linqServerModeSource;
 
            this.Scripts.OnFillEmptySpace = "XtraReport1_FillEmptySpace";
            this.Version = "16.2";
            this.DesignerLoaded += new DevExpress.XtraReports.UserDesigner.DesignerLoadedEventHandler(this.CatalogoXtraReport_DesignerLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_linqServerModeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.Data.Linq.LinqServerModeSource Agrupacion_linqServerModeSource;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel Integrantes_xrLabel;
        private DevExpress.XtraReports.UI.CalculatedField DobleVinculo_calculatedField;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;


    }
}
