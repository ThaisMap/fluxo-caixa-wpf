using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Adiantamentos")]
    public class Adiantamento : Lancamento
    {

        public string Placa { get; set; }
        public string Motorista { get; set; }
        public bool Pendente { get; set; } = true;
       
        public Adiantamento() : base()
        {

        }

        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Adiantamentos.Add(this);
                }
                else
                {
                    var adiantamento = Banco.Adiantamentos.Find(Id);
                    adiantamento.Pendente = Pendente;
                }
                Banco.SaveChanges();
            }
        }

    }
}