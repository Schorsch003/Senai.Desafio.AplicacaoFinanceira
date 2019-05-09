using System;

namespace Senai.Desafio.AplicacaoFinanceira.Model {
    public class TransacaoModel {
        string TipoTransacao {get;set;}
        string Descricao {get;set;}
        DateTime DataTransacao {get;set;}
        float Valor {get;set;}
    }
}