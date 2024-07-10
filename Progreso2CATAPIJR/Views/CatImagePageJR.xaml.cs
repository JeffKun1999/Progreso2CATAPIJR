namespace Progreso2CATAPIJR.Views;
using Progreso2CATAPIJR.ViewModels;

public partial class CatImagePageJR : ContentPage
{
	public CatImagePageJR()
	{
		InitializeComponent();
        BindingContext = new CatImageViewModelJR();
    }
}