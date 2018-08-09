using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXApplication9.ReportesSistema;

namespace DXApplication9
{
    partial class ConfiguracionGeneral
    {

        public static int Anno
        {
            get { return DynamicQueryable.FirstOrDefault((new NegocioDataContext()).ConfiguracionGeneral).AnnoDeTrabajo; }
        }
        public static string AgenciaTrabajo
        {
            get { return DynamicQueryable.FirstOrDefault((new NegocioDataContext()).ConfiguracionGeneral).Agencia; }
        }

        ///en el caso de que se este cerrando las nominas que se hagan aparecen un año antes de la configuracion , 
        /// esto permite que el sistema este trabajando por ejemeplo en el año 2018 (ordenes de trabajo, facturas, contratos salen con fechas 2018)
        /// sin embargo las nominas salen el año anterior porque la contabilidad no ha cerrado el año
        /// Este valor se configura en la configuracion.
        public static bool EsCierre
        {
            get { return DynamicQueryable.FirstOrDefault((new NegocioDataContext()).ConfiguracionGeneral).CerrandoAnno; }
        }
        public static string GetBancoEmpresa(int aTipoMonedaId)
        {
            var banco = (new NegocioDataContext()).CuentasEmpresa.FirstOrDefault(c => c.TipoMonedaId == aTipoMonedaId).Banco;
            return banco == null ? "" : banco;
        }
        public static ConfiguracionGeneral ConfiguracionActual
        {
            get
            {
                ConfiguracionGeneral configuracion = new NegocioDataContext().ConfiguracionGeneral.FirstOrDefault(c=>c.ConfiguracionID!=null);
                return configuracion;
            }
        }
    }
}
