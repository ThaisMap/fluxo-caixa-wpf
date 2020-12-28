using Caixa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Validacoes
{
    class SaldoSuficiente : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            double valorRetirado = Convert.ToDouble(value);


            Sessao status = Sessao.Status;

            return valorRetirado <= status.Saldo;
        }
    }
}
