﻿using System;
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


    public partial class EmpresariosForm : DevExpress.XtraEditors.XtraForm
    {
      NegocioDataContext  AGlobalDataContext = new NegocioDataContext();
       
        public EmpresariosForm(NegocioDataContext aGlobalDataContext=null)
        {
            InitializeComponent();
            
            // This line of code is generated by Data Source Configuration Wizard
            bindingSource1.DataSource = AGlobalDataContext.Empresarios;}

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                AGlobalDataContext.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                
                var gridView = gridView1;
                XtraMessageBox.Show("Error en la operacion",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    gridView.DeleteRow(e.RowHandle);
            }
         }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
           AGlobalDataContext.SubmitChanges();
            DialogResult = DialogResult.OK;}

        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
          
        }
    }
}