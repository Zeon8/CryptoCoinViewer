using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace CryptoCoinViewer.Views.Controls;

public partial class ValueCard : UserControl
{
    public static readonly DependencyProperty TextProperty
        = DependencyProperty.Register(nameof(Text), typeof(string), typeof(ValueCard));

    public static readonly DependencyProperty ValueProperty
        = DependencyProperty.Register(nameof(Value), typeof(string), typeof(ValueCard));

    [Bindable(true)]
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    [Bindable(true)]
    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    
    public ValueCard()
    {
        InitializeComponent();
    }
}