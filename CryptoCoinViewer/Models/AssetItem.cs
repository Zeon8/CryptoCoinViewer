namespace CryptoCoinViewer.Models;

public class AssetItem
{
    public Asset Asset { get; }

    public string Image => $"https://assets.coincap.io/assets/icons/{Asset.Symbol.ToLower()}@2x.png";

    public AssetItem(Asset asset)
    {
        Asset = asset;
    }
}