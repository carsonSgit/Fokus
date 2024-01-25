using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Fokus.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Tap()
        {
            await Shell.Current.GoToAsync($"{nameof(TaskPage)}");
        }
    }
}
