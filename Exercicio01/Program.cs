using System;
using System.Collections.Generic;

namespace Exercicio01
{
    class Program
    {

        static void Main(string[] args)
        {
            //Operacoes.TipoOperacoes();

            List<OS> _osList = new List<OS>();

            Metodos.CarregarMenuPrincipal();

            string _menu = Console.ReadLine().ToString();

            Metodos.MenuOpcoes(_osList, _menu, null);
        }
    }
}


