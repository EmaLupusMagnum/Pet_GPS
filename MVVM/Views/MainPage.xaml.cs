using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using PetGPS.MVVM.Models;
using PetGPS.MVVM.ViewModels;

namespace PetGPS.MVVM.Views;

public partial class MainPage : ContentPage
{
    MainViewModel vm;
	public MainPage()
	{
		InitializeComponent();
        vm = new MainViewModel();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var geolocationrequest = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(2));
        var location = await Geolocation.GetLocationAsync(geolocationrequest);

        Map.MoveToRegion(MapSpan.FromCenterAndRadius(location,Distance.FromKilometers(10)));
        vm.UpdateReports();
        AddPins();
    }

    private async void BtnAddPin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ReportPage");
    }

    private async void AddPins()
    {
        List<Report> reports = vm.Reports;

        foreach (var r in reports)
        {
            var locations = await Geocoding.GetLocationsAsync(r.Location);
            var loc = locations.FirstOrDefault();

            Pin pin = new Pin()
            {
                Address = vm.GetPetDesc(r.PetId),
                Location = loc,
                Label = vm.GetPetName(r.PetId),
                Type = PinType.SavedPin,
                MarkerId = r.PetId
            };

            pin.InfoWindowClicked += PinMarked;
            Map.Pins.Add(pin);
        }

    }

    private async void PinMarked(object sender, PinClickedEventArgs e)
    {
        var pinInfo = (Pin)sender;
        int petId = 1;

        await Shell.Current.GoToAsync($"VisualizePet?id={petId}");
    }
}