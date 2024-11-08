namespace CryptoCoinViewer.Models
{
    public record Market
    {
        public required string ExchangeId { get; init; }

        public required string BaseId { get; init; }

        public required string QuoteId { get; init; }

        public required string BaseSymbol { get; init; }

        public required string QuoteSymbol { get; init; }

        public required decimal VolumeUsd24Hr { get; init; }

        public required decimal PriceUsd { get; init; }

        public required decimal VolumePercent { get; init; }
    }
}
