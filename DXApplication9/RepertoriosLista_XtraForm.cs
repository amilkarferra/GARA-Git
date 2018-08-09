using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace DXApplication9
{
    public partial class RepertoriosLista_XtraForm : BaseXtraForm
    {
        private NegocioDataContext GlobalDataContext = new NegocioDataContext();

        public RepertoriosLista_XtraForm()
        {
            InitializeComponent();
           // gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            agrupacionBindingSource.DataSource = GlobalDataContext.Agrupacion.OrderBy(c => c.Nombre);
            //  cancionBindingSource.DataSource = GlobalDataContext.Cancion;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public NegocioDataContext GetDataSource()
        {
            GlobalDataContext = new NegocioDataContext();
            return GlobalDataContext;
        }


        private void gridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (Agrupacion_lookUpEdit.EditValue == null) return;
            gridView.SetRowCellValue(e.RowHandle, colAgrupacionId, Convert.ToInt32(Agrupacion_lookUpEdit.EditValue));
        }

        private void Agrupaciones_barEditItem_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void Agrupaciones_barEditItem_EditValueChanged(object sender, EventArgs e)
        {
            PopulaCanciones();
            gridView.OptionsBehavior.Editable = true;
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

        }

        private void PopulaCanciones()
        {
            var value = Convert.ToInt32(Agrupacion_lookUpEdit.EditValue);
            cancionBindingSource.DataSource = GetDataSource().Cancion.Where(c => c.AgrupacionId == value);
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                GlobalDataContext.SubmitChanges();
                Utils.MuestraMensajeOk();
            }
            catch (Exception)
            {
                
                Utils.MuestraError();
                PopulaCanciones();

            }

        }

        private void gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            try
            {
                GlobalDataContext.SubmitChanges();
                Utils.MuestraMensajeOk();
            }
            catch (Exception)
            {

                Utils.MuestraError();
            }
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }

        private void gridView_Click(object sender, EventArgs e)
        {
            var rowHandle = 0;
            var column = GetClickedInformation(gridControl, gridView, out rowHandle);
            if (column != null && column == del_gridColumn)
            {
                gridView.DeleteRow(rowHandle);
            }




        }

        private void EditaActividadSeleccionada()
        {
            //int rowHandle;
            //var column = GetClickedInformation(gridControl, gridView, out rowHandle);
            //Cancion ot = (Cancion)gridView.GetRow(rowHandle);
            //if (!LoginHelper.EliminaValidacion)
            //    if (!ot.ValidaPorNominaAsociada()) return;
            //EditOtXtraForm editOtXtraForm = new EditOtXtraForm(ot.OrdenDeTrabajoID);
            ////splashScreenManager1.ShowWaitForm();
            //if (editOtXtraForm.ShowDialog() == DialogResult.Cancel) return;
            ////_GlobalDataContext.Refresh(RefreshMode.OverwriteCurrentValues,_Ot);
            //PopulaOrdenDeTrabajoGridControl();
            //if (editOtXtraForm.GlobalActividad != null)
            //    SeleccionaActividad(editOtXtraForm.GlobalActividad);
        }
    }
}