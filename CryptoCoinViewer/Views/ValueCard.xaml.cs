using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace CryptoCoinViewer.Views;

public partial class ValueCard : UserControl
{
    public static readonly DependencyProperty TextProperty
        = DependencyProperty.Register(nameof(Text), typeof(string), typeof(ValueType));

    public static readonly DependencyProperty ValueProperty
        = DependencyProperty.Register(nameof(Value), typeof(object), typeof(ValueType));

    [Bindable(true)]
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    [Bindable(true)]
    public object Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    
    public ValueCard()
    {
        InitializeComponent();
        DataContext = this;
    }
}