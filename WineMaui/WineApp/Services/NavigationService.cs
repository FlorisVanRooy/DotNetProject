using WineApp.Views;

namespace WineApp.Services
{
    class NavigationService : INavigationService
    {
        private INavigation _navigation;
        private IServiceProvider _serviceProvider;
        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _navigation = Application.Current.MainPage.Navigation;
        }

        public async Task NavigateToDetailsAsync()
        {
            await _navigation.PushAsync(_serviceProvider.GetRequiredService<DetailsPage>());
        }
        public async Task NavigateBackAsync()
        {
            if (_navigation.NavigationStack.Count > 1)
            {
                await _navigation.PopAsync();
            }
            else
            {
                throw new InvalidOperationException("No pages to navigate back to!");
            }
        }

        public async Task NavigateToWineAsync()
        {
            await _navigation.PushAsync(_serviceProvider.GetRequiredService<WinePage>());
        }
    }
}
