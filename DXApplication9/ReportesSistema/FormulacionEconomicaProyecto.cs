using System;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class FormulacionEconomicaProyecto : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        public FormulacionEconomicaProyecto(Proyectos aProyectos)
        {
            ConfiguracionGeneral configuracion = AGlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            InitializeComponent();
            ParaElencoArtistico_xrLabel.Text += aProyectos.IngresoUnidadArtistica + " " + aProyectos.TipoMoneda.Abreviatura;
            ParaElArtista_xrLabel.Text += aProyectos.IngresoUnidadArtistica + " " + aProyectos.TipoMoneda.Abreviatura;
            ParaLaAgencia_xrLabel.Text += aProyectos.IngresoAgencia + " " + aProyectos.TipoMoneda.Abreviatura;
            ParaLaAgencia1_xrLabel.Text += aProyectos.IngresoAgencia + " " + aProyectos.TipoMoneda.Abreviatura;
            if (aProyectos.ParticipantesDeProyectos.Count>0)
            ParaCadaIntegrante_xrLabel.Text +=
               Decimal.Round((Convert.ToDecimal(aProyectos.IngresoUnidadArtistica / aProyectos.ParticipantesDeProyectos.Count)),2) + " " + aProyectos.TipoMoneda.Abreviatura;
            //NombreJefe_xrLabel.Text = _Configuracion.NombreDeJefeAgencia;
            //Cargo_xrLabel.Text = _Configuracion.CargoDeJefeDeAgencia;
            var firstOrDefault = aProyectos.Presentacion.FirstOrDefault();
            if (firstOrDefault != null)
                ValorDelContrato_xrLabel.Text += aProyectos.ValorDelContrato + " " + aProyectos.TipoMoneda.Abreviatura;
            ConformaPiedDeFirmas((int)Enumerados.Reportes.FormulacionEconomicaProyecto);
        }


        public void ConformaPiedDeFirmas(int identificadorReporte)
        {
            var reporte = AGlobalDataContext.Reportes.FirstOrDefault(c => c.IdentificadorReporte == identificadorReporte);
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
