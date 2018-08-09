using System.Drawing;
using DevExpress.XtraReports.UI;
using DirectionMode = DevExpress.XtraPrinting.Drawing.DirectionMode;

namespace DXApplication9.ReportesSistema
{
    public partial class ImageFullPageXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ImageFullPageXtraReport()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            SetTextWatermark(this);
        }
        public void SetTextWatermark(XtraReport report)
        {
            // Adjust text watermark settings. 
            report.Watermark.Text = "SUSTITUIR POR ORIGINAL";
            report.Watermark.TextDirection = (DirectionMode) DevExpress.Charts.Model.DirectionMode.Counterclockwise;
            report.Watermark.Font = new Font(report.Watermark.Font.FontFamily, 40);
            report.Watermark.ForeColor = Color.DodgerBlue;
            report.Watermark.TextTransparency = 150;
            report.Watermark.ShowBehind = false;
            report.Watermark.PageRange = "1,3-5";
        }



    }
}
