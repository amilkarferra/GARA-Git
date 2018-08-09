using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using DevExpress.Data.Linq;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraReports.UI;
using System.Linq;
using DevExpress.XtraSplashScreen;
using DXApplication9;
using Microsoft.SqlServer.Server;

namespace DXApplication9.Reportes
{
    public partial class HojaNotificacionICMXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext GlobalDataContext = new NegocioDataContext();
        private Proyectos _Proyecto = null;

        public HojaNotificacionICMXtraReport(Guid aProyectoId)
        {
            InitializeComponent();
            ProyectolinqServerModeSource.QueryableSource = (GlobalDataContext.Proyectos.Where(c => c.ProyectoID == aProyectoId));
            _Proyecto = GlobalDataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == aProyectoId);
            var _Configuracion = GlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            DirigidoA_xrRichText.Text += DirigidoA_xrRichText1.Text = "Comisión de Salida ICM";
            FechaConfeccion_xrRichText.Text = FechaConfeccion_xrRichText1.Text = string.Format("{0}, {1} ", "La Habana", (_Proyecto.FechaConfeccion).ToString("D", CultureInfo.CreateSpecificCulture("es-ES")));
            ConfigurarTextoNotificacion();
            NombreJefeGerComerc_xrRichText.Text = NombreJefeGerComerc_xrRichText1.Text = _Configuracion.NombreDeJefeAgencia.Trim();
            CargoJefeComercial_xrRichText.Text = CargoJefeComercial_xrRichText1.Text = _Configuracion.CargoDeJefeDeAgencia.Trim();
            Agencia_xrRichText.Text = Agencia_xrRichText1.Text = _Configuracion.Agencia;

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


        }
        private void ConfigurarTextoNotificacion()
        {
            TextoNotificacion_xrRichText.Text = TextoNotificacion_xrRichText1.Text = string.Format("{0} {1} a {2} ",
             "Por medio del presente documento, se notifica proyecto de salida de ", _Proyecto.Agrupacion.Nombre.TipoOracion(), _Proyecto.Paises.NombrePais);
        }

        private void HojaNotificacionICMXtraReport_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            //try
            //{
            //    SplashScreenManager.CloseForm();
            //}
            //catch (Exception)
            //{
            //    return;
            //}
            
        }

    }

}
