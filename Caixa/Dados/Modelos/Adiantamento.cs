using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Adiantamentos")]
    public class Adiantamento : Lancamento
    {

        public string Placa { get; set; }
        public string Motorista { get; set; }
        public bool Pendente { get; set; }
        public Adiantamento(string placa, string motorista, bool pendente, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario_Id, lancamento.Filial_Id, lancamento.Valor, lancamento.TipoDocumento)
        {
            Placa = placa;
            Motorista = motorista;
            Pendente = pendente;
        }

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