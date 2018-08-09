using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Commands.Internal;
using DXApplication9.ReportesSistema;
using DXApplication9.Code;
using MessageBox = System.Windows.MessageBox;

namespace DXApplication9
{
    public partial class Proyectos
    {
        public Enumerados.TipoProyecto EnumTipoProyecto
        {
            get
            {
                var tipo = (Enumerados.TipoProyecto)Enum.Parse(typeof (Enumerados.TipoProyecto), TipoProyectoId.ToString());
                return tipo;

            }
        }

        //public string TipoMoneda
        //{
        //    get
        //    {
        //        var _FirstOrDefault = Presentacion.FirstOrDefault();
        //        if (_FirstOrDefault != null)
        //            return _FirstOrDefault.TipoMoneda.Abreviatura;
        //        return "";
        //    }
        //}

        public object Empresarios
        {
            get { return ControlClientes.Empresarios; }
        }


        public bool EsTramiteMigratorio
        {
            get
            {
                bool _bool = TipoProyectoId == Convert.ToInt32(Enumerados.TipoProyecto.TramiteMigratorio);
                return _bool;

            }
        }

        /// <summary>
        /// Devuelve true si es un proyecto comercial o promocional que lleva habilitación.
        /// </summary>
        //public bool EsHabilitacionDePasaporte
        //{
        //    get
        //    {
        //        bool esHabilitacion = TipoProyecto.Trim() == Enumerados.TipoProyecto..ToString().Trim();
        //        return esComercial;

        //    }
        //}

        /// <summary>
        /// Si el proyecto es de tramite migratorio y tiene prorrogas devuelve true
        /// </summary>
        public bool TieneProrrogas
        {
            get
            {
                bool tieneProrrogas = ParticipantesDeProyectos.Any(
                    c =>
                        c.TipoTramiteMigratorio != null &&
                        c.TipoTramiteMigratorio == (int) Enumerados.TipoTramiteMigratorio.Prorroga);
                return tieneProrrogas;
            }
        }

        public bool TieneConfeccionPasaportesOrdinarios
        {
            get
            {
                bool tienePassOrdinarios = ParticipantesDeProyectos.Any(
                    c =>
                        c.TipoTramiteMigratorio != null &&
                        c.TipoTramiteMigratorio == (int) Enumerados.TipoTramiteMigratorio.ConfeccionDePasaporteOrdinario);
                return tienePassOrdinarios;
            }
        }


        public bool TieneConfeccionPasaportesOficiales
        {
            get
            {
                bool tienePassOficiales = ParticipantesDeProyectos.Any(
                    c =>
                        c.TipoTramiteMigratorio != null &&
                        c.TipoTramiteMigratorio == (int) Enumerados.TipoTramiteMigratorio.ConfeccionDePasaporteOficial);
                return tienePassOficiales;
            }
        }

        public string ConsecutivoString
        {
            get
            {
                ConfiguracionGeneral configuracion =
                    DynamicQueryable.FirstOrDefault(new NegocioDataContext().ConfiguracionGeneral);
                return string.Format("{0}/{1}", Consecutivo, configuracion.AnnoDeTrabajo);
            }
        }

        public string ObservacionProyecto
        {
            get
            {
                try
                {
                    var firstOrDefault =
                        new NegocioDataContext().Presentacion.FirstOrDefault(c => c.ProyectoId == ProyectoID);
                    if (firstOrDefault != null)
                    {
                        string observacion =
                            String.Format(
                                "La Agrupación {0} ha sido invitada por {1}, en condición de {2} de la empresa {3} ({13}) " +
                                "a propósito de una {4} en  {5} desde el {6} hasta el {7}, dicha " +
                                "empresa asume {8} y paga un total de cachet {9} {10}, por {11} presentaciones. " +
                                "Nuestra agencia recibe {12} {10} de ingreso en la presente acción. La unidad Artística viajará con pasaporte {14}.",
                                Agrupacion.Nombre,
                                ControlClientes.Representante, ControlClientes.CargoRepresentante,
                                ControlClientes.NombreDeEntidad,
                                MotivoDeInvitacion, Paises.NombrePais, FechaInicial.Value.ToLongDateString(),
                                FechaFinal.Value.ToLongDateString(),
                                EmpresarioAsume, IngresoUnidadArtistica, firstOrDefault.TipoMoneda.Abreviatura,
                                Presentacion.Sum(c => c.Cantidad), IngresoAgencia,
                                ControlClientes.Empresarios.ObjetoSocial, TipoPasaporteString);
                        return observacion;
                    }

                    return "Por favor inserte al menos una presentación de la gira para poder generar este resumen";

                }
                catch (Exception e)
                {

                    return String.Format("Error Genrando el resumen, el error es -{0}", e.Message);
                }

                return String.Empty;}

        }

