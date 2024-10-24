namespace WineApp.Services
{
    public interface INavigationService
    {
        Task NavigateToDetailsAsync();
        Task NavigateToWineAsync();
        Task NavigateBackAsync();
    }
}
