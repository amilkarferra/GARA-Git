using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication9
{
    partial class HistoricoDeuda
    {
        public bool UltimaInsertada
        {
            get
            {
              var ultimaDeuda =  new NegocioDataContext().HistoricoDeuda.Where(
                    c => c.AgrupacionId == AgrupacionId && c.TipoMonedaId == TipoMonedaId)
                    .OrderByDescending(c => c.Fecha).ThenByDescending(c=>c.HistoricoDeudaID)
                    .FirstOrDefault();
                return ultimaDeuda != null && ultimaDeuda.HistoricoDeudaID == HistoricoDeudaID;

            }
        }

        public decimal DeudaAnterior
        {
            
            get
            {
                decimal importeFinal = 0;
                var historicos =
                    new NegocioDataContext().HistoricoDeuda.Where(
                        c =>
                            c.AgrupacionId == AgrupacionId && c.TipoMonedaId == TipoMonedaId &&
                            c.HistoricoDeudaID < HistoricoDeudaID);

              //  var historicos = HistoricoDeuda.Where(c => c.AgrupacionId == AgrupacionID && c.TipoMonedaId == aTipoMonedaId);
                if (historicos.Any())
                {

                    var primerInicializacionHistorico = historicos.OrderByDescending(c=>c.HistoricoDeudaID).FirstOrDefault(c => c.EsInicializacion);
                    if (primerInicializacionHistorico != null)
                        historicos =historicos.Where(c => c.HistoricoDeudaID > primerInicializacionHistorico.HistoricoDeudaID);
                    var deudas =
                        historicos.Where(c => c.TipoIncrementoDeuda == Enumerados.TipoGestionDeuda.NuevaDeuda.ToEntero());
                    var deudasImporte = deudas.Any() ? deudas.Sum(c => c.importe) : 0;
                    var importeInicializacion = (primerInicializacionHistorico == null) ? 0 : primerInicializacionHistorico.importe;
                    deudasImporte += importeInicializacion;
                    var pagos = historicos.Where(c => c.TipoIncrementoDeuda == Enumerados.TipoGestionDeuda.RebajarDeuda.ToEntero());
                    var pagosImporte = pagos.Any()?pagos.Sum(c => c.importe):0;
                    return decimal.Round((deudasImporte - pagosImporte > 0 ? deudasImporte - pagosImporte : 0), 2);
                }
                return 0;

            }
        }
        /// <summary>
        /// Deuda que quedaría al aplicar la acción actual
        /// </summary>
        public decimal DeudaResultante
        {
            get
            {
               // var deudaAnterior = DeudaAnterior;
                if (TipoIncrementoDeuda == (int) Enumerados.TipoGestionDeuda.InicializarDeuda)
                    return importe.RedondeaDecimal();
                else if ((TipoIncrementoDeuda == (int) Enumerados.TipoGestionDeuda.NuevaDeuda))
                {
                    return (DeudaAnterior + importe).RedondeaDecimal();
                }
                else if ((TipoIncrementoDeuda == (int) Enumerados.TipoGestionDeuda.RebajarDeuda))
                {
                    return (DeudaAnterior - importe).RedondeaDecimal();
                }
                return 0;
            }
        }
    }
}
