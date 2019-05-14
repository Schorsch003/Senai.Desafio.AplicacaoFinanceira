using System;
using System.Collections.Generic;
using System.IO;
using Ionic.Zip;
using Senai.Desafio.AplicacaoFinanceira.Model;
using Spire.Doc;
using Spire.Doc.Documents;

namespace Senai.Desafio.AplicacaoFinanceira.Repositorio {
    public class TransacaoRepositorio {

        public void Inserir (TransacaoModel tm) {

            StreamWriter sw = new StreamWriter ("transacoes.csv", true);
            sw.WriteLine ($"{tm.IdUsuario};{tm.TipoTransacao}; {tm.Descricao}; {tm.Valor}; {tm.DataTransacao}");
            sw.Close ();
            CriarArquivo ();

        }

        public List<TransacaoModel> ListarTransacoes () {
            var listaTransacoes = new List<TransacaoModel> ();
            TransacaoModel TransacaoListado;

            if (!File.Exists ("transacoes.csv")) {
                return null;
            }

            string[] linhasTransicoes = File.ReadAllLines ("transacoes.csv");
            foreach (var item in linhasTransicoes) {
                if (item == null) {
                    return null;
                }

                TransacaoListado = new TransacaoModel ();
                string[] dadosTransacao = item.Split (";");
                for (int i = 0; i < dadosTransacao.Length; i++) {
                    TransacaoListado.IdUsuario = int.Parse (dadosTransacao[0]);
                    TransacaoListado.TipoTransacao = dadosTransacao[1];
                    TransacaoListado.Descricao = dadosTransacao[2];
                    TransacaoListado.Valor = float.Parse (dadosTransacao[3]);
                    TransacaoListado.DataTransacao = DateTime.Parse (dadosTransacao[4]);
                }
                listaTransacoes.Add (TransacaoListado);
            }
            return listaTransacoes;
        }

        public void CriarArquivo () {
            Document documento = new Document ();
            float despesa = 0, receita = 0;
            var listaTransacoes = ListarTransacoes ();
            UsuarioRepositorio ur = new UsuarioRepositorio ();
            var listaUsuarios = ur.Listar ();

            Paragraph p1 = documento.AddSection ().AddParagraph ();

            foreach (var item in listaTransacoes) {
                if (item.TipoTransacao.Equals ("Receita")) {
                    receita += item.Valor;
                } else {
                    despesa += item.Valor;
                }
                float Saldo = receita - despesa;
                foreach (var itens in listaUsuarios) {
                    if ((item != null && itens != null) && itens.Id.Equals (item.IdUsuario)) {
                        p1.AppendText ($"Usuario: {itens.Nome}\nSaldo: {Saldo}");
                        p1.AppendText ($"\nTipo de transação: {item.TipoTransacao}\nData da Transação: {item.DataTransacao}\nDescrição da Transação: {item.Descricao}\nValor da Descriçao: {item.Valor}\n");
                        p1.AppendText ($"---------------------------------------------------------------------------------------------------------------------------");
                    }

                }
            }

            documento.SaveToFile ("Transacoes.docx");

            ZipFile zip = new ZipFile ();

            zip.AddFile ("Transacoes.docx");
            zip.Save ("Transacoes.zip");

        }

    }
}