using System.Collections.Generic;

namespace Dados.Modelos
{
    public class TipoDocumento : BaseClass
    {
        public string Descricao { get; set; }
        public bool Soma { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }

        public TipoDocumento(string descricao, bool soma, int id) : base(id)
        {
            Descricao = descricao;
            Soma = soma;
        }
    }
}