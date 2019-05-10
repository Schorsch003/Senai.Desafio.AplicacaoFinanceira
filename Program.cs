using System;
using Senai.Desafio.AplicacaoFinanceira.Controller;
using Senai.Desafio.AplicacaoFinanceira.Repositorio;
using Senai.Desafio.AplicacaoFinanceira.Utils;

namespace Senai.Desafio.AplicacaoFinanceira {
    class Program {
        static void Main (string[] args) {
            Console.Clear ();
            bool querSair = false;
            do {
                int codigo = MenuUtils.MenuDeslogado ();
                switch (codigo) {
                    case 1:
                        UsuarioController.CadastrarUsuario ();
                        break;
                    case 2:
                        var usuarioLogado = UsuarioController.FazerLogin ();
                        if (usuarioLogado != null) {
                            MenuUtils.MenuLogado ();
                        }
                        bool opcaoLogado = false;

                        do {
                            int codigoLogado = MenuUtils.MenuLogado ();
                            switch (codigoLogado) {
                                case 1:
                                    //Inserir credito
                                    TransicaoController.InserirCredito();
                                    break;
                                case 2:
                                    //REalizar transição
                                    TransicaoController.DebitarDespesa();
                                    break;
                                case 3:
                                    //
                                    TransicaoController.ListarTransacoes();
                                    break;

                                case 0:
                                    //Encerar transação
                                    opcaoLogado = true;
                                    break;
                            }

                        } while (!opcaoLogado);
                        break;
                    case 0:
                        querSair = true;
                        break;
                }
            } while (!querSair);
        }
    }
}