using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineApp.Messages;
using WineApp.Services;
using WineCode.Models;

namespace WineApp.ViewModels
{
    public class WineViewModel : ObservableRecipient, IWineViewModel, IRecipient<WineSelectedMessage>
    {
        private Wine wine;
        public Wine Wine 
        {
            get { return wine; }
            set => SetProperty(ref wine, value);
        }
        public ICommand NavigateBackCommand { get; set; }

        public void Receive(WineSelectedMessage message)
        {
            Wine = message.Value;
        }

        private INavigationService _navigationService;
        public WineViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Register<WineViewModel, WineSelectedMessage>(this, (r, m) => r.Receive(m));
            BindCommands();
        }

        private void BindCommands()
        {
            NavigateBackCommand = new AsyncRelayCommand(NavigateBackAsync);
        }

        private async Task NavigateBackAsync()
        {
            await _navigationService.NavigateBackAsync();
        }
    }
}
