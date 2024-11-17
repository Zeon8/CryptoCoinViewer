using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCoinViewer.Models;
using CryptoCoinViewer.Services;
using System.Windows;

namespace CryptoCoinViewer.ViewModels;

public partial class CurrencyDetailsViewModel : ViewModelBase
{
    public AssetItem AssetItem { get; }

    public CandleStickChartViewModel ChartViewModel { get; } = new();

    [ObservableProperty]
    private IEnumerable<Market>? _markets;

    private readonly CryptoAssetsService _cryptoAssetsService;
    private readonly ChartService _chartService;

    public CurrencyDetailsViewModel(AssetItem assetViewMovel, CryptoAssetsService cryptoAssetsService, ChartService chartService)
    {
        AssetItem = assetViewMovel;
        _cryptoAssetsService = cryptoAssetsService;
        _chartService = chartService;
    }

    public async Task Load()
    {
        IEnumerable<Market> markets = await _cryptoAssetsService.GetMarkets(AssetItem.Asset);
        await Application.Current.Dispatcher.InvokeAsync(() => Markets = markets);
        await LoadCandles(days: 1);
    }

    [RelayCommand]
    private async Task LoadCandles(int days)
    {
        IEnumerable<CandleStick>? candleSticks = await _chartService.GetCandleSticks(AssetItem.Asset.Id, days);
        if (candleSticks is not null)
            await Application.Current.Dispatcher.InvokeAsync(() => ChartViewModel.Update(candleSticks));
    }
}