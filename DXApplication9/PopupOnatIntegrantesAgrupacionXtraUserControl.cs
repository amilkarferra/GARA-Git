using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication9
{
    public partial class PopupOnatIntegrantesAgrupacionXtraUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        NegocioDataContext Adc= new NegocioDataContext();
        public PopupOnatIntegrantesAgrupacionXtraUserControl()
        {
            InitializeComponent();
            agrupacionBindingSource.DataSource = Adc.Agrupacion;
            tipoMonedaBindingSource.DataSource = Adc.TipoMoneda;

        }

        private void PopupOnatIntegrantesAgrupacionXtraUserControl_Leave(object sender, EventArgs e)
        {
            dxValidationProvider1.Validate();
        }
    }
}
