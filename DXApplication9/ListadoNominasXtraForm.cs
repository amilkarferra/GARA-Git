using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DevExpress.DXCore.Controls.Data.Linq.Helpers;
using DevExpress;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DXApplication9.ReportesSistema;
using DevExpress.XtraBars;

namespace DXApplication9
{
    public partial class ListadoNominasXtraForm : BaseXtraForm
    {
        readonly NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        public DevExpress.XtraGrid.Views.Grid.GridView GlobalGridView = null;
        public ListadoNominasXtraForm()
        {
            InitializeComponent();
            GlobalGridView = gridView1;
            IEnumerable<Nomina> nominas = null;
            nominaBindingSource.DataSource = new NegocioDataContext().Nomina;



            TipoMoneda_repositoryItemLookUpEdit.DataSource = AGlobalDataContext.TipoMoneda;
            TipoActividad_repositoryItemLookUpEdit.DataSource =
                Enumerados.ListaDeEnumerados(typeof(Enumerados.TipoActividad));
            TipoActividad_repositoryItemLookUpEdit.ValueMember = "Valor";
            TipoActividad_repositoryItemLookUpEdit.DisplayMember = "Tipo";
            PopulaAnnoCheckBox();
            FiltraAnno();

        }

        private void gridView1_CalcPreviewText(object sender, DevExpress.XtraGrid.Views.Grid.CalcPreviewTextEventArgs e)
        {


        }

        private void gridView1_CalcPreviewText_1(object sender, DevExpress.XtraGrid.Views.Grid.CalcPreviewTextEventArgs e)
        {
            Nomina nomina = (Nomina)e.Row;


        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //Nomina nomina = (Nomina)gridView1.GetRow(e.ListSourceRowIndex);
            //Nomina nominaAsociada = nomina.GetNominaAsociada();
            //if (e.Column == colNumeroNomina)
            //{
            //    e.DisplayText = nominaAsociada.Consecutivo.ToString();
            //}
            //if (e.Column == colNoActividad)
            //{
            //    e.DisplayText = nomina.OrdenDeTrabajo.ConsecutivoString;
            //}
            //if (e.Column == colImporteNomina)
            //{
            //    e.DisplayText = nomina.OrdenDeTrabajo.ImporteConDescuento.ToString();
            //}
            //gridView1.SetRowCellValue(e.RowHandle, colNumeroNomina, nominaAsociada);
            //gridView1.SetRowCellValue(e.RowHandle, colConsecutivo, ot.ConsecutivoString);
            //gridView1.SetRowCellValue(e.RowHandle, colImporteFinal, ot.ImporteConDescuento);
            //gridView1.SetRowCellValue(e., colNetoACobrar, nomina.OrdenDeTrabajo.ImporteNetoQueSeCobraReal);
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var gridView = gridView1;
            Point clickPoint = gridControl1.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {
                int rowHandle = hitInfo.RowHandle;
                Nomina nomina = (Nomina)gridView.GetRow(rowHandle);
                GridColumn column = hitInfo.Column;
                //MessageBox.Show(column.Name + " "+rowHandle);
                if (column == Preview_gridColumn)
                {
                    if (nomina != null && !nomina.EstaCuadrada)
                    {
                        XtraMessageBox.Show("La nomina no está cuadrada", "Información",
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    try
                    {
                        SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);
                    }
                    catch (Exception)
                    {

                        SplashScreenManager.CloseForm();
                        SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);

                    }

                    NominaXtraReport reporte = new NominaXtraReport(nomina.OrdenDeTrabajo);
                    reporte.CreateDocument();
                    reporte.ShowPreview();
                }
                if (column == Edit_gridColumn)
                {
                    IngresosXtraForm ingresosXtraForm = new IngresosXtraForm(nomina);
                    if (ingresosXtraForm.ShowDialog() != DialogResult.Cancel)
                        nominaBindingSource.DataSource = new NegocioDataContext().Nomina;
                }
            }
        }
        private void FiltraAnno()
        {
            string cadenaDeFiltrado = GetCadenaDeFiltradoPorAnno();
            if (cadenaDeFiltrado == String.Empty) return;
            gridView1.Columns["Anno"].FilterInfo = new ColumnFilterInfo(ColumnFilterType.Value,
                ConfiguracionGeneral.Anno, cadenaDeFiltrado);
        }
        private string GetCadenaDeFiltradoPorAnno()
        {
            string cadenaFiltro = "";
            var items = Annos_checkedComboBoxEdit.Properties.Items.Where(c => c.CheckState == CheckState.Checked);
            if (!items.Any()) return String.Empty; foreach (var item in items)
            {
                cadenaFiltro += string.Format("[Anno]='{0}' OR", item.Value);
            }
            //Elimino el ultimo OR

            return cadenaFiltro.Right(2);
        }

        private void PopulaAnnoCheckBox()
        {
            var annos = AGlobalDataContext.OrdenDeTrabajo.DistinctBy(c => c.Anno).Select(c => c.Anno);
            foreach (var anno in annos)
            {
                Annos_checkedComboBoxEdit.Properties.Items.Add(anno,
                    anno == ConfiguracionGeneral.Anno ? CheckState.Checked : CheckState.Unchecked);
            }
            // Annos_checkedComboBoxEdit.Properties.DataSource = annos;
            //Annos_checkedComboBoxEdit.

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int rowHandle;
            var column = GetClickedInformation(gridControl1, gridView1, out rowHandle);
            Nomina nomina = (Nomina)gridView1.GetRow(rowHandle);
            IngresosXtraForm editForm = new IngresosXtraForm(nomina);
            if (editForm.ShowDialog() == DialogResult.Cancel) return;
            ActualizaTablaDeNominas();

        }

        private void ActualizaTablaDeNominas()
        {
            nominaBindingSource.DataSource = new NegocioDataContext().Nomina;
        }

        private void Refresh_simpleButton_Click(object sender, EventArgs e)
        {
            ActualizaTablaDeNominas();
        }

        private void Annos_checkedComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            FiltraAnno();
        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }
        private List<int> _selectedDataSourceRowIndeces;

        private void GlobalGridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selectedRowHandles = GlobalGridView.GetSelectedRows();
            _selectedDataSourceRowIndeces = selectedRowHandles.Select(x => GlobalGridView.GetDataSourceRowIndex(x)).ToList();
        }

        private void GlobalGridView_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            if (MostrarSoloSeleccionados_checkButton.Checked && _selectedDataSourceRowIndeces != null)
            {
                e.Visible = _selectedDataSourceRowIndeces.Contains(e.ListSourceRow);
                e.Handled = true;
            }
            else
            {
                e.Visible = true;
            }
        }

        private void MostrarSeleccionados_barCheckItem_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            //if(MostrarSeleccionados_barCheckItem.Checked)
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }

        private void MostrarSoloSeleccionados_checkButton_CheckedChanged(object sender, EventArgs e)
        {
            GlobalGridView.RefreshData();
        }
    }
    
}