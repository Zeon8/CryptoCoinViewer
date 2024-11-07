using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCoinViewer.Models;
using CryptoCoinViewer.Services;
using CryptoCoinViewer.Views;
using Wpf.Ui;

namespace CryptoCoinViewer.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    public ObservableCollection<AssetItem> AssetItems { get; } = new();

    [ObservableProperty]
    private AssetItem _selectedAsset;
    
    private readonly CryptoAssetsService _assetsService;
    private readonly INavigationService _navigationService;

    public HomeViewModel(CryptoAssetsService assetsService, INavigationService navigationService)
    {
        _assetsService = assetsService;
        _navigationService = navigationService;
    }

    public async Task Load()
    {
        IEnumerable<Asset>? assets = await _assetsService.GetAssets();
        if (assets is not null)
        {
            await Application.Current.Dispatcher
                .InvokeAsync(() =>
                {
                    foreach (var asset in assets)
                        AssetItems.Add(new AssetItem(asset));
                });
        }
    }

    [RelayCommand]
    private void OpenDetails()
    {
        _navigationService.Navigate(typeof(CurrencyDetailsView));
    }
}