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
    public partial class NomencladorTipoCargosXtraForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public NegocioDataContext _dataContext = new NegocioDataContext();

        public NomencladorTipoCargosXtraForm()
        {
            InitializeComponent();
            bindingSource.DataSource = _dataContext.TipoNomencladorCargo;

        }

        private void Add_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView.AddNewRow();
            gridView.ShowEditForm();
        }

        private void Edit_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView.ShowEditForm();

        }

        private void Del_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Utils.MuestraMensajeEliminacion()==DialogResult.Yes) 
            gridView.DeleteSelectedRows();
        }

        private void Refresh_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActualizaTabla();
        }

        private void ActualizaTabla()
        {
            _dataContext = new NegocioDataContext();
            bindingSource.DataSource = _dataContext.TipoNomencladorCargo;
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception exception)
            {
               
                Utils.MuestraErrorDeEliminacion();

            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView.ShowPrintPreview();
        }
    }
}