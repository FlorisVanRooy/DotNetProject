using WineApp.ViewModels;

namespace WineApp.Views;

public partial class HomePage : ContentPage
{
	public HomePage(IHomeViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}