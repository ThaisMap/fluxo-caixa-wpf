using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Suprimentos")]
    public class Suprimento : Lancamento
    {
        public Suprimento(int? fechamento, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario, lancamento.Filial, lancamento.Valor, lancamento.TipoDocumento)
        {
            Fechamento = fechamento;
        }

        public Suprimento() : base()
        {

        }

        public int? Fechamento { get; set; }
    }
}