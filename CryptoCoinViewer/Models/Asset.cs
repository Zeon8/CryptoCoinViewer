namespace CryptoCoinViewer.Models;

public record Asset
{
    public required string Id { get; init; }
    
    public required int Rank { get; init; }
    
    public required string Symbol { get; init; }
    
    public required string Name { get; init; }
    
    public required decimal Supply { get; init; }
    
    public required string MaxSupply { get; init; }
    
    public required decimal MarketCapUsd { get; init; }
    
    public required decimal VolumeUsd24Hr { get; init; }
    
    public required decimal PriceUsd { get; init; }
    
    public required decimal ChangePercent24Hr { get; init; }
    
    public required decimal Vwap24Hr { get; init; }
}