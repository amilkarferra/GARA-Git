using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication9
{
    partial class TrayectoriaArtista
    {
        public static int EscribirEnTrayectoria(AgrupacionDeArtista agrupacionDeArtista, DateTime fechaBaja, DateTime fechaAlta)
        {
            var dataContext = new NegocioDataContext();
            TrayectoriaArtista trayectoria = (new TrayectoriaArtista
            {
                Agrupacion=agrupacionDeArtista.Agrupacion.Nombre,
                Centro = ConfiguracionGeneral.AgenciaTrabajo,
                Desde = fechaAlta,
                Hasta = fechaBaja
            });
            try
            {
                dataContext.TrayectoriaArtista.InsertOnSubmit(trayectoria);
                dataContext.SubmitChanges();
                return trayectoria.TrayectoriaArtistaID;
            }
            catch (Exception)
            {
                
                return 0;
            }
        }
    }
}
