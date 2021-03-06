﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table("Fechamentos")]
    public class Fechamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Filial_Id { get; set; }
        public double ValorInicial { get; set; }
        public double? ValorFinal { get; set; }
        public string ArquivoScan { get; set; }
        public bool Fechado { get; set; } = false;
        public virtual Filial Filial { get; set; }
        public virtual ICollection<Lancamento> Lancamentos { get; set; } 

        public Fechamento()
        {
                
        }      

        public Fechamento(Filial filial)
        {
            Data = DateTime.Now; 
            Filial_Id = filial.Id;
            ValorInicial = filial.Saldo;
            ArquivoScan = "";
        }

        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                var fechamento = Banco.Fechamentos.FirstOrDefault(x => x.Filial_Id == Filial_Id && DbFunctions.TruncateTime(x.Data) == DbFunctions.TruncateTime(Data.Date)); 
                if (fechamento != null)
                {                   
                    fechamento.ArquivoScan = ArquivoScan;
                    fechamento.ValorFinal = ValorFinal;
                    fechamento.ValorInicial = ValorInicial;
                    fechamento.Fechado = Fechado;
                }
                else
                {                    
                    Banco.Fechamentos.Add(this);
                }
                Banco.SaveChanges();
            }
        }
    }
}