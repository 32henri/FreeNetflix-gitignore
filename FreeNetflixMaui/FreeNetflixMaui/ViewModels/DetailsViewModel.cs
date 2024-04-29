using FreeNetflixMaui.Models;
using FreeNetflixMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FreeNetflixMaui.ViewModels
{
    [QueryProperty(nameof(Media), nameof(Media))]

    public partial class DetailsViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;

        public DetailsViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }
    }
}