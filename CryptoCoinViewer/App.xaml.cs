using System.Configuration;
using System.Data;
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
        builder.Services.AddSingleton<CryptoAssetsService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<MainWindowViewModel>();
        builder.Services.AddTransient<HomeView>();
        builder.Services.AddTransient<MainWindow>();
        var host = builder.Build();
        
        host.Services.GetRequiredService<MainWindow>().Show();
        base.OnStartup(e);
    }
}