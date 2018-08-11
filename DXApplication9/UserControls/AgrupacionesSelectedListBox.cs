using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DXApplication9.ReportesSistema;

namespace DXApplication9.UserControls
{
    public partial class AgrupacionesSelectedListBox : UserControl
    {
        NegocioDataContext _negocioDataContext = new NegocioDataContext();

        public int[] AgrupacionesSeleccionadas
        {

            get
            {
                int[] agrupacionesSeleccionadas = new int[] { };
                var i = 0;
                var items = Agrupaciones_checkedComboBoxEdit.EditValue.ToString().Split(',')
                    .Select(c => Convert.ToInt32((c))).ToArray();

                return items;

                //foreach (var item in items)
                //{
                //    var a = item;
                //    agrupacionesSeleccionadas[i] = (int) items[i];
                //}
                //return agrupacionesSeleccionadas ;
            }
            //get
            //{
            //    var selectedRows = searchLookUpEdit1View.GetSelectedRows();
            //    var agrupacionesId = new int[selectedRows.Length];
            //    var i = 0;
            //    foreach (var rowId in selectedRows)
            //    {
            //        agrupacionesId[i] = ((Agrupacion) searchLookUpEdit1View.GetRow(rowId)).AgrupacionID;
            //        i++;
            //    }

            //    return agrupacionesId;
            //}
        }
        
        public AgrupacionesSelectedListBox()
        {
            InitializeComponent();
            agrupacionBindingSource.DataSource =_negocioDataContext.Agrupacion;
        }

        private void SoloCatalogo_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            agrupacionBindingSource.DataSource = _negocioDataContext.Agrupacion.Where(c => c.PerteneceACatalogo);
        }

        private void MostrarTodos_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            agrupacionBindingSource.DataSource = _negocioDataContext.Agrupacion;

        }

        private void MostrarNoCatalogo_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            agrupacionBindingSource.DataSource = _negocioDataContext.Agrupacion.Where(c => !c.PerteneceACatalogo);

        }
       
    }
}
