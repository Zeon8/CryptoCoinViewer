using System.Configuration;
using System.Data;
using System.Windows;
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