namespace maui_esqueletonMVC.Views;
using maui_esqueletonMVC.ViewModels;

public partial class VentanaUno : ContentPage
{
	public VentanaUno()
	{
		InitializeComponent();
        BindingContext = new VentanaUnoVM();
    }
}