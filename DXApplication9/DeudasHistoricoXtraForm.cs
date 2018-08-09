using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DXApplication9.Properties;

namespace DXApplication9
{
    public partial class DeudasHistoricoXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public NegocioDataContext AglobalDataContext = new NegocioDataContext();
        private HistoricoDeuda DeudaSeleccionada;
        private int? filaSeleccionada;
        public DeudasHistoricoXtraForm()
        {
            InitializeComponent();
            PopulaControles();
           // ImageCollection.AddImage(DevExpress.Utils.Image,);
            
        }

        private void PopulaControles()
        {
            PupulaDeudas();
            agrupacionBindingSource.DataSource = AglobalDataContext.Agrupacion;
            tipoMonedaBindingSource.DataSource = AglobalDataContext.TipoMoneda;
            TipoIncrementoDeuda_repositoryItemLookUpEdit.DataSource =
                Enumerados.ListaDeEnumerados(typeof (Enumerados.TipoGestionDeuda));
            
          //  PopulaImageComboBox();

        }

        private void PopulaImageComboBox()
        {
            var lista = Enumerados.ListaDeEnumerados(typeof (Enumerados.TipoGestionDeuda));
            //foreach (var tipos in lista)
            //{
            //    ImageComboBoxItem item = new ImageComboBoxItem();
            //}
            foreach (var enumerado in lista)
            {
                ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Description = enumerado.Tipo,
                   ImageIndex = Convert.ToInt32(enumerado.Valor),
                    Value = Convert.ToInt32(enumerado.Valor)
                };
                TipoAccionDeudas_repositoryItemImageComboBox.Items.Add(item);}
         //       TipoAccionDeudas_repositoryItemImageComboBox.AddEnum(typeof(Enumerados.TipoGestionDeuda));
            TipoAccionDeudas_repositoryItemImageComboBox.SmallImages = imageCollection1;
        }

        private void Accion_LargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var agrupacionId = Convert.ToInt32(Agrupacion_lookUpEdit.EditValue);
            PopupGestionDeudaXtraForm popup = new PopupGestionDeudaXtraForm(agrupacionId,AglobalDataContext);
            if(popup.ShowDialog() == DialogResult.OK)
            {
               
               PupulaDeudas();
            }
        }

        private void Agrupacion_lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            PupulaDeudas();
            GestionarAccion_barLargeButtonItem.Enabled = true;}

        private void PupulaDeudas()
        {
            AglobalDataContext = new NegocioDataContext();
            var agrupacionId = Convert.ToInt32(Agrupacion_lookUpEdit.EditValue);
            historicoDeudaBindingSource.DataSource =
               AglobalDataContext.HistoricoDeuda.Where(c => c.AgrupacionId == agrupacionId);
        }

        private void Deudas_gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                DeudaSeleccionada = null;
                filaSeleccionada = null;
                EditarAccion_barLargeButtonItem.Enabled = false;
                return;
            }
            HistoricoDeuda deuda = (HistoricoDeuda) Deudas_gridView.GetRow(e.FocusedRowHandle);
            DeudaSeleccionada = deuda;
            filaSeleccionada = e.FocusedRowHandle;
            EliminarDeuda_barLargeButtonItem.Enabled = deuda.UltimaInsertada;
            EditarAccion_barLargeButtonItem.Enabled = true;

        }

        private void EliminarDeuda_barLargeButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            try
            {
                if (DeudaSeleccionada.UltimaInsertada)
                {
                    if (XtraMessageBox.Show("Esta acción es irreversible, esta seguro?", "Atención",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        var deuda =
                            AglobalDataContext.HistoricoDeuda.FirstOrDefault(
                                c => c.HistoricoDeudaID == DeudaSeleccionada.HistoricoDeudaID);
                        if (deuda != null) AglobalDataContext.HistoricoDeuda.DeleteOnSubmit(deuda);
                        AglobalDataContext.SubmitChanges();
                        if(filaSeleccionada!=null)
                        Deudas_gridView.DeleteRow(Convert.ToInt32(filaSeleccionada));
                        EliminarDeuda_barLargeButtonItem.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                
                XtraMessageBox.Show("No se pudo completar la acción", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public GridColumn GetClickedInformation(GridControl aGridControl, GridView agridView, out int rowHandle)
        {
            var gridView = agridView;
            Point clickPoint = aGridControl.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {rowHandle = hitInfo.RowHandle;
                GridColumn column = hitInfo.Column;
                return column;
            }
            rowHandle = 0;
            return null;
        }

        private void Deudas_gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
           // var deuda = (HistoricoDeuda)Deudas_gridView.GetRow(e.RowHandle);

        }

        private void EditarAccion_barLargeButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopupGestionDeudaXtraForm popup = new PopupGestionDeudaXtraForm(DeudaSeleccionada, AglobalDataContext);
            if (popup.ShowDialog() == DialogResult.OK)
            {

                PupulaDeudas();
            }
        }


    }
}