using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication9
{
    partial class Paises
    {
        public bool EsCuba
        {
            get { return Codigo == 53; }
        }

        /// <summary>
        /// Devuelve El Identificador qeu ocupa el pais de cuba en la base de datos buscandola por el codigo 53 del pais
        /// </summary>
        /// <returns></returns>
        public static int PaisIdDeCuba
        {
            get
            {
                var dc = new NegocioDataContext();
                var firstOrDefault = dc.Paises.FirstOrDefault(c => c.Codigo == 53);
                if (firstOrDefault != null)
                    return firstOrDefault.PaisID;
                return 0;
            }

        }
    }
}
