using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using Dados.Modelos;

namespace Caixa.Models
{
    public class Suprimento_M : Observavel
    {
        private Lancamento suprimento = new Lancamento();
        private Sessao status = Sessao.Status;

        [Required(ErrorMessage = "Informe o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um valor acima de 0")]
        public double Valor
        {
            get => suprimento.Valor;
            set
            {
                suprimento.Valor = value;
                ValidateProperty(value, "Valor");
                OnPropertyChanged("Valor");
            }
        }


        public Suprimento_M(string tipo)
        {
            suprimento = new Lancamento();
            suprimento.TipoDocumento_Id = Listas.TiposDocumento().Where(t => t.Descricao.ToLower() == tipo).Select(t => t.Id).FirstOrDefault();
        }

        public Suprimento_M(Lancamento doBanco)
        {
            suprimento = doBanco;
        }
         
        private void DadosFixos()
        {
            suprimento.Data = DateTime.Now;
            suprimento.Usuario_Id = status.IdUsuario;
            suprimento.Filial_Id = status.IdFilial;
            suprimento.Fechamento_Id = Listas.GetFechamentoNaData(suprimento.Filial_Id, suprimento.Data);
        }

        public void Salvar()
        {
            if (Validacoes.NovoFechamento.ValidaDataFechamento(suprimento.Data))
            {
                DadosFixos();
                suprimento.SalvarLancamentoBase();
                status.AddValorSaldoFilial(Valor);
            }
        }
    }
}
