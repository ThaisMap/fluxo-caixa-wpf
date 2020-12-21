using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Suprimentos")]
    public class Suprimento : Lancamento
    {
        public int? Fechamento { get; set; }

        public Suprimento(int? fechamento, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario_Id, lancamento.Filial_Id, lancamento.Valor, lancamento.TipoDocumento)
        {
            Fechamento = fechamento;
        }

        public Suprimento() : base()
        {

        }
        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Suprimentos.Add(this);
                }
                else
                {
                    var suprimento = Banco.Suprimentos.Find(Id);
                    suprimento.Fechamento = Fechamento;
                }
                Banco.SaveChanges();
            }
        }
    }
}