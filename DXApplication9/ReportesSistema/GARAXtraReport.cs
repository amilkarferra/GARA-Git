using System.Drawing;
using System.IO;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class GaraXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public NegocioDataContext GlobalDataContext = new NegocioDataContext();
        public int ReporteIdentificador = 0;
        public GaraXtraReport()
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

            Configuracion_linqServerModeSource.QueryableSource = GlobalDataContext.ConfiguracionGeneral;
            ConfiguracionGeneral configuracion = GlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            if (configuracion.LogoAgencia != null)
            {
                MemoryStream ms = new MemoryStream(configuracion.LogoAgencia);
                Bitmap imagenBitmap = new Bitmap(ms);
                xrPictureBox1.Image = imagenBitmap;
            }

            string[] lineas = new string[4];
            lineas[0] = $"Dirección: {configuracion.DireccionEmpresa}";
            lineas[1] = $"Tel: {configuracion.TelefonosAgencia}";
            lineas[2] = $"Correo electrónico: {configuracion.CorreoElectronico} ";
            lineas[3] = $"Web: {configuracion.SitioWeb}";
            DatosContactoxrRichText.Lines = lineas;
        }


        public void ConformaPiedDeFirmas(int identificadorReporte)
        {
            var reporte = GlobalDataContext.Reportes.FirstOrDefault(c => c.IdentificadorReporte == identificadorReporte);
            if (reporte == null) return;
            //Izquierda
            if (reporte.PersonasQueFirmanReporte != null)
            {


                if (reporte.PersonasQueFirmanReporte.EsUsuarioRegistrado)
                {
                    nombreIxq_xrTableCell.Text = LoginHelper.UsuarioRegistrado.NombreCompleto;
                    CargoIzq_xrTableCell.Text = LoginHelper.UsuarioRegistrado.Cargo;
                    AgenciaIzq_xrTableCell.Text = reporte.PersonasQueFirmanReporte.CentroQuePertenece;
                }

                else
                {
                    nombreIxq_xrTableCell.Text = reporte.PersonasQueFirmanReporte.NombreCompleto;
                    CargoIzq_xrTableCell.Text = reporte.PersonasQueFirmanReporte.Cargo;
                    AgenciaIzq_xrTableCell.Text = reporte.PersonasQueFirmanReporte.CentroQuePertenece;
                }
            }
            else
            {
                FirmaIzq_xrTable.Visible = false;
            }
            //Centro
            if (reporte.PersonasQueFirmanReporte1 != null)
            {
                if (reporte.PersonasQueFirmanReporte1.EsUsuarioRegistrado)
                {
                    NombreCentro_xrTableCell.Text = LoginHelper.UsuarioRegistrado.NombreCompleto;
                    cargoCentro_xrTableCell.Text = LoginHelper.UsuarioRegistrado.Cargo;
                    if (reporte.PersonasQueFirmanReporte != null)
                        AgenciaCentro_xrTableCell.Text = reporte.PersonasQueFirmanReporte.CentroQuePertenece;
                }
                else
                {
                    NombreCentro_xrTableCell.Text = reporte.PersonasQueFirmanReporte1.NombreCompleto;
                    cargoCentro_xrTableCell.Text = reporte.PersonasQueFirmanReporte1.Cargo;
                    AgenciaCentro_xrTableCell.Text = reporte.PersonasQueFirmanReporte1.CentroQuePertenece;
                }
            }
            else
            {
                FirmCentro_xrTable.Visible = false;
            }

            //Derecha
            if (reporte.PersonasQueFirmanReporte2 != null)
            {
                if (reporte.PersonasQueFirmanReporte2.EsUsuarioRegistrado)
                {
                    NombreDer_xrTableCell.Text = LoginHelper.UsuarioRegistrado.NombreCompleto;
                    CargoDer_xrTableCell.Text = LoginHelper.UsuarioRegistrado.Cargo;
                    if (reporte.PersonasQueFirmanReporte != null)
                        AgenciaDer_xrTableCell.Text = reporte.PersonasQueFirmanReporte.CentroQuePertenece;
                }
                else
                {
                    NombreDer_xrTableCell.Text = reporte.PersonasQueFirmanReporte2.NombreCompleto;
                    CargoDer_xrTableCell.Text = reporte.PersonasQueFirmanReporte2.Cargo;
                    AgenciaDer_xrTableCell.Text = reporte.PersonasQueFirmanReporte2.CentroQuePertenece;
                }
            }
            else
            {
                FirmDer_xrTable.Visible = false;
            }
        }

        /// <summary>
        /// Para insertar una cantidad determinada de filas vacias a una columna y poder llenar 
        /// una pagina.
        /// <Author>Amilkar Ferrá</Author>
        /// </summary>
        /// <param name="aTable"></param>
        /// <param name="aNumberOfRows"></param>
        public void AddEmptyRowsToTable(XRTable aTable, int aNumberOfRows)
        {
            for (int i = 0; i < aNumberOfRows; i++)
            {
                aTable.Rows.Add(new XRTableRow());
            }

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

        public void OcultaFirmas()
        {
            PageFooter.Visible = false;
        }
    }
}
