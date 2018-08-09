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
    public partial class PopupEstadoContratoXtraForm : DevExpress.XtraEditors.XtraForm
    {
        NegocioDataContext AGlobalDataContext= new NegocioDataContext();
        private EstadoContrato AEstadoContrato;
        public PopupEstadoContratoXtraForm(EstadoContrato estadoContrato=null)
        {
            AEstadoContrato = estadoContrato ?? new EstadoContrato();InitializeComponent();

        }

        private void Ok_simpleButton_Click(object sender, EventArgs e)
        {
            var estado = AEstadoContrato.EstadoContratoID == 0
                ? AEstadoContrato
                : AGlobalDataContext.EstadoContrato.FirstOrDefault(
                    c => c.EstadoContratoID == AEstadoContrato.EstadoContratoID);
            estado.Color = colorPickEdit1.Color.ToArgb();
            var descripcion = Convert.ToString(Estado_textEdit.EditValue);
            estado.Abreviatura = descripcion.Length > 20
                ? Convert.ToString(Estado_textEdit.EditValue).Substring(0, 20)
                : descripcion;
            estado.Descripción = descripcion.Trim();
            estado.InvalidaContrato = InvalidaCtto_checkEdit.Checked;
            if(estado.EstadoContratoID==0)AGlobalDataContext.EstadoContrato.InsertOnSubmit(estado);
            AGlobalDataContext.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}