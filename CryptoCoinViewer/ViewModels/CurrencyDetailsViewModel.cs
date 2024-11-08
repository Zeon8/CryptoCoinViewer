using CommunityToolkit.Mvvm.ComponentModel;
using CryptoCoinViewer.Models;
using CryptoCoinViewer.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace CryptoCoinViewer.ViewModels;

public partial class CurrencyDetailsViewModel : ViewModelBase
{
    public AssetItem AssetItem { get; }

    [ObservableProperty]
    private IEnumerable<Market>? _markets;

    private readonly CryptoAssetsService _cryptoAssetsService;

    public CurrencyDetailsViewModel(AssetItem assetViewMovel, CryptoAssetsService cryptoAssetsService)
    {
        AssetItem = assetViewMovel;
        _cryptoAssetsService = cryptoAssetsService;
    }

    public async Task Load()
    {
        IEnumerable<Market>? markets = await _cryptoAssetsService.GetMarkets(AssetItem.Asset);
        if(markets is not null)
            await Application.Current.Dispatcher.InvokeAsync(() => Markets = markets);
    }
}