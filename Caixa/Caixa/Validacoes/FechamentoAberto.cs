using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dados;
using Caixa.Models;
using System.Data.Entity;

namespace Caixa.Validacoes
{
    public class FechamentoAberto : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);

            using (var Banco = new CaixaContext())
            {
                Sessao status = Sessao.Status;

                var fechamento = Banco.Fechamentos
                    .Where(x => x.Filial_Id == status.IdFilial
                    && DbFunctions.TruncateTime(x.Data) == DbFunctions.TruncateTime(dateTime)).FirstOrDefault();

                if (fechamento == null)
                    return false;
                return !fechamento.Fechado;
            }    
        }
    }
}
