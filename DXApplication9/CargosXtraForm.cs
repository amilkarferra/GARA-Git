using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace DXApplication9
{
    public partial class CargosXtraForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private NegocioDataContext _dataContext = new NegocioDataContext();
        public CargosXtraForm()
        {
            InitializeComponent();
            bindingSource.DataSource = _dataContext.NomencladorCargo;
            tipoNomencladorCargoBindingSource.DataSource = _dataContext.TipoNomencladorCargo;
           
        }

        private void Cargos_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception)
            {
                
                 var gridView = this.gridView;
                XtraMessageBox.Show("Error en la operacion",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    gridView.DeleteRow(e.RowHandle);
            }
        }

        private void Nuevo_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView.AddNewRow();
            gridView.ShowEditForm();
        }

        private void Edit_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView.ShowEditForm();

        }

        private void Delete_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Utils.MuestraMensajeEliminacion() == DialogResult.Yes)
                gridView.DeleteSelectedRows();
        }

        private void Refresh_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           ActualizaTabla();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gridView_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {

        }

        private void gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception exception)
            {

                Utils.MuestraErrorDeEliminacion();
                ActualizaTabla();
            }
        }

        private void ActualizaTabla()
        {
            _dataContext = new NegocioDataContext();
            bindingSource.DataSource = _dataContext.NomencladorCargo;
        }
    }
}