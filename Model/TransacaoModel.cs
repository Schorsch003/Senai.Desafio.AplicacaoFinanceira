using System;

namespace Senai.Desafio.AplicacaoFinanceira.Model {
    public class TransacaoModel {
        public int IdUsuario {get;set;}
        public string TipoTransacao {get;set;}
        public string Descricao {get;set;}
        public DateTime DataTransacao {get;set;}
        public float Valor {get;set;}
    }
}