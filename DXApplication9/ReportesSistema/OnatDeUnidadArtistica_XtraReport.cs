using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace DXApplication9.ReportesSistema
{
    public partial class OnatDeUnidadArtistica_XtraReport : XtraReport
    {
        public OnatDeUnidadArtistica_XtraReport(int agrupacionId, DateTime fechaFinal, DateTime fechaInicial, int tipoMonedaId)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(ReportesWaitForm));
            }
            catch
            {

                SplashScreenManager.CloseForm();
                SplashScreenManager.ShowForm(typeof(ReportesWaitForm));
            }

            InitializeComponent();       
            bindingSource1.DataSource = Agrupacion.GetOnatDeUnidadArtistica(agrupacionId, fechaFinal, fechaInicial, tipoMonedaId);
            var GlobalDataContext = new NegocioDataContext();
            Configuracion_linqServerModeSource.QueryableSource = GlobalDataContext.ConfiguracionGeneral;
            ConfiguracionGeneral configuracion = GlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            if (configuracion.LogoAgencia != null)
            {
                MemoryStream ms = new MemoryStream(configuracion.LogoAgencia);
                Bitmap imagenBitmap = new Bitmap(ms);
                xrPictureBox1.Image = imagenBitmap;
            }

            Titulo_xrRichText.Html= $"<center>Ingreso de unidad artística <br> Agrupacion: <b>{Agrupacion.GetAgrupacionById(agrupacionId).Nombre.ToUpper()}</b> <br> Período <b>{fechaInicial.ToShortDateString()} - {fechaFinal.ToShortDateString()}</b> <br> Moneda: <b>{TipoMoneda.GetMonedaById(tipoMonedaId).Abreviatura}</b></center>";
            Titulo_xrRichText.TextAlignment = TextAlignment.MiddleCenter;
            
            ExportOptions.Xls.SheetName= ExportOptions.Xlsx.SheetName = $"Onat {Agrupacion.GetAgrupacionById(agrupacionId).Nombre} {TipoMoneda.GetMonedaById(tipoMonedaId).Abreviatura}";
            
            string[] lineas = new string[4];
            lineas[0] = $"Dirección: {configuracion.DireccionEmpresa}";
            lineas[1] = $"Tel: {configuracion.TelefonosAgencia}";
            lineas[2] = $"Correo electrónico: {configuracion.CorreoElectronico} ";
            lineas[3] = $"Web: {configuracion.SitioWeb}";
            DatosContactoxrRichText.Lines = lineas;
        }

        private void GARAXtraReport_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch
            {

                //olvidalo
            }
        }

        private void GARAXtraReport_AfterPrint(object sender, System.EventArgs e)
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
