using System;
using Senai.Desafio.AplicacaoFinanceira.Controller;
using Senai.Desafio.AplicacaoFinanceira.Utils;

namespace Senai.Desafio.AplicacaoFinanceira
{
    class Program {
        static void Main (string[] args) {
            Console.Clear ();
            int codigo = MenuUtils.MenuDeslogado ();
            switch (codigo) {
                case 1:
                UsuarioController.CadastrarUsuario();
                    break;
                case 2:
                    break;
            }
        }
    }
}