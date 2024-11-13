using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCoinViewer.Models;
using CryptoCoinViewer.Services;
using System.Windows;

namespace CryptoCoinViewer.ViewModels
{
    public partial class CurrencyViewModel : ViewModelBase
    {
        public bool IsUpdating { get; set; }
        
        public event Action? AmountChanged;
        
        [ObservableProperty]
        private AssetItem? _assetItem;
        
        [ObservableProperty]
        private decimal _amount;

        [ObservableProperty]
        private IEnumerable<AssetItem> _assetItems = [];

        private readonly CryptoAssetsService _cryptoAssetsService;

        public CurrencyViewModel(CryptoAssetsService cryptoAssetsService)
        {
            _cryptoAssetsService = cryptoAssetsService;
        }

        partial void OnAssetItemChanged(AssetItem? value) => NotifyAmountChanged();
        partial void OnAmountChanged(decimal value) => NotifyAmountChanged();

        private void NotifyAmountChanged()
        {
            if(!IsUpdating)
                AmountChanged?.Invoke();
        }

        [RelayCommand]
        private async Task UpdateSearchList(string currencyName)
        {
            var items = await _cryptoAssetsService.SearchAssets(currencyName);
            Application.Current.Dispatcher.Invoke(() => AssetItems = items.Select(asset => new AssetItem(asset)));
        }

    }
}
