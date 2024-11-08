namespace CryptoCoinViewer.Models;

public record AssetsResponse<T>
{
    public required IEnumerable<T> Data { get; init; }
}