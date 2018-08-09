using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace DXApplication9
{
    public static class LoginHelper
    {
        public static bool EsAdministrador(this Usuario anUsuario)
        {
            return anUsuario.RoleId == (int)Enumerados.Roles.Administrador ||anUsuario.RoleId == (int)Enumerados.Roles.SuperAdministrador;
        }
        public static Usuario UsuarioRegistrado;

        public static Enumerados.Roles RoleDeUsuario
        {
            get
            {
                try
                {
                    var role = (Enumerados.Roles)(Enum.Parse(typeof(Enumerados.Roles), UsuarioRegistrado.RoleId.ToString()));
                    return role;

                }
                catch (Exception)
                {

                    throw;}
            }
        }

        public static bool EliminaValidacion
        {
            get { return RoleDeUsuario == Enumerados.Roles.SuperAdministrador; }
        }
    }

    public partial class Usuario
    {
        public bool PuedeEditarIntegrantes
        {
            get
            {
                return this.EsAdministrador() || RoleId == (int)Enumerados.Roles.RecursosHumanos;

            }
        }
        public bool PuedeEditarOrdenDeTrabajo
        {
            get
            {
                return this.EsAdministrador() || RoleId == (int)Enumerados.Roles.Comercial;

            }
        }
        public bool PuedeAsignarCheque
        {
            get
            {

                return this.EsAdministrador() || RoleId == (int)Enumerados.Roles.Comercial || RoleId == (int)Enumerados.Roles.Economico;

            }
        }

        public string Password2
        {
            get
            {
                return Password;
            }
        }
    }

}
