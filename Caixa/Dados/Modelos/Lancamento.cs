using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table ("Lancamentos")]
    public class Lancamento : BaseClass
    {
        public Lancamento(DateTime data, Usuario usuario, Filial filial, double valor, TipoDocumento tipoDocumento, int id) : base(id)
        {
            Data = data;
            Usuario = usuario;
            Filial = filial;
            Valor = tipoDocumento.Soma ? valor : -valor;
            TipoDocumento = tipoDocumento;
        }

        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public Filial Filial { get; set; }
        public double Valor { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
}