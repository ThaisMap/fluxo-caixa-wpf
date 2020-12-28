using Dados;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caixa.Models
{
    public class Sessao : Observavel
    { 
        private Dados.Modelos.Usuario usuario;
        private  Filial filial;
        private Fechamento fechamento;

        public string NomeUsuario { get => usuario.Nome; }
        public int IdUsuario { get => usuario.Id; }
        public string NomeFilial { get => filial.Nome; }
        public int IdFilial { get => filial.Id; }
        public double SaldoInicial { get => fechamento.ValorInicial; } 
        public double Saldo { get => filial.Saldo; }  
        public DateTime Hoje { get => DateTime.Today; }

        public int IdFechamento { get => fechamento.Id; }
        public Sessao()
        {
            using (var Banco = new CaixaContext())
            {
                usuario = Banco.Usuarios.First();
                filial = new Filial(Banco.Filiais.Find(usuario.Filial_Id));

               var fechamentoBanco = Banco.Fechamentos.FirstOrDefault(x => x.Filial_Id == filial.Id && x.Data >= Hoje);
                if(fechamentoBanco == null)
                {
                    fechamento = new Fechamento(filial);
                    fechamento.Salvar();
                }
                else
                {
                    fechamento = new Fechamento(fechamentoBanco);
                }
            }
        }

        public void AddValorSaldoFilial(double valor)
        {
            filial.Saldo += valor;
            filial.Salvar();
        }

    }
}
