﻿using Caixa.Validacoes;
using Dados;
using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Models
{
    public class Debito_M : Observavel
    {
        private Debito debito;
        private Sessao status = Sessao.Status;

        public Debito_M()
        {
            debito = new Debito();
            debito.Data = DateTime.Now;
        }

        [Required(ErrorMessage = "Informe a data")]
        public DateTime Data
        {
            get => debito.Data;
            set
            {
                debito.Data = value;
                ValidateProperty(value, "Data");
                OnPropertyChanged("Data");
            }
        }


        [Required(ErrorMessage = "Informe o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um valor acima de 0")]
        [SaldoSuficiente(ErrorMessage = "Saldo insuficiente")]
        public double Valor
        {
            get => debito.Valor;
            set
            {
                debito.Valor = value;
                ValidateProperty(value, "Valor");
                OnPropertyChanged("Valor");
            }
        }

        [Required(ErrorMessage = "Selecione um tipo")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione um tipo")]
        public int TipoDocumento
        {
            get => debito.TipoDocumento_Id;
            set
            {
                debito.TipoDocumento_Id = value;
                ValidateProperty(value, "TipoDocumento");
                OnPropertyChanged("TipoDocumento");
            }
        }

        [Required(ErrorMessage = "Informe o numero do Cte")]
        [Range(1, int.MaxValue, ErrorMessage ="Número inválido")]
        public int Cte
        {
            get => debito.Cte;
            set
            {
                debito.Cte = value;
                ValidateProperty(value, "Cte");
                OnPropertyChanged("Cte");
            }
        }

        [Required(ErrorMessage = "Informe a quantidade de volumes")]
        [Range(1, int.MaxValue, ErrorMessage ="Quantidade inválida")]
        public int Volumes
        {
            get => debito.Volumes;
            set
            {
                debito.Volumes = value;
                ValidateProperty(value, "Volumes");
                OnPropertyChanged("Volumes");
            }
        }

        [Required(ErrorMessage = "Informe o cliente")]
        public int Cliente
        {
            get => debito.Cliente_Id;
            set
            {
                debito.Cliente_Id = value;
                ValidateProperty(value, "Cliente");
                AlteraParaTipoCliente(value);
                OnPropertyChanged("Cliente");
            }
        }

        [Required(ErrorMessage = "Selecione um tipo")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione um tipo")]
        public int TipoCobranca
        {
            get => debito.TipoCobranca_Id;
            set
            {
                debito.TipoCobranca_Id = value;
                ValidateProperty(value, "TipoCobranca");
                OnPropertyChanged("TipoCobranca");
            }
        }

        public bool IsValid { get => isValid(); }

        private void AlteraParaTipoCliente(int IdCliente)
        {
            if(IdCliente > 0)
            {

                using (var Banco = new CaixaContext())
                {
                    var tipoCliente = Banco.Clientes.Find(IdCliente).TipoCobranca_Id;
                    TipoCobranca = tipoCliente;
                }
            }
        }
       

        private void DadosFixos()
        {
            debito.Usuario_Id = status.IdUsuario;
            debito.Filial_Id = status.IdFilial;
            debito.Fechamento_Id = Listas.GetFechamentoNaData(debito.Filial_Id, debito.Data);
        }

        public bool Salvar()
        {
            if (NovoFechamento.ValidaDataFechamento(Data))
            {
                DadosFixos();
                debito.Salvar();
                status.AddValorSaldoFilial(-Valor);
                return true;
            }
            return false;
        }
    }
}
