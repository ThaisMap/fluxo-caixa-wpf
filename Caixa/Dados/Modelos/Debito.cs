using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Debitos")]
    public class Debito : Lancamento
    {
        public Debito(TipoCobranca tipoCobranca, string cte, int volumes, Cliente cliente, int? fechamento, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario, lancamento.Filial, lancamento.Valor, lancamento.TipoDocumento)
        {
            TipoCobranca_Id = tipoCobranca.Id;
            Cte = cte;
            Volumes = volumes;
            Cliente = cliente;
            Fechamento = fechamento;
        }
        public Debito() : base()
        {

        }

        public string Cte { get; set; }
        public int Volumes { get; set; }
        public int Cliente_Id { get; set; }
        public int TipoCobranca_Id { get; set; }
        public int? Fechamento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual TipoCobranca TipoCobranca { get; set; }
    }
}