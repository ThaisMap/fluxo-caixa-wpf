using System.Collections.Generic;

namespace Dados.Modelos
{
    public class TipoCobranca : BaseClass
    {
        public string Descricao { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Debito> Debitos { get; set; }

        public TipoCobranca(string descricao, int id) : base(id)
        {
            Descricao = descricao;
        }
    }
}