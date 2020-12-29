using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table("Debitos")]
    public class Debito : Lancamento
    {
        public int Cte { get; set; }
        public int Volumes { get; set; }
        public int Cliente_Id { get; set; }
        public int TipoCobranca_Id { get; set; } 
        public virtual Cliente Cliente { get; set; }
        public virtual TipoCobranca TipoCobranca { get; set; }


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
                    debito.Fechamento_Id = Fechamento_Id;
                }
                Banco.SaveChanges();
            }
        }
    }
}