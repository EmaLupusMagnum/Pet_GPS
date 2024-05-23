using PetGPS.MVVM.ViewModels;

namespace PetGPS.MVVM.Views;
[QueryProperty(nameof(PetName), "name")]
[QueryProperty(nameof(PetDesc), "desc")]

public partial class VisualizePet : ContentPage
{
	public string PetName { get; set; }
	public string PetDesc { get; set; }

	public VisualizePetViewModel vm;
	public VisualizePet()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        vm = new VisualizePetViewModel(PetName,PetDesc);
        BindingContext = vm;
    }
}