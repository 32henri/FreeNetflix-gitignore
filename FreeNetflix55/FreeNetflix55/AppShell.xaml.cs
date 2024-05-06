using FreeNetflix55.Pages;
namespace FreeNetflix55
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
        }
    }
}
