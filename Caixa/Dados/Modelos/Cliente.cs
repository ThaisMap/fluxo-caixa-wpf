using System.Collections.Generic;

namespace Dados.Modelos
{
    public class Cliente : BaseClass
    {
        public Cliente(string nome, TipoCobranca tipoCobranca, int id) : base(id)
        {
            Nome = nome;
            TipoCobranca = tipoCobranca;
        }

        public string Nome { get; set; }
        public TipoCobranca TipoCobranca { get; set; }
        public ICollection<Debito> Debitos { get; set; }
    }
}