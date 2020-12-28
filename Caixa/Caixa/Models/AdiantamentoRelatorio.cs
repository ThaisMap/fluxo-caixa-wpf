using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Models
{
    public class AdiantamentoRelatorio
    {
        public AdiantamentoRelatorio(int id)
        {

            using (var Banco = new CaixaContext())
            {
                var adianto = Banco.Adiantamentos.Include("Filial").Where(x => x.Id == id).FirstOrDefault();
                if(adianto != null)
                {
                    Id = id;
                    NomeFilial = adianto.Filial.Nome;
                    Motorista = adianto.Motorista;
                    Placa = adianto.Placa;
                    Valor = adianto.Valor;
                }
            }   
        }

        public int Id { get; }
        public string NomeFilial { get; }
        public string Motorista { get; }
        public string Placa { get; }
        public double  Valor { get; }
    }
}
