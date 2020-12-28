using Dados;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table("TIposCobranca")]
    public class TipoCobranca
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Debito> Debitos { get; set; }

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