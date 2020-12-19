using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Adiantamentos")]
    public class Adiantamento : Lancamento
    {
        public Adiantamento(string placa, string motorista, bool pendente, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario, lancamento.Filial, lancamento.Valor, lancamento.TipoDocumento)
        {
            Placa = placa;
            Motorista = motorista;
            Pendente = pendente;
        }

        public Adiantamento() : base()
        {

        }

        public string Placa { get; set; }
        public string Motorista { get; set; }
        public bool Pendente { get; set; }

    }
}