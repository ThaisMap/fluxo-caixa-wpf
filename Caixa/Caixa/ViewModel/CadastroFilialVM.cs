using Dados;
using Caixa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Caixa.Commands;

namespace Caixa.ViewModel
{
    public class CadastroFilialVM
    {
        private Filial filial;
        private ObservableCollection<Filial> filiaisCadastradas;

        public Filial Filial { get => filial; }
        public ObservableCollection<Filial> FiliaisCadastradas { get => filiaisCadastradas; }
        public ICommand ComandoInserir { get; private set; }
        public bool CanExecute { get => !String.IsNullOrEmpty(filial.Nome); }


        public CadastroFilialVM()
        {
            filial = new Filial();
            ComandoInserir = new InserirFilial(this);
            using (var Banco = new CaixaContext())
            {
                var filiais = Banco.Filiais.ToList();
                filiaisCadastradas = new ObservableCollection<Filial>(filiais.Select(f => new Filial(f)));
            }
        }

        public void Salvar()
        {
            Filial.Salvar();
        }


    }


}
