using PetGPS.MVVM.ViewModels;

namespace PetGPS.MVVM.Views;

public partial class PetRegPage : ContentPage
{
	PetRegViewModel vm = new PetRegViewModel();
	public PetRegPage()
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private async void BtnRegisterPet_Clicked(object sender, EventArgs e)
    {
		var sex = PckSex.SelectedItem as string;
		string message = vm.CheckPet(EntryName.Text, EntryRace.Text, EntryColors.Text,EdtDescription.Text, sex);
		bool sure = false;

		if (message == "Valid")
		{
           sure = await DisplayAlert("Todo bien", $"Revise los datos antes de guardar:\nNombre: {vm.PetName}"+
			   $"\nRaza: {vm.PetRace}\nColores: {vm.PetColors}\nSexo: {vm.PetSexSelected}" , "Guardar","Cancelar");
        }
		else
			await DisplayAlert("Error",message,"Ok");

		if (sure) 
		{
			vm.SavePet();
			await Shell.Current.GoToAsync($"..");
        }
    }
}