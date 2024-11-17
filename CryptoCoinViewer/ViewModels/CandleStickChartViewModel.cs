using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using System.Globalization;
using CryptoCoinViewer.Models;
using CryptoCoinViewer.Resources;

namespace CryptoCoinViewer.ViewModels
{
    public partial class CandleStickChartViewModel : ViewModelBase
    {
        [ObservableProperty]
        private IEnumerable<Axis>? _xAxes;

        [ObservableProperty]
        private IEnumerable<ISeries>? _series;

        private readonly CultureInfo _usCultureInfo = CultureInfo.GetCultureInfo("en-US");

        public void Update(IEnumerable<CandleStick> candleSticks)
        {
            Series = [
                new CandlesticksSeries<FinancialPointI>
                {
                    Values = candleSticks
                        .Select(c => new FinancialPointI((double)c.High, (double)c.Open, (double)c.Close, (double)c.Low))
                        .ToArray(),

                    YToolTipLabelFormatter = point => string.Create(_usCultureInfo,
                        $"{Locale.CandleOpen}: {point.Model.Open:C}{Environment.NewLine}" +
                        $"{Locale.CandleHigh}: {point.Model.High:C}{Environment.NewLine}" +
                        $"{Locale.CandleLow}: {point.Model.Low:C}{Environment.NewLine}" +
                        $"{Locale.CandleClose}: {point.Model.Close:C}")
                }
            ];

            XAxes = [
                new Axis
                {
                    LabelsRotation = 15,
                    Labels = candleSticks
                        .Select(c => c.DateTime.ToString())
                        .ToArray()
                }
            ];
        }
    }
}
