namespace DXApplication9.ReportesSistema
{
    partial class ListadoIntegranteFirmaGerente
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoIntegranteFirmaGerente));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.Integrante_xrLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.ListadoIntegrantes_xrLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.DatosContactoxrRichText = new DevExpress.XtraReports.UI.XRRichText();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PieFirmaGerente_xrLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.linqServerModeSource1 = new DevExpress.Data.Linq.LinqServerModeSource();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.DatosContactoxrRichText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Integrante_xrLabel});
            this.Detail.HeightF = 26.25002F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // Integrante_xrLabel
            // 
            this.Integrante_xrLabel.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Integrante_xrLabel.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Integrante_xrLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Integrante_xrLabel.Name = "Integrante_xrLabel";
            this.Integrante_xrLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Integrante_xrLabel.SizeF = new System.Drawing.SizeF(339.5833F, 26.25002F);
            this.Integrante_xrLabel.StylePriority.UseBorders = false;
            this.Integrante_xrLabel.StylePriority.UseFont = false;
            this.Integrante_xrLabel.Text = "Integrante_xrLabel";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 85F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ListadoIntegrantes_xrLabel
            // 
            this.ListadoIntegrantes_xrLabel.Font = new System.Drawing.Font("Arial", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ListadoIntegrantes_xrLabel.LocationFloat = new DevExpress.Utils.PointFloat(75F, 177.4167F);
            this.ListadoIntegrantes_xrLabel.Name = "ListadoIntegrantes_xrLabel";
            this.ListadoIntegrantes_xrLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ListadoIntegrantes_xrLabel.SizeF = new System.Drawing.SizeF(523.9583F, 23F);
            this.ListadoIntegrantes_xrLabel.StylePriority.UseFont = false;
            this.ListadoIntegrantes_xrLabel.StylePriority.UseTextAlignment = false;
            this.ListadoIntegrantes_xrLabel.Text = "LISTADO DE INTEGRANTES ";
            // 
            // DatosContactoxrRichText
            // 
            this.DatosContactoxrRichText.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.DatosContactoxrRichText.LocationFloat = new DevExpress.Utils.PointFloat(353.1248F, 0F);
            this.DatosContactoxrRichText.Name = "DatosContactoxrRichText";
            this.DatosContactoxrRichText.SerializableRtfString = resources.GetString("DatosContactoxrRichText.SerializableRtfString");
            this.DatosContactoxrRichText.SizeF = new System.Drawing.SizeF(286.875F, 91.87498F);
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(132.2917F, 101.8749F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderWidth = 2F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 101.8749F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(639.9999F, 22.99999F);
            this.xrLine1.StylePriority.UseBorderWidth = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 200F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PieFirmaGerente_xrLabel
            // 
            this.PieFirmaGerente_xrLabel.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.PieFirmaGerente_xrLabel.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.PieFirmaGerente_xrLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31.83333F);
            this.PieFirmaGerente_xrLabel.Multiline = true;
            this.PieFirmaGerente_xrLabel.Name = "PieFirmaGerente_xrLabel";
            this.PieFirmaGerente_xrLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PieFirmaGerente_xrLabel.SizeF = new System.Drawing.SizeF(221.875F, 68.16667F);
            this.PieFirmaGerente_xrLabel.StylePriority.UseBorders = false;
            this.PieFirmaGerente_xrLabel.StylePriority.UseFont = false;
            this.PieFirmaGerente_xrLabel.Text = "PieFirmaGerente_xrLabel";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DXApplication9.NegocioDataContext);
            // 
            // linqServerModeSource1
            // 
            this.linqServerModeSource1.ElementType = typeof(DXApplication9.ParticipantesDeProyectos);
            this.linqServerModeSource1.KeyExpression = "[ParticipanteID]";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PieFirmaGerente_xrLabel});
            this.ReportFooter.HeightF = 100F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.ListadoIntegrantes_xrLabel,
            this.DatosContactoxrRichText,
            this.xrLine1});
            this.PageHeader.HeightF = 210.4167F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ListadoIntegranteFirmaGerente
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.PageHeader});
            this.DataMember = "Proyectos.ParticipantesDeProyectos";
            this.DataSource = this.linqServerModeSource1;
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 85, 200);
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.DatosContactoxrRichText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRRichText DatosContactoxrRichText;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraReports.UI.XRLabel Integrante_xrLabel;
        private DevExpress.XtraReports.UI.XRLabel PieFirmaGerente_xrLabel;
        private DevExpress.Data.Linq.LinqServerModeSource linqServerModeSource1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel ListadoIntegrantes_xrLabel;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
    }
}
