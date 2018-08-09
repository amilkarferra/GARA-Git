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
    public partial class PopupPresentacionXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private Presentacion APresentacion;
        private NegocioDataContext AGlobalDatacontext;
        private Proyectos AProyecto;
        public PopupPresentacionXtraForm(Presentacion apresentacion, NegocioDataContext dataContext = null)
        {
            InitializeComponent();
            AGlobalDatacontext = dataContext ?? new NegocioDataContext();
            APresentacion = AGlobalDatacontext.Presentacion.FirstOrDefault(c => c.PresentacionID == apresentacion.PresentacionID);
            var proyecto = AGlobalDatacontext.Proyectos.FirstOrDefault(c => c.ProyectoID == apresentacion.ProyectoId);
            Desde_dateEdit.Properties.MinValue = Hasta_dateEdit.Properties.MinValue = (DateTime)proyecto.FechaInicial;
            Desde_dateEdit.Properties.MaxValue = Hasta_dateEdit.Properties.MaxValue = (DateTime)proyecto.FechaFinal;

        }

        public PopupPresentacionXtraForm()
        {
            
        }
        private void Salvar_simpleButton_Click(object sender, EventArgs e)
        {

        }

        private void Salir_simpleButton_Click(object sender, EventArgs e)
        {

        }
    }
}