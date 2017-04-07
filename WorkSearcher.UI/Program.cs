using System;
using System.Windows.Forms;
using WorkerSearcher.Computrabajo;

namespace WorkSearcher.UI
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
            Application.Run(new Form1(new ComputrabajoSearcher()));
        }
    }
}
