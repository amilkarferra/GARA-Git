using System;
using DevExpress.XtraSplashScreen;

namespace DXApplication9.ReportesSistema
{
    public partial class ExportacionesXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ExportacionesXtraReport()
        {
            try
            {
                SplashScreenManager.CloseForm();

            }
            catch
            {
                // ignored
            }
            SplashScreenManager.ShowForm(typeof(ReportesWaitForm));
            InitializeComponent();
        }

        private void ExportacionesXtraReport_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
