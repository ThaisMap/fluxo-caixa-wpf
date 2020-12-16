using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Debitos")]
    public class Debito : Lancamento
    {
        public Debito(TipoCobranca tipoCobranca, string cte, int volumes, Cliente cliente, int? fechamento, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario, lancamento.Filial, lancamento.Valor, lancamento.TipoDocumento, lancamento.Id)
        {
            TipoCobranca = tipoCobranca;
            Cte = cte;
            Volumes = volumes;
            Cliente = cliente;
            Fechamento = fechamento;
        }

        public string Cte { get; set; }
        public int Volumes { get; set; }
        public Cliente Cliente { get; set; }
        public TipoCobranca TipoCobranca { get; set; }
        public int? Fechamento { get; set; }
    }
}