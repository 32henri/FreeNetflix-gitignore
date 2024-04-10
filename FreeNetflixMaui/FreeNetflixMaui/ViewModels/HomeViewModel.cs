using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FreeNetflixMaui.Models;
using FreeNetflixMaui.Services;
using System.Collections.ObjectModel;

namespace FreeNetflixMaui.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;
        public HomeViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [ObservableProperty]
        private Media _trendingMovie;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ShowMovieInfoBox))]
        private Media? _selectedMedia;

        public bool ShowMovieInfoBox => SelectedMedia is not null;

        public ObservableCollection<Media> Trending { get; set; } = new();
        public ObservableCollection<Media> TopRated { get; set; } = new();
        public ObservableCollection<Media> NetflixOriginals { get; set; } = new();
        public ObservableCollection<Media> ActionMovies { get; set; } = new();

        public async Task InitializeAsync()
        {
            var trendingListTask =  await _tmdbService.GetTrendingAsync();
            if(trendingListTask?.Any() == true)
            {
                foreach (var trending in trendingListTask)
                {
                    Trending.Add(trending);
                }
            }

            var netflixOriginals = await _tmdbService.GetNetflixOriginalAsync();
            if (netflixOriginals?.Any() == true)
            {
                foreach (var original in netflixOriginals)
                {
                    NetflixOriginals.Add(original);
                }
            }


        }
        private static void SetMediaCollection(IEnumerable<Media> medias, ObservableCollection<Media> collection)
        {
            collection.Clear();
            foreach (var media in medias)
            {
                collection.Add(media);
            }
        }

        [RelayCommand]
        private void SelectMedia(Media? media = null)
        {
            if (media is not null)
            {
                if (media.Id == SelectedMedia?.Id)
                {
                    media = null;
                }
            }
            SelectedMedia = media;
        }
    }
}