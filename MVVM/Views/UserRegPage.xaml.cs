using PetGPS.MVVM.ViewModels;
namespace PetGPS.MVVM.Views;

public partial class UserRegPage : ContentPage
{
    UserRegViewModel vm = new UserRegViewModel();

    public UserRegPage()
	{
		InitializeComponent();
		BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        vm.UpdateData();
    }

    private async void BtnAddPet_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PetRegPage");
    }


    private async void BtnRegister_Clicked(object sender, EventArgs e)
    {
        bool yes = false;
        string isOk = vm.AllChecked(EntryName.Text, EntryPass.Text, EntryEmail.Text, EntryPhone.Text);

        if (isOk == "Valid")
            yes =
                await DisplayAlert("Todo luce bien", "Asegurate de que tus datos esten bien:\n" +
                $"Nombre: {vm.Name}\nContraseņa: {vm.Password}\nEmail: {vm.Email}\nTelefono: {vm.Phone}", "Ok", "Cancelar");
        else
            await DisplayAlert("Error",isOk, "Error");

        if (yes)
        {
            vm.SaveData();
            await Shell.Current.GoToAsync("//MainPage");    
        }
    }
}