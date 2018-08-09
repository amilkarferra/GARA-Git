using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication9.UserControls
{
    public partial class EscalaSalairalPopupXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private EscalaSalarial GlobalEscalaSalarial = null;
        private NegocioDataContext GlobalDataContext = new NegocioDataContext();

        public EscalaSalairalPopupXtraForm(EscalaSalarial anEscalaSalarial = null)
        {
            InitializeComponent();
            if (anEscalaSalarial == null)
            {
                GlobalEscalaSalarial = new EscalaSalarial();
            }
            else
            {
                GlobalEscalaSalarial = GlobalDataContext.EscalaSalarial.FirstOrDefault(c => c.EscalaSalarialID == anEscalaSalarial.EscalaSalarialID);
                EscalaSalarial_textEdit.EditValue = GlobalEscalaSalarial.Escala;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (GlobalEscalaSalarial.EscalaSalarialID == 0)
                {
                    if (
                        GlobalDataContext.EscalaSalarial.Any(
                            c => c.Escala == Convert.ToInt32(EscalaSalarial_textEdit.EditValue)))
                    {
                        Utils.MuestraError("Escala Salarial definida con anterioridad");
                        EscalaSalarial_textEdit.EditValue = String.Empty;
                        return;
                    }
                    GlobalDataContext.EscalaSalarial.InsertOnSubmit(new EscalaSalarial
                    {
                        Escala = Convert.ToInt32(EscalaSalarial_textEdit.EditValue)
                    });
                }
                else
                {
                    if (
                        GlobalDataContext.EscalaSalarial.Any(
                            c => c.Escala == Convert.ToInt32(EscalaSalarial_textEdit.EditValue) && c.EscalaSalarialID != GlobalEscalaSalarial.EscalaSalarialID))
                    {
                        Utils.MuestraError("Escala Salarial definida con anterioridad");
                        EscalaSalarial_textEdit.EditValue = String.Empty;
                    }
                    else
                    {
                        GlobalEscalaSalarial.Escala = Convert.ToInt32(EscalaSalarial_textEdit.EditValue);

                    }
                }

                try
                {
                    GlobalDataContext.SubmitChanges();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception)
                {
                    Utils.MuestraError("Error durante la operación");
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}