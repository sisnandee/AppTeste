using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppTeste.ViewModels
{
    public partial class CoinViewModel : ObservableObject
    {
        public string _LadoEscolhido = string.Empty;
        public string _Imagem = string.Empty;
        public string _Resultado = string.Empty;
    }
}
