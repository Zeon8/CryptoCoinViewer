using System.Windows;
using System.Windows.Controls.Primitives;

namespace CryptoCoinViewer.AttachedProperties
{
    public class CommandParameter
    {
        public static int GetInt32(DependencyObject obj)
        {
            return (int)obj.GetValue(Int32Property);
        }

        public static void SetInt32(DependencyObject obj, int value)
        {
            obj.SetValue(Int32Property, value);
        }

        public static readonly DependencyProperty Int32Property =
            DependencyProperty.Register("Int32", typeof(int), typeof(ButtonBase),
                new PropertyMetadata(CommandParameterChanged));

        private static void CommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var binding = (ButtonBase)d;
            binding.CommandParameter = e.NewValue;
        }
    }
}
