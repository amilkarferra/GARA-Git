using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication9
{
    partial class TipoMoneda
    {
       public  static TipoMoneda MonedaPrincipal
        {
            get
            {
                return (new NegocioDataContext()).TipoMoneda.FirstOrDefault(c => (bool)c.EsMonedaPrincipal);
            }
        }

        internal static TipoMoneda GetMonedaById(int Id)
        {
            return (new NegocioDataContext()).TipoMoneda.FirstOrDefault(c => c.TipoMonedaID==Id);
        }
    }
}
