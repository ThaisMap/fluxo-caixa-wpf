using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table("TiposDocumento")]
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Soma { get; set; }
        public virtual ICollection<Lancamento> Lancamentos { get; set; }

        public TipoDocumento(string descricao, bool soma)
        {
            Descricao = descricao;
            Soma = soma;
        }
        public TipoDocumento()
        {
                
        }

        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.TiposDocumento.Add(this);
                }
                else
                {
                    var tipo = Banco.TiposDocumento.Find(Id);
                   tipo.Descricao = Descricao;
                   tipo.Soma = Soma;
                }
                Banco.SaveChanges();
            }
        }

    }
}