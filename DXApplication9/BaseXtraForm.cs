using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace DXApplication9
{
    public partial class BaseXtraForm : DevExpress.XtraEditors.XtraForm
    {
        //public BaseXtraForm()
        //{
        //    InitializeComponent();
        //}

        public GridColumn GetClickedInformation(GridControl aGridControl, GridView agridView, out int rowHandle)
        {
            var gridView = agridView;
            Point clickPoint = aGridControl.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {
                rowHandle = hitInfo.RowHandle;
                GridColumn column = hitInfo.Column;
                return column;
            }
            rowHandle = 0;
            return null;
        }

        //private SplashScreenManager GetMainSplashScreen()
        //{
        //    var _MainForm = (MainForm)MdiParent;
        //    if (_MainForm != null)return _MainForm.MainSplashScreenManager;
        //    return null;
        //}

        //protected void CierraSplashScreen()
        //{
        //    var SplashScreen = GetMainSplashScreen();
        //    if (SplashScreen != null) SplashScreen.CloseWaitForm();
        //}

        //protected void MuestraSplashScreen()
        //{
        //    var SplashScreen = GetMainSplashScreen();
        //    if (SplashScreen != null) SplashScreen.ShowWaitForm();
        //}
    }


}