using System.Collections.ObjectModel;
using System.Windows;
using CryptoCoinViewer.Models;
using CryptoCoinViewer.Services;

namespace CryptoCoinViewer.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public ObservableCollection<AssetViewModel> Assets { get; } = new();
    
    private readonly CryptoAssetsService _assetsService;

    public HomeViewModel(CryptoAssetsService assetsService)
    {
        _assetsService = assetsService;
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
                        Assets.Add(new AssetViewModel(asset));
                });
        }
    }
}