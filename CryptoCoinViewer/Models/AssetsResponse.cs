namespace CryptoCoinViewer.Models;

public record AssetsResponse
{
    public required Asset[] Data { get; init; }
}