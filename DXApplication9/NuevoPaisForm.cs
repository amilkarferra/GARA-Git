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
    public partial class NuevoPaisForm : DevExpress.XtraEditors.XtraForm
    {
        public Paises PaisNuevo = new Paises();
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        public NuevoPaisForm()
        {
            InitializeComponent();
            //continentesBindingSource.DataSource = _GlobalDataContext.Continentes;
            paisesBindingSource.DataSource = AGlobalDataContext.Paises;
        }

        private void NuevoPais_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'artistasDataSet.Continentes' table. You can move, or remove it, as needed.
            //this.continentesTableAdapter.Fill(this.artistasDataSet.Continentes);
            // TODO: This line of code loads data into the 'artistasDataSet.Paises' table. You can move, or remove it, as needed.
            //this.paisesTableAdapter.Fill(this.artistasDataSet.Paises);

        }


        private void buttonEdit2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            
        }

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                PaisNuevo.NombrePais = NombrePaisTextEdit.EditValue.ToString().Trim();
                PaisNuevo.Codigo = Convert.ToInt32(Codigo_textEdit.EditValue);
                if(AGlobalDataContext.Paises.Any(c=>c.Codigo==PaisNuevo.Codigo)|| AGlobalDataContext.Paises.Any(c => c.NombrePais.Trim().ToLower() == PaisNuevo.NombrePais.Trim().ToLower()))
                {
                    Utils.MuestraInformacion("País o código ya existente, por favor verifique");
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return ;
                }
                AGlobalDataContext.Paises.InsertOnSubmit(PaisNuevo);
                AGlobalDataContext.SubmitChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                Utils.MuestraError();
            }

        }
    }
}