using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
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

    private async void BtnAddPin_Clicked(object sender, EventArgs e)
    {
        string ubicacion = await DisplayPromptAsync("Entra una ubicacion","Pon una ubicacion entre mas precisa mejor", "Listo", "Cancelar");

        if (!string.IsNullOrWhiteSpace(ubicacion))
        {
            try
            {
                var location = await Geocoding.GetLocationsAsync(ubicacion);
                var firstLocation = location?.FirstOrDefault();

                if (firstLocation != null)
                {
                    var pin = new Pin
                    {
                        Label = "Ubicación",
                        Location = new Location(firstLocation.Latitude, firstLocation.Longitude),
                        Type = PinType.SavedPin
                    };

                    Map.Pins.Clear();
                    Map.Pins.Add(pin);
                    Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(firstLocation.Latitude, firstLocation.Longitude), Distance.FromKilometers(1)));

                }
                else
                {
                    await DisplayAlert("Error", "No se pudo encontrar la ubicación", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Por favor ingrese una ubicación", "OK");
        }
    }
}