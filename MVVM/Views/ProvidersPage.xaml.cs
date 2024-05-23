using PetGPS.MVVM.ViewModels;

namespace PetGPS.MVVM.Views;

public partial class ProvidersPage : ContentPage
{
	ProovidersViewModel vm = new ProovidersViewModel();
	public ProvidersPage()
	{
		InitializeComponent();
		BindingContext = vm;
	}
}