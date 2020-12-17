using System.Collections.Generic;

namespace Dados.Modelos
{
    public class TipoDocumento : BaseClass
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Soma { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }

        public TipoDocumento(string descricao, bool soma)
        {
            Descricao = descricao;
            Soma = soma;
        }
        public TipoDocumento()
        {
                
        }

    }
}