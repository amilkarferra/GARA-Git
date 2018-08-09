using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication9
{

    public partial class RolesPorReporteUserControl :UserControl
    {
        public class SmallConfiguracion
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public int ParentId { get; set; }
            public bool Existe { get; set; }
        }

        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        public RolesPorReporteUserControl()
        {
            InitializeComponent();
            PopulaTree();
        }

        private void PopulaTree()
        {
            List<SmallConfiguracion> listaReporteRoles = new List<SmallConfiguracion>();
            var listaDeReportes = Enumerados.ListaDeEnumerados(typeof (Enumerados.Reportes));
            var listaDeRoles = Enumerados.ListaDeEnumerados(typeof (Enumerados.Roles));
            int band = 0;
            foreach (var reporte in listaDeReportes)
            {
                SmallConfiguracion rootNode = new SmallConfiguracion
                {
                    Id = Convert.ToInt32(reporte.Valor),
                    Descripcion =reporte.Tipo,
                    ParentId = 0,
                    Existe = false
                };
                listaReporteRoles.Add(rootNode);
                foreach (var role in listaDeRoles)
                {
                    band ++;
                    SmallConfiguracion node = new SmallConfiguracion
                    {
                        Id = Convert.ToInt32(role.Valor)+1000*rootNode.Id,
                        Descripcion = role.Tipo,
                        ParentId = Convert.ToInt32(reporte.Valor),
                        Existe = AGlobalDataContext.ConfigurarPiePorRole.Any(c=>c.ReporteID==rootNode.Id && c.RoleID==Convert.ToInt32(role.Valor))

                    };
                    listaReporteRoles.Add(node);
                }
            }
            treeList1.DataSource = listaReporteRoles;
            treeList1.RootValue = 0;
            treeList1.ParentFieldName = "ParentId";
            treeList1.KeyFieldName = "Id";
            treeList1.CheckBoxFieldName = "Existe";
        }
    }
}