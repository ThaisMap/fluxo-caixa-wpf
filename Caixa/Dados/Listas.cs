using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dados
{
    public static class Listas
    {
        private static CaixaContext Context = new CaixaContext();


        public static List<Caixa> GetCaixas = new List<Caixa>() {
            new Caixa(DateTime.Today, "-", "-", "SUPRIMENTO", 1,  2000.00, "SUPRIMENTO"),
            new Caixa(DateTime.Today, "123456", "PRAFESTA", "DEBITO", 10, -20, "RECIBO"),
            new Caixa(DateTime.Today, "001", "CASTELATO", "DEBITO", 100, -200, "ADIANTAMENTO"),
            new Caixa(DateTime.Today, "001", "ESTORNO ADIANTAMENTO 001", "CRÉDITO", 1, 250, "ESTORNO"),
            new Caixa(DateTime.Today, "102030", "MARILAN", "DEBITO", 10, -500, "RECIBO"),
        };

        public static List<Filial> Filiais = Context.Filiais.ToList();

        public static List<Usuario> UsuariosCadastrados = Context.Usuarios.ToList();

        public static List<TipoCobranca> TiposCobranca = Context.TiposCobranca.ToList();

        public static List<TipoDocumento> TiposDocumento = Context.TiposDocumento.ToList();

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
        public DateTime Data { get; set; }
        public string Cte { get; set; }
        public string Cliente { get; set; }
        public string TipoValor { get; set; }
        public int Volumes { get; set; }
        public double valor { get; set; }
        public string TipoCobranca { get; set; }



        public Caixa(DateTime data, string cte, string cliente, string tipoValor, int volumes, double valor, string tipoDoc)
        {
            Data = data;
            Cte = cte;
            Cliente = cliente;
            TipoValor = tipoValor;
            this.valor = valor;
            TipoCobranca = tipoDoc;
            Volumes = volumes;
        }
    }
}
