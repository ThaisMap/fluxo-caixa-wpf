using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Modelos
{
    public class BaseClass
    {
        public int Id { get; set; }

        public BaseClass(int id)
        {
            Id = id;
        }
    }
    public class Usuario : BaseClass
    {
        public Usuario(string nome, string senha, string login, bool admin, Filial filial, int id) : base(id)
        { 
            Nome = nome;
            Senha = senha;
            Login = login;
            Admin = admin;
            Filial = filial;
        }

        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public bool Admin { get; set; }
        public Filial Filial { get; set; }
    }

    public class Cliente : BaseClass
    {
        public Cliente(string nome, TipoCobranca tipoCobranca, int id) : base(id)
        {
            Nome = nome;
            TipoCobranca = tipoCobranca;
        }

        public string Nome { get; set; }
        public TipoCobranca TipoCobranca { get; set; }
    }

    public class TipoCobranca : BaseClass
    {
        public string Descricao { get; set; }

        public TipoCobranca(string descricao, int id) : base(id)
        {
            Descricao = descricao;
        }
    }

    public class TipoDocumento : BaseClass
    {
        public string Descricao { get; set; }
        public bool Soma { get; set; }

        public TipoDocumento(string descricao, bool soma, int id) : base(id)
        {
            Descricao = descricao;
            Soma = soma;
        }
    }

    public class Lancamento : BaseClass
    {
        public Lancamento(DateTime data, Usuario usuario, Filial filial, double valor, TipoDocumento tipoDocumento, int id) : base(id)
        {
            Data = data;
            Usuario = usuario;
            Filial = filial;
            Valor = tipoDocumento.Soma ? valor : -valor;
            TipoDocumento = tipoDocumento;
        }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public Filial Filial { get; set; }
        public double Valor { get; set; }
        public TipoDocumento TipoDocumento { get; set; }        
    }

    public class Suprimento : Lancamento
    {
        public Suprimento(int? fechamento, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario, lancamento.Filial, lancamento.Valor, lancamento.TipoDocumento, lancamento.Id)
        {
            Fechamento = fechamento;
        }         
        public int? Fechamento { get; set; } 
    }

    public class Debito : Lancamento
    {
        public Debito(TipoCobranca tipoCobranca, string cte, int volumes, Cliente cliente, int? fechamento, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario, lancamento.Filial, lancamento.Valor, lancamento.TipoDocumento, lancamento.Id)
        {
            TipoCobranca = tipoCobranca;
            Cte = cte;
            Volumes = volumes;
            Cliente = cliente;
            Fechamento = fechamento;
        }

        public TipoCobranca TipoCobranca { get; set; }
        public string Cte { get; set; }
        public int Volumes { get; set; }
        public Cliente Cliente { get; set; }
        public int? Fechamento { get; set; }
    }

    public class Adiantamento : Lancamento
    {
        public Adiantamento(string placa, string motorista, bool pendente, Lancamento lancamento) :
            base(lancamento.Data, lancamento.Usuario, lancamento.Filial, lancamento.Valor, lancamento.TipoDocumento, lancamento.Id)
        {
            Placa = placa;
            Motorista = motorista;
            Pendente = pendente;
        }

        public string Placa { get; set; }
        public string Motorista { get; set; }
        public bool Pendente { get; set; }
    }
    
    public class Fechamento : BaseClass
    {
        public Fechamento(DateTime data, Filial filial, double valorInicial, double? valorFinal, string arquivoScan, int id) : base(id)
        {
            Data = data;
            Filial = filial;
            ValorInicial = valorInicial;
            ValorFinal = valorFinal;
            ArquivoScan = arquivoScan;
        }

        public DateTime Data { get; set; }
        public Filial Filial { get; set; }
        public double ValorInicial { get; set; }
        public double? ValorFinal { get; set; }
        public string ArquivoScan { get; set; }

    }

}
