using System.Configuration;
using System.Data;
using System.Windows;
using CryptoCoinViewer.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CryptoCoinViewer;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddTransient<MainWindowViewModel>();
        builder.Services.AddTransient<MainWindow>();
        var host = builder.Build();
        
        host.Services.GetRequiredService<MainWindow>().Show();
        base.OnStartup(e);
    }
}