using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;

namespace DXApplication9
{
    
    public partial class NomencladorGridXtraUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public NegocioDataContext _dataContext = new NegocioDataContext();
        public NomencladorGridXtraUserControl()
        {
            InitializeComponent();
            bindingSource.DataSource = _dataContext.NoEscalaSalarial;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.AddNewRow();
            gridView.ShowEditForm();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Esta acción es irreversible está seguro qeu desea eliminar el registro?", "Atención",MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)==DialogResult.Yes);
            gridView.DeleteSelectedRows();
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception exception)
            {

                Utils.MuestraError(exception.Message);
            }
        }

        private void gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception )
            {

               Utils.MuestraError();
            }
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
           _dataContext = new NegocioDataContext();
            bindingSource.DataSource = _dataContext.NoEscalaSalarial;
        }

    }
}
