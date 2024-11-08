using CryptoCoinViewer.Models;

namespace CryptoCoinViewer.ViewModels;

public class CurrencyDetailsViewModel : ViewModelBase
{
    public AssetItem AssetItem { get; }

    public CurrencyDetailsViewModel(AssetItem assetViewMovel)
    {
        AssetItem = assetViewMovel;
    }
}