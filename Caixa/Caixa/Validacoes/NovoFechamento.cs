using Caixa.Models;
using Dados;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Validacoes
{
    public class NovoFechamento
    {  
        public static bool ValidaDataFechamento(DateTime dataTestada)
        {
            int filial = Sessao.Status.IdFilial;


            using (var Banco = new CaixaContext())
            {
                var fechamentosFilial = Banco.Fechamentos.Where(x => x.Filial_Id == filial);
                var dataIgual = fechamentosFilial.Where(x => DbFunctions.TruncateTime(x.Data) == DbFunctions.TruncateTime(dataTestada)).FirstOrDefault();
                if(dataIgual != null) // se houver fechamento na data do lançamento 
                { 
                    //se o fechamento estiver aberto a data é válida
                    //mas ele estiver fechado, a data é invalida
                    return !dataIgual.Fechado;
                } 
                else //se nao houver fechamento na data informada
                {
                    //se houver algum fechamento fechado após ou na data, a data é invalida
                    var dataMaior = fechamentosFilial.Where(x => DbFunctions.TruncateTime(x.Data) >= DbFunctions.TruncateTime(dataTestada)).OrderBy(x => x.Data);
                    if (dataMaior.Any(x=> x.Fechado == true))
                        return false;
                    else
                    { //se não criamos um novo fechamento na data informada
                        var novo = new Dados.Modelos.Fechamento()
                        {
                            ArquivoScan = "",
                            Data =  dataTestada,
                            Fechado = false,
                            Filial_Id = filial,
                            ValorInicial = dataMaior.Any(x => x.Fechado == false) ? dataMaior.First().ValorInicial : Sessao.Status.Saldo
                        };

                        Banco.Fechamentos.Add(novo);
                        return true;
                    }
                }
            }
        }
    }
}
