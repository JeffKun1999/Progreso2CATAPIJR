namespace Progreso2CATAPIJR.Views;
using Progreso2CATAPIJR.ViewModels;

public partial class SavedCatImagesPageJR : ContentPage
{
	public SavedCatImagesPageJR()
	{
		InitializeComponent();
        BindingContext = new SavedCatImagesViewModelJR();

    }
}