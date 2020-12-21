using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table("Debitos")]
    public class Debito : Lancamento
    {
        public string Cte { get; set; }
        public int Volumes { get; set; }
        public int Cliente_Id { get; set; }
        public int TipoCobranca_Id { get; set; }
        public int? Fechamento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual TipoCobranca TipoCobranca { get; set; }


        public Debito(TipoCobranca tipoCobranca, string cte, int volumes, Cliente cliente, int? fechamento, Lancamento lancamento) :
           base(lancamento.Data, lancamento.Usuario_Id, lancamento.Filial_Id, lancamento.Valor, lancamento.TipoDocumento)
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
        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Debitos.Add(this);
                }
                else
                {
                    var debito = Banco.Debitos.Find(Id);
                    debito.Fechamento = Fechamento;
                }
                Banco.SaveChanges();
            }
        }
    }
}