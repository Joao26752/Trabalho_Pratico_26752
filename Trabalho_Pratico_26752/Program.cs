using System;
using System.Windows.Forms;

namespace Trabalho_Pratico_26752
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new LoginForm();
            Application.Run(loginForm); // Come�a pela tela de login
        }
    }
}
