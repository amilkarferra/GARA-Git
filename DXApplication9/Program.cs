using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;


namespace DXApplication9
{
    
    static class Program
    {
       
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(){
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-Es");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-Es");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.XtraEditors.WindowsFormsSettings.ColumnFilterPopupMode = ColumnFilterPopupMode.Excel;
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    " El problema:" + e.Message +" no permite comenzar con la aplicación, Por favor comuniquelo al especialista encargado", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //Cachet _Cachet = new Cachet();
            //_Cachet.AgrupacionsIds = new[] {1, 2};

        }
       }
}
