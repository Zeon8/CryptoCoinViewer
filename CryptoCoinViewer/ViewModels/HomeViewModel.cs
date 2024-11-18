using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCoinViewer.Models;
using CryptoCoinViewer.Services;
using CryptoCoinViewer.Views.Pages;
using Wpf.Ui;

namespace CryptoCoinViewer.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    public string? SearchCurrencyName { get; set; }

    [ObservableProperty]
    private IEnumerable<AssetItem>? _assetItems;

    [ObservableProperty]
    private AssetItem? _selectedAssetItem;


    private readonly CryptoAssetsService _assetsService;
    private readonly ChartService _chartService;
    
    private readonly INavigationService _navigationService;
    private readonly DialogService _dialogService;

    public HomeViewModel(CryptoAssetsService assetsService, INavigationService navigationService,
        ChartService chartService, DialogService dialogService)
    {
        _assetsService = assetsService;
        _navigationService = navigationService;
        _chartService = chartService;
        this._dialogService = dialogService;
    }

    public async Task Load()
    {
        IEnumerable<Asset> assets = await _assetsService.GetAssets();
        await SetAssetsAsync(assets);
    }

    private async Task SetAssetsAsync(IEnumerable<Asset> assets)
    {
        await Application.Current.Dispatcher
                        .InvokeAsync(() => AssetItems = assets.Select(asset => new AssetItem(asset)));
    }

    [RelayCommand]
    private Task OpenDetails()
    {
        if (SelectedAssetItem is null)
            return Task.CompletedTask;

        var viewModel = new CurrencyDetailsViewModel(SelectedAssetItem, _assetsService, 
            _chartService, _dialogService);
        _navigationService.Navigate(typeof(CurrencyDetailsView), viewModel);
        return viewModel.Load();
    }

    [RelayCommand]
    private async Task Search()
    {
        Debug.WriteLine(SearchCurrencyName);
        if (string.IsNullOrWhiteSpace(SearchCurrencyName))
            await Load();
        else
        {
            IEnumerable<Asset> assets = await _assetsService.SearchAssets(SearchCurrencyName);
            await SetAssetsAsync(assets);
        }
    }
}