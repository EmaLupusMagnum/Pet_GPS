namespace PetGPS.MVVM.Views;
public partial class LoginPage : ContentPage
{
    public LoginPage() 
    { 
        InitializeComponent();
    }

    private async void LogIn_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("LoggedPage");
    }

    private async void BtnLogProv_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Lo siento", "Actualmente esta funcion no esta disponible, intentalo nuevamente en unas semanas","Ok");
    }

    private async void BtnLogUser_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("UserRegPage");
    }
}


