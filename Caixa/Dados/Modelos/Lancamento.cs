using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Lancamentos")]
    public class Lancamento 
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public int TipoDocumento_Id { get; set; }
        public int Usuario_Id { get; set; }
        public int Filial_Id { get; set; }
        public int Fechamento_Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Filial Filial { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }

        public virtual Fechamento Fechamento { get; set; }
        public Lancamento()
        {

        }
        public Lancamento(DateTime data, int usuario, int filial, double valor, TipoDocumento tipoDocumento)
        {
            Data = data;
            Usuario_Id = usuario;
            Filial_Id = filial;
            Valor = tipoDocumento.Soma ? valor : -valor;
            TipoDocumento_Id = tipoDocumento.Id;
        }
         

        public void SalvarSuprimento()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Lancamentos.Add(this);
                }
                else
                {
                    var lancamento = Banco.Lancamentos.Find(Id);
                    lancamento.TipoDocumento_Id = TipoDocumento_Id;
                }
                Banco.SaveChanges();
            }
        }
    }
}