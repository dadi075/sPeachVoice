using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sPeachVoice
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new Main();
        }
    }
    public class Main
    {
        public Connection connection = new Connection();

        public Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm(this));
        }
    }
}
