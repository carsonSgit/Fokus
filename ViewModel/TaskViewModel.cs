using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Fokus.ViewModel
{
    public partial class TaskViewModel : ObservableObject
    {
        IConnectivity connectivity;

        public TaskViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        /* The dotnet tutorial says to use ICommand, but in the CommunityToolkit.Mvvm.ComponentModel version past the tutorial,
            * they have changed it to RelayCommand.
            * Source: https://stackoverflow.com/questions/72578034/cant-use-icommand-attribute-in-view-model-using-communitytoolkit-mvvm
            */
        [RelayCommand]
        async Task Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            // Device does not have internet...
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Error", "No internet connection", "OK");
                return;
            }

            Items.Add(Text);
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s))
                Items.Remove(s);
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        }
    }
}
