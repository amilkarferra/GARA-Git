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
    public partial class PopupAgrupacionXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private int ATipoVinculo;

        public int GrupoSeleccionado
        {
            get { return Convert.ToInt32(checkedComboBoxEdit1.EditValue); }
        }
        public DateTime FechaAlta
        {
            get { return FechaAlta_dateEdit.DateTime; }
        }

        public int TipoVinculo
        {
            get { return ATipoVinculo; }
            set  { ATipoVinculo = value; }
        }

        public int CargoId
        {
            get { return Convert.ToInt32(Cargo_lookUpEdit.EditValue); }
        }

        public string AbreviaturaCargo
        {
            get { return AbreCargo_textEdit.EditValue.ToString().Trim(); }
        }
        public PopupAgrupacionXtraForm()
        {
            InitializeComponent();
            agrupacionBindingSource.DataSource =AGlobalDataContext.Agrupacion.Where(c => c.PerteneceACatalogo).OrderBy(c=>c.Nombre);
            TipoVinculo_lookUpEdit.Properties.DataSource =
                Enumerados.ListaDeEnumerados(typeof (Enumerados.TipoVinculoDeArtista));
               // Enumerados.ProyectoEnumerados.TipoVinculoArtista.EnumToList();
            TipoVinculo_lookUpEdit.Properties.ValueMember = "Valor";
            TipoVinculo_lookUpEdit.Properties.DisplayMember = "Tipo";
            nomencladorCargoBindingSource.DataSource = AGlobalDataContext.NomencladorCargo.OrderBy(c => c.PesoDeCargo);

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
            Dispose();
        }

        private void OK_simpleButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cargo_lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AbreCargo_textEdit.EditValue = Cargo_lookUpEdit.Text.Substring(0, 20).Trim();
            }
            catch 
            {
                
                  AbreCargo_textEdit.EditValue = Cargo_lookUpEdit.Text.Trim();
            }
        }

        private void checkedComboBoxEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            checkedComboBoxEdit1.ClosePopup();
            agrupacionBindingSource.DataSource =
                   AGlobalDataContext.Agrupacion.OrderBy(c => c.Nombre);
            checkedComboBoxEdit1.ResetBindings();
            Utils.MuestraInformacion("Actualizada lista de Unidades Artísticas");
        }

      
    }
}