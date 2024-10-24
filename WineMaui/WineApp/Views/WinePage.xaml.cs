using WineApp.ViewModels;

namespace WineApp.Views;

public partial class WinePage : ContentPage
{
	public WinePage(IWineViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}