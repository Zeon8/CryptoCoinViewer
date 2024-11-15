using System.Net.Http;
using System.Windows;
using CryptoCoinViewer.Services;
using CryptoCoinViewer.ViewModels;
using CryptoCoinViewer.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wpf.Ui;

namespace CryptoCoinViewer;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton(new HttpClient()
        {
            BaseAddress = new Uri("https://api.coincap.io/v2/")
        });

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IThemeService, Wpf.Ui.ThemeService>();

        builder.Services.AddSingleton<CryptoAssetsService>();
        builder.Services.AddSingleton<SettingsService>();
        builder.Services.AddSingleton<SettingsApplier>();
        builder.Services.AddSingleton<DialogService>();
        builder.Services.AddSingleton<Services.ThemeService>();
        builder.Services.AddSingleton<LocalizationService>();

        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<ConverterViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<MainWindowViewModel>();

        builder.Services.AddTransient<SettingsView>();
        builder.Services.AddTransient<ConverterView>();
        builder.Services.AddTransient<HomeView>();
        builder.Services.AddTransient<CurrencyDetailsView>();
        builder.Services.AddTransient<MainWindow>();
        var host = builder.Build();

        LoadSettings(host);

        host.Services.GetRequiredService<MainWindow>().Show();
        base.OnStartup(e);


    }

    private void LoadSettings(IHost host)
    {
        var settingsService = host.Services.GetRequiredService<SettingsService>();
        var settingsApplier = host.Services.GetRequiredService<SettingsApplier>();

        var settings = Task.Run(settingsService.LoadSettings).GetAwaiter().GetResult();
        if (settings is not null)
            settingsApplier.ApplySettings(settings);
    }
}