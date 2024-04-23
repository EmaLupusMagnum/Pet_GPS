using PetGPS.MVVM.Models;
using PetGPS.MVVM.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PetGPS.MVVM.Views;

public partial class ReportPage : ContentPage
{
    ReportViewModel vm = new ReportViewModel();
	public ReportPage()
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

    private async void BtnReport_Clicked(object sender, EventArgs e)
    {
        var pet = PetsCollection.SelectedItem as Pet;
        string location = EntryLocation.Text;
        string description = DescriptionEditor.Text;

        string message = await vm.ValidateReport(pet, location, description);

        if (message != "Valid")
            await DisplayAlert("Error",message,"Ok");
        else
        {
            bool sure = await DisplayAlert("Estas seguro?", "El reporte se guardara revisa los datos:\n" +
                $"Mascota: {vm.Pet.Name}\nLugar: {vm.Location}", "Si","No");

            if (sure)
            {
                vm.UploadReport();
                await Shell.Current.GoToAsync("//MainPage");
            }
                
        }
    }
}