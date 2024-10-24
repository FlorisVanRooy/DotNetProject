using WineApp.ViewModels;

namespace WineApp.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(IDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}