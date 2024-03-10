using System.Diagnostics;

namespace PetGPS.MVVM.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	public async void getus()
	{
		var user = App.UserRepo.GetItems().First();
		await DisplayAlert("ok",$" {user.Id} {user.Name} {user.Email} {user.Phone} {user.Password}","ok");

		Debug.WriteLine(user.Name);
	}
}