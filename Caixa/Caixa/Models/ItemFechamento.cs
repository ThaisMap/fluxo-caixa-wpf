using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Models
{  
    public class ItemFechamento
    {
        public DateTime Data        { get; private set; }
        public string Cliente       { get; private set; }
        public string CTe              { get; private set; }
        public string Volumes          { get; private set; }
        public string TipoDocumento  { get; private set; }
        public string TipoCobranca  { get; private set; }
        public double Valor         { get; private set; }
        public double SaldoInicial  { get; private set; }
        public double SaldoFinal    { get; private set; }
        public string Filial        { get; private set; }
        public string Usuario        { get; private set; }

        public ItemFechamento(int idLancamento)
        {
            using (var Banco = new CaixaContext())
            {
                var lancamento = Banco.Lancamentos.Find(idLancamento);
                if (lancamento != null)
                {
                    Data = lancamento.Data;
                    TipoDocumento = lancamento.TipoDocumento.Descricao;
                    Valor = lancamento.Valor;
                    SaldoInicial = lancamento.Fechamento.ValorInicial;
                    SaldoFinal =  lancamento.Fechamento.ValorFinal == null ? 0 : (double)lancamento.Fechamento.ValorFinal;
                    Filial = lancamento.Filial.Nome;
                    Usuario = lancamento.Usuario.Nome;

                    //CASO SEJA UM DEBITO
                    var debito = Banco.Debitos.FirstOrDefault(x=> x.Id == idLancamento);
                    if (debito != null)
                    {
                        Cliente = debito.Cliente.Nome;
                        CTe = debito.Cte.ToString();
                        Volumes = debito.Volumes.ToString();
                        TipoCobranca = debito.TipoCobranca.Descricao;
                    }
                    else
                    {//CASO SEJA UM SUPRIMENTO
                        CTe = "";
                        Volumes = "";
                        TipoCobranca = "";
                        Cliente = "";
                        if (TipoDocumento.ToLower().Contains("adiantamento"))
                            TipoDocumento += " " + idLancamento;
                        //CASO SEJA UM ADIANTAMENTO
                        var adiantamento = Banco.Adiantamentos.FirstOrDefault(x => x.Id == idLancamento);
                        if (adiantamento != null)
                        {
                            Cliente = adiantamento.Motorista; 
                        }
                         
                    }
                }
            }

        }
    }
}
