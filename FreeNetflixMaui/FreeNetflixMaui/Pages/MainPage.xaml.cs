namespace FreeNetflixMaui.Pages;
using FreeNetflixMaui.ViewModels;


public partial class MainPage : ContentPage
{
    private readonly HomeViewModel _homeViewModel;
    public MainPage(HomeViewModel homeViewModel)
    {
        InitializeComponent();
        _homeViewModel = homeViewModel;
        BindingContext = _homeViewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _homeViewModel.InitializeAsync();
    }


    private void MovieInfoBox_Closed(object sender, EventArgs e)
    {
        _homeViewModel.SelectMediaCommand.Execute(null);
    }

}