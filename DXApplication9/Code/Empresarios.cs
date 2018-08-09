using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication9
{
    public partial class Empresarios
    {
        public static Empresarios GetEmpresario(int empresarioId)
        {
            NegocioDataContext dataContext = new NegocioDataContext();
            return dataContext.Empresarios.FirstOrDefault(c => c.EmpresarioID == empresarioId);
        }
    }
   }
