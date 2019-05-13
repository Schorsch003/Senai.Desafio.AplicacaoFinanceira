using System;
using System.Collections.Generic;
using System.IO;
using Senai.Desafio.AplicacaoFinanceira.Model;
using Senai.Desafio.AplicacaoFinanceira.Repositorio;

namespace Senai.Desafio.AplicacaoFinanceira.Controller {
    public class TransicaoController {
        static TransacaoRepositorio tr = new TransacaoRepositorio ();
        public static void InserirCredito (UsuarioModel us) {
            float valor;
            string descricao;
            Console.WriteLine ("Qual o Valor requisitado");
            valor = float.Parse (Console.ReadLine ());
            Console.WriteLine ("De uma Descrição ao crédito inserido");
            descricao = Console.ReadLine ();

            TransacaoModel transacao = new TransacaoModel ();
            transacao.IdUsuario = us.Id;
            transacao.TipoTransacao = "Receita";
            transacao.Valor = valor;
            transacao.Descricao = descricao;
            transacao.DataTransacao = DateTime.Now;

            tr.Inserir (transacao);

        }
        public static void DebitarDespesa (UsuarioModel us) {
            float valor;
            string descricao;
            Console.WriteLine ("Qual o Valor da despesa");
            valor = float.Parse (Console.ReadLine ());
            Console.WriteLine ("De uma Descrição ao crédito debitado");
            descricao = Console.ReadLine ();

            TransacaoModel transacao = new TransacaoModel ();
            transacao.IdUsuario = us.Id;
            transacao.TipoTransacao = "Despesa";
            transacao.Valor = valor;
            transacao.Descricao = descricao;
            transacao.DataTransacao = DateTime.Now;

            tr.Inserir (transacao);

        }

        public static void ListarTransacoes (UsuarioModel us) {
            List<TransacaoModel> listaTransacoes = tr.ListarTransacoes ();

            float receita = 0;
            float despesa = 0;
            foreach (var item in listaTransacoes) {
                if (item != null && us.Id.Equals (item.IdUsuario)) {

                    Console.WriteLine ($"{item.TipoTransacao}\nR${item.Valor}\n{item.Descricao}\n{item.DataTransacao}\n");
                    Console.WriteLine ("---------------------------------------------------------------------------------");
                    if (item.TipoTransacao.Equals ("Receita")) {
                        receita += item.Valor;
                    } else {
                        despesa += item.Valor;
                    }
                    float Saldo = receita - despesa;

                    Console.WriteLine ($"Seu saldo é de: {Saldo}");

                }
            }
            Console.WriteLine ("Pressione ENTER para voltar ao Menu");
            Console.ReadLine ();
        }
    }
}