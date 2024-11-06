namespace CryptoCoinViewer.Models;

public record Asset
{
    public required string Id { get; init; }

    public required int Rank { get; init; }

    public required string Symbol { get; init; }

    public required string Name { get; init; }

    public required string Supply { get; init; }
    
    public required string MaxSupply { get; init; }
    
    public required string MarketCapUsd { get; init; }
    
    public required string VolumeUsd24Hr { get; init; }
    
    public required string PriceUsd { get; init; }
    
    public required string ChangePercent24Hr { get; init; }
    
    public required string Vwap24Hr { get; init; }
}