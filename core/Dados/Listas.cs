using Dados.Modelos;
using System;
using System.Collections.Generic;

namespace Dados
{
    public static class Listas
    { 
        public static List<Caixa> GetCaixas = new List<Caixa>() {
            new Caixa("27/11/2020", "-", "-", "SUPRIMENTO", "R$ 2000,00", "SUPRIMENTO"),
            new Caixa("27/11/2020", "123456", "PRAFESTA", "DEBITO", "R$ 20,00", "RECIBO"),
            new Caixa("27/11/2020", "001", "CASTELATO", "DEBITO", "R$ 200,00", "ADIANTAMENTO"),
            new Caixa("28/11/2020", "001", "ESTORNO ADIANTAMENTO 001", "CRÉDITO", "R$ 200,00", "ESTORNO"),
            new Caixa("27/11/2020", "102030", "MARILAN", "DEBITO", "R$ 50,00", "RECIBO"),
        };

        public static List<Filial> Filiais = new List<Filial>() {
            new Filial("Bicas", 1670, 1),
            new Filial("Atibaia", 5000, 2)
        };

        public static List<Usuario> UsuariosCadastrados = new List<Usuario>() {
            new Usuario("Walter", "1234", "walter", true, Filiais[0], 1),
            new Usuario("Thais", "1234", "thais", false, Filiais[0], 2), 
            new Usuario("Matheus", "1234", "matheus", true, Filiais[1], 3),
            new Usuario("Anderson", "1234", "anderson", false, Filiais[1], 4),
        };

        public static List<TipoCobranca> TiposCobranca = new List<TipoCobranca>()
        {
            new TipoCobranca("Reembolsada", 0),
            new TipoCobranca("Não Reembolsada", 1),
        };

        public static List<TipoDocumento> TiposDocumento = new List<TipoDocumento>()
        {
            new TipoDocumento("Suprimento", true, 0), 
            new TipoDocumento("Recibo", false, 1),
            new TipoDocumento("Nota Fiscal", false, 2),
            new TipoDocumento("Adiantamento", false, 3), 
            new TipoDocumento("Estorno de adiantamento", true, 4), 

        };

        public static List<Cliente> Clientes = new List<Cliente>()
        {
            new Cliente("MARILAN", TiposCobranca[0], 0), 
            new Cliente("PRAFESTA", TiposCobranca[1], 1),
            new Cliente("KIMBERLY REEMBOLSADO", TiposCobranca[0], 2),
            new Cliente("KIMBERLY NÃO REEMBOLSADO", TiposCobranca[1], 3),
        };

        public static List<Lancamento> Lancamentos = new List<Lancamento>()
        {
            new Lancamento(DateTime.Today.AddDays(-1), UsuariosCadastrados[0], Filiais[0], 2000.0 ,TiposDocumento[0], 0), //suprimento
            new Lancamento(DateTime.Today.AddDays(-1), UsuariosCadastrados[1], Filiais[0], 220.0, TiposDocumento[2], 1), //Nf
            new Lancamento(DateTime.Today.AddDays(-1), UsuariosCadastrados[1], Filiais[0], 250.0, TiposDocumento[3], 2), //adiantamento
            new Lancamento(DateTime.Today.AddDays(-1), UsuariosCadastrados[1], Filiais[0], 250.0, TiposDocumento[4], 3), // Estorno
            new Lancamento(DateTime.Today.AddDays(-1), UsuariosCadastrados[1], Filiais[0], 10.0, TiposDocumento[1], 4),//Recibo
            new Lancamento(DateTime.Today.AddDays(-1), UsuariosCadastrados[1], Filiais[0], 100.0, TiposDocumento[1], 5),//Recibo
            new Lancamento(DateTime.Today, UsuariosCadastrados[0], Filiais[0], 1000.0 ,TiposDocumento[0], 6), //suprimento
            new Lancamento(DateTime.Today, UsuariosCadastrados[1], Filiais[0], 150.0, TiposDocumento[3], 7),//adiantamento
            new Lancamento(DateTime.Today, UsuariosCadastrados[1], Filiais[0], 10.0, TiposDocumento[1], 8),//Recibo
            new Lancamento(DateTime.Today, UsuariosCadastrados[1], Filiais[0], 120.0, TiposDocumento[2], 9),  //Nf
            new Lancamento(DateTime.Today, UsuariosCadastrados[1], Filiais[0], 100.0, TiposDocumento[1],10),//Recibo
        };

        public static List<Suprimento> Suprimentos = new List<Suprimento>()
        {
            new Suprimento(0, Lancamentos[0]), 
            new Suprimento(null, Lancamentos[6]), 
            new Suprimento(0, Lancamentos[3])
        };

        public static List<Adiantamento> Adiantamentos = new List<Adiantamento>()
        {
            new Adiantamento("AAA1111", "JOSE DA SILVA", false, Lancamentos[2]),
            new Adiantamento("AAA1111", "JOAO DOS SANTOS", true, Lancamentos[7]),
        };

        public static List<Debito> Debitos = new List<Debito>()
        {
            new Debito(TiposCobranca[0], "321654", 100, Clientes[0], 0, Lancamentos[1]),
            new Debito(TiposCobranca[0], "321665", 200, Clientes[1], 0, Lancamentos[4]),
            new Debito(TiposCobranca[0], "321687", 300, Clientes[2], 0, Lancamentos[5]),
            new Debito(TiposCobranca[0], "321698", 120, Clientes[3], 0, Lancamentos[8]),
            new Debito(TiposCobranca[0], "321744", 130, Clientes[0], 0, Lancamentos[9]),
            new Debito(TiposCobranca[0], "321750", 140, Clientes[3], 0, Lancamentos[10])
        };

        public static List<Fechamento> Fechamentos = new List<Fechamento>()
        {
            new Fechamento(DateTime.Today.AddDays(-1), Filiais[0], 0.0, 1670.0, "S://caixa.pdf", 0),
            new Fechamento(DateTime.Today, Filiais[0], 1670.0, null, "", 1),
        };
    }





    public class Caixa
    {
        public string Data { get; set; }
        public string Cte { get; set; }
        public string Cliente { get; set; }
        public string TipoValor { get; set; }
        public string valor { get; set; }
        public string TipoDoc { get; set; }



        public Caixa(string data, string cte, string cliente, string tipoValor, string valor, string tipoDoc)
        {
            Data = data;
            Cte = cte;
            Cliente = cliente;
            TipoValor = tipoValor;
            this.valor = valor;
            TipoDoc = tipoDoc;
        }
    }
}
