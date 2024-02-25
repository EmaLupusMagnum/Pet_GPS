using PetGPS.MVVM.ViewModels;
namespace PetGPS.MVVM.Views;

public partial class UserRegPage : ContentPage
{
	public UserRegPage()
	{
		InitializeComponent();
		BindingContext = new UserRegViewModel();
	}
}