using Dados;
using System.Collections.Generic;

namespace Dados.Modelos
{
    public class TipoCobranca
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Debito> Debitos { get; set; }

        public TipoCobranca()
        {

        }
        public TipoCobranca(string descricao) 
        {
            Descricao = descricao;
        }

        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if(Id == 0)
                {
                    Banco.TiposCobranca.Add(this);
                }
                else
                {
                    Banco.TiposCobranca.Find(Id).Descricao = Descricao;
                }
                Banco.SaveChanges();
            }            
        }
    }
}