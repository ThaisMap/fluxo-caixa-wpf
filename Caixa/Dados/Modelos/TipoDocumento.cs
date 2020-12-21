using System.Collections.Generic;

namespace Dados.Modelos
{
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