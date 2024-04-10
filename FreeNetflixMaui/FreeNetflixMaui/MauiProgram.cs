﻿using CommunityToolkit.Maui;
using FreeNetflixMaui.Pages;
using FreeNetflixMaui.Services;
using FreeNetflixMaui.ViewModels;

namespace FreeNetflixMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
				fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSemibold");
			});

#if DEBUG

#endif

        builder.Services.AddHttpClient(TmdbService.TmdbHttpClientName,
            httpClient => httpClient.BaseAddress = new Uri("https://api.themoviedb.org"));

        builder.Services.AddSingleton<TmdbService>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}