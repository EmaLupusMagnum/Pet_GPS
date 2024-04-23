using PetGPS.MVVM.ViewModels;

namespace PetGPS.MVVM.Views;
[QueryProperty(nameof(PetId), "id")]
public partial class VisualizePet : ContentPage
{
	public int PetId { get; set; }
	public VisualizePetViewModel vm;
	public VisualizePet()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        vm = new VisualizePetViewModel(PetId);
        BindingContext = vm;
    }
}