using System.Diagnostics;
using CryptoCoinViewer.Services;

namespace CryptoCoinViewer.ViewModels
{
    public partial class ConverterViewModel : ViewModelBase
    {
        public CurrencyViewModel FirstCurrency { get; }
        public CurrencyViewModel SecondCurrency { get; }

        public ConverterViewModel(CryptoAssetsService cryptoAssetsService)
        {
            FirstCurrency = new CurrencyViewModel(cryptoAssetsService);
            SecondCurrency = new CurrencyViewModel(cryptoAssetsService);

            FirstCurrency.AmountChanged += () => Convert(FirstCurrency, SecondCurrency);
            SecondCurrency.AmountChanged += () => Convert(SecondCurrency, FirstCurrency);
        }

        private void Convert(CurrencyViewModel inputViewModel, CurrencyViewModel outputViewModel)
        {
            decimal? inputPrice = inputViewModel.AssetItem?.Asset.PriceUsd;
            decimal? outputPrice = outputViewModel.AssetItem?.Asset.PriceUsd;
            if (!inputPrice.HasValue || !outputPrice.HasValue) 
                return;
            
            decimal ratio = inputPrice.Value / outputPrice.Value;
            outputViewModel.IsUpdating = true;
            outputViewModel.Amount = inputViewModel.Amount * ratio;
            outputViewModel.IsUpdating = false;
            Debug.WriteLine(outputViewModel.Amount);
        }
    }
}
