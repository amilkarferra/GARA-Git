using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class HojaFundamentacionXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private Proyectos AProyecto = null;
        private Enumerados.TipoProyecto ATipoProyecto;

        public HojaFundamentacionXtraReport(Guid aProyectoId, bool habilitacionPasaporte = false)
        {

            InitializeComponent();


            ProyectolinqServerModeSource.QueryableSource = (AGlobalDataContext.Proyectos.Where(c => c.ProyectoID == aProyectoId));

            AProyecto = AGlobalDataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == aProyectoId);
            ATipoProyecto = habilitacionPasaporte
                ? Enumerados.TipoProyecto.TramiteMigratorio
                : AProyecto.EnumTipoProyecto;
            var configuracion = AGlobalDataContext.ConfiguracionGeneral.FirstOrDefault();

            string[] dirigidoALines = new string[3];
            dirigidoALines[0] = string.Format("Atte: {0}", configuracion.Destinatario_O_DirigidoA);
            dirigidoALines[1] = configuracion.CargoDestinatario.Trim();
            dirigidoALines[2] = configuracion.EmpresaDestinatario.Trim();
            DirigidoA_xrRichText.Lines = dirigidoALines;

            string[] deLines = new string[3];
            deLines[0] = string.Format("De: {0}", configuracion.NombreDeJefeAgencia);
            deLines[1] = string.Format(configuracion.CargoDeJefeDeAgencia);
            deLines[2] = string.Format(configuracion.Agencia);
            De_xrRichText.Lines = deLines;

            FechaConfeccion_xrRichText.Text = string.Format("{0}, {1} ", "La Habana", (AProyecto.FechaConfeccion).ToString("D", CultureInfo.CreateSpecificCulture("es-ES")));
            //ConfigurarTextoFundamentacion();
            CoCargo_DexrRichText.Text = string.Format("Co. {0}:", configuracion.CargoDestinatario);
            string causa = habilitacionPasaporte ? AProyecto.CausaHabilitacionPasaporte : AProyecto.CausaDeProyecto.Trim();

            CausaDe_xrRichText.Text = causa;
            //NombreJefeGerComerc_xrRichText.Text = _Configuracion.NombreDeJefeAgencia.Trim();
            //CargoJefeComercial_xrRichText.Text = _Configuracion.CargoDeJefeDeAgencia.Trim(); Agencia_xrRichText.Text = _Configuracion.Agencia;
            TextoNotificacion_xrRichText.Text = ConformaTextoFundamentacionCabecera(habilitacionPasaporte);
            ConformaPiedDeFirmas((int)Enumerados.Reportes.HojaFundamentacionXtraReport);


            //Encabezado
            //Configuracion_objectDataSource.DataSource = _GlobalDataContext.ConfiguracionGeneral;
            //ConfiguracionGeneral _Configuracion = (new NegocioDataContext()).ConfiguracionGeneral.FirstOrDefault();
            if (configuracion.LogoAgencia != null)
            {
                MemoryStream ms = new MemoryStream(configuracion.LogoAgencia);
                Bitmap imagenBitmap = new Bitmap(ms);
                xrPictureBox1.Image = imagenBitmap;
            }
            string[] lineas = new string[4];
            lineas[0] = string.Format("Dirección: {0}", configuracion.DireccionEmpresa);
            lineas[1] = string.Format("Tel: {0}",configuracion.TelefonosAgencia);
            lineas[2] = string.Format("Correo electrónico: {0} ",configuracion.CorreoElectronico);
            lineas[3] = string.Format("Web: {0}",configuracion.SitioWeb);DatosContactoxrRichText.Lines = lineas;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // var _ParticipanteActual = (ParticipantesDeProyectos)GetCurrentRow();
            //  NombreParticipante_xrRichText.Text = 
        }
        private void ConfigurarTextoFundamentacion()
        {
            //if (_Proyecto.TipoProyecto.Trim() == Enumerados.TipoProyecto.TramiteMigratorio.ToString().Trim())
            //{

            //    if (_Proyecto.ParticipantesDeProyectos.Count() > 1){
            //        TextoNotificacion_xrRichText.Text = string.Format("Ref: {0}",
            //        "Fundamentación para ");
            //        Participantes_Detail.Visible = true;//    }
            //    else{
            //        Participantes_Detail.Visible = false;
            //        var _ParticipanteDeProyecto = _Proyecto.ParticipantesDeProyectos.FirstOrDefault();
            //        var _TipoTramite = Utils.SplitUpperCase(_ParticipanteDeProyecto.TipoTramiteMigratorio);
            //        //if(_TipoTramite==Enumerados.TipoProyectoMigratorio.Prorroga.ToString().)
            //        TextoNotificacion_xrRichText.Text = string.Format("{0} {1} a favor de {2} {3} {4}, {5} {6}.",
            //            "Fundamentacion para ", _TipoTramite, _ParticipanteDeProyecto.Nombre.Trim(), _ParticipanteDeProyecto.PrimerApellido.Trim(), _ParticipanteDeProyecto.SegundoApellido.Trim(), "Integrante de la Agrupación ", _Proyecto.Agrupacion.Nombre.Trim()).ToUpper();

            //    }
            //}
        }
        private string ConformaTextoFundamentacionCabecera(bool habilitacionDePasaporte)
        {
            // if (Integrantes_gridView.DataRowCount < 1) return;
            string causa = "Fundamentación para  ";
            //var _TipoProyecto = _Proyecto.EnumTipoProyecto;
            if (habilitacionDePasaporte) ATipoProyecto = Enumerados.TipoProyecto.TramiteMigratorio;
            switch (ATipoProyecto)
            {
                case Enumerados.TipoProyecto.TramiteMigratorio:
                    causa += "  la necesidad de realizar";
                    //var Integrantes = _Proyecto.ParticipantesDeProyectos.ToList();
                    if (AProyecto.TieneProrrogas)
                    {
                        causa += " prorrogas";
                        if (AProyecto.TieneConfeccionPasaportesOficiales ||
                            AProyecto.TieneConfeccionPasaportesOrdinarios)
                            causa += " y";
                    }

                    if (AProyecto.TieneConfeccionPasaportesOrdinarios)
                    {
                        causa += " confección de pasaportes Ordinarios";
                        if (AProyecto.TieneConfeccionPasaportesOficiales)
                            causa += " y";

                    }
                    if (AProyecto.TieneConfeccionPasaportesOficiales)
                    {
                        causa += " confección de pasaportes Oficiales";
                    }

                    causa += string.Format(" de integrantes de la agrupación {0}", AProyecto.Agrupacion.Nombre);

                    return causa;

                case Enumerados.TipoProyecto.Comercial:
                    causa += string.Format("Notificacion de salida de la orquesta {0} para {1}",
                        AProyecto.Agrupacion.Nombre, AProyecto.Paises.NombrePais);
                    return causa;

                case Enumerados.TipoProyecto.Promocional:
                    causa += string.Format("Notificacion de salida de la orquesta {0} para {1} a una gira con caracter promocional.",
                      AProyecto.Agrupacion.Nombre, AProyecto.Paises.NombrePais);
                    return causa;

                default:
                    return "";
            }

        }

        public void ConformaPiedDeFirmas(int identificadorReporte)
        {
            var reporte = AGlobalDataContext.Reportes.FirstOrDefault(c => c.IdentificadorReporte == identificadorReporte);
            //Izquierda
            if (reporte.PersonasQueFirmanReporte == null)
            {
                FirmaIzq_xrTable.Visible = false;
            }
            else
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
