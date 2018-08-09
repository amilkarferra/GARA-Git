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
    public partial class DocumentosInvitadosXtraForm : DevExpress.XtraEditors.XtraForm
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private int AParticipanteId;
        public DocumentosInvitadosXtraForm(int aParticipanteId)
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            bindingSource1.DataSource =
                AGlobalDataContext.DocumentosInvitados.Where(c => c.ParticipanteId == aParticipanteId)
                    .Select(c => c.Imagenes);
            AParticipanteId = aParticipanteId;
        }

        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                int[] filas = gridView1.GetSelectedRows();

                foreach (var fila in filas)
                {
                    Imagenes imagen = (Imagenes)gridView1.GetRow(fila);
                    AGlobalDataContext.Imagenes.DeleteOnSubmit(imagen);
                }
                AGlobalDataContext.SubmitChanges();
              }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            var a = e.Column;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var imagen = (Imagenes)e.Row;
            AGlobalDataContext.SubmitChanges();
            AGlobalDataContext.DocumentosInvitados.InsertOnSubmit(new DocumentosInvitados{ImagenId = imagen.ImagenID,ParticipanteId = AParticipanteId});
            AGlobalDataContext.SubmitChanges();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            pictureEdit1.Image = ((Imagenes)gridView1.GetFocusedRow()).BitmapImagen;
        }
    }
}