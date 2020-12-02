using System;
using System.Collections.Generic;

namespace Dados
{
    public static class Listas
    {
        public static List<Caixa> GetCaixas = new List<Caixa>()
            {
                new Caixa("27/11/2020", "-", "-", "SUPRIMENTO", "R$ 2000,00", "SUPRIMENTO"),
                new Caixa("27/11/2020", "123456", "PRAFESTA", "DEBITO", "R$ 20,00", "RECIBO"),
                new Caixa("27/11/2020", "001", "CASTELATO", "DEBITO", "R$ 200,00", "ADIANTAMENTO"),
                new Caixa("28/11/2020", "001", "ESTORNO ADIANTAMENTO 001", "CRÉDITO", "R$ 200,00", "ESTORNO"),
                new Caixa("27/11/2020", "102030", "MARILAN", "DEBITO", "R$ 50,00", "RECIBO"),
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
