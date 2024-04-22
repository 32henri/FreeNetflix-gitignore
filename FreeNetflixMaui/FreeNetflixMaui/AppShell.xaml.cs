using FreeNetflixMaui.Pages;

namespace FreeNetflixMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
    }
}
