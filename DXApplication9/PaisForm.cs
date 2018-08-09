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

namespace DXApplication9
{
    public partial class PaisForm : DevExpress.XtraEditors.XtraForm
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();

        public PaisForm()
        {
            InitializeComponent();
            var listaDeContinentes = Enumerados.ListaDeEnumerados(typeof (Enumerados.Continentes));
            Continentes_repositoryItemLookUpEdit.DataSource = listaDeContinentes;
            Continentes_repositoryItemLookUpEdit.DisplayMember = "Tipo";
            Continentes_repositoryItemLookUpEdit.ValueMember = "Valor";
            CompruebaPaisCuba();
            paisesBindingSource.DataSource = AGlobalDataContext.Paises.OrderBy(c=>c.NombrePais);
            //     continentesBindingSource.DataSource = _GlobalDataContext.Continentes;

        }

        private void CompruebaPaisCuba()
        {
            if (AGlobalDataContext.Paises.Any(c => c.Codigo == 53)) return;
            AGlobalDataContext.Paises.InsertOnSubmit(new Paises
            {
                NombrePais = "Cuba",
                Codigo = 53
            });
            AGlobalDataContext.SubmitChanges();
        }

        private void PaisForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'artistasDataSet.Continentes' table. You can move, or remove it, as needed.
            //this.continentesTableAdapter.Fill(this.artistasDataSet.Continentes);

        }

        

        private void PaisgridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

            Paises pais = (Paises) e.Row;
            //if (pais.PaisID == 0)
            //{
            //    if (_GlobalDataContext.Paises.Any(c => c.Codigo == pais.Codigo))
            //    {
            //        XtraMessageBox.Show("Ya existe un pais con este código. Verifique.",
            //        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //        Paises_gridView.DeleteRow(e.RowHandle);
            //        return;
            //    }
            //}
           if (AGlobalDataContext.Paises.Any(c => c.Codigo == pais.Codigo && ((c.PaisID != pais.PaisID))))
            {
                XtraMessageBox.Show("Ya existe un pais con este código. Verifique.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Paises_gridView.DeleteRow(e.RowHandle);
                return;
            }
           try
           {
               AGlobalDataContext.SubmitChanges();
           }
           catch (Exception)
           {
               
               var gridView = Paises_gridView;
                XtraMessageBox.Show("Error en la operacion",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    gridView.DeleteRow(e.RowHandle);
           }
           // continentesBindingSource.ResetBindings(false);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
         //   continentesBindingSource.ResetBindings(false);
        }
    }
}