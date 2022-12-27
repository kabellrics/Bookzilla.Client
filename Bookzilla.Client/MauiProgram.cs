using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Implémentation;
using Bookzilla.Client.Services.Interface;
using Bookzilla.Client.ViewModels.VM;

namespace Bookzilla.Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<BookzillaLocalDatabase>();
		return builder
            .RegisterAppServices()
            .RegisterViewModels()
            .Build();
	}
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
        mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        mauiAppBuilder.Services.AddSingleton<ISynchroService, SynchroService>();
        mauiAppBuilder.Services.AddSingleton<IRepository, Repository>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<HomeViewModel>();
        mauiAppBuilder.Services.AddSingleton<SettingViewModel>();
        mauiAppBuilder.Services.AddSingleton<SynchroViewModel>();

        mauiAppBuilder.Services.AddSingleton<CollectionListViewModel>();
        mauiAppBuilder.Services.AddSingleton<CollectionDetailViewModel>();
        mauiAppBuilder.Services.AddSingleton<SerieListViewModel>();
        mauiAppBuilder.Services.AddSingleton<SerieDetailViewModel>();
        mauiAppBuilder.Services.AddSingleton<AlbumListViewModel>();
        mauiAppBuilder.Services.AddSingleton<AlbumDetailViewModel>();

        return mauiAppBuilder;
    }
}
