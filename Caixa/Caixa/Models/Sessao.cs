using Dados;
using Dados.Modelos;
using System;
using System.Linq;

namespace Caixa.Models
{
    public sealed class Sessao : Observavel
    {
        private static Sessao instancia = null;
        private Filial filial;
        private Usuario usuario;
        private double saldoInicial = 0;
        public static Sessao Status
        {
            get
            {
                if (instancia == null)
                { instancia = new Sessao(); }
                return instancia;
            }
        }

        public DateTime Hoje { get => DateTime.Today; }
        public int IdFilial { get => filial.Id; }
        public int IdUsuario { get => usuario.Id; }
        public string NomeFilial { get => filial.Nome; }
        public string NomeUsuario { get => usuario.Nome; }

        public bool UsuarioMaster { get => usuario.Admin; }

        public double Saldo
        {
            get => filial.Saldo;
            set
            {
                filial.Saldo = value;
                OnPropertyChanged("Saldo");
            }
        }

        public double SaldoInicial
        {
            get => saldoInicial;
            set
            {
                saldoInicial = value;
                OnPropertyChanged("SaldoInicial");
            }
        }

        private Sessao()
        {
            using (var Banco = new CaixaContext())
            {
                usuario = Banco.Usuarios.Where(x => x.Id == 1).FirstOrDefault();
                filial = Banco.Filiais.Find(usuario.Filial_Id);
            }
            RecarregarFechamento();
        }

        public void AddValorSaldoFilial(double valor)
        {
            // Pode ter sido adicionado um lançamento numa data anterior, daí alteraria o saldo inicial mais recente
            RecarregarFechamento();
            Saldo += valor;
            filial.Salvar();
        }

        private void RecarregarFechamento()
        {
            using (var Banco = new CaixaContext())
            {
                var fechamentoBanco = Banco.Fechamentos
                    .Where(x => x.Filial_Id == filial.Id && !x.Fechado)
                    .OrderByDescending(x => x.Data)
                    .FirstOrDefault();

                //  se não tiver nenhum fechamento aberto, considera o saldo da filial como inicial e final
                SaldoInicial = fechamentoBanco == null ? filial.Saldo : fechamentoBanco.ValorInicial;
            }
        }
    }
}