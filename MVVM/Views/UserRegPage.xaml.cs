
using PetGPS.MVVM.ViewModels;
using System.Reflection.Metadata.Ecma335;
namespace PetGPS.MVVM.Views;

public partial class UserRegPage : ContentPage
{
    UserRegViewModel vm = new UserRegViewModel();
	public UserRegPage()
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void BtnAddPet_Clicked(object sender, EventArgs e)
    {

    }

    private async void BtnRegister_Clicked(object sender, EventArgs e)
    {
        bool yes = false;
        string isOk = vm.AllChecked(EntryName.Text, EntryPass.Text, EntryEmail.Text, EntryPhone.Text);

        if (isOk == "Valid")
            yes =
                await DisplayAlert("Todo luce bien", "Asegurate de que tus datos esten bien:\n" +
                $"Nombre: {vm.Name}\nContraseña: {vm.Password}\nEmail: {vm.Email}\nTelefono: {vm.Phone}", "Ok", "Cancelar");
        else
            await DisplayAlert("Error",isOk, "Error");

        if (yes)
        {
            bool savedata = await DisplayAlert("Guardar Inicio Sesion","Quieres guardar tu sesion en este dispositivo","Si","No");

            if (savedata)
                vm.SaveData();
            await Shell.Current.GoToAsync("//MainPage");    
        }
    }
}