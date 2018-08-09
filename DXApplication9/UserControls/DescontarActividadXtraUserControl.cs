using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication9.UserControls
{
    public partial class DescontarActividadXtraUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        readonly NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private readonly OrdenDeTrabajo AOrdenDeTrabajo;
        public DescontarActividadXtraUserControl(OrdenDeTrabajo anOrdenDeTrabajo)
        {
            InitializeComponent();
            AOrdenDeTrabajo = anOrdenDeTrabajo;
            gridControl1.DataSource =
                AGlobalDataContext.DescuentoPorActividad.Where(c => c.DocumentoReferenciaId == anOrdenDeTrabajo.OrdenDeTrabajoID);

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, colDocumentoReferenciaId, AOrdenDeTrabajo.OrdenDeTrabajoID);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
        }
    }
}
