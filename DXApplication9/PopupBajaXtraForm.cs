using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication9
{
    public partial class PopupBajaXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private Artista AIntegrante;
        private NegocioDataContext ADataContext;
        private int AGlobalAgrupacionId;
        private int AglobalAgrupacionDeArtistaId;


        public PopupBajaXtraForm(int anArtistaId, int agrupacionId, NegocioDataContext aDataContext = null)
        {
            InitializeComponent();
            AGlobalAgrupacionId = agrupacionId;
            ADataContext = aDataContext ?? new NegocioDataContext();
            AIntegrante = ADataContext.Artista.FirstOrDefault(c => c.ArtistaID == anArtistaId);
            Text = string.Format("Otorgando la Baja de {0}", AIntegrante.NombreCompleto);
        }

        public PopupBajaXtraForm(int anAgrupacionArtistaId, NegocioDataContext aDataContext = null)
        {
            InitializeComponent();
            AglobalAgrupacionDeArtistaId = anAgrupacionArtistaId;
            ADataContext = aDataContext ?? new NegocioDataContext();
            AgrupacionDeArtista agrupacionDeArtista = ADataContext.AgrupacionDeArtista.FirstOrDefault(c => c.AgrupacionDeArtistaID == anAgrupacionArtistaId);
            AIntegrante = agrupacionDeArtista.Artista;
            Text = string.Format("Otorgando la Baja de {0}", agrupacionDeArtista.Artista.NombreCompleto);
        }

        private void PopupBajaXtraForm_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DateTime lastFechaOt = Convert.ToDateTime("1/1/1999");
            DateTime lastFechaProyecto = Convert.ToDateTime("1/1/1999");
            var firstOrDefault = AIntegrante.ParticipantesDeAcividad.Where(c => c.Importe > 0).OrderBy(c => c.OrdenDeTrabajo.FechaFinalActividad)
                .Select(b => b.OrdenDeTrabajo)
                .FirstOrDefault();
            if (firstOrDefault != null)
            {
                lastFechaOt =
                   firstOrDefault
                       .FechaFinalActividad;
            }
            var firstOrDefault1 = AIntegrante.ParticipantesDeAcividad.OrderBy(c => c.OrdenDeTrabajo.FechaFinalActividad)
               .Select(b => b.OrdenDeTrabajo)
               .FirstOrDefault();
            if (firstOrDefault1 != null)
            {
                lastFechaOt =
                   firstOrDefault1
                       .FechaFinalActividad;
            }
            var lastFecha = lastFechaOt > lastFechaProyecto ? lastFechaProyecto : lastFechaOt;
            if (dateEdit1.DateTime < lastFecha)
            {
                MessageBox.Show("El integrante tiene un ingreso en una fecha posterior a la propuesta por usted, se corrige la fecha mínima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateEdit1.DateTime = lastFecha;
                dateEdit1.Properties.MinValue = lastFecha;
            }
        }

        private void Aceptar_simpleButton_Click(object sender, EventArgs e)
        {

            AgrupacionDeArtista agrupacionDeArtista =
                ADataContext.AgrupacionDeArtista.FirstOrDefault(
                    c => c.AgrupacionDeArtistaID == AglobalAgrupacionDeArtistaId);

            if (!agrupacionDeArtista.TieneActividadHistorica)

                if (XtraMessageBox.Show(
                    "Esta persona no presenta datos en nuestro sistema, desea Eliminarlo completamente? Note que si selecciona No quedara en el sistema para poder trabajar con el mismo en un fúturo",
                    "Atención", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    ADataContext.AgrupacionDeArtista.DeleteOnSubmit(agrupacionDeArtista);
                    ADataContext.SubmitChanges();
                    ADataContext.Artista.DeleteOnSubmit(
                        ADataContext.Artista.FirstOrDefault(c => c.ArtistaID == agrupacionDeArtista.ArtistaId));
                    ADataContext.SubmitChanges();
                    return;
                }

            agrupacionDeArtista.FechaBaja = dateEdit1.DateTime;
            TrayectoriaArtista.EscribirEnTrayectoria(agrupacionDeArtista, (DateTime)agrupacionDeArtista.FechaBaja, (DateTime)agrupacionDeArtista.FechaAlta);
            ADataContext.SubmitChanges();
            DialogResult = DialogResult.OK;
            Close();


                       
        }

        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
            Cache.LuegoDeBaja = true;
        }
    }
}