using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using DevExpress.DataAccess.Native.ExpressionEditor;
using DXApplication9.ReportesSistema;

namespace DXApplication9
{
    partial class Agrupacion
    {
        public Image BitmapImagen
        {
            get
            {
                if (Logo != null)
                {
                    byte[] pictBinary = this.Logo.ToArray();
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
                    Logo = imagen;

                }

            }

        }

        public decimal GetDeuda(int aTipoMonedaId)
        {

            var historicos = HistoricoDeuda.Where(c => c.AgrupacionId == AgrupacionID && c.TipoMonedaId == aTipoMonedaId);
            if (historicos.Any())
            {
                var primerInicializacionHistorico = historicos.LastOrDefault(c => c.EsInicializacion);
                if (primerInicializacionHistorico != null)
                    historicos =
                        historicos.Where(c => c.HistoricoDeudaID > primerInicializacionHistorico.HistoricoDeudaID);
                var deudas = historicos.Where(c => c.TipoIncrementoDeuda == Enumerados.TipoGestionDeuda.NuevaDeuda.ToEntero())
                    .Sum(c => c.importe) +
                                 (primerInicializacionHistorico == null ? 0 : primerInicializacionHistorico.importe);
                var pagos = historicos.Where(c => c.TipoIncrementoDeuda == Enumerados.TipoGestionDeuda.RebajarDeuda.ToEntero())
                    .Sum(c => c.importe);
                return decimal.Round((deudas - pagos > 0 ? deudas - pagos : 0), 2);
            }
            return 0;


        }

        public static IQueryable GetOnatDeUnidadArtistica(int agrupacionId, DateTime fechaFinal, DateTime fechaInicial, int tipoMonedaId)
        {
            try
            {
                List<OnatDeUA> lista = new List<OnatDeUA>();
                var dc = new NegocioDataContext();
                var actividadesImplicadasIDs = dc.Nomina
                    .Where(c => c.AgrupacionId == agrupacionId && c.OrdenDeTrabajo.TipoMonedaId == tipoMonedaId && c.FechaEmision >= fechaInicial && c.FechaEmision <= fechaFinal)
                    .Select(c => c.OrdenDeTrabajo.OrdenDeTrabajoID);
                var listaParticipantes = dc.ParticipantesDeAcividad
                    .Where(c => actividadesImplicadasIDs.Contains(c.OrdenDeTrabajo.OrdenDeTrabajoID)).AsEnumerable()
                    .DistinctBy(c => c.ArtistaId);

                foreach (var participantesDeAcividad in listaParticipantes.OrderBy(c => c.Artista.Nombre))
                {
                    var artista = participantesDeAcividad.Artista;
                    OnatDeUA onatDeUa = new OnatDeUA();
                    onatDeUa.IntgranteNombre = artista.NombreCompleto;
                    onatDeUa.IntgranteDireccion = artista.Direccion.Trim();
                    onatDeUa.IntgranteMunicipio = artista.Municipio.Descripcion.Trim();
                    onatDeUa.IntgranteProvincia = artista.Municipio.Provincia.Descripcion.Trim();
                    onatDeUa.ImporteParticipacionDeEmpresa =
                        artista.GetImportesDeParticipacionDeEmpresa(tipoMonedaId, fechaInicial, fechaFinal);
                    onatDeUa.ImporteContrato =
                        artista.GetImporteDeContratoDeServicio(tipoMonedaId, fechaInicial, fechaFinal);
                    onatDeUa.CarnetDeIdentidad = artista.CarnetIdentidad;
                    onatDeUa.Ingreso = artista.GetIngresosPersonales(tipoMonedaId, fechaInicial, fechaFinal);
                    onatDeUa.Retenido = artista.GetAporteOnat(tipoMonedaId, fechaInicial, fechaFinal);

                    lista.Add(onatDeUa);
                }
                return lista.AsQueryable();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Agrupacion GetAgrupacionById(int agrupacionId)
        {
            return new NegocioDataContext().Agrupacion.FirstOrDefault(c => c.AgrupacionID == agrupacionId);
        }
    }
}
