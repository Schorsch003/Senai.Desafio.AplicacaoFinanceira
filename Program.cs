using System;
using Senai.Desafio.AplicacaoFinanceira.Controller;
using Senai.Desafio.AplicacaoFinanceira.Model;
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
                        Console.Clear ();
                        UsuarioController.CadastrarUsuario ();
                        break;
                    case 2:
                        Console.Clear ();
                        var usuarioLogado = UsuarioController.FazerLogin ();
                        bool opcaoLogado = false;
                        if (usuarioLogado != null) {
                            do {
                                int codigoLogado = MenuUtils.MenuLogado ();
                                switch (codigoLogado) {
                                    case 1:
                                        //Inserir credito
                                        Console.Clear ();
                                        TransicaoController.InserirCredito (usuarioLogado);
                                        break;
                                    case 2:
                                        //Realizar transação
                                        Console.Clear ();
                                        TransicaoController.DebitarDespesa (usuarioLogado);
                                        break;
                                    case 3:
                                        // Listar transações
                                        Console.Clear ();
                                        TransicaoController.ListarTransacoes (usuarioLogado);
                                        break;
                                    case 0:
                                        //Encerar transação
                                        TransacaoRepositorio tr = new TransacaoRepositorio ();
                                        tr.CriarArquivo ();
                                        opcaoLogado = true;
                                        break;
                                }
                            } while (!opcaoLogado);
                        }
                        break;
                    case 9:
                        UsuarioRepositorio ur = new UsuarioRepositorio ();
                        ur.CriarArquivo ();
                        break;
                    case 0:
                        querSair = true;
                        break;
                }
            }
            while (!querSair);
        }
    }
}