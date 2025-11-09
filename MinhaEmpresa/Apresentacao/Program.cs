using MinhaEmpresa.Apresentacao;
using System;

namespace MinhaEmpresa
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Menu menu = new Menu();
            menu.ShowDialog();

        }
    }
}
