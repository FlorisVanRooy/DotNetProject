using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineApp.Messages;
using WineApp.Services;
using WineCode.Models;
using Microsoft.Maui.ApplicationModel;

namespace WineApp.ViewModels
{
    public class DetailsViewModel : ObservableRecipient, IDetailsViewModel, IRecipient<DetectedRecipeMessage>
    {
        private Wine selectedWine;
        public Wine SelectedWine
        {
            get { return selectedWine; }
            set => SetProperty(ref selectedWine, value);
        }

        private ObservableCollection<Wine> wines;
        public ObservableCollection<Wine> Wines
        {
            get { return wines; }
            set => SetProperty(ref wines, value);
        }

        public ICommand ToggleFavoriteCommand { get; set; }
        public ICommand NavigateToWineCommand { get; set; }
        public ICommand NavigateBackCommand { get; set; }

        public void Receive(DetectedRecipeMessage message)
        {
            DetectedRecipe = message.Value;
        }

        private Recipe detectedRecipe;
        public Recipe DetectedRecipe
        {
            get { return detectedRecipe; }
            set => SetProperty(ref detectedRecipe, value);
        }

        private INavigationService _navigationService;
        public DetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Register<DetailsViewModel, DetectedRecipeMessage>(this, (r, m) => r.Receive(m));
            BindCommands();
        }

        private void BindCommands()
        {
            ToggleFavoriteCommand = new AsyncRelayCommand(ToggleFavorite);
            NavigateToWineCommand = new AsyncRelayCommand(NavigateToWine);
            NavigateBackCommand = new AsyncRelayCommand(NavigateBack);
            OpenLinkCommand = new AsyncRelayCommand(OpenLink); // Gebruik een andere naam voor de methode
        }

        // Verander de naam van de methode
        public ICommand OpenLinkCommand { get; set; }

        private async Task OpenLink()
        {
            var url = DetectedRecipe.Link;  // De URL van het gebonden object
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                await Launcher.OpenAsync(new Uri(url));
            }
        }

        private async Task NavigateToWine()
        {
            await _navigationService.NavigateToWineAsync();
            WeakReferenceMessenger.Default.Send(new WineSelectedMessage(SelectedWine));
        }

        private async Task NavigateBack()
        {
            await _navigationService.NavigateBackAsync();
        }

        private async Task ToggleFavorite()
        {
            SelectedWine.Favorite = !SelectedWine.Favorite;
            await ApiService<Wine>.PutAsync("wines/" + SelectedWine.WineID, SelectedWine);
            detectedRecipe.Wines = detectedRecipe.Wines.OrderByDescending(w => w.Favorite).ToList();
            OnPropertyChanged(nameof(DetectedRecipe));
        }
    }
}
