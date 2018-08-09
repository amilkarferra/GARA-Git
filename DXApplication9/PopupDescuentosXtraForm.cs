using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;

namespace DXApplication9
{
    public partial class PopupDescuentosXtraForm : DevExpress.XtraEditors.XtraForm
    {
        NegocioDataContext ADc = new NegocioDataContext();
        private OrdenDeTrabajo AGlobalOrdenDeTrabajo;
        public PopupDescuentosXtraForm(OrdenDeTrabajo ordenDeTrabajo)
        {
            InitializeComponent();
            AGlobalOrdenDeTrabajo = ordenDeTrabajo;
            gridControl1.DataSource =
                ADc.DescuentoPorActividad.Where(c => c.DocumentoReferenciaId == AGlobalOrdenDeTrabajo.OrdenDeTrabajoID);
            TipoDescuento_repositoryItemLookUpEdit.DataSource = ADc.TipoDescuento;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            ADc.SubmitChanges();
            ADc.DescuentoPorActividad.Where(c => c.DocumentoReferenciaId == AGlobalOrdenDeTrabajo.OrdenDeTrabajoID);

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, colDocumentoReferenciaId, AGlobalOrdenDeTrabajo.OrdenDeTrabajoID);
            //Importe_repositoryItemTextEdit.va
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Dispose();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var gridView = gridView1;
            Point clickPoint = gridControl1.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {
                int rowHandle = hitInfo.RowHandle;
                GridColumn column = hitInfo.Column;
                //MessageBox.Show(column.Name + " "+rowHandle);
                if (column == Del_gridColumn)
                {
                    DescuentoPorActividad descuento = (DescuentoPorActividad)gridView.GetRow(rowHandle);
                    if (
                        MessageBox.Show("Esta acción es irreversible", "Atención", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        
                        ADc.DescuentoPorActividad.DeleteOnSubmit(descuento);
                        AGlobalOrdenDeTrabajo.Descuento = AGlobalOrdenDeTrabajo.GetDescuentos();
                        ADc.SubmitChanges();
                        gridView1.DeleteRow(rowHandle);
                    }
                }
            }
        }

        private void gridControl1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //var _column = gridView1.FocusedColumn;
            //if (_column != colImporte) return;
            //var descuentoAcumulado = Convert.ToDecimal(AGlobalOrdenDeTrabajo.Descuento);
            //if (descuentoAcumulado + Convert.ToDecimal(e.Value) > AGlobalOrdenDeTrabajo.Agrupacion.GetDeuda(AGlobalOrdenDeTrabajo.TipoMonedaId))
            //{
            //    e.Valid = false;
            //    e.ErrorText = "El descuento total no puede sobrepasar la deuda de la Unidad Artística";
            //}

        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var descuento = ((DescuentoPorActividad)e.Row).Importe;
            //if (_column != colImporte) return;
            var descuentoAcumulado = Convert.ToDecimal(AGlobalOrdenDeTrabajo.Descuento);
            if (descuentoAcumulado + descuento > AGlobalOrdenDeTrabajo.Agrupacion.GetDeuda(AGlobalOrdenDeTrabajo.TipoMonedaId))
            {
                gridView1.SetColumnError(colImporte, "El descuento total no puede sobrepasar la deuda de la Unidad Artística");
                e.Valid = false;
                // e.ErrorText = "El descuento total no puede sobrepasar la deuda de la Unidad Artística";
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.WindowCaption = string.Format("Deuda Actual: {0}",
                AGlobalOrdenDeTrabajo.Agrupacion.GetDeuda(AGlobalOrdenDeTrabajo.TipoMonedaId));
            e.ErrorText = "El descuento total no puede sobrepasar la deuda Actual de la Unidad Artística";
            e.ExceptionMode = ExceptionMode.DisplayError;
        }
    }
}