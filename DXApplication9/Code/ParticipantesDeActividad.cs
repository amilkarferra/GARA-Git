using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication9
{
    partial class ParticipantesDeAcividad
    {
        public decimal ParticipacionDeEmpresaDeActividad
        {get
            {
                //Todo Verificar bien si por fin el importe de la Onat estara antes o despues de la deuda
                //var porcientoParticipacionArtista = Importe/OrdenDeTrabajo.ImporteConDescuento*100;
                var importeParticipaEmpresa = ImporteContrato*OrdenDeTrabajo.PorcientoUtilidadEmpresa/100;
                return importeParticipaEmpresa;
            }
        }

        public decimal IndiceParticipacion
        {
            get
            {
                //Todo Verificar bien si por fin el importe de la Onat estara antes o despues de la deuda
                var indiceParticipacionArtista = Importe / OrdenDeTrabajo.ImporteConDescuento;
                return indiceParticipacionArtista.RedondeaDecimal();
            }
        }

        /// <summary>
        /// Importe que se refleja en la ONAT  
        /// </summary>
        public decimal ImporteContrato
        {
            get
            {
                if (OrdenDeTrabajo.PorCientoUnidadArtistica != null)
                {
                    var importeContrato = 100 * Importe / Convert.ToInt32(OrdenDeTrabajo.PorCientoUnidadArtistica);
                    return importeContrato;
                }
                return 0;
                ////Todo Verificar bien si por fin el importe de la Onat estara antes o despues de la deuda
                //var porcientoParticipacionArtista = Importe / OrdenDeTrabajo.ImporteConDescuento * 100;
                //var importeParticipaEmpresa = Importe / OrdenDeTrabajo.ImporteUnidadArtisticaSinDescuento * OrdenDeTrabajo.ImporteIngresaAgencia;
                //return importeParticipaEmpresa;
            }
        }
    }
}