        public bool EsComercial
        {
            get { return TipoProyectoId == Convert.ToInt32(Enumerados.TipoProyecto.Comercial); }
        }

        public bool EsPromocional
        {
            get { return TipoProyectoId == Convert.ToInt32(Enumerados.TipoProyecto.Promocional); }
        }

        public bool EsProyectoNacional
        {
            get { return TipoProyectoId == Convert.ToInt32(Enumerados.TipoProyecto.ProyectoNacional); }
        }

        public bool EsIntercambio
        {
            get { return TipoProyectoId == Convert.ToInt32(Enumerados.TipoProyecto.IntercambioCultural); }
            
        }

        /// <summary>
        /// Devuelve un texto de fundamentacion para tramites migratorios
        /// </summary>
        /// <param name="muestroDesempeños">true-Muestra los desempeños de los integrantes</param>
        /// <returns></returns>
        public string GetTextoFundamentacionTramitesMigratorios(bool muestroDesempeños)
        {

            try
            {

                var tipoTramites =
                    ParticipantesDeProyectos.Where(c => c.TipoTramiteMigratorio != null)
                        .DistinctBy(c => c.TipoTramiteMigratorio)
                        .Select(c => c.TipoTramiteMigratorio).ToArray();
                string cadena = String.Empty;
                for (int j = 0; j < tipoTramites.Count(); j++)
                {
                    var tipoTramite = tipoTramites[j];
                    if (j != 0) cadena += " y ";
                    //1er tramite
                    var participantes =
                        ParticipantesDeProyectos.Where(c => c.TipoTramiteMigratorio == tipoTramite).ToArray();
                    var tramite = (Enumerados.TipoTramiteMigratorio) tipoTramite;
                    cadena += string.Format("{0} de: ", tramite.StringValue());
                    for (int i = 0; i < participantes.Count(); i++)
                    {
                        var participante = participantes[i];
                        if (i == participantes.Count() - 1 && i != 0) cadena += "y de ";
                        cadena += string.Format("{0} {1} {2}", participante.NombreCompleto,
                            muestroDesempeños ? " - " + participante.Desempenno : string.Empty,
                            i == tipoTramites.Count() - 1 ? ". " : ", ");
                    }
                }
                //string prorrogas = String.Empty;
                //string confeccionOrdiarios = String.Empty;//string confeccionOficiales = String.Empty;
                //if (TieneProrrogas)
                //{
                //    prorrogas += " Confección de Prorrogas de: ";
                //}
                //if (TieneConfeccionPasaportesOrdinarios)
                //    confeccionOrdiarios += " Confección de Pasaportes Ordinarios de: ";
                //if (TieneConfeccionPasaportesOficiales)
                //    confeccionOficiales += " Confección de Pasaportes Oficiales de: ";

                //var participantes = ParticipantesDeProyectos;
                //foreach (var participante in participantes)
                //{
                //    if (participante.TipoTramiteMigratorio != null)
                //        switch (participante.TipoTramiteMigratorio)
                //        {
                //            case (int)Enumerados.TipoTramiteMigratorio.Prorroga:
                //                {
                //                    prorrogas += string.Format("{0}{1},", participante.NombreCompleto,
                //                        muestroDesempeños ? "-" + participante.Artista.AbrevDesempenno : string.Empty);
                //                    break;
                //                }
                //            case (int)Enumerados.TipoTramiteMigratorio.ConfeccionDePasaporteOrdinario:
                //                {
                //                    confeccionOrdiarios += string.Format("{0}{1},", participante.NombreCompleto,
                //                    muestroDesempeños ? "-" + participante.Artista.AbrevDesempenno : string.Empty);
                //                    break;

                //                }
                //            case (int)Enumerados.TipoTramiteMigratorio.ConfeccionDePasaporteOficial:
                //                {
                //                    confeccionOficiales += string.Format("{0}{1},", participante.NombreCompleto,
                //                    muestroDesempeños ? "-" + participante.Artista.AbrevDesempenno : string.Empty);
                //                    break;
                //                }
                //        };
                //}
                //prorrogas = prorrogas.Acabado();
                //confeccionOrdiarios = confeccionOrdiarios.Acabado();
                //confeccionOficiales = confeccionOficiales.Acabado();
                //return String.Format("{0},{1},{2}", prorrogas, confeccionOrdiarios, confeccionOficiales).Acabado();
                return cadena;
            }
            catch (Exception)
            {

                return String.Empty;
            }
        }

        public void MostrarReporteFundamentacion(bool anHabillitacionDePasaporte = false)
        {
            Proyectos proyectos = (new NegocioDataContext().Proyectos.FirstOrDefault(c => c.ProyectoID == ProyectoID));
            XtraReport hojaNotificacionXtra = new XtraReport();
            hojaNotificacionXtra.CreateDocument();
            HojaFundamentacionXtraReport hojaFundamentacionXtra = new HojaFundamentacionXtraReport(
                proyectos.ProyectoID, anHabillitacionDePasaporte);
            hojaFundamentacionXtra.CreateDocument();
            PlanillaSalida salida = new PlanillaSalida(proyectos, anHabillitacionDePasaporte);
            salida.CreateDocument();
            hojaNotificacionXtra.Pages.AddRange(hojaFundamentacionXtra.Pages);
            hojaNotificacionXtra.Pages.AddRange(salida.Pages);
            if (
                ParticipantesDeProyectos.Any(
                    c => c.TipoParticipante == Enumerados.TipoParticipante.Integrante.ToString()))
            {
                TablaCertificoXtraReportV2 tablaCertifico = new TablaCertificoXtraReportV2(this);
                tablaCertifico.CreateDocument();
                hojaNotificacionXtra.Pages.AddRange(tablaCertifico.Pages);
            }
            //hojaNotificacionXtra.Pages.AddRange(GetCartaDeInvitacion(true).Pages);
            //var documentosPages = GetDocumentosDeInvitados(false).Pages;
            //hojaNotificacionXtra.Pages.AddRange(documentosPages);
            hojaNotificacionXtra.ShowRibbonPreviewDialog();

            //List<ImageFullPageXtraReport> _CartaDeInvitacion = GetCartaDeInvitacion();
            //foreach (var _ImageFullPageXtraReport in _CartaDeInvitacion)
            //{
            //    _ImageFullPageXtraReport.CreateDocument();
            //    _HojaNotificacionXtra.Pages.AddRange(_ImageFullPageXtraReport.Pages);
            //}


            //using (ReportPrintTool printTool = new ReportPrintTool(hojaNotificacionXtra))
            //{
            //    // Invoke the Ribbon Print Preview form modally,  
            //    // and load the report document into it. 
            //    printTool.ShowRibbonPreviewDialog();

            //    // Invoke the Ribbon Print Preview form 
            //    // with the specified look and feel setting. 
            //    //printTool.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
            //}
        }

        public void MostrarReporteProyectoEconomico()
        {
            GetProyectoEconomico().ShowRibbonPreviewDialog();

        }

        public void MostrarReporteProyectoInstituto()
        {
            try
            {


                XtraReport proyectoInsituto = new XtraReport();
                proyectoInsituto.CreateDocument();
                proyectoInsituto.Pages.AddRange(GetProyectoEconomico(true).Pages);
                proyectoInsituto.Pages.AddRange(GetCartaDeInvitacion(true).Pages);
                proyectoInsituto.Pages.AddRange(GetReporteTablaCertifico().Pages);
                for (var i = 0; i < 5; i++)
                {
                    //ModeloDeViajeV2 modelo2 = new ModeloDeViajeV2(this);
                    //modelo2.CreateDocument();
                    //_ProyectoInsituto.Pages.AddRange(modelo2.Pages);
                    //ModeloDeViaje _CertificoIcm = new ModeloDeViaje(this);
                    //_CertificoIcm.CreateDocument();
                    //_ProyectoInsituto.Pages.AddRange(_CertificoIcm.Pages);
                    var reporteModeloDeViaje = GetReporteModeloDeViaje();
                    proyectoInsituto.Pages.AddRange(reporteModeloDeViaje.Pages);
                }
                //ModeloDeViaje _aFirmaGerente = new ModeloDeViaje(this);
                //_ProyectoInsituto.Pages.AddRange(_aFirmaGerente.Pages);

                var repertorio = GetReporteRepertorio();
                proyectoInsituto.Pages.AddRange(repertorio.Pages);
                var repertorio1 = GetReporteRepertorio();
                proyectoInsituto.Pages.AddRange(repertorio1.Pages);
                proyectoInsituto.ShowRibbonPreviewDialog();
            }
            catch (Exception e)
            {
               Utils.MuestraError("Error al crear reporte<br>Verifique la inserción de los datos por favor");
            }


        }

