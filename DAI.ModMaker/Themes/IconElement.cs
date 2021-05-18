using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;


namespace DAI.ModMaker.Themes
{
    public partial class IconElement : ContentControl
    {
        static IconElement()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconElement), new FrameworkPropertyMetadata(typeof(IconElement)));
            FocusableProperty.OverrideMetadata(typeof(IconElement), new FrameworkPropertyMetadata(false));
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
                nameof(Icon),
                typeof(UIElement),
                typeof(IconElement),
                null);

        public UIElement Icon
        {
            get { return (UIElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    }
}