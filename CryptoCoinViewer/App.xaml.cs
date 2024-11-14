using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Windows;
using CryptoCoinViewer.Models;
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

        builder.Services.AddSingleton<DialogService>();
        builder.Services.AddSingleton<LocalizationService>();
        builder.Services.AddSingleton<SettingsService>();
        builder.Services.AddSingleton<CryptoAssetsService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();

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

        SetupLocalization(host);

        host.Services.GetRequiredService<MainWindow>().Show();
        base.OnStartup(e);


    }

    private void SetupLocalization(IHost host)
    {
        var settingsService = host.Services.GetRequiredService<SettingsService>();
        var localizationService = host.Services.GetRequiredService<LocalizationService>();

        var settings = Task.Run(settingsService.GetSettings).GetAwaiter().GetResult();
        if (settings is not null)
        {
            localizationService.ApplyLanguage(settings);
        }
    }
}