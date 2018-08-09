using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.XtraRichEdit.Model.History;
using DXApplication9.ReportesSistema;

namespace DXApplication9
{
    public partial class Artista
    {
        public bool Activo
        {
            get
            {
                if (Estado == null) return true;
                return Estado == 1;

            }
        }

        public string DireccionSegura => Direccion??"";
        public string CarnetIdentidadSeguro => CarnetIdentidad??"";

        /// <summary>
        /// Arreglo de identificadores de agrupaciones al cual pertenece el integrante
        /// </summary>
        private int[] AAgrupacionesIds = null;

        public string AgrupacionesString
        {
            get
            {
                var nombreAgrupaciones =
                    AgrupacionDeArtista.Where(c => c.ArtistaId == ArtistaID).Select(c => c.Agrupacion.Nombre);
                string agrupaciones = "";
                foreach (string nombre in nombreAgrupaciones)
                {
                    agrupaciones += ", " + nombre;
                }
                return agrupaciones.Acabado();
            }

        }

        public AgrupacionDeArtista PrimerVinculoAgrupacionDeArtista
        {
            get
            {
                var primerVinculo = AgrupacionDeArtista.FirstOrDefault(
                    c => c.TipoVinculo == (int)Enumerados.TipoVinculoDeArtista.PrimerVinculo && c.FechaBaja == null);
                if (primerVinculo != null)
                    return primerVinculo;
                primerVinculo = AgrupacionDeArtista.FirstOrDefault(c => c.FechaBaja != null);
                return primerVinculo;
            }
        }

        public int[] AgrupacionesId
        {
            get { return AAgrupacionesIds; }
            set { AAgrupacionesIds = value; }
        }

        public ParticipantesDeProyectos ToParticipante(Guid aProyectoId, NegocioDataContext aNegocioDataContext = null)
        {
            try
            {
                NegocioDataContext dataContext = aNegocioDataContext ?? new NegocioDataContext();
                Proyectos proyecto = dataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == aProyectoId);
                if (proyecto != null)
                {

                    // var _FirstOrDefault = AgrupacionDeArtista.FirstOrDefault(c => c.TipoVinculo ==(int)Enumerados.TipoVinculoDeArtista.PrimerVinculo);
                    // if (_FirstOrDefault != null) {
                    ParticipantesDeProyectos participante = new ParticipantesDeProyectos();
                    {
                        //AgrupacionDeArtista agrupacionArtista = dataContext.AgrupacionDeArtista.FirstOrDefault(c => c.ArtistaId == ArtistaID && c.AgrupacionId == proyecto.AgrupacionId);
                        participante.ProyectoId = proyecto.ProyectoID;
                        participante.ArtistaId = ArtistaID;
                        var primerVinculo = PrimerVinculoAgrupacionDeArtista ?? AgrupacionDeArtista.FirstOrDefault(c => c.FechaBaja == null);
                        participante.EsInvitado = !(primerVinculo.AgrupacionId == proyecto.AgrupacionId);
                        //participante.TipoParticipante = GetTipoParticipante(agrupacionArtista.AgrupacionDeArtistaID).ToString();
                        participante.AgrupacionId =
                            AgrupacionDeArtista.Any(
                                c =>
                                    c.TipoVinculo == Convert.ToInt32(Enumerados.TipoVinculoDeArtista.PrimerVinculo) &&
                                    c.FechaBaja != null)
                                ? AgrupacionDeArtista.FirstOrDefault(
                                    c => c.TipoVinculo == Convert.ToInt32(Enumerados.TipoVinculoDeArtista.PrimerVinculo))
                                    .AgrupacionId
                                : proyecto.AgrupacionId;
                        participante.Desempenno = primerVinculo.AbrevDesempenno;

                    };
                    if (Pasaportes.Any())
                    {
                        participante.NumeroDePasaporte = Pasaportes.FirstOrDefault().NumeroPasaporte;
                    }
                    return participante;
                    //}
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        public string NombreCompleto
        {
            get { return string.Format("{0} {1} {2}", Nombre.Trim(), PrimerApellido.Trim(), SegundoApellido.Trim()); }
        }

        public Image BitmapImagen
        {
            get
            {
                if (Foto != null)
                {
                    byte[] pictBinary = this.Foto.ToArray();
                    MemoryStream ms = new MemoryStream(pictBinary);
                    Bitmap imagenBitmap = new Bitmap(ms);
                    return imagenBitmap;
                }
                return null;
            }
            set
            {
                Binary binary;
                using (MemoryStream ms = new MemoryStream())
                {
                    value.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    binary = new Binary(ms.GetBuffer());
                    byte[] imagen = binary.ToArray();
                    Foto = imagen;

                }

            }

        }

        public bool TieneDatosHistoricos
        {
            get
            {
                using (NegocioDataContext dataContext = new NegocioDataContext())
                {
                    return (ParticipantesDeAcividad.Any() || ParticipantesDeProyectos.Any());
                }

            }
        }

        public DateTime FechaDeNacimiento
        {

            get
            {

                //76101102262
                var anno = CarnetIdentidad.Substring(0, 2);
                var mes = CarnetIdentidad.Substring(2, 2);
                var dia = CarnetIdentidad.Substring(4, 2);
                var fechaNacimiento = Convert.ToDateTime(string.Format("{0}/{1}/{2}", dia, mes, anno));
                return fechaNacimiento;
            }
        }

        public int Edad
        {
            get
            {
                try
                {
                    var annos = DateTime.Now.Year - FechaDeNacimiento.Year;
                    if (DateTime.Now.Month <= FechaDeNacimiento.Month)
                        if (DateTime.Now.Day <= FechaDeNacimiento.Day)
                            annos += 1;
                    return annos - 1;
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }

        public string Sexo
        {
            get
            {
                try
                {
                    var Ident = CarnetIdentidad.Substring(9, 1);
                    var sex = Convert.ToInt32(Ident) % 2 == 0 ? Enumerados.Sexo.Masculino.StringValue() : Enumerados.Sexo.Femenino.StringValue();
                    return sex;
                }
                catch (Exception)
                {

                    return String.Empty;
                }
            }
        }
        public List<TrayectoriaArtista> TrayectoriasActuales
        {

            get
            {
                using (NegocioDataContext dataContext = new NegocioDataContext())
                {
                    var trayectorias =
                        AgrupacionDeArtista.Where(c => c.FechaBaja == null).Select(c => new TrayectoriaArtista
                        {
                            Agrupacion = c.Agrupacion.Nombre,
                            Centro = DynamicQueryable.FirstOrDefault(dataContext.ConfiguracionGeneral).Agencia,
                            Desde = Convert.ToDateTime(c.FechaAlta),
                            ArtistaId = ArtistaID,
                            Desempenno =
                                String.Format("{0}{1}", c.AbrevDesempenno,
                                    c.TipoVinculo == (int)Enumerados.TipoVinculoDeArtista.SegundoVinculo
                                        ? " (Doble Vinculo)"
                                        : "")
                        });

                    return trayectorias.ToList();
                }
            }
        }

        /// <summary>
        /// Devuelve Lista de los artistas sin incluir las bajas en una fecha determinada
        /// </summary>
        /// <param name="anAgrupacionId"></param>
        /// <returns></returns>
        public static List<Artista> GetActiveList(int anAgrupacionId, NegocioDataContext aDataContext = null)
        {
            try
            {
                NegocioDataContext dataContext = aDataContext ?? new NegocioDataContext();
                List<Artista> list =
                    dataContext.AgrupacionDeArtista.Where(
                        c => c.AgrupacionId == anAgrupacionId && c.FechaBaja < Convert.ToDateTime("1/1/2014"))
                        .Select(c => c.Artista)
                        .ToList();
                return list;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        public static void SetTemporalAgrupaciones(int[] anAgrupacionesIds)
        {

        }

        public static void InsertAgrupacion(int agrupacionId, int artistaId)
        {
            throw new NotImplementedException();
        }

        public decimal GetIngresosPersonales(int TipoMonedaId, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                var dc = new NegocioDataContext();
                decimal importe = 0;
                var actividades = dc.ParticipantesDeAcividad.Where(c => c.ArtistaId == ArtistaID && c.OrdenDeTrabajo.TipoMonedaId == TipoMonedaId && c.OrdenDeTrabajo.Nomina.FechaEmision >= FechaInicial && c.OrdenDeTrabajo.Nomina.FechaEmision <= FechaFinal);
                if (!actividades.Any()) return 0;
                importe = Convert.ToDecimal(actividades.Sum(c => c.Importe)).RedondeaDecimal();
                return importe.RedondeaDecimal();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// Devuelve la suma de los Ingresos a la agencia  de las actividades que ha trabajado un artista
        /// en un rango de fecha determinado y en una moneda determinada
        /// </summary>
        /// <param name="TipoMonedaId"></param>
        /// <param name="FechaInicial"></param>
        /// <param name="FechaFinal"></param>
        /// <returns></returns>
        public decimal GetImporteDeContratoDeServicio(int TipoMonedaId, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                var dc = new NegocioDataContext();
                decimal importe = 0;
                var ParticipanteActividade = dc.ParticipantesDeAcividad.Where(c => c.ArtistaId == ArtistaID && c.OrdenDeTrabajo.TipoMonedaId == TipoMonedaId && c.OrdenDeTrabajo.Nomina.FechaEmision >= FechaInicial && c.OrdenDeTrabajo.Nomina.FechaEmision <= FechaFinal);
                if (!ParticipanteActividade.Any()) return 0;

                foreach (var participanteActividad in ParticipanteActividade)
                {
                    importe += participanteActividad.ImporteContrato;
                }
                //importe = Convert.ToDecimal(actividades.Sum(c => c.ImporteIngresaAgencia)).RedondeaDecimal();
                return importe.RedondeaDecimal();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public decimal GetImportesDeParticipacionDeEmpresa(int tipoMonedaId, DateTime fechaIncial, DateTime fechaFinal)
        {
            try
            {
                var dc = new NegocioDataContext(); decimal importe = 0;

                //var importeParticipaEmpresa = Importe / OrdenDeTrabajo.ImporteConDescuento * 100 * OrdenDeTrabajo.ImporteIngresaAgencia / 100;


                IQueryable<ParticipantesDeAcividad> ImportesActividades =
                    dc.ParticipantesDeAcividad.Where(
                        c =>
                            c.ArtistaId == ArtistaID && c.OrdenDeTrabajo.TipoMonedaId == tipoMonedaId &&
                            c.OrdenDeTrabajo.Nomina.FechaEmision >= fechaIncial &&
                            c.OrdenDeTrabajo.Nomina.FechaEmision <= fechaFinal);

                foreach (var participantesDeAcividad in ImportesActividades)
                {
                    importe += participantesDeAcividad.ParticipacionDeEmpresaDeActividad;
                }


                return importe.RedondeaDecimal();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public decimal GetAporteOnat(int tipoMonedaId, DateTime fechaInicial, DateTime fechaFinal)
        {
            var dc = new NegocioDataContext(); 

            try
            {
                var importe = dc.ParticipantesDeAcividad.Where(
                        c =>
                            c.ArtistaId == ArtistaID && c.OrdenDeTrabajo.TipoMonedaId == tipoMonedaId &&
                            c.OrdenDeTrabajo.Nomina.FechaEmision >= fechaInicial &&
                            c.OrdenDeTrabajo.Nomina.FechaEmision <= fechaFinal).Sum(c => c.Importe * 5 / 100)
                    .RedondeaDecimal();
                return importe;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public string DireccionCompleta
        {
            get
            {
                try
                {
                    var direccion = string.Format("{0}, {1}, {2}", Direccion, Municipio.Descripcion, Municipio.Provincia.Descripcion);
                    return direccion;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }

        public DateTime FechaAltaAgrupacionActual
        {
            get
            {
                try
                {
                    var fechaAlta = PrimerVinculoAgrupacionDeArtista.FechaAlta;
                    return (DateTime)fechaAlta;
                }
                catch (Exception)
                {

                    return DateTime.Now;
                }
            }
        }
    }
}

