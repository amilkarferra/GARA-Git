using System;
using System.Globalization;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class TablaCertificoXtraReportV2 : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private Proyectos AGlobalProyecto;
        private Agrupacion AAgrupacion;

        public TablaCertificoXtraReportV2(Proyectos aProyecto)
        {
            AGlobalProyecto = aProyecto;
            AAgrupacion = AGlobalProyecto.Agrupacion;
            InitializeComponent();
            
            //  Landscape = true;
            Integrantes_linqServerModeSource.QueryableSource =
                AGlobalDataContext.ParticipantesDeProyectos.Where(c => c.ProyectoId == aProyecto.ProyectoID && !c.EsInvitado).Select(c => c.Artista).OrderBy(c => c.NomencladorCargo.PesoDeCargo).ThenBy(c => c.Nombre);
            ConformaTextosGenerales(aProyecto.Agrupacion, aProyecto);
            ConformaPiedDeFirmas((int)Enumerados.Reportes.TablaDeCertificos);
            #region Conformacion de Texto de Viajan como invitado
            IQueryable<ParticipantesDeProyectos> invitados =
                   AGlobalDataContext.ParticipantesDeProyectos.Where(c => c.ProyectoId == aProyecto.ProyectoID && c.EsInvitado);
            int cantInv = invitados.Count();
            if (invitados.Count() > 0)
            {
                string textoViajanComo = string.Format("{0} como {1} ", cantInv > 1 ? "Viajan" : "Viaja", cantInv > 1 ? "invitados" : "invitado");
                foreach (var invitado in invitados)
                { if (invitado.NombreCompleto != null) if (invitado.Artista.Organismo != null) textoViajanComo += string.Format(", {0} de {1}", invitado.NombreCompleto, invitado.Artista.Organismo.Trim().TipoFrase()); } var textoFinal = textoViajanComo.Acabado();
                ViajanComo_xrRichText.Text = textoFinal;
            }
            #endregion
        }


        public TablaCertificoXtraReportV2(Agrupacion agrupacion)
        {
            InitializeComponent();
            Integrantes_linqServerModeSource.QueryableSource =
                AGlobalDataContext.AgrupacionDeArtista.Where(c => c.AgrupacionId == agrupacion.AgrupacionID && c.FechaBaja == null).Select(c => c.Artista).OrderBy(c => c.NomencladorCargo.PesoDeCargo).ThenBy(c => c.Nombre);
            ConformaTextosGenerales(agrupacion);
            ConformaPiedDeFirmas((int)Enumerados.Reportes.TablaDeCertificos);
        }

        public TablaCertificoXtraReportV2(int[] integrantes, int agrupacionId)
        {
            InitializeComponent();

           AAgrupacion= AGlobalDataContext.Agrupacion.FirstOrDefault(c => c.AgrupacionID == agrupacionId);
            CorresScriptCompletaCargoArtistas(integrantes,agrupacionId);
            Integrantes_linqServerModeSource.QueryableSource =
                AGlobalDataContext.Artista.Where(c => integrantes.Contains(c.ArtistaID)).OrderBy(c => c.NomencladorCargo.PesoDeCargo).ThenBy(c => c.Nombre);
            ConformaTextosGenerales(AAgrupacion);
            ConformaPiedDeFirmas((int)Enumerados.Reportes.TablaDeCertificos);
        }

        private void CorresScriptCompletaCargoArtistas(int[] integrantes, int agrupacionId)
        {
            var artistas = AGlobalDataContext.Artista.Where(c => integrantes.Contains(c.ArtistaID));
            var agrupacion = AGlobalDataContext.Agrupacion.FirstOrDefault(c => c.AgrupacionID == agrupacionId);
            foreach (var artista in artistas)
            {
                var agrupacionDeArtista =
                    AGlobalDataContext.AgrupacionDeArtista.FirstOrDefault(
                        c => c.ArtistaId == artista.ArtistaID && c.AgrupacionId == agrupacionId);
                if (agrupacionDeArtista != null)
                {
                    if (!string.IsNullOrEmpty(agrupacionDeArtista.AbrevDesempenno))
                    {
                        artista.AbrevDesempenno = agrupacionDeArtista.AbrevDesempenno;
                        AGlobalDataContext.SubmitChanges();
                    }
                }
            }

            ConformaTextosGenerales(agrupacion);
        }

        private void ConformaTextosGenerales(Agrupacion agrupacion, Proyectos aProyecto = null)
        {
            PorMedio_xrRichText.Text =
            string.Format("{0} {1} tienen el estatus laboral que a continuación se acredita: ", "Por medio de la Presente certificamos que los integrantes de la agrupación ", agrupacion.Nombre);
            if (aProyecto != null) ParaQueConste_xrRichText.Text = string.Format("Y para que así conste firman la presente el  {0} ", (DateTime.Today).ToString("D", CultureInfo.CreateSpecificCulture("es-ES")));
            Configuracion_linqServerModeSource.QueryableSource = AGlobalDataContext.ConfiguracionGeneral;
            // NombreEspecialista_xrLabel.Text = LoginHelper.UsuarioRegistrado.NombreCompleto;

        }


        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var artista = (Artista)GetCurrentRow();
            if (artista == null) return;
            if (artista.FechaIngresoSector != null)
                FechaEntradaSector_xrLabel.Text = artista.FechaIngresoSector <= DateTime.MinValue
                    ? " - "
                    : ((DateTime) artista.FechaIngresoSector).ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            var primerVinculo = artista.PrimerVinculoAgrupacionDeArtista;
            if (primerVinculo != null)
            {
                Ocupacion_xrLabel.Text = primerVinculo.AbrevDesempenno;
            }
            else
            {
                var agrupacionDeArtista = artista.AgrupacionDeArtista.FirstOrDefault(
                    c => AGlobalProyecto != null && (c.AgrupacionId ==AAgrupacion.AgrupacionID && c.ArtistaId == artista.ArtistaID));
                if (agrupacionDeArtista != null)
                    Ocupacion_xrLabel.Text =
                        agrupacionDeArtista
                            .AbrevDesempenno;
            }
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


 