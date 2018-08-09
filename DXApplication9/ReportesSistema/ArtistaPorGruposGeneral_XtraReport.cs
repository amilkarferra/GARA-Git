using System;
using DevExpress.XtraSplashScreen;

namespace DXApplication9.ReportesSistema
{
    public partial class ArtistaPorGruposGeneralXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ArtistaPorGruposGeneralXtraReport()
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

        private void ArtistaPorGruposGeneral_XtraReport_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch (Exception)
            {
                SplashScreenManager.CloseForm();
            }
        }

    }
}
