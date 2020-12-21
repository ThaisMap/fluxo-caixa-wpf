using System.Collections.Generic;

namespace Dados.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoCobranca_Id { get; set; }

        public virtual TipoCobranca TipoCobranca { get; set; }
        public virtual ICollection<Debito> Debitos { get; set; }


        public Cliente(string nome, TipoCobranca tipoCobranca) 
        {
            Nome = nome;
            TipoCobranca_Id = tipoCobranca.Id;
        }

        public Cliente()
        {
                
        }

         
        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Clientes.Add(this);
                }
                else
                {
                    var tipo = Banco.Clientes.Find(Id);
                    tipo.Nome = Nome;
                    tipo.TipoCobranca_Id = TipoCobranca_Id;
                }
                Banco.SaveChanges();
            }
        }
    }
}