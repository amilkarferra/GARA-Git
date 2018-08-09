using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DXApplication9.ReportesSistema;

namespace DXApplication9
{
    public partial class OrdenDeTrabajo
    {
        public string NumeroDeOrden
        {
            get
            {
                if (Anno == 0) return "Entre en la configuracion e inserte e año de trabajo";
                return string.Format("{0}/{1}", Consecutivo, Anno);
            }
            set
            {
                //int anno = Convert.ToInt32(value.Split('/')[1]);
                Anno = ConfiguracionGeneral.Anno;
                int consecutivo = Convert.ToInt32(value.Split('/')[0]);
                Consecutivo = consecutivo;
            }
        }

        public decimal Descuentos
        {
            get
            {
                NegocioDataContext dataContext = new NegocioDataContext();
                var descuentosAsociados = dataContext.DescuentoPorActividad.Where(c => c.DocumentoReferenciaId == OrdenDeTrabajoID);
                if (!DynamicQueryable.Any(descuentosAsociados)) return 0;
                return descuentosAsociados.Sum(c => c.Importe);
            }
        }

        public bool TieneNominaAsociada
        {

            get
            {
                NegocioDataContext dataContext = new NegocioDataContext();


                return dataContext.Nomina.Any(c => c.DocumentoReferenciaId == OrdenDeTrabajoID);
            }
        }

        public bool EsUltima
        {
            get
            {
                return
                    DynamicQueryable.FirstOrDefault((new NegocioDataContext()).OrdenDeTrabajo.Where(c => c.TipoActividad == TipoActividad).OrderBy(c => c.Anno).ThenByDescending(c => c.Consecutivo))
                        .OrdenDeTrabajoID == OrdenDeTrabajoID;
            }
        }


        public string ConsecutivoString
        {
            get { return string.Format("{0}/{1}", Consecutivo, Anno); }
        }
        /// <summary>
        /// Numero de la cuenta 
        /// </summary>
        public string NumeroCuenta
        {
            get
            {
                var cuentaDeCliente =
                    new NegocioDataContext().CuentasBancariasDeCliente.FirstOrDefault(
                        c => c.ControlClienteId == ClienteQueContrataId && c.TipoMonedaId == TipoMonedaId);
                if (cuentaDeCliente != null) return cuentaDeCliente.NumeroCuenta;
                return "";
            }
        }
        public string TitularCuenta
        {
            get
            {
                var cuentaDeCliente =
                    new NegocioDataContext().CuentasBancariasDeCliente.FirstOrDefault(
                        c => c.ControlClienteId == ClienteQueContrataId && c.TipoMonedaId == TipoMonedaId);
                if (cuentaDeCliente != null) return cuentaDeCliente.Titular;
                return "";
            }
        }

        /// <summary>
        /// Importe que se ha distribuido por la actividad entre los participantes
        /// Util para determinar si falta aun importe por distribuir
        /// </summary>
        public decimal ImporteDistribuidoHastaMomento
        {
            get
            {
                try
                {
                    return
                            new NegocioDataContext().ParticipantesDeAcividad.Where(c => c.ActividadId == OrdenDeTrabajoID).Sum(c => c.Importe);
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }

        /// <summary>
        /// Importe que aun no se ha distribuido entre los participantes
        /// 
        /// </summary>
        public decimal ImporteRestaPorDistribuir
        {
            get
            {
                var
                    firstOrDefault = new NegocioDataContext().OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == OrdenDeTrabajoID);
                if (firstOrDefault != null)
                {
                    var distribuido = firstOrDefault.ParticipantesDeAcividad.Sum(c => c.Importe);
                    return ImporteConDescuento - distribuido;
                }

                return 0;
            }
        }

        /// <summary>
        /// Dieta que aun no se ha distribuido entre los participantes
        /// 
        /// </summary>
        public decimal DietaRestaPorDistribuir
        {
            get
            {
                var
                    firstOrDefault = new NegocioDataContext().OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == OrdenDeTrabajoID);
                if (firstOrDefault != null)
                {
                    var distribuido = firstOrDefault.ParticipantesDeAcividad.Sum(c => c.Dieta);
                    return ImporteDieta - distribuido;
                }

                return 0;
            }
        }


        /// <summary>
        /// Devuelve el consecutivo de  numero de OT que le tocaría en consecutividad segun el ultimo insertado
        /// </summary>
        /// <returns></returns>
        public static string GetProximoNumeroDeActividad(Enumerados.TipoActividad aTipoActividad)
        {

            var annoTrabajo = ConfiguracionGeneral.Anno;
            //if (_AnnoTrabajo == 0)
            //{
            //    MessageBox.Show("Inserte el numero de año de trabajo en la configuración General", "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return string.Empty;
            //}
            //var ActividadesDelAño = new NegocioDataContext().OrdenDeTrabajo.Where(c => c.Anno == _AnnoTrabajo);
            //OrdenDeTrabajo _UltimaActividad = DynamicQueryable.FirstOrDefault(ActividadesDelAño.Where(c => c.TipoActividad == (int)aTipoActividad).OrderByDescending(c => c.Consecutivo));
            //int _UltimoConsecutivo = 0;
            //if (_UltimaActividad != null)
            //{
            //    _UltimoConsecutivo = _UltimaActividad.Consecutivo;
            //}
            return string.Format("{0}/{1}", GetProximoConsecutivo(aTipoActividad), annoTrabajo);
        }

        public static int GetProximoConsecutivo(Enumerados.TipoActividad aTipoActividad)
        {
            try
            {
                var annoTrabajo = ConfiguracionGeneral.Anno;
                if (annoTrabajo == 0)
                {
                    MessageBox.Show("Inserte el numero de año de trabajo en la configuración General", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                var actividadesDelAño = new NegocioDataContext().OrdenDeTrabajo.Where(c => c.Anno == annoTrabajo);
                OrdenDeTrabajo ultimaActividad = DynamicQueryable.FirstOrDefault(actividadesDelAño.Where(c => c.TipoActividad == (int)aTipoActividad).OrderByDescending(c => c.Consecutivo));
                int ultimoConsecutivo = 0;
                if (ultimaActividad != null)
                {
                    ultimoConsecutivo = ultimaActividad.Consecutivo;
                }
                return ultimoConsecutivo + 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// Devuelve el ultimo consecutivo segun la moneda para conformar Numero de Contrato
        /// Ejemplo de Numero de Contrato es 49/14-1-3/14
        /// </summary>
        /// <param name="anAgrupacionId"></param>
        /// <param name="aMoneda"></param>
        /// <returns></returns>
        public static int GetUltimaPresentacionPorMoneda(int anAgrupacionId, int aMoneda)
        {
            try
            {
                if (DynamicQueryable.Any((new NegocioDataContext()).OrdenDeTrabajo))
                {
                    var ultPresentacion =
                        DynamicQueryable.FirstOrDefault((new NegocioDataContext()).OrdenDeTrabajo.Where(c => c.TipoMonedaId == aMoneda && c.AgrupacionId == anAgrupacionId && c.FechaConfeccion.Year == ConfiguracionGeneral.Anno).OrderByDescending(c => c.Consecutivo));
                    if (ultPresentacion == null) return 0;
                    var ultContratoMoneda = (ultPresentacion.NumeroContrato.Split('-')[2]).Split('/')[0];
                    return Convert.ToInt32(ultContratoMoneda);
                }
                return 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }

        /// <summary>
        /// Genera el numero de contrato en turno con el formato NumeroDeContrato/añoDelContrato-CodigoDeAgrupacion-Consecutivo/añoQueSeTrabaja
        /// </summary>
        /// <param name="anAgrupacionId"></param>
        /// <param name="aMoneda"></param>
        /// <param name="anEmpresaId"></param>
        /// <returns></returns>
        public static string GetNumeroDeContratoEnTurno(int anAgrupacionId, int aMoneda, int anEmpresaId)
        {
            try
            {
                var contrato =
                        (new NegocioDataContext()).ControlClientes.FirstOrDefault(c => c.ControlClienteID == anEmpresaId);
                string numeroDeContratoCliente = string.Format("{0}/{1}", contrato.NumeroContrato,
                    contrato.FechaContrato.Year);
                string codigoAgrupacion =
                    (new NegocioDataContext()).Agrupacion.FirstOrDefault(c => c.AgrupacionID == anAgrupacionId).Codigo;
                int ultPresentacionByMoneda = GetUltimaPresentacionPorMoneda(anAgrupacionId, aMoneda);
                int annoTrabajo = (int)DynamicQueryable.FirstOrDefault((new NegocioDataContext()).ConfiguracionGeneral).AnnoDeTrabajo;
                string numeroContrato = string.Format("{0}-{1}-{2}/{3}", numeroDeContratoCliente, codigoAgrupacion,
                    ultPresentacionByMoneda + 1, annoTrabajo);
                return numeroContrato;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        public static IQueryable<AgrupacionDeArtista> GetAgrupacionDeArtistasParticipantes(Guid actividadId, NegocioDataContext dataContext = null)
        {
            var dc = dataContext ?? new NegocioDataContext();
            var actividad = dc.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == actividadId);
            var agrupacionDeArtista =
                // actividad.Agrupacion.AgrupacionDeArtista.Where(c => (c.FechaBaja == null || c.FechaBaja > actividad.FechaIncialActividad) && c.FechaAlta<=actividad.FechaIncialActividad);
                dc.AgrupacionDeArtista.Where(c => c.AgrupacionId == actividad.AgrupacionId && (c.FechaBaja == null || c.FechaBaja > actividad.FechaIncialActividad) &&
                       (c.FechaAlta <= actividad.FechaIncialActividad));
            agrupacionDeArtista = agrupacionDeArtista.Where(c => c.Artista.Estado == Enumerados.EstadoArtista.Activo.ToEntero());
            return agrupacionDeArtista;
        }


        //public static void Insert(OrdenDeTrabajo anOrdenDeTrabajo)
        //{
        //    try
        //    {
        //        var dc = (new NegocioDataContext());
        //        dc.OrdenDeTrabajo.InsertOnSubmit(anOrdenDeTrabajo);
        //        dc.SubmitChanges();
        //        var _Participantes = Artista.GetActiveList(anOrdenDeTrabajo.AgrupacionId, dc);
        //        foreach (var _Participante in _Participantes)
        //        {
        //            dc.ParticipantesDeAcividad.InsertOnSubmit(new ParticipantesDeAcividad
        //            {
        //                ArtistaId = _Participante.ArtistaID,
        //                ActividadId = anOrdenDeTrabajo.OrdenDeTrabajoID
        //            });
        //        }
        //        dc.SubmitChanges();
        //    }
        //    catch (Exception _exception)
        //    {
        //        MessageBox.Show(_exception.Message);

        //    }
        //}

        public string GetDescripcion()
        {
            try
            {
                var actividad = new NegocioDataContext().OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == OrdenDeTrabajoID);
                var descripcion =
                        string.Format(
                            "Orden de Trabajo realizada en {0} el día {1} por la agrupación {2} y contratada por {3}, número de contrato {4}.",
                            actividad.LugarDePresentacion, actividad.FechaTexto, actividad.Agrupacion.Nombre, actividad.ControlClientes.NombreDeEntidad, actividad.NumeroContrato
                            );
                return descripcion;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return "-Error generando descripcion-";
            }
        }

        public string FechaTexto
        {
            get
            {
                if (FechaFinalActividad != FechaIncialActividad)
                {
                    return string.Format("Del {0} hasta el {1}", FechaFinalActividad.ToShortDateString(),
                        FechaIncialActividad.ToShortDateString());
                }
                return FechaIncialActividad.ToShortDateString();
            }
        }

        /// <summary>
        /// Devuelve si ya está tomado el numero de la orden de trabajo
        /// </summary>
        /// <param name="anOrdenNumero"></param>
        /// <returns></returns>
        public static bool ExisteNumeroDeOrden(string anOrdenNumero)
        {
            return
                (new NegocioDataContext()).OrdenDeTrabajo.Any(
                    c =>
                        c.Consecutivo == Convert.ToInt32(anOrdenNumero.Split('/')[0]) &&
                        c.Anno == Convert.ToInt32(anOrdenNumero.Split('/')[1]));
        }

        /// <summary>
        /// 
        /// 
        /// Obtiene el numero de la orden segun el OrdenDeTrabajoID
        /// </summary>
        /// <param name="anOrdenDetrabajoId">Identificador</param>
        /// <returns>el numero de la orden de trabajo si existe de lo contrario devuelve una cadena vacia</returns>
        public static string GetNumeroDeOrden(Guid anOrdenDetrabajoId)
        {
            try
            {
                var firstOrDefault = GetOrdenDeTrabajoById(anOrdenDetrabajoId);
                if (firstOrDefault != null)
                {
                    var deOrden = firstOrDefault.NumeroDeOrden;
                    if (deOrden != null) return deOrden;
                }
                return "";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }


        /// <summary>
        /// Devuelve la orden de trabajo segun Id
        /// </summary>
        /// <param name="anOrdenDetrabajoId">Identificador</param>
        /// <returns>la Orden de trabajo</returns>
        public static OrdenDeTrabajo GetOrdenDeTrabajoById(Guid anOrdenDetrabajoId, NegocioDataContext aDataContext = null)
        {
            NegocioDataContext dataContext = aDataContext ?? (new NegocioDataContext());
            var firstOrDefault = dataContext.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == anOrdenDetrabajoId);
            return firstOrDefault;
        }

        public static int GetConsecutivoByNroDeOrden(string aNumeroDeOrden)
        {
            var consecutivo = aNumeroDeOrden.Left(aNumeroDeOrden.IndexOf('/'));
            return Convert.ToInt32(consecutivo);
        }

        public static int GetAnnoByNroDeOrden(string aNumeroDeOrden)
        {
            var anno = aNumeroDeOrden.Substring(aNumeroDeOrden.IndexOf('/') + 1);
            return Convert.ToInt32(anno);
        }

        public void MuestraReporte()
        {

            try
            {
                OrdenDeTrabajo ordenDeTrabajo = GetOrdenDeTrabajoById(OrdenDeTrabajoID);
                switch (TipoActividad)
                {
                    case (int)Enumerados.TipoActividad.OrdenDeTrabajo:

                        OrdenDeTrabajoXtraReport reporteDeTrabajoXtraReport = new OrdenDeTrabajoXtraReport(ordenDeTrabajo);
                        reporteDeTrabajoXtraReport.CreateDocument();
                        M2XtraReport m2XtraReport = new M2XtraReport(ordenDeTrabajo);
                        m2XtraReport.CreateDocument();
                        m2XtraReport.PrintingSystem.PrintingDocument.AutoFitToPagesWidth = 1;
                        reporteDeTrabajoXtraReport.Pages.AddRange(m2XtraReport.Pages);
                        reporteDeTrabajoXtraReport.ShowPreview();
                        break;
                    case (int)Enumerados.TipoActividad.Factura:
                        FactExportXtraReport reporte = new FactExportXtraReport(ordenDeTrabajo);
                        reporte.CreateDocument();
                        reporte.ShowPreview();
                        break;
                    case (int)Enumerados.TipoActividad.ProduccionInterna:

                        ProduccionInternaXtraReport reporteDeProdInternaXtraReportXtraReport = new ProduccionInternaXtraReport(ordenDeTrabajo);
                        reporteDeProdInternaXtraReportXtraReport.CreateDocument();
                        M2XtraReport m2XtraReport1 = new M2XtraReport(ordenDeTrabajo);
                        m2XtraReport1.CreateDocument();
                        m2XtraReport1.PrintingSystem.PrintingDocument.AutoFitToPagesWidth = 1;
                        reporteDeProdInternaXtraReportXtraReport.Pages.AddRange(m2XtraReport1.Pages);
                        reporteDeProdInternaXtraReportXtraReport.ShowPreview();
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }

        }
        /// <summary>
        /// Salva la activdad
        /// </summary>
        /// <param name="agrupacionId"></param>
        /// <param name="numeroDeContrato"></param>
        /// <param name="fechaConfeccion"></param>
        /// <param name="fechaInicial"></param>
        /// <param name="fechaFinal"></param>
        /// <param name="clienteQueContrataId"></param>
        /// <param name="lugarDePresentacion"></param>
        /// <param name="importeDePresentacionContratado"></param>
        /// <param name="tipoMonedaId"></param>
        /// <param name="cantidadActividades"></param>
        /// <param name="activdadId"></param>
        /// <param name="aTipoActividad"></param>
        /// <param name="esPorCover"></param>
        /// <param name="anAnno"></param>
        /// <param name="anObservaciones"></param>
        /// <param name="aProyectoId"></param>
        /// <param name="aDataContext"></param>
        /// <returns>la actividad si es salvada correctamente, nulo si hay error</returns>
        public static OrdenDeTrabajo SalvaActividad(int agrupacionId, string numeroDeContrato,
            DateTime fechaConfeccion, DateTime fechaInicial, DateTime fechaFinal, int clienteQueContrataId,
            string lugarDePresentacion, decimal importeDePresentacionContratado, int tipoMonedaId, int cantidadActividades
            , Guid activdadId = new Guid(), Enumerados.TipoActividad aTipoActividad = Enumerados.TipoActividad.OrdenDeTrabajo, bool esPorCover = false, int anAnno = 0, string anObservaciones = null,string aNotasRecordatorias=null, Guid? aProyectoId = null, NegocioDataContext aDataContext = null)
        {
            bool isAnUpdate = true;

            try
            {
                var dc =  new NegocioDataContext();
                var actividadInicial = GetOrdenDeTrabajoById(activdadId);
                var actividad = GetOrdenDeTrabajoById(activdadId, dc);
                if (actividad == null)
                {
                    actividad = new OrdenDeTrabajo();
                    isAnUpdate = false;

                }

                actividad.EsPorCover = esPorCover;
                actividad.FechaConfeccion = fechaConfeccion;
                actividad.ClienteQueContrataId = clienteQueContrataId;
                actividad.AgrupacionId = agrupacionId;
                //actividad.Anno = ConfiguracionGeneral.Anno;
                actividad.CantidadActividades = cantidadActividades;
                actividad.FechaFinalActividad = fechaFinal;
                actividad.FechaIncialActividad = fechaInicial;
                actividad.ImportePorActividad =aTipoActividad==Enumerados.TipoActividad.Factura?actividad.GetImporteDeFactura():importeDePresentacionContratado;
                actividad.LugarDePresentacion = lugarDePresentacion;
                actividad.TipoMonedaId = tipoMonedaId;
                actividad.NumeroContrato = numeroDeContrato;
                actividad.TipoActividad = (int)aTipoActividad;
                actividad.Anno = isAnUpdate ? actividad.Anno : anAnno;
                actividad.Observaciones = anObservaciones;
                actividad.ProyectosId = aProyectoId;
                actividad.Nota = aNotasRecordatorias;
                if (!isAnUpdate)
                {
                    actividad.Consecutivo = GetConsecutivoByNroDeOrden(GetProximoNumeroDeActividad(aTipoActividad));
                    actividad.Estado = (short)Enumerados.EstadoOrdenDeTrabajo.Realizada;
                    actividad.OrdenDeTrabajoID = Guid.NewGuid();
                    dc.OrdenDeTrabajo.InsertOnSubmit(actividad);
                    //Insertando los participantes de proyectos
                    //TODO descomentar esto para activar la insercion de los participantes de actividad desde la orden de trabajo
                    //    //InsertaParticipantesDeActividad(_Actividad.OrdenDeTrabajoID);
                    //}
                    //else if (isAnUpdate)
                    ////Regenero todod los participantes poruqe puede haber hasta cambios de fechas y por consiguientes bajas u altas en el cambio
                    //{
                    //    _Actividad.EliminarParticipantesDeActividad(aDataContext);
                    //    _Actividad.InsertaParticipantesDeActividad();
                }
                if (actividadInicial != null)
                {
                    actividadInicial.OnFechaDePagoChanged();
                }

                dc.SubmitChanges();
                

                if (isAnUpdate)
                {
                    var oOldRecord = actividadInicial;
                    var oNewRecord = actividad;
                    var oType = oOldRecord.GetType();
                    var TipoPropiedadesAceptadas = new string[]
                    {
                        "Int32", "Decimal", "DateTime", "Boolean", "Guid ", "String"
                    };
                    string cambios = "";
                    foreach (var oProperty in oType.GetProperties())
                    {
                        if (TipoPropiedadesAceptadas.Contains(oProperty.PropertyType.Name))
                            // if (oProperty.CanWrite && !oProperty.PropertyType.Name.Contains("Entity")&&!oProperty.PropertyType.FullName.Contains("DX"))
                        {
                            var oOldValue = oProperty.GetValue(oOldRecord, null);
                            var oNewValue = oProperty.GetValue(oNewRecord, null);
                            // this will handle the scenario where either value is null
                            if (!object.Equals(oOldValue, oNewValue))
                            {
                                // Handle the display values when the underlying value is null
                                var sOldValue = oOldValue == null ? "null" : oOldValue.ToString();
                                var sNewValue = oNewValue == null ? "null" : oNewValue.ToString();
                                cambios += " -Propiedad " + oProperty.Name + " antes: " + sOldValue + "; cambia a: " +
                                           sNewValue;
                            }
                        }
                    }

                    RegistraLogAccion(Enumerados.TipoAccion.Modificar,
                        actividad.OrdenDeTrabajoID, cambios);
                }
                else //se inserta una nueva actividad
                {
                   RegistraLogAccion(Enumerados.TipoAccion.Insertar, actividad.OrdenDeTrabajoID,"Se crea la Actividad",aDataContext);
                }
                return actividad;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

                return null;
            }

        }

        /// <summary>
        /// returna actividad contratada por un cliente en una fecha y una moneda.
        /// Util para detectar si ya existe alguna orden semejante insertada en el sistema
        /// </summary>
        /// <param name="fechaIncial"></param>
        /// <param name="clienteContrataId"></param>
        /// <param name="monedaId"></param>
        /// <returns></returns>
        public static OrdenDeTrabajo GetActividadSemejante(DateTime fechaIncial, int clienteContrataId, int monedaId, int anAgrupacionId)
        {

            var ordenParecida = (new NegocioDataContext()).OrdenDeTrabajo.FirstOrDefault(
                     c => c.AgrupacionId == anAgrupacionId &&
                         c.ClienteQueContrataId == clienteContrataId &&
                         c.FechaIncialActividad == fechaIncial && c.TipoMonedaId == monedaId);
            return ordenParecida;

        }

        /// <summary>
        /// returna actividad contratada por un cliente en una fecha y una moneda.
        /// Util para detectar si ya existe alguna orden semejante insertada en el sistema
        /// </summary>
        /// <returns></returns>
        public OrdenDeTrabajo GetActividadSemejante()
        {
            var ordenParecida = (new NegocioDataContext()).OrdenDeTrabajo.FirstOrDefault(
                    c => c.AgrupacionId == AgrupacionId &&
                        c.ClienteQueContrataId == ClienteQueContrataId &&
                        c.FechaIncialActividad == FechaIncialActividad && c.TipoMonedaId == TipoMonedaId);
            return ordenParecida;
        }

        public static void EliminarParticipantesDeActividad(Guid actividadId, NegocioDataContext aDataContext = null)
        {
            var dataContext = aDataContext ?? new NegocioDataContext();
            var participantes = dataContext.ParticipantesDeAcividad.Where(c => c.ActividadId == actividadId);
            dataContext.ParticipantesDeAcividad.DeleteAllOnSubmit(participantes);
            dataContext.SubmitChanges();
        }

        public static void
        InsertaParticipantesDeActividad(Guid actividadId, NegocioDataContext aDataContext = null)
        {
            try
            {
                var dataContext = aDataContext ?? new NegocioDataContext();
                //Insertando los participantes de proyectos
                var orden = GetOrdenDeTrabajoById(actividadId);
                var integrantesTotales = dataContext.AgrupacionDeArtista.Where(c => c.AgrupacionId == orden.AgrupacionId);
                if (DynamicQueryable.Any(integrantesTotales))
                {// var IntegrantesDelGrupo = IntegrantesTotales.Select(d => d.Artista);
                    var integrantesActivos = GetAgrupacionDeArtistasParticipantes(actividadId, dataContext);

                    foreach (var integrante in integrantesActivos)
                    {
                        dataContext.ParticipantesDeAcividad.InsertOnSubmit(new ParticipantesDeAcividad { ArtistaId = integrante.ArtistaId, ActividadId = actividadId });
                    }
                }

                dataContext.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertaParticipantesDeActividad(NegocioDataContext aDataContext = null)
        {
            InsertaParticipantesDeActividad(OrdenDeTrabajoID, aDataContext);
        }

        public void EliminarParticipantesDeActividad(NegocioDataContext aDataContext = null)
        {
            EliminarParticipantesDeActividad(OrdenDeTrabajoID, aDataContext);
        }

        public bool Existe()
        {
            var aDataContext = new NegocioDataContext();
            var orden = (aDataContext.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == OrdenDeTrabajoID));
            if (orden == null) return false;
            return true;

        }


        public bool ValidaPorNominaAsociada()
        {
            if (TieneNominaAsociada)
            {
                MessageBox.Show("Esta Orden De Trabajo no puede Editarse / Borrare por tener nomina asociada ");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Cierra una orden de trabajo
        /// </summary>
        /// <param name="fechaLiquidacion">Fecha que se cierra la orden</param>
        /// <param name="porcientoUnidadArtistica">Porciento que cobrará la Unidad Artistica</param>
        /// <param name="importeFinal">Ingreso total de la actividad</param>
        /// <param name="numeroCheque">cheque que paga la actividad en caso de que lo tenga</param>
        /// <param name="observacionesCierre">Nota , puede incluir distribución</param>
        /// <param name="porcientoCliente">Porciento del ingreso que pasa al cliente , cuando es cover resbalante por ejemplo porciento que se queda la casa de la musica del importe total</param>
        /// <param name="fechaEntregaCheque">Fecha de Entrega de cheque</param>
        /// <returns>True si todo OK </returns>
        public bool CierraOrdenDeTrabajo(DateTime fechaLiquidacion, decimal porcientoUnidadArtistica, decimal importeFinal, string numeroCheque = null, string observacionesCierre = null, decimal? porcientoCliente = null, DateTime? fechaEntregaCheque = null, string aNota = "")
        {
            var dt = new NegocioDataContext();
            try
            {
                PorCientoUnidadArtistica = porcientoUnidadArtistica;
                var ot =
                   dt.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == OrdenDeTrabajoID);
                ot.FechaLiquidacion = fechaLiquidacion;
                ot.ImporteFinal = importeFinal;
                ot.PorCientoUnidadArtistica = porcientoUnidadArtistica;
                ot.PorcientoCliente = porcientoCliente;

                ot.Observaciones = observacionesCierre;
                ot.ImportePorActividad = importeFinal / (CantidadActividades == 0 ? 1 : CantidadActividades);
                ot.Descuento = Descuentos;
                ot.Nota = aNota.Trim();
                ot.Cheque = "";
                if (!string.IsNullOrEmpty(numeroCheque))
                {
                    if (fechaEntregaCheque != null)
                        ot.FechaEntregaCheque = fechaEntregaCheque;
                    ot.Cheque = numeroCheque;
                }
                if (ot.EsPorCover) ot.CantidadActividades = 1;
                ot.SetEstado();
                dt.SubmitChanges();
                OrdenDeTrabajo.RegistraLogAccion(Enumerados.TipoAccion.Cerrar, OrdenDeTrabajoID, "Se cierra orden de trabajo");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //public decimal GetDescuento()
        //{
        //    try
        //    {
        //        var descuentoPorActividads = (new NegocioDataContext()).DescuentoPorActividad.Where(c => c.DocumentoReferenciaId == OrdenDeTrabajoID);
        //        if (descuentoPorActividads.Any())
        //        {
        //            decimal descuento = descuentoPorActividads.Sum(c => c.Importe);
        //            return descuento;
        //        }
        //        return 0;
        //    }
        //    catch (Exception _exception)
        //    {

        //        MessageBox.Show("Error al obtener descuentos");
        //        return 0;
        //    }
        //}
        /// <summary>
        /// Importe que cobra realmente la unidad artistica luego de quitar los descuentos
        /// </summary>
        public decimal ImporteConDescuento
        {
            get
            {
                try
                {
                    return ImporteUnidadArtisticaSinDescuento - Descuentos;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al obtener descuentos");
                    return 0;
                }
            }
        }

        /// <summary>
        /// IngresoDeLaActividadEnAgencia
        /// </summary>
        public decimal ImporteDistribuirEnAgencia
        {
            get
            {
                try
                {
                    if (PorcientoCliente != 0 || PorcientoCliente != null)
                    {
                        if (ImporteFinal != null)
                        {
                            decimal importe = (decimal)ImporteFinal * (100 - Convert.ToInt32(PorcientoCliente)) / 100;
                            return decimal.Round(importe, 2);
                        }
                        return 0;
                    }
                    return 0;
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }

        public decimal ImporteIngresaCliente
        {
            get
            {
                try
                {
                    var @decimal = ImporteFinal * PorcientoCliente / 100;
                    if (@decimal != null)
                        return Decimal.Round((decimal)@decimal, 2);
                    return 0;
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }

        public decimal ImporteIngresaAgencia
        {
            get
            {
                if (ImporteFinal != null)
                    return decimal.Round((Convert.ToDecimal(ImporteFinal * (100 - PorcientoCliente) / 100)), 2);
                return 0;
            }
        }

        public decimal ImporteUnidadArtisticaSinDescuento
        {
            get
            {

                try
                {
                    return decimal.Round((Convert.ToDecimal(ImporteIngresaAgencia * (PorCientoUnidadArtistica) / 100)), 2);
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }

        public decimal ImporteUtilidadAgencia
        {
            get
            {
                try
                {
                    return decimal.Round((ImporteIngresaAgencia - ImporteUnidadArtisticaSinDescuento), 2);
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }

        public Nomina GetNominaAsociada()
        {
            try
            {
                using (NegocioDataContext dc = new NegocioDataContext())
                {
                    Nomina nomina = dc.Nomina.FirstOrDefault(c => c.DocumentoReferenciaId == OrdenDeTrabajoID);
                    return nomina;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public static void SetEstadoDeOrdenDeTrabajo(Guid ordenTrabajoId, Enumerados.EstadoOrdenDeTrabajo anEstado)
        {
            using (NegocioDataContext dc = new NegocioDataContext())
            {
                OrdenDeTrabajo orden = dc.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == ordenTrabajoId);
                orden.Estado = (short)anEstado;
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Cancelo una orden de trabajo y elimino todos los participantes de la misma
        /// </summary>
        /// <param name="anOrdenDeTrabajoId"></param>

        public static void CancelaOrdenDeTrabajo(Guid anOrdenDeTrabajoId)
        {
            try
            {
                using (NegocioDataContext dc = new NegocioDataContext())
                {
                    OrdenDeTrabajo orden = dc.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == anOrdenDeTrabajoId);
                    var estadoOrden = (Enumerados.EstadoOrdenDeTrabajo)Enum.Parse(typeof(Enumerados.EstadoOrdenDeTrabajo), orden.Estado.ToString());
                    if (estadoOrden == Enumerados.EstadoOrdenDeTrabajo.Realizada ||
                        estadoOrden == Enumerados.EstadoOrdenDeTrabajo.Cancelada)
                    {
                        try
                        {

                            orden.Estado = (int)Enumerados.EstadoOrdenDeTrabajo.Cancelada;
                            dc.SubmitChanges();
                            orden.EliminarParticipantesDeActividad(dc);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("La orden " + orden.Consecutivo + " no puede procesarce, recuerde que las ordenes cerradas o con nominas emitidas no pueden ser canceladas", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }



                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al procesar la acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        /// <summary>
        /// Pongo en estado realizada una Orden De Trabajo y le asocio los participantes de la actividad
        /// </summary>
        /// <param name="anOrdenDeTrabajoId"></param>
        public static void QuitarEstadoCancelado(Guid anOrdenDeTrabajoId)
        {
            try
            {
                using (NegocioDataContext dc = new NegocioDataContext())
                {
                    OrdenDeTrabajo orden = dc.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == anOrdenDeTrabajoId);
                    if (orden.Estado != (short)Enumerados.EstadoOrdenDeTrabajo.Cancelada)
                    {
                        MessageBox.Show("La orden " + orden.Consecutivo + " no está cancelada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    orden.Estado = (int)Enumerados.EstadoOrdenDeTrabajo.Realizada;
                    //orden.InsertaParticipantesDeActividad();

                    dc.SubmitChanges();
                    orden.RegistraLog(Enumerados.TipoAccion.Descancelar,"Se descansela la orden de trabajo",dc);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al procesar la acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public decimal GetImporteDeFactura()
        {
            try
            {
                decimal importeTotal = 0;
                foreach (var importeDeFactura in ImportesDeFacturaEnFrontera)
                {
                    importeTotal += Convert.ToInt32(importeDeFactura.Cantidad) *
                                     Convert.ToDecimal(importeDeFactura.ImporteUnitario);
                }
                return importeTotal;
            }
            catch (Exception)
            {

                return 0;
            }
        }


        public static OrdenDeTrabajo GetUltimaActividad(Enumerados.TipoActividad tipoDeActividad)
        {
            int aTipoActividad = (int)tipoDeActividad;
            OrdenDeTrabajo ultimaActividad = DynamicQueryable.FirstOrDefault((new NegocioDataContext()).OrdenDeTrabajo.Where(a => a.TipoActividad == (int)aTipoActividad).OrderByDescending(c => c.Consecutivo));
            return ultimaActividad;
        }

        /// <summary>
        /// Retorna el importe real que se cobra teniendo en cuenta todas los redondeos a dos decimales
        /// </summary>
        /// <returns>
        /// Devuelve el importe del cheque que se cobra redondeado a dos decimales
        /// </returns>
        public decimal ImporteNetoQueSeCobraReal
        {
            get
            {
                decimal importeNetoCobrarReal = ParticipantesDeAcividad.Sum(c => decimal.Round(c.Importe * 95 / 100, 2)); return importeNetoCobrarReal;
            }
        }

        public int PorCientoIngresaEmpresa
        {
            get
            {
                if (PorcientoCliente != null) return 100 - Convert.ToInt32(PorcientoCliente);
                return 0;
            }
        }

        public int PorcientoUtilidadEmpresa
        {
            get { return 100 - Convert.ToInt32(PorCientoUnidadArtistica); }
        }

        public decimal Onat
        {
            get
            {
                decimal onat = ParticipantesDeAcividad.Sum(c => decimal.Round(c.Importe * 5 / 100, 2));
                return onat;

            }
        }

        /// <summary>
        /// Efectivo real para el artista luego de descontar deudas y Onat
        /// </summary>
        public decimal EfectivoACobrarArtistaDecimal
        {
            get { return ImporteNetoQueSeCobraReal - Onat; }
        }

        public bool TieneDeudaHistorico
        {
            get
            {
                return new NegocioDataContext().HistoricoDeuda.Any(c => c.ActividadId == OrdenDeTrabajoID);

            }
        }

        /// <summary>
        /// Elimina todos los descuentos que esten en la tabla historico que tiene que ver 
        /// con la actividad.
        /// </summary>
        /// <returns></returns>
        public bool EliminaHistoricoDeudas()
        {
            try
            {
                var dc = new NegocioDataContext();
                var deudas = dc.HistoricoDeuda.Where(c => c.ActividadId == OrdenDeTrabajoID);
                dc.HistoricoDeuda.DeleteAllOnSubmit(deudas);
                dc.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        /// <summary>
        /// Inserta en la tabla HistoricoDeudas todos los descuentos que se hacen en la actividad
        /// </summary>
        public bool InsertaHistoricoDeudas(DateTime? aFecha = null)
        {
            try
            {
                var dc = new NegocioDataContext();
                var descuentos = DescuentoPorActividad;
                if (DescuentoPorActividad.Any())
                {
                    foreach (var descuentoPorActividad in descuentos)
                    {
                        var historico = new HistoricoDeuda
                        {
                            ActividadId = OrdenDeTrabajoID,
                            AgrupacionId = AgrupacionId,
                            Descripcion = string.Format("Se Descuenta deuda de {0} {1} - ({2}) ", TipoActividadString, ConsecutivoString, descuentoPorActividad.Descripcion),
                            TipoMonedaId = TipoMonedaId,
                            TipoIncrementoDeuda = (int)Enumerados.TipoGestionDeuda.RebajarDeuda,
                            importe = descuentoPorActividad.Importe,
                            Fecha = aFecha ?? DateTime.Now
                        }; dc.HistoricoDeuda.InsertOnSubmit(historico);
                        dc.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Devuelve 'Factura' u 'Orden de Trabajo según sea el caso'
        /// </summary>
        public string TipoActividadString
        {
            get
            {
                string tipo = ((Enumerados.TipoActividad)Enum.Parse(typeof(Enumerados.TipoActividad), TipoActividad.ToString()))
                   .StringValue();
                return tipo;
            }
        }

        public decimal ImporteCache
        {
            get
            {
                var importesDeFacturaEnFrontera = ImportesDeFacturaEnFrontera.FirstOrDefault(
                    c => c.TipoImporte == Enumerados.TipoImporteFacturas.Cache.ToEntero());
                if (importesDeFacturaEnFrontera != null)
                {
                    var importeCachet =
                        importesDeFacturaEnFrontera.ImporteUnitario ?? 0;
                    return importeCachet;
                }
                return 0;
            }
        }
        public decimal ImporteDieta
        {
            get
            {
                var importesDeFacturaEnFrontera = ImportesDeFacturaEnFrontera.FirstOrDefault(
                    c => c.TipoImporte == Enumerados.TipoImporteFacturas.Dieta.ToEntero());
                if (importesDeFacturaEnFrontera != null)
                {
                    var importeDieta =
                        importesDeFacturaEnFrontera.ImporteUnitario ?? 0;
                    return importeDieta;
                }
                return 0;
            }
        }

        public bool EstaPagada
        {
            get
            {
                return ((Estado == (int)Enumerados.EstadoOrdenDeTrabajo.PagadaCobrada) ||
                        Estado == (int)Enumerados.EstadoOrdenDeTrabajo.Pagada);
            }
        }

        public bool EstaCerrada
        {
            get
            {
                return ((Estado == (int)Enumerados.EstadoOrdenDeTrabajo.CerradaCobrada) ||
                      Estado == (int)Enumerados.EstadoOrdenDeTrabajo.Cerrada);
            }
        }
        /// <summary>
        /// Da el valor  de estado  a la orden de trabajo que le corresponde, Los cambios no se escriben aún en la base de datos
        /// </summary>
        public void SetEstado()
        {
            Estado = (short)Enumerados.EstadoOrdenDeTrabajo.Realizada;
            if (FechaLiquidacion != null) Estado = (short)Enumerados.EstadoOrdenDeTrabajo.Cerrada;
            if (!string.IsNullOrEmpty(Cheque)) Estado = (short)Enumerados.EstadoOrdenDeTrabajo.Cobrada;
            if (!string.IsNullOrEmpty(Cheque) && FechaLiquidacion != null) Estado = (short)Enumerados.EstadoOrdenDeTrabajo.CerradaCobrada;
            if (TieneNominaAsociada) Estado = (short)Enumerados.EstadoOrdenDeTrabajo.AsociadaNomina;
            if (!string.IsNullOrEmpty(Cheque) & TieneNominaAsociada) Estado = (short)Enumerados.EstadoOrdenDeTrabajo.AsociadaNominaCobrada;
            if (ChequePaga != null) Estado = (short)Enumerados.EstadoOrdenDeTrabajo.Pagada;
            if (ChequePaga != null && !string.IsNullOrEmpty(Cheque)) Estado = (short)Enumerados.EstadoOrdenDeTrabajo.PagadaCobrada;
        }

        public static OrdenDeTrabajo DuplicarActividad(OrdenDeTrabajo anActividad, NegocioDataContext aDc)
        {
            try
            {
                Enumerados.TipoActividad tipoActividad = (Enumerados.TipoActividad)Enum.Parse(typeof(Enumerados.TipoActividad),
                        anActividad.TipoActividad.ToString());
                OrdenDeTrabajo ordenNueva = new OrdenDeTrabajo
                {
                    OrdenDeTrabajoID = Guid.NewGuid(),
                    TipoMonedaId = anActividad.TipoMonedaId,
                    AgrupacionId = anActividad.AgrupacionId,
                    Anno = ConfiguracionGeneral.Anno,
                    CantidadActividades = anActividad.CantidadActividades,
                    ClienteQueContrataId = anActividad.ClienteQueContrataId,
                    Consecutivo = GetProximoConsecutivo(tipoActividad),
                    FechaConfeccion = DateTime.Today,
                    FechaFinalActividad = DateTime.Today,
                    FechaIncialActividad = DateTime.Today,
                    TipoActividad = anActividad.TipoActividad,
                    ImportePorActividad = anActividad.ImportePorActividad,
                    LugarDePresentacion = anActividad.LugarDePresentacion,
                    NumeroContrato = anActividad.ControlClientes.NumeroContratoString,
                    Estado = (int)Enumerados.EstadoOrdenDeTrabajo.Realizada,
                    EsPorCover = anActividad.EsPorCover

                };

                aDc.OrdenDeTrabajo.InsertOnSubmit(ordenNueva);
                aDc.SubmitChanges();
                if ((int)tipoActividad == (int)Enumerados.TipoActividad.Factura)
                {
                    foreach (var importesDeFacturaEnFrontera in anActividad.ImportesDeFacturaEnFrontera)
                    {
                        ordenNueva.ImportesDeFacturaEnFrontera.Add(new ImportesDeFacturaEnFrontera
                        {
                            ActividadId = ordenNueva.OrdenDeTrabajoID,
                            Cantidad = importesDeFacturaEnFrontera.Cantidad,
                            Descripción = importesDeFacturaEnFrontera.Descripción,
                            ImporteUnitario = importesDeFacturaEnFrontera.ImporteUnitario,
                            TipoImporte = importesDeFacturaEnFrontera.TipoImporte
                        });
                        aDc.SubmitChanges();
                    }

                }
                return ordenNueva;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public bool EliminaImportesDeFactura(ImportesDeFacturaEnFrontera importe = null)
        {
            try
            {
                var dc = new NegocioDataContext();
                var importes = dc.ImportesDeFacturaEnFrontera.Where(c => c.ActividadId == OrdenDeTrabajoID);
                if (importe != null)
                    importes = dc.ImportesDeFacturaEnFrontera.Where(c => c.ImporteFacturaID == importe.ImporteFacturaID);
                dc.ImportesDeFacturaEnFrontera.DeleteAllOnSubmit(importes);
                dc.SubmitChanges();
                return true;

            }
            catch (Exception)
            {
                Utils.MuestraError();
                return false;

                throw;
            }
        }

        public void EliminaCierre()
        {
            if (!EstaCerrada)
            {
                Utils.MuestraInformacion("Solo se puede eliminar el cierre de una orden con estado cerrado");
            }
            else
            {
                var dc = new NegocioDataContext();
                var orden = dc.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == OrdenDeTrabajoID);
                orden.FechaLiquidacion = null;
                orden.SetEstado();
                dc.SubmitChanges();

            }
        }

        public void SetFechaDeSolicitud(DateTime today)
        {
            var dc = new NegocioDataContext();
            var orden = dc.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == OrdenDeTrabajoID);
            orden.FechaSolicitudDePago = today;
            //orden.SetEstado();
            dc.SubmitChanges();
        }

        public static bool SalvaNota(string aNota, Guid ActividadId, NegocioDataContext aNegocioDataContext)
        {
            var actividad = GetOrdenDeTrabajoById(ActividadId, aNegocioDataContext);
            actividad.Nota = aNota;
            try
            {
                aNegocioDataContext.SubmitChanges();
                RegistraLogAccion(Enumerados.TipoAccion.SalvaNota,actividad._OrdenDeTrabajoID, "Se le inserta una nota a la actividad", aNegocioDataContext);
                return true;
            }
            catch (Exception)
            {
                Utils.MuestraError();
                return false;
            }
        }

        /// <summary>
        /// Devuelve el importe rebajado a una actividad determinada
        /// </summary>
        /// <returns></returns>
        public decimal GetDescuentos()
        {
            var Dc = new NegocioDataContext();
            var HistoricoDeudas = Dc.HistoricoDeuda.Where(c => c.ActividadId == OrdenDeTrabajoID && c.TipoIncrementoDeuda == Enumerados.TipoGestionDeuda.RebajarDeuda.ToEntero());
            if (HistoricoDeudas.Any())
            {
                var importe = HistoricoDeudas.Sum(c => c.importe);
                return importe;
            }
            return 0;
        }

        public bool EsFacturaDeProyecto => ProyectoAsociado != null;

        public Proyectos ProyectoAsociado
        {
            get
            {
                var proyectoAsociado = new NegocioDataContext().Proyectos.FirstOrDefault(c => c.FacturaDeProyectoId == OrdenDeTrabajoID);
                return proyectoAsociado;
            }


        }

        /// <summary>
        /// Inserta solamente a los integrantes de proyectos en la nomina
        /// de la factura creada al cerrar el proyecto </summary>
        public void InsertaParticipantesDeActividadDeProyecto()
        {

            try
            {
                var participantes = ProyectoAsociado.ParticipantesDeProyectos;
                var dc = new NegocioDataContext();
                foreach (var participante in participantes)
                {
                    var participanteDeActividad = new ParticipantesDeAcividad
                    {
                        ArtistaId = participante.ArtistaId,
                        ActividadId = OrdenDeTrabajoID

                    };
                    dc.ParticipantesDeAcividad.InsertOnSubmit(participanteDeActividad);
                    dc.SubmitChanges();
                }
            }
            catch (Exception)
            {
                Utils.MuestraError();
            }
        }


        public static void RegistraLogAccion(Enumerados.TipoAccion atIpoAccion, Guid anActividadId, string aDescripcion, NegocioDataContext aNegocioDataContext = null)
        {
            try
            {
                var dc = aNegocioDataContext ?? new NegocioDataContext();
                OrdenDeTrabajo Activdad = dc.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == anActividadId);
                LogOrdenDeTrabajo log = new LogOrdenDeTrabajo();
                log.Fecha = DateTime.Now;
                log.Descripcion = aDescripcion;
                log.TipoAccion = atIpoAccion.ToEntero();
                log.OrdenDeTrabajoId = anActividadId;
                log.UsuarioId = LoginHelper.UsuarioRegistrado.UsuarioID;
                dc.LogOrdenDeTrabajo.InsertOnSubmit(log);
                dc.SubmitChanges();
            }
            catch (Exception e)
            {
                Utils.InsertaLogError(e);
            }

        }


        public void RegistraLog(Enumerados.TipoAccion aTipoAccion, string aDescripcion, NegocioDataContext aNegocioDataContext = null)
        {
            OrdenDeTrabajo.RegistraLogAccion(aTipoAccion, OrdenDeTrabajoID, aDescripcion, aNegocioDataContext);
        }
        /// <summary>
        /// Devuelve la cuenta del cliente si esta registrada
        /// </summary>
        /// <returns>la cuenta si esta registrada sino devuelve null</returns>
        public CuentasBancariasDeCliente GetCuentaCLiente()
        {
            try
            {
              var cuenta =  this.ControlClientes.CuentasBancariasDeCliente.FirstOrDefault(c => c.TipoMonedaId == TipoMonedaId);
                return cuenta;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
