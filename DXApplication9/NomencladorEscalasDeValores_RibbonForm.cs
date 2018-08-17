using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;using DevExpress.XtraBars;

namespace DXApplication9
{
    public partial class NomencladorEscalasDeValores_RibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public NegocioDataContext _dataContext = new NegocioDataContext();

        public NomencladorEscalasDeValores_RibbonForm()
        {
            InitializeComponent();
            bindingSource.DataSource = _dataContext.NomencladorEscalasDeIngreso;

        }

        private void Nuevo_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.AddNewRow();
            gridView.ShowEditForm();
        }

        private void Edit_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.ShowEditForm();
        }

        private void Eliminar_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utils.MuestraMensajeEliminacion() == DialogResult.Yes)
                gridView.DeleteSelectedRows();
        }

        private void Refrescar_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActualizaTabla();
        }

        private void Preview_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.ShowRibbonPrintPreview();
        }

        private void ActualizaTabla()
        {
            _dataContext = new NegocioDataContext();
            bindingSource.DataSource = _dataContext.NomencladorEscalasDeIngreso;
        }

        private void gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception exception)
            {
                Utils.MuestraError();
            }
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception exception)
            {

                Utils.MuestraError();

            }
        }
    }
}