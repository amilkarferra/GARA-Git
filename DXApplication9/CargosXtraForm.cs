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
    public partial class CargosXtraForm : DevExpress.XtraEditors.XtraForm
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        public CargosXtraForm()
        {
            InitializeComponent();
            nomencladorCargoBindingSource.DataSource = AGlobalDataContext.NomencladorCargo;
            TipoCargo_repositoryItemLookUpEdit.DataSource = Enumerados.ListaDeEnumerados(typeof (Enumerados.TipoCargo));
            TipoCargo_repositoryItemLookUpEdit.DisplayMember = "Tipo";
            TipoCargo_repositoryItemLookUpEdit.ValueMember = "Valor";
        }

        private void Cargos_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                AGlobalDataContext.SubmitChanges();
            }
            catch (Exception)
            {
                
                 var gridView = Cargos_gridView;
                XtraMessageBox.Show("Error en la operacion",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    gridView.DeleteRow(e.RowHandle);
            }
        }
    }
}