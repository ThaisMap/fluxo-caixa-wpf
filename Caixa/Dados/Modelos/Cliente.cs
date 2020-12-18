﻿using System.Collections.Generic;

namespace Dados.Modelos
{
    public class Cliente
    {
        public Cliente(string nome, TipoCobranca tipoCobranca) 
        {
            Nome = nome;
            TipoCobranca = tipoCobranca;
        }

        public Cliente()
        {
                
        }


        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoCobranca TipoCobranca { get; set; }
        public ICollection<Debito> Debitos { get; set; }

        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Clientes.Add(this);
                }
                else
                {
                    var tipo = Banco.Clientes.Find(Id);
                    tipo.Nome = Nome;
                    tipo.TipoCobranca = TipoCobranca;
                }
                Banco.SaveChanges();
            }
        }
    }
}