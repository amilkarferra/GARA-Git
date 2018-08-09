using System;
using System.Collections.Generic;
using System.Linq;using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPrinting.Native;
using DXApplication9.ReportesSistema;

namespace DXApplication9
{
    partial class Nomina
    {
        public static Int32 GetProximoConsecutivo()
        {
            try
            {
                using (NegocioDataContext dc = new NegocioDataContext())
                {
                    Int32 annoDeTrabajo =ConfiguracionGeneral.EsCierre? ConfiguracionGeneral.Anno-1:ConfiguracionGeneral.Anno;
                    var nominas = dc.Nomina.Where(c => c.Anno == annoDeTrabajo);
                    if (DynamicQueryable.Any(nominas))
                    {
                        var ultConsecutivo = DynamicQueryable.FirstOrDefault(nominas.OrderByDescending(c => c.Consecutivo)).Consecutivo;
                        return ultConsecutivo + 1;
                    }

                    return 1;

                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public bool EstaCuadrada
        {
            get
            {
                var cuadrado = OrdenDeTrabajo.ImporteRestaPorDistribuir == 0;
                //ingreso de la actividad
                return cuadrado;
            }
        }

        public string ConsecutivoString { get{ return String.Format("{0}/{1}",Consecutivo,Anno);} }
    }
}