        public XtraReport GetReporteTablaCertifico()
        {
            if (
                ParticipantesDeProyectos.Any(
                    c => c.TipoParticipante == Enumerados.TipoParticipante.Integrante.ToString()))
            {
                TablaCertificoXtraReportV2 tablaCertifico = new TablaCertificoXtraReportV2(this);
                tablaCertifico.CreateDocument();
                return tablaCertifico;
            }
            return null;
        }

        public XtraReport GetReporteRepertorio()
        {
            RepertorioXtraReport repertorio = new RepertorioXtraReport(this);
            repertorio.CreateDocument();
            return repertorio;
        }

        public XtraReport GetReporteModeloDeViaje()
        {
            ModeloDeViajeV2 modelo2 = new ModeloDeViajeV2(this);
            modelo2.CreateDocument();
            ModeloDeViaje certificoIcm = new ModeloDeViaje(this);
            certificoIcm.CreateDocument();
            modelo2.Pages.AddRange(certificoIcm.Pages);
            return modelo2;
        }

        private ImageFullPageXtraReport GetCartaDeInvitacion(bool aParaProyectoInstituto)
        {
            try
            {
                ImageFullPageXtraReport hojasDeLaCarta = new ImageFullPageXtraReport();
                var cartas = CartasDeInvitacion.ToList().OrderBy(c => c.Imagenes.Orden);
                foreach (var carta in cartas)
                {
                    ImageFullPageXtraReport reporteFullPageXtraReport = new ImageFullPageXtraReport();
                    byte[] pictBinary = carta.Imagenes.Imagen.ToArray();
                    MemoryStream ms = new MemoryStream(pictBinary);
                    Bitmap imagenBitmap = new Bitmap(ms);
                    reporteFullPageXtraReport.xrPictureBox1.Image = imagenBitmap;
                    // if (!aParaProyectoInstituto) _ReporteFullPageXtraReport.Watermark.Text = "";
                    reporteFullPageXtraReport.CreateDocument();
                    reporteFullPageXtraReport.DrawWatermark = aParaProyectoInstituto;
                    hojasDeLaCarta.Pages.AddRange(reporteFullPageXtraReport.Pages);
                }
                return hojasDeLaCarta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetLugaresDePresentacion()
        {
            string presentaciones = "";
            foreach (var presentacion in this.Presentacion)
            {
                presentaciones += "," + presentacion.Escenario;
            }
            return presentaciones.Replace("-", ", ").Acabado();
        }

        public decimal GetValorContrato()
        {
            decimal valor = 0;
            foreach (var presentacion in Presentacion)
            {
                if (presentacion.Cachet != null)
                    valor += (decimal) (presentacion.Cachet*presentacion.Cantidad);
            }
            return valor;
        }

        public void MuestraReporteTablaParticipantes()
        {

            if (!ParticipantesDeProyectos.Any())
            {
                XtraMessageBox.Show(
                    "El proyecto no tiene definido ningún participante por lo que no se puede mostrar este reporte",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            TablaParticipantesDeProyectosXtraReport report = new TablaParticipantesDeProyectosXtraReport(this.ProyectoID);
            report.ShowRibbonPreviewDialog();
        }

        private void MuestraReporte(XtraReport aXtraReport)
        {
            aXtraReport.ShowRibbonPreviewDialog();
            //using (ReportPrintTool printTool = new ReportPrintTool(aXtraReport))
            //{
            //    // Invoke the Ribbon Print Preview form modally,  
            //    // and load the report document into it. 
            //    printTool.ShowRibbonPreviewDialog();

            //    // Invoke the Ribbon Print Preview form 
            //    // with the specified look and feel setting. 
            //    //printTool.ShowRibbonPreview(UserLookAndFeel.Default);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esParaInsituto">Si es para instituto</param>
        /// <returns></returns>
        private XtraReport GetProyectoEconomico(bool esParaInsituto = false)
        {
            ProyectoParaInstitutoMusicaXtraReport proyectoParaInstituto = new ProyectoParaInstitutoMusicaXtraReport(this);
            proyectoParaInstituto.CreateDocument();
            FormulacionEconomicaProyecto formulacionEconomica = new FormulacionEconomicaProyecto(this);
            formulacionEconomica.CreateDocument();
            ////ListadoIntegranteFirmaGerente _ListadoIntegranteFirma = new ListadoIntegranteFirmaGerente(this);
            ////_ListadoIntegranteFirma.CreateDocument();
            //_ProyectoParaInstituto.Pages.AddRange(_FormulacionEconomica.Pages);
            ////_ProyectoParaInstituto.Pages.AddRange(_ListadoIntegranteFirma.Pages);
            //_ProyectoParaInstituto.Pages.AddRange(GetCartaDeInvitacion(esParaInsituto).Pages);
            //if (ParticipantesDeProyectos.Any(c => c.TipoParticipante == Enumerados.TipoParticipante.Integrante.ToString()))
            //{
            //    TablaCertificoXtraReportV2 _TablaCertifico = new TablaCertificoXtraReportV2(this);
            //    _TablaCertifico.CreateDocument();
            //    _ProyectoParaInstituto.Pages.AddRange(_TablaCertifico.Pages);
            //}
            //_ProyectoParaInstituto.Pages.AddRange(GetDocumentosDeInvitados(esParaInsituto).Pages);
            //RepertorioXtraReport _RepertorioXtraReport = new RepertorioXtraReport(this);
            //_RepertorioXtraReport.CreateDocument();
            //_ProyectoParaInstituto.Pages.AddRange(_RepertorioXtraReport.Pages);
            proyectoParaInstituto.Pages.AddRange(formulacionEconomica.Pages);
            return proyectoParaInstituto;
        }

        public XtraReport GetDocumentosDeInvitados(bool aParaProyectoInstituto)
        {
            NegocioDataContext dataContext = new NegocioDataContext();
            try
            {
                List<ParticipantesDeProyectos> invitados =
                    ParticipantesDeProyectos.Where(
                        c => c.TipoParticipante == Enumerados.TipoParticipante.Invitado.ToString()).ToList();
                ImageFullPageXtraReport documentosXtraReport = new ImageFullPageXtraReport();
                documentosXtraReport.CreateDocument();
                documentosXtraReport.Pages.RemoveAt(0);
                foreach (var invitado in invitados)
                {
                    ImageFullPageXtraReport reporteFullPageXtraReport = new ImageFullPageXtraReport();
                    var imagenes =
                        dataContext.DocumentosInvitados.Where(c => c.ParticipanteId == invitado.ParticipanteID)
                            .ToArray();
                    foreach (var documento in imagenes)
                    {

                        byte[] pictBinary = documento.Imagenes.Imagen.ToArray();
                        MemoryStream ms = new MemoryStream(pictBinary);
                        Bitmap imagenBitmap = new Bitmap(ms);
                        reporteFullPageXtraReport.xrPictureBox1.Image = imagenBitmap;
                        if (!aParaProyectoInstituto) reporteFullPageXtraReport.Watermark.Text = "";
                        reporteFullPageXtraReport.CreateDocument();
                        documentosXtraReport.Pages.AddRange(reporteFullPageXtraReport.Pages);
                    }

                }

                return documentosXtraReport;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void MuestraPlanillaSalida()
        {
            PlanillaSalida planilla = new PlanillaSalida(this);
            planilla.ShowRibbonPreviewDialog();
        }

        public void MuestraListaDeIntegrantes()
        {
            ListadoIntegranteFirmaGerente listaIntegrantes = new ListadoIntegranteFirmaGerente(this);
            MuestraReporte(listaIntegrantes);
        }

        public List<ParticipantesDeProyectos> GetInvitados()
        {
            try
            {
                List<ParticipantesDeProyectos> invitados = new List<ParticipantesDeProyectos>();
                var participanteDeProyecto =
                    (new NegocioDataContext()).ParticipantesDeProyectos.Where(c => c.ProyectoId == ProyectoID);
                foreach (var participante in participanteDeProyecto)
                {
                    if (participante.AgrupacionId != AgrupacionId)
                        invitados.Add(participante);
                }

                return invitados;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Devuelve el consecutivo en turno
        /// </summary>
        /// <returns></returns>
        public static int GetConsecutivo()
        {
            Proyectos ultimoProyecto = GetUltimoProyecto();
            if (ultimoProyecto != null)
                return ultimoProyecto.Consecutivo + 1;
            return 1;
        }

        private static Proyectos GetUltimoProyecto()
        {
            NegocioDataContext aDataContext = new NegocioDataContext();
            ConfiguracionGeneral configuracion = DynamicQueryable.FirstOrDefault(aDataContext.ConfiguracionGeneral);
            var proyectosdelAnno = aDataContext.Proyectos.Where(c => c.Anno == configuracion.AnnoDeTrabajo);
            if (DynamicQueryable.Any(proyectosdelAnno))
            {
                Proyectos ultimoProyecto =
                    DynamicQueryable.FirstOrDefault(proyectosdelAnno.OrderByDescending(c => c.Consecutivo));
                return ultimoProyecto;
            }
            return null;
        }

        public void MuestraReporteTablaDeCertifico()
        {
            try
            {
                var certifico = GetReporteTablaCertifico();
                if (certifico == null)
                {
                    XtraMessageBox.Show("No existen participantes del proyecto", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    return;
                }
                certifico.ShowPreviewDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// para trabajar con los proyecto internacionales se crea un registro con nombre Proyecto En Frontera, 
        /// con el campo EsProyectroEnFrontera true;
        /// </summary>
        /// <returns>el Id del proyecto en frontera</returns>
        public static int InsertaAgrupacionProyecto()
        {
            try
            {
                var aDataContext = new NegocioDataContext();
                var agrupacionProyectoEnFrontera = aDataContext.Agrupacion.FirstOrDefault(c => c.EsProyecto);
                if (agrupacionProyectoEnFrontera == null)
                {
                    agrupacionProyectoEnFrontera = new Agrupacion
                    {
                        Nombre = "Proyecto En Frontera o Internacional",
                        EsProyecto = true,
                        PerteneceACatalogo = true
                    };
                    aDataContext.Agrupacion.InsertOnSubmit(agrupacionProyectoEnFrontera);
                    aDataContext.SubmitChanges();
                }
                return agrupacionProyectoEnFrontera.AgrupacionID;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public IQueryable<EntitySet<ParticipantesDeProyectos>> GetParticipantes()
        {
            var participantes =
                new NegocioDataContext().Proyectos.Where(c => c.ProyectoID == ProyectoID)
                    .Select(c => c.ParticipantesDeProyectos);   
            return participantes;
        }

        public void SetEstado()
        {
            var dc = new NegocioDataContext();
            var proyecto = dc.Proyectos.FirstOrDefault(c => c.ProyectoID == ProyectoID);
           // var anEstado;
            Enumerados.EstadoProyecto anEstado = Enumerados.EstadoProyecto.Realizado;
            if (TieneNominaAsociada)
            {
               anEstado = (Enumerados.EstadoProyecto.AsociadaNomina);
            }
            else if (FechaInicial >= DateTime.Today && FechaFinal <= DateTime.Today)
            {
                anEstado =(Enumerados.EstadoProyecto.EnEjecucion);
            }
            else if(FechaInicial > DateTime.Today)
            {
                anEstado = (Enumerados.EstadoProyecto.Pendiente);

            }
            proyecto.EstadoProyecto = anEstado.ToEntero();
            dc.SubmitChanges();
        }

        public bool TieneNominaAsociada
        {
            get
            {
                return new NegocioDataContext().Nomina.Any(c=>c.DocumentoReferenciaId==ProyectoID);
            }
        }

        public OrdenDeTrabajo FacturaDeCierre
        {
            get
            {
                try
                {
                    OrdenDeTrabajo factura = new NegocioDataContext().OrdenDeTrabajo.FirstOrDefault(c => c.ProyectosId == ProyectoID  && c.Estado != Enumerados.EstadoOrdenDeTrabajo.Cancelada.ToEntero());
                    return factura;
                }
                catch (Exception)
                {

                    return null;
                }
            } 
        }

        public object TipoPasaporteString
        {
            get
            {
                return  (((Enum)(Enum.Parse(typeof(Enumerados.TipoPasaporte), TipoPasaporte.ToString()))).StringValue());
            }
        }
    }
}
    

