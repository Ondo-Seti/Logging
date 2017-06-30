using System;
using System.Windows.Forms;

namespace Ondo.Logging.WindowsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Ondo.Logging.Desktop.Application.UseOndoLogging();

            Application.Run(new LoggingExampleForm());
        }       
    }   
}
