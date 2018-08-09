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
    public partial class TrayectoriaArtistaXtraForm : DevExpress.XtraEditors.XtraForm
    {
        NegocioDataContext AGlobDataContext = new NegocioDataContext();
        public TrayectoriaArtistaXtraForm(Artista anArtista)
        {
            InitializeComponent();
            trayectoriaArtistaBindingSource.DataSource =
                AGlobDataContext.TrayectoriaArtista.Where(c => c.ArtistaId == anArtista.ArtistaID);
        }

        private void TrayectoriaArtista_gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            try
            {
                AGlobDataContext.SubmitChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la acción, Verifique datos insertados");
               
            }
        }

        private void TrayectoriaArtista_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                AGlobDataContext.SubmitChanges();
            }
            catch (Exception )
            {
                var gridView = TrayectoriaArtista_gridView;
                XtraMessageBox.Show("Error en la operacion",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                gridView.DeleteRow(e.RowHandle);

            }

        }
    }
}