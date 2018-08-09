using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace DXApplication9
{
    public partial class CargosDeFirmantesXtraForm : DevExpress.XtraEditors.XtraForm
    {
        readonly NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        public CargosDeFirmantesXtraForm()
        {
            InitializeComponent();
            InsertaUsuarioRegistrado();
            PopulaGrid();
        }

        private void PopulaGrid()
        {

            personasQueFirmanReporteBindingSource.DataSource = AGlobalDataContext.PersonasQueFirmanReporte;
        }

        private void InsertaUsuarioRegistrado()
        {
            if (!AGlobalDataContext.PersonasQueFirmanReporte.Any(c => c.EsUsuarioRegistrado))
            {
                AGlobalDataContext.PersonasQueFirmanReporte.InsertOnSubmit(new PersonasQueFirmanReporte
                {
                    Cargo = "Usuario Registrado",
                    EsUsuarioRegistrado = true,
                    NombreCompleto = "Usuario Registrado",
                    CentroQuePertenece = AGlobalDataContext.ConfiguracionGeneral.FirstOrDefault().Agencia
                });
                AGlobalDataContext.SubmitChanges();
                PopulaGrid();
            }
        }

        private void Firmantes_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
        }

        private void Firmantes_gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Del_simpleButton.Enabled = Firmantes_gridView.GetSelectedRows().Any();

        }

        private void Del_simpleButton_Click(object sender, EventArgs e)
        {
            var selectedRows = Firmantes_gridView.GetSelectedRows();
            for (int i = 0; i < selectedRows.Count(); i++)
            {
                PersonasQueFirmanReporte persona = (PersonasQueFirmanReporte)Firmantes_gridView.GetRow(i);
                if (persona.EsUsuarioRegistrado)
                {
                    XtraMessageBox.Show("El usuario registrado no puede ser borrado", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    Firmantes_gridView.DeleteRow(i);
                }
            }
            AGlobalDataContext.SubmitChanges();
        }

        private void CargosDeFirmantesXtraForm_Load(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch
            {

                //donothing
            }
        }
    }
}