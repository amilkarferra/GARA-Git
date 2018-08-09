using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class ModeloDeViaje : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext _GlobalDataContext = new NegocioDataContext();
        //private ConfiguracionGeneral _configuracion = (new NegocioDataContext()).ConfiguracionGeneral.FirstOrDefault();

        public ModeloDeViaje(Proyectos aProyecto, bool aFirmaDeGerente = false)
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource =
                (new NegocioDataContext()).ParticipantesDeProyectos.Where(c => c.ProyectoId == aProyecto.ProyectoID)
                    .OrderBy(c => c.Artista.Nombre);
            //TextoCertifico_xrLabel.Text =
            //    string.Format(
            //        "Por este medio se hace constar que se presentó en la comisión de salida del Instituto Cubano de la Música el Proyecto de la agrupación: {0}, para su gira a {1} en el período comprendido desde el {2} hasta el {3}, con los siguientes integrantes:", aProyecto.Agrupacion.Nombre, aProyecto.Paises.NombrePais, aProyecto.FechaInicial.Value.ToString("D", CultureInfo.CreateSpecificCulture("es-ES")), aProyecto.FechaFinal.Value.ToString("D", CultureInfo.CreateSpecificCulture("es-ES")));
            if (string.IsNullOrEmpty(aProyecto.ResumenProyecto))
            {
                TextoCertifico_xrLabel.Text = "Usted debe generar el resumen del proyecto en el tab 4 Resumen del proyecto y luego guardar los cambios pendientes.";
            }
            else
            {
                TextoCertifico_xrLabel.Text = aProyecto.ResumenProyecto;
            }
           
            //AnnoActual_xrLabel.Text = (new NegocioDataContext()).ConfiguracionGeneral.FirstOrDefault().AnnoDeTrabajo.ToString();
            //ICMNombre_xrLabel.Text = _configuracion.NombreRepresentanteICM;
            //ICMCargo_xrLabel.Text = _configuracion.CargoRepresentanteInstituto;
            //PresidenteCargo_xrLabel.Visible = PresidenteNombre_xrLabel.Visible = !aFirmaDeGerente;
            //if (aFirmaDeGerente)
            //{
            //    ICMNombre_xrLabel.Text = _configuracion.NombreDeJefeAgencia;
            //    ICMCargo_xrLabel.Text = _configuracion.CargoDeJefeDeAgencia;

            //
            ConformaPiedDeFirmas((int)Enumerados.Reportes.ModeloDeViaje);
        }

        public void ConformaPiedDeFirmas(int identificadorReporte)
        {
            var reporte = _GlobalDataContext.Reportes.FirstOrDefault(c => c.IdentificadorReporte == identificadorReporte);
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


    }
}
