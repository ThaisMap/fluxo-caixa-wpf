using Dados;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caixa.Models
{
    public sealed class Sessao : Observavel
    { 
        private Dados.Modelos.Usuario usuario;
        private  Filial filial;
        private Fechamento fechamento;
        private static Sessao instancia = null;

        public string NomeUsuario { get => usuario.Nome; }
        public int IdUsuario { get => usuario.Id; }
        public string NomeFilial { get => filial.Nome; }
        public int IdFilial { get => filial.Id; }
        public double SaldoInicial { get => fechamento.ValorInicial; }  

        public static Sessao Status { get
            {
                if (instancia == null)
                { instancia = new Sessao(); }
                return instancia;
            } }

        public double Saldo
        {
            get => filial.Saldo;
            set
            {
                ValidateProperty(value, "Saldo");
                filial.Saldo = value;
                OnPropertyChanged("Saldo");
            }
        }
        
        public DateTime Hoje { get => DateTime.Today; }

        public int IdFechamento { get => fechamento.Id; }
        private Sessao()
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
            Saldo += valor;
            filial.Salvar();
        }

    }
}
