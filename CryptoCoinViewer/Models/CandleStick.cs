namespace CryptoCoinViewer.Models
{
    public record CandleStick
    {
        public required DateTime DateTime { get; init; }

        public required double Open { get; init; }

        public required double High { get; init; }

        public required double Low { get; init; }

        public required double Close { get; init; }
    }
}
