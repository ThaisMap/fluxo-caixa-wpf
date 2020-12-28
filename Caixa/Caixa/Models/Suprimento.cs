﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Caixa.Models
{
    public class Suprimento : Observavel
    {
        private Dados.Modelos.Lancamento suprimento = new Dados.Modelos.Lancamento();
        private Sessao status = new Sessao();

        [Required(ErrorMessage = "Informe o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um valor acima de 0")]
        public double Valor
        {
            get => suprimento.Valor;
            set
            {
                ValidateProperty(value, "Valor");
                suprimento.Valor = value;
                OnPropertyChanged("Valor");
            }
        }
        
        public Suprimento()
        {
            suprimento = new Dados.Modelos.Lancamento();
            DadosFixos();
        }

        public Suprimento(Dados.Modelos.Lancamento doBanco)
        {
            suprimento = doBanco;
        }
         
        private void DadosFixos()
        {
            suprimento.Data = DateTime.Today;
            suprimento.Usuario_Id = status.IdUsuario;
            suprimento.Filial_Id = status.IdFilial;
            suprimento.TipoDocumento_Id = Listas.TiposDocumento.Where(t => t.Descricao.ToLower() == "suprimento").Select(t => t.Id).FirstOrDefault();
            suprimento.Fechamento_Id = status.IdFechamento;
        }

        public void Salvar()
        {
            suprimento.SalvarLancamentoBase();
            status.AddValorSaldoFilial(Valor);
        }
    }
}