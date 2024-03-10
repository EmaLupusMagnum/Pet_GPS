namespace PetGPS.MVVM.Views;

public partial class LoadingPage : ContentPage
{
    private readonly AuthService _authService;

    public LoadingPage(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        if (await _authService.IsAuthenticatedAsync())
            await Shell.Current.GoToAsync("//MainPage");
        else
            await Shell.Current.GoToAsync("/LoginPage");
    }
}