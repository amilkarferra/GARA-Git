using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication9
{
    public partial class Presentacion
    {
      public  string FechaString
        {
            get { Presentacion presentacion = this;
            if (presentacion.Hasta == null || presentacion.Desde == presentacion.Hasta)
            {
                if (presentacion.Desde != null)
                    return presentacion.Desde.Value.ToShortDateString();
                return "";
            }
            else
            {
                if (presentacion.Desde != null)
                    return string.Format("Desde el {0} hasta el {1}",presentacion.Desde.Value.ToShortDateString(), presentacion.Hasta.Value.ToShortDateString());
            }
            return (presentacion.Hasta == null || presentacion.Desde == presentacion.Hasta
                ? presentacion.Desde.Value.ToShortDateString()
                : presentacion.Desde.Value.ToShortDateString());
        }
        }
    }

    
}
