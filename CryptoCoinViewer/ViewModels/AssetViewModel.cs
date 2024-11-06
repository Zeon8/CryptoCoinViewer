using System.Windows.Media.Imaging;
using CryptoCoinViewer.Models;

namespace CryptoCoinViewer.ViewModels;

public class AssetViewModel
{
    public Asset Asset { get; }

    public string PriceUSD => Asset.PriceUsd + "$";

    public string Image => $"https://assets.coincap.io/assets/icons/{Asset.Symbol.ToLower()}@2x.png";
    
    public AssetViewModel(Asset asset)
    {
        Asset = asset;
    }
}