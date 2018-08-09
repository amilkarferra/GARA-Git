using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraReports.UI;

namespace DXApplication9
{


    public class Tipos
    {
        public string Tipo { get; set; }
        public string Valor { get; set; }

    }

    



    //public class Globales
    //{
    //    public static SplashScreen GlobalSplashScreenLocal = new SplashScreen();


    //    public static SplashScreen GlobalSplashScreen
    //    {
    //        get
    //        {
    //            GlobalSplashScreenLocal.UseWaitCursor = true;
    //            return GlobalSplashScreenLocal;
    //        }
    //        set { GlobalSplashScreenLocal = value; }
    //    }
    //}

    public static class Cache
    {
        public static List<int> AgrupacionsIds { get; set; }
        public static bool LuegoDeBaja { get; set; }
    }

    public static class Enumerados
    {
        

        /// <summary>
        /// Convierte un enumerado determinado en una lista de Tipo - Valor
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Tipos> ListaDeEnumerados(Type type)
        {
            List<Tipos> lista = new List<Tipos>();
            Array descripciones = Enum.GetValues(type);

            foreach (var descripcion in descripciones)
            {
                var descripcion1 = (((Enum)(Enum.Parse(type, descripcion.ToString()))).StringValue());
                var valor = Convert.ToInt32(Enum.Parse(type, descripcion.ToString()));
                var tipo = new Tipos
                {
                    Tipo = descripcion1,
                    Valor = valor.ToString()
                };
                lista.Add(tipo);

            }
            return lista;
        }

        public static int ToEntero(this Enum value)
        {
            return Convert.ToInt32(value);
        }
        /// <summary>
        /// Devuelve el valor del Atributo Description del valor del enumerado
        /// Si no tiene dicho atributo devuelve el valor convertido a cadena.
        /// </summary>
        /// <param name="value">valor del enumerado Ej. TipoAcceso.Lectura</param>
        /// <returns></returns>
        public static string StringValue(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi == null) return String.Empty;

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static int Value(this Enum value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public enum TipoCargo
        {
            [Description("Artista")]
            Artista = 1,
            [Description("Apoyo")]
            Apoyo = 2
        }
        public enum TipoTramiteMigratorio
        {
            [Description("Confección de Pasaporte Ordinario")]
            ConfeccionDePasaporteOrdinario = 1,
            [Description("Confección de Pasaporte Oficial")]
            ConfeccionDePasaporteOficial = 2,
            [Description("Confección de Prorroga")]
            Prorroga = 3
        }
        public enum TipoParticipante
        {
            [Description("Integrante de La Agrupación")]
            Integrante = 1,
            [Description("Invitado del Proyecto")]
            Invitado = 2,

        }
        public enum Moneda
        {
            [Description("CUP")]
            Cup = 6,
            [Description("CUC")]
            Cuc = 4,
        }

        public enum TipoGestionDeuda
        {
            [Description("Nueva Deuda")]
            NuevaDeuda = 1,
            [Description("Inicializar Deuda")]
            InicializarDeuda = 2,
            [Description("Rebajar Deuda")]
            RebajarDeuda = 3,

        }


        public enum TipoProyecto
        {
            [Description("Tramite Migratorio")]
            TramiteMigratorio = 1,
            [Description("Contrato Comercial")]
            Comercial = 2,
            [Description("Promocional")]
            Promocional = 3,
            [Description("Proyecto Nacional")]
            ProyectoNacional = 4,
            [Description("Intercambio Cultural")]
            IntercambioCultural = 5

        }
        public enum TipoPasaporte
        {

            Ordinario,
            Oficial,
        }



        public enum ProyectoEnumerados
        {
            TipoProyectoMigratorio = 1,
            TipoParticipante = 2,
            TipoProyecto = 3,
            TipoPasaporte = 4,
            EstadoOrdenDeTrabajo = 5,
            Moneda = 6,
            TipoVinculoArtista = 7,
            RolesDelSistema = 8,
            TipoActivdad = 9,
            TipoCargo = 10

        }

        public enum EstadoOrdenDeTrabajo
        {
            [Description("Realizada")]
            Realizada = 1,
            [Description("Cerrada")]
            Cerrada = 2,
            [Description("Cancelada")]
            Cancelada = 3,
            [Description("Asociada a Nomina")]
            AsociadaNomina = 4,
            [Description("Cobrada")]
            Cobrada = 5,
            [Description("Pagada")]
            Pagada = 6,
            [Description("Asociada a Nomina y Cobrada")]
            AsociadaNominaCobrada = 7,
            [Description("Cerrada y Cobrada")]
            CerradaCobrada = 8,
            [Description("Pagada y Cobrada")]
            PagadaCobrada = 9
        }

        public enum EstadoContrato
        {
            [Description("Archivado")]
            Realizado = 1,
            [Description("Por Recoger")]
            PorRecoger = 2,
            [Description("Cancelado")]
            Cancelado = 3,
            [Description("Bloqueado")]
            Bloqueado = 4
        }

        public enum EstadoProyecto
        {
            [Description("Realizado")]
            Realizado = 1,
            [Description("Cerrado")]
            Cerrado = 2,
            [Description("Cancelado")]
            Cancelado = 3,
            [Description("Asociado a Nomina")]
            AsociadaNomina = 4,
            [Description("En Ejecución")]
            EnEjecucion = 5,
            [Description("Pendiente")]
            Pendiente = 6
        }

        public enum EstadoArtista
        {
            [Description("Activo")]
            Activo = 1,
            [Description("Desactivado")]
            Desactivado = 2,
        }
        public enum TipoVinculoDeArtista
        {
            [Description("Primer Vinculo")]
            PrimerVinculo,
            [Description("Segundo Vinculo")]
            SegundoVinculo
        }

        public enum TipoMovimiento
        {
            [Description("Alta")]
            Alta,
            [Description("Baja")]
            Baja
        }

        public enum Continentes
        {
            Norteamerica = 1,
            SudAmerica = 2,
            Asia = 3,
            Europa = 4,
            Africa = 5,
            Australia = 6
        }


        public enum TipoFormulario
        {
            [Description("Tipo de Monedas")]
            Moneda = 1,
            [Description("Registro de Clientes")]
            RegistroClientes = 2,
            [Description("Nomenclador de Estados de Contratos")]
            NomencladorEstadosContratos = 3

        }

        public enum Roles
        {
            [Description("Administrador del Sistema")]
            Administrador = 1,
            [Description("Operador de Recursos Humanos")]
            RecursosHumanos = 2,
            [Description("Económico")]
            Economico = 3,
            [Description("Juridico")]
            Juridico = 4,
            [Description("Comercial")]
            Comercial = 5,
            [Description("Super Administrador")]
            SuperAdministrador = 6

        }


        public enum TipoActividad
        {
            [Description("Orden de Trabajo")]
            OrdenDeTrabajo = 1,
            [Description("Factura")]
            Factura = 2,
            [Description("Proyecto")]
            Proyecto = 3,
            [Description("Producción Interna")]
            ProduccionInterna = 4
        }

        public enum Reportes
        {
            [Description("Integrantes de grupos")]
            ArtistaPorGruposGeneralXtraReport = 1,
            [Description("Catálogo de la agencia")]
            CatalogoXtraReport = 2,
            [Description("Cierre de Ordenes de Actividades")]
            CierreOtXtraReport = 3,
            [Description("Diactamen Laboral de Integrante")]
            DictamenXtraReport = 4,
            [Description("Entrega de Varias Ordenes o Facturas")]
            EntregaOtEconomiaXtraReport = 5,
            [Description("Registro de Exportaciones")]
            ExportacionesXtraReport = 6,
            [Description("Formaulción Económica del Proyecto Internacional")]
            FormulacionEconomicaProyecto = 7,
            [Description("Fundamentación de un proyecto")]
            HojaFundamentacionXtraReport = 8,
            [Description("Planilla de salida")]
            PlanillaSalida = 9,
            [Description("Lista de integrantes del proyecto")]
            ListadoIntegranteFirmaGerente = 10,
            [Description("Anexo con participantes del proyecto del ICM")]
            ModeloDeViaje = 11,
            [Description("Modelo de Viaje del ICM")]
            ModeloDeViajeV2 = 12,
            [Description("Nómina de una Actividad")]
            NominaXtraReport = 13,
            [Description("Tabla de Certificos de Integrantes")]
            TablaDeCertificos = 14,
            [Description("Certifico Individual")]
            CertificoIndividualXtraReport = 15,
            [Description("ONAT Certifico Individual")]
            CertificoIngresosPersonalesArtistaXtraReport = 16
        }

        public enum TipoImporteFacturas
        {
            [Description("Cache")]
            Cache = 1,
            [Description("Dieta")]
            Dieta = 2,

        }

        public enum Sexo
        {
            [Description("Feménino")]
            Femenino = 1,
            [Description("Mascúlino")]
            Masculino = 2,

        }

        public enum TipoAccion
        {
            [Description("Insertar")]
            Insertar = 1,
            [Description("Modificar")]
            Modificar = 2,
            [Description("Cambiar Estado")]
            Cancelar = 3,
            [Description("Cerrar")]
            Cerrar = 4,
            [Description("Se Elimina el cierre")]
            EliminarCierre = 5,
            [Description("Se solicita el pago")]
            SolicitaPago = 6,
            [Description("Se Imprime Actividad")]
            Imprimir = 7,
            [Description("Se Descansela la actividad")]
            Descancelar = 8,
            [Description("Salva Nota")]
            SalvaNota = 9,
            [Description("Inserta Pago del cliente")]
            InsertarPago = 10,
            [Description("Cancela Pago del cliente")]
            CancelaPago = 10,
            [Description("Inserta Cobro al artista")]
            InsertarCobro = 11,
            [Description("Cancela cobro del artista")]
            CancelaCobro = 12,
            [Description("Eliminar solicitud de pago")]
            EliminarSolicitudDePago = 13
        }

        //public static List<Tipos> EnumToList(this ProyectoEnumerados aEnumerados)
        //{
        //    List<Tipos> lista = new List<Tipos>();
        //    var enumerado = aEnumerados;
        //    switch (enumerado)
        //    {
        //        case ProyectoEnumerados.TipoCargo:
        //            lista.Add(new Tipos { Valor = ((int)TipoCargo.Apoyo).ToString(), Tipo = TipoCargo.Apoyo.StringValue() });
        //            lista.Add(new Tipos { Valor = ((int)TipoCargo.Artista).ToString(), Tipo = TipoCargo.Artista.StringValue() }); break;
        //        case ProyectoEnumerados.TipoActivdad:
        //            lista.Add(new Tipos { Valor = ((int)TipoActividad.OrdenDeTrabajo).ToString(), Tipo = TipoActividad.OrdenDeTrabajo.StringValue() });
        //            lista.Add(new Tipos { Valor = ((int)TipoActividad.Factura).ToString(), Tipo = TipoActividad.Factura.StringValue() });
        //            lista.Add(new Tipos { Valor = ((int)TipoActividad.Proyecto).ToString(), Tipo = TipoActividad.Proyecto.StringValue() });
        //            break;
        //        case ProyectoEnumerados.TipoProyectoMigratorio:
        //            lista.Add(new Tipos { Valor = ((int)TipoTramiteMigratorio.Prorroga).ToString(), Tipo = TipoTramiteMigratorio.Prorroga.StringValue() });
        //            lista.Add(new Tipos { Valor = ((int)TipoTramiteMigratorio.ConfeccionDePasaporteOrdinario).ToString(), Tipo = TipoTramiteMigratorio.ConfeccionDePasaporteOrdinario.StringValue() });
        //            lista.Add(new Tipos { Valor = ((int)TipoTramiteMigratorio.ConfeccionDePasaporteOficial).ToString(), Tipo = TipoTramiteMigratorio.ConfeccionDePasaporteOficial.StringValue() });
        //            break;
        //        case ProyectoEnumerados.TipoParticipante:
        //            lista.Add(new Tipos { Valor = TipoParticipante.Invitado.ToString(), Tipo = TipoParticipante.Invitado.StringValue() });
        //            lista.Add(new Tipos { Valor = TipoParticipante.Integrante.ToString(), Tipo = TipoParticipante.Integrante.StringValue() });
        //            break;

        //        case ProyectoEnumerados.TipoProyecto:
        //            {
        //                lista.Add(new Tipos { Tipo = TipoProyecto.Comercial.StringValue(), Valor = TipoProyecto.Comercial.ToString() });
        //                lista.Add(new Tipos { Tipo = TipoProyecto.TramiteMigratorio.StringValue(), Valor = TipoProyecto.TramiteMigratorio.ToString() });
        //                lista.Add(new Tipos { Tipo = TipoProyecto.Promocional.StringValue(), Valor = TipoProyecto.Promocional.ToString() });
        //                lista.Add(new Tipos { Tipo = TipoProyecto.ProyectoNacional.StringValue(), Valor = TipoProyecto.ProyectoNacional.ToString() });
        //                break;
        //            }
        //        case ProyectoEnumerados.TipoPasaporte:
        //            {
        //                lista.Add(new Tipos { Tipo = TipoPasaporte.Ordinario.StringValue(), Valor = TipoPasaporte.Ordinario.StringValue() });
        //                lista.Add(new Tipos { Tipo = TipoPasaporte.Oficial.StringValue(), Valor = TipoPasaporte.Oficial.StringValue() });
        //                break;
        //            }
        //        case ProyectoEnumerados.EstadoOrdenDeTrabajo:
        //            {
        //                lista.Add(new Tipos { Tipo = EstadoOrdenDeTrabajo.Realizada.StringValue(), Valor = ((int)EstadoOrdenDeTrabajo.Realizada).ToString() });
        //                lista.Add(new Tipos { Tipo = EstadoOrdenDeTrabajo.Cerrada.StringValue(), Valor = ((int)EstadoOrdenDeTrabajo.Cerrada).ToString() });
        //                lista.Add(new Tipos { Tipo = EstadoOrdenDeTrabajo.Cancelada.StringValue(), Valor = ((int)EstadoOrdenDeTrabajo.Cancelada).ToString() });
        //                lista.Add(new Tipos { Tipo = EstadoOrdenDeTrabajo.AsociadaNomina.StringValue(), Valor = ((int)EstadoOrdenDeTrabajo.AsociadaNomina).ToString() });
        //                lista.Add(new Tipos { Tipo = EstadoOrdenDeTrabajo.Cobrada.StringValue(), Valor = ((int)EstadoOrdenDeTrabajo.Cobrada).ToString() });
        //                lista.Add(new Tipos { Tipo = EstadoOrdenDeTrabajo.Pagada.StringValue(), Valor = ((int)EstadoOrdenDeTrabajo.Pagada).ToString() });
        //                lista.Add(new Tipos { Tipo = EstadoOrdenDeTrabajo.AsociadaNominaCobrada.StringValue(), Valor = ((int)EstadoOrdenDeTrabajo.AsociadaNominaCobrada).ToString() });
        //                lista.Add(new Tipos { Tipo = EstadoOrdenDeTrabajo.CerradaCobrada.StringValue(), Valor = ((int)EstadoOrdenDeTrabajo.CerradaCobrada).ToString() });
        //                lista.Add(new Tipos { Tipo = EstadoOrdenDeTrabajo.PagadaCobrada.StringValue(), Valor = ((int)EstadoOrdenDeTrabajo.PagadaCobrada).ToString() });

        //                break;
        //            }
        //        case ProyectoEnumerados.Moneda:
        //            lista.Add(new Tipos { Valor = ((int)Moneda.Cup).ToString(), Tipo = Moneda.Cup.StringValue() });
        //            lista.Add(new Tipos { Valor = ((int)Moneda.Cuc).ToString(), Tipo = Moneda.Cuc.StringValue() });
        //            break;
        //        case ProyectoEnumerados.TipoVinculoArtista:
        //            lista.Add(new Tipos { Tipo = TipoVinculoDeArtista.PrimerVinculo.StringValue(), Valor = ((int)TipoVinculoDeArtista.PrimerVinculo).ToString() });
        //            lista.Add(new Tipos { Tipo = TipoVinculoDeArtista.SegundoVinculo.StringValue(), Valor = ((int)TipoVinculoDeArtista.SegundoVinculo).ToString() });
        //            break;
        //        case ProyectoEnumerados.RolesDelSistema:
        //            lista.Add(new Tipos { Tipo = Roles.Administrador.StringValue(), Valor = ((int)Roles.Administrador).ToString() });
        //            lista.Add(new Tipos { Tipo = Roles.RecursosHumanos.StringValue(), Valor = ((int)Roles.RecursosHumanos).ToString() });
        //            lista.Add(new Tipos { Tipo = Roles.Juridico.StringValue(), Valor = ((int)Roles.Juridico).ToString() });
        //            lista.Add(new Tipos { Tipo = Roles.Economico.StringValue(), Valor = ((int)Roles.Economico).ToString() });
        //            lista.Add(new Tipos { Tipo = Roles.Comercial.StringValue(), Valor = ((int)Roles.Comercial).ToString() });
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //    return lista;
        //}




    }

    public static class Utils
    {
        private static NegocioDataContext _globalDataContext = new NegocioDataContext();
        private static int[] _agrupacionesIds = null;

        public static DateTime PrimerDiaAnnoEnCurso
        {
            get
            {
                DateTime _desde = Convert.ToDateTime(string.Format("1/1/{0}", ConfiguracionGeneral.Anno));
                return _desde;
            }
        }
        public static DateTime UltimoDiaAnnoEnCurso
        {
            get
            {
                DateTime _hasta = Convert.ToDateTime(string.Format("31/12/{0}", ConfiguracionGeneral.Anno));
                return _hasta;
            }
        }

        /// <summary>
        /// Conforma una oracion de una palabra separada por mayusculas
        /// </summary>
        /// <example>si PalabraDeEjemplo devuelve la oracion 'Palabra De Ejemplo' </example>
        /// <param name="aWord"></param>
        /// <returns></returns>
        public static string SplitUpperCase(string aWord)
        {
            if (String.IsNullOrEmpty(aWord)) return "";
            bool primeraLetra = false;
            string sentence = null;
            var array = aWord.ToCharArray();
            foreach (char c in array)
            {
                if (c.ToString().ToUpper().CompareTo(c.ToString()) == 0) //Indica que es Mayuscula
                {
                    sentence += string.Format("{0} {1}", " ", primeraLetra ? c.ToString() : c.ToString().ToLower());
                }
                else
                {
                    sentence += c;
                }

            }
            return sentence.Trim().Replace("confeccion", "confección");
        }
        /// <summary>
        /// Pone en el datasource un enumerado del proyecto, AUN EN PRUEBA
        /// </summary>
        /// <param name="lookUpEdit"></param>
        /// <param name="type"></param>
        public static void SetEnum(this LookUpEdit lookUpEdit, Type type)
        {
            try
            {
                lookUpEdit.Properties.DataSource = Enumerados.ListaDeEnumerados(type);
                lookUpEdit.Properties.DisplayMember = "Tipo";
                lookUpEdit.Properties.ValueMember = "Valor";
            }
            catch
            {
                // ignored
            }
        }
        public static NegocioDataContext GlobalDataContext
        {
            get { return _globalDataContext; }
            set { _globalDataContext = value; }
        }


        public static int[] AgrupacionesTemporales
        {
            get { return _agrupacionesIds; }
            set { _agrupacionesIds = value; }
        }

        public static IList<T> GetAllControlsRecusrvive<T>(Control control) where T : Control
        {
            var rtn = new List<T>();
            foreach (Control item in control.Controls)
            {
                var ctr = item as T;
                if (ctr != null)
                {
                    rtn.Add(ctr);
                }
                else
                {
                    rtn.AddRange(GetAllControlsRecusrvive<T>(item));
                }

            }
            return rtn;
        }


        public static string EncodePassword(string originalPassword)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Muestra un mensaje de error en pantalla usando el XtramessageBox
        /// </summary>
        /// <param name="aMensaje"></param>
        public static void MuestraError(string aMensaje = "Error en la Acción")
        {
            XtraMessageBox.AllowHtmlText = true;
            XtraMessageBox.Show(aMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra un mensaje Informativo en pantalla usando el XtramessageBox
        /// 
        /// </summary>
        /// <param name="aMensaje"></param>
        public static void MuestraInformacion(string aMensaje)
        {
            XtraMessageBox.AllowHtmlText = true;
            XtraMessageBox.Show(aMensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Redonde a 2 cifras decimales
        /// </summary>
        /// <param name="importe"></param>
        /// <returns></returns>
        public static decimal RedondeaDecimal(this decimal importe)
        {
            return Decimal.Round(importe, 2);
        }

        public static void MuestraMensajeOk()
        {
            MuestraInformacion("Acción exitosa");
        }
        /// <summary>
        /// Imprime varias copias de un reporte determinado
        /// </summary>
        /// <param name="aXtraReport">un reporte de tipo XTRAREPORT</param>
        /// <param name="aCant">cantidad de copias a imprimir</param>
        public static void PrintReport(XtraReport aXtraReport, int aCant)
        {
            try
            {
                ReportPrintTool pt = new ReportPrintTool(aXtraReport);
                pt.PrinterSettings.Copies = (short)aCant;
                pt.Print();
            }
            catch (Exception)
            {
                MuestraError();
            }
        }

        public static void InsertaLogError(Exception exception)
        {
            var dc = new NegocioDataContext();
            var logError = new LogAction();
            //TODO implementar y estudiar el objeto exception para que se pueda implementar bien este log
        }
    }
    public class NumLetra
    {
        private String[] AUnidades =
        {
            "", "un ", "dos ", "tres ", "cuatro ", "cinco ", "seis ", "siete ", "ocho ",
            "nueve "
        };

        private String[] ADecenas =
        {
            "diez ", "once ", "doce ", "trece ", "catorce ", "quince ", "dieciseis ",
            "diecisiete ", "dieciocho ", "diecinueve", "veinte ", "treinta ", "cuarenta ",
            "cincuenta ", "sesenta ", "setenta ", "ochenta ", "noventa "
        };

        private String[] ACentenas =
        {
            "", "ciento ", "doscientos ", "trecientos ", "cuatrocientos ", "quinientos ", "seiscientos ",
            "setecientos ", "ochocientos ", "novecientos "
        };

        private Regex AR;

        public String Convertir(String numero, bool mayusculas)
        {

            String literal = "";
            String parteDecimal;
            //si el numero utiliza (.) en lugar de (,) -> se reemplaza
            numero = numero.Replace(".", ",");

            //si el numero no tiene parte decimal, se le agrega ,00
            if (numero.IndexOf(",") == -1)
            {
                numero = numero + ",00";
            }
            //se valida formato de entrada -> 0,00 y 999 999 999,00
            AR = new Regex(@"\d{1,9},\d{1,2}");
            MatchCollection mc = AR.Matches(numero);
            if (mc.Count > 0)
            {
                //se divide el numero 0000000,00 -> entero y decimal
                String[] num = numero.Split(',');

                //de da formato al numero decimal
                parteDecimal = num[1] + "/100 ";
                //se convierte el numero a literal
                if (int.Parse(num[0]) == 0)
                {
                    //si el valor es cero                
                    literal = "cero ";
                }
                else if (int.Parse(num[0]) > 999999)
                {
                    //si es millon
                    literal = GetMillones(num[0]);
                }
                else if (int.Parse(num[0]) > 999)
                {
                    //si es miles
                    literal = GetMiles(num[0]);
                }
                else if (int.Parse(num[0]) > 99)
                {
                    //si es centena
                    literal = GetCentenas(num[0]);
                }
                else if (int.Parse(num[0]) > 9)
                {
                    //si es decena
                    literal = GetDecenas(num[0]);
                }
                else
                {
                    //sino unidades -> 9
                    literal = GetUnidades(num[0]);
                }
                //devuelve el resultado en mayusculas o minusculas
                if (mayusculas)
                {
                    return (literal + parteDecimal).ToUpper();
                }
                else
                {
                    return (literal + parteDecimal);
                }
            }
            else
            {
                //error, no se puede convertir
                return literal = null;
            }
        }

        /* funciones para convertir los numeros a literales */

        private String GetUnidades(String numero)
        {
            // 1 - 9            
            //si tuviera algun 0 antes se lo quita -> 09 = 9 o 009=9
            String num = numero.Substring(numero.Length - 1);
            return AUnidades[int.Parse(num)];
        }

        private String GetDecenas(String num)
        {
            // 99                        
            int n = int.Parse(num);
            if (n < 10)
            {
                //para casos como -> 01 - 09
                return GetUnidades(num);
            }
            else if (n > 19)
            {
                //para 20...99
                String u = GetUnidades(num);
                if (u.Equals(""))
                {
                    //para 20,30,40,50,60,70,80,90
                    return ADecenas[int.Parse(num.Substring(0, 1)) + 8];
                }
                else
                {
                    return ADecenas[int.Parse(num.Substring(0, 1)) + 8] + "y " + u;
                }
            }
            else
            {
                //numeros entre 11 y 19
                return ADecenas[n - 10];
            }
        }

        private String GetCentenas(String num)
        {
            // 999 o 099
            if (int.Parse(num) > 99)
            {
                //es centena
                if (int.Parse(num) == 100)
                {
                    //caso especial
                    return " cien ";
                }
                else
                {
                    return ACentenas[int.Parse(num.Substring(0, 1))] + GetDecenas(num.Substring(1));
                }
            }
            else
            {
                //por Ej. 099 
                //se quita el 0 antes de convertir a decenas
                return GetDecenas(int.Parse(num) + "");
            }
        }

        private String GetMiles(String numero)
        {
            // 999 999
            //obtiene las centenas
            String c = numero.Substring(numero.Length - 3);
            //obtiene los miles
            String m = numero.Substring(0, numero.Length - 3);
            String n = "";
            //se comprueba que miles tenga valor entero
            if (int.Parse(m) > 0)
            {
                n = GetCentenas(m);
                return n + "mil " + GetCentenas(c);
            }
            else
            {
                return "" + GetCentenas(c);
            }

        }

        private String GetMillones(String numero)
        {
            //000 000 000        
            //se obtiene los miles
            String miles = numero.Substring(numero.Length - 6);
            //se obtiene los millones
            String millon = numero.Substring(0, numero.Length - 6);
            String n = "";
            if (millon.Length > 1)
            {
                n = GetCentenas(millon) + "millones ";
            }
            else
            {
                n = GetUnidades(millon) + "millon ";
            }
            return n + GetMiles(miles);
        }

        //private void ConformaListaEnumerados(Type anEnumType )
        //{
        //    List<anEnumType> listaDeEnumeradosClasses = new List<EnumeradosReporteClass>();
        //    Array descripciones = Enum.GetValues(typeof(Enumerados.Reportes));

        //    foreach (var descripcion in descripciones)
        //    {
        //        var descripcion1 =
        //            ((Enumerados.Reportes)(Enum.Parse(, descripcion.ToString())))
        //                .StringValue();
        //        var valor = Convert.ToInt32(Enum.Parse(typeof(Enumerados.Reportes), descripcion.ToString()));
        //        //TODO verificar en la base de datos si no está en la tabla Reportes el que se corresponde 
        //        //TODO al identificador y de no estar insertarlo, de lo contrario mantenerlo
        //        if (!_GlobalDataContext.Reportes.Any(c => c.IdentificadorReporte == valor))
        //        {
        //            Reportes reporte = new Reportes
        //            {
        //                Descripcion = descripcion1,
        //                IdentificadorReporte = valor,
        //                NombreReporte = descripcion.ToString()
        //            };
        //            _GlobalDataContext.Reportes.InsertOnSubmit(reporte);
        //            _GlobalDataContext.SubmitChanges();
        //Enum.pa
        //var a = typeof()
        //return 
        //        }

    }

  






}









