using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace YCProyectoMVVM.ViewModels
{
    internal class AboutViewModel
    {
 
        public string YCMoreInfoUrl => "https://drive.google.com/drive/folders/13s_ORHFmryvn15nskmOBeiN3q6ecIauj?usp=sharing";
        public string YCMessage => "No tiene ni idea de cuanto sufrí (igual no funciona) ;-;";
        public ICommand ShowMoreInfoCommand { get; }

        public AboutViewModel()
        {
            ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
        }

        async Task ShowMoreInfo() =>
            await Launcher.Default.OpenAsync(YCMoreInfoUrl);
    }
}
