using System;
using System.Linq;
using DevExpress.XtraSplashScreen;

namespace DXApplication9.ReportesSistema
{
    public partial class CatalogoXtraReport : GaraXtraReport
    {
        public CatalogoXtraReport()
        {

            InitializeComponent();
            
            try
            {
                SplashScreenManager.ShowForm(typeof(ReportesWaitForm), true, true);
            }
            catch (Exception)
            {

                SplashScreenManager.CloseForm();
                SplashScreenManager.ShowForm(typeof(ReportesWaitForm), true, true);
            }
            Agrupacion_linqServerModeSource.QueryableSource = new NegocioDataContext().Agrupacion.Where(c => c.PerteneceACatalogo);
            ConformaPiedDeFirmas((int)Enumerados.Reportes.CatalogoXtraReport);
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var agrupacion = (Agrupacion)GetCurrentRow();
            var integrantes = agrupacion.AgrupacionDeArtista.Where(c => c.FechaBaja == null);
            Integrantes_xrLabel.Text = integrantes.Count().ToString();
        }

        private void CatalogoXtraReport_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();

            }
            catch
            {

                //donothing
            }
        }



    }
}
