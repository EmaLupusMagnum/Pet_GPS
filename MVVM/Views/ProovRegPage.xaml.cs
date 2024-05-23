using PetGPS.MVVM.ViewModels;
using System.Diagnostics;

namespace PetGPS.MVVM.Views;

public partial class ProovRegPage : ContentPage
{
	ProovRegViewModel vm = new ProovRegViewModel();
	public ProovRegPage()
	{
		InitializeComponent();
		BindingContext = vm;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        vm.updateData();
    }
    private async void Register_Clicked(object sender, EventArgs e)
    {
        var collection = CollectionServices.SelectedItems;
        List<string> services = new List<string>();

        foreach (var service in collection) 
        {
            services.Add(service.ToString());
        }

        bool yes = false;
        string isOk = vm.AllChecked(EntryName.Text, EntryPassword.Text, EntryEmail.Text, EntryPhone.Text, services);

        if (isOk == "Valid")
            yes =
                await DisplayAlert("Todo luce bien", "Asegurate de que tus datos esten bien:\n" +
                $"Nombre: {vm.Name}\nContraseña: {vm.Password}\nEmail: {vm.Email}\nTelefono: {vm.Phone}\nServicios: {vm.ServiceType}", "Ok", "Cancelar");
        else
            await DisplayAlert("Error", isOk, "Error");

        if (yes)
        {
            vm.SaveData();
            await Shell.Current.GoToAsync("//MainPage");
        }
    }

    private async void AddPet_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PetRegPage");
    }
}