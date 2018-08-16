using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace DXApplication9
{
    public partial class CargosXtraForm : XtraForm
    {
        private readonly NegocioDataContext _aGlobalDataContext = new NegocioDataContext();
        public CargosXtraForm()
        {
            InitializeComponent();
            nomencladorCargoBindingSource.DataSource = _aGlobalDataContext.NomencladorCargo;
            tipoNomencladorCargoBindingSource.DataSource = _aGlobalDataContext.TipoNomencladorCargo;
           
        }

        private void Cargos_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            try
            {
                _aGlobalDataContext.SubmitChanges();
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