using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppTeste.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppTeste.ViewModels
{
    public partial class CoinViewModel : ObservableObject
    {
        public CoinViewModel()
        {
            Application.Current.MainPage
                .DisplayAlert("Mensagem", "Bem-Vindo(a) ao COIN FLIP!!", "OK");

            FlipCommand = new Command(Flip);
        }
        public ICommand FlipCommand { get; set; }

        [ObservableProperty]
        public string _LadoEscolhido = string.Empty;

        [ObservableProperty]
        public string _Imagem = string.Empty;

        [ObservableProperty]
        public string _Resultado = string.Empty;

        public async void Flip()
        {
            try
            {
               

                if (string.IsNullOrEmpty(_LadoEscolhido)) 
                {
                    throw new Exception("Selecione o lado da moeda");
                }

                string nome = await Application.Current.MainPage.
                DisplayPromptAsync("Identificação", "Digite seu nome: ");

                string diaSemana = 
                await Application.Current.MainPage
                    .DisplayActionSheet("Dia da Semana", 
                    "Cancelar", 
                    "OK",
                    "Domingo",
                    "Segunda",
                    "Terça",
                    "Quarta",
                    "Quinta",
                    "Sexta",
                    "Sábado");

                Coin coin = new Coin();
                _Resultado = coin.Jogar(_LadoEscolhido);
                _Imagem = $"{coin.Lado}.png";

                _Resultado = $"{nome}, Hoje é {diaSemana}, {_Resultado}";

                OnPropertyChanged(nameof(Resultado));
                OnPropertyChanged(nameof(Imagem));

                bool retorno= await Application.Current.MainPage
                    .DisplayAlert("Mensagem", "Deseja reiniciar o jogo?", "Sim", "Não");

                if(retorno)
                {
                    _Resultado = string.Empty;
                    _Imagem = string.Empty;

                    OnPropertyChanged(nameof(Resultado));
                    OnPropertyChanged(nameof(Imagem));

                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", ex.Message, "OK");
            }

            

        }

    }
}
