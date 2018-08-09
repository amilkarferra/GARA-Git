using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication9
{
  public class OnatDeUA
    {

        public string IntgranteNombre { get; set; }
        public string IntgranteDireccion { get; set; }
        public string IntgranteMunicipio { get; set; }
        public string IntgranteProvincia { get; set; }
        public decimal ImporteContrato { get; set; }
        public decimal Ingreso { get; set; }
        public decimal Retenido { get; set; }
        public decimal ImporteParticipacionDeEmpresa { get; set; }
        public string CarnetDeIdentidad { get; set; }
        public decimal PorcientoParticipacion
        {
            get
            {
                try
                {
                    var importe = decimal.Round((ImporteParticipacionDeEmpresa * 100 /
                                                 ImporteContrato).RedondeaDecimal(), 2);
                    return importe;
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }




    }
}
