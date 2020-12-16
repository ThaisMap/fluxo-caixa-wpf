using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Suprimentos")]
    public class Suprimento : Lancamento
    {
        public Suprimento(int? fechamento, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario, lancamento.Filial, lancamento.Valor, lancamento.TipoDocumento, lancamento.Id)
        {
            Fechamento = fechamento;
        }

        public int? Fechamento { get; set; }
    }
}