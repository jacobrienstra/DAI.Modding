using System;
using System.Globalization;
using System.Windows.Data;

namespace DAI.Mod.Manager.Utilities {
    internal sealed class MinPatchVersionToMessageConverter : IValueConverter {
        public string Compatible { get; set; } = "";
        public string Incompatible { get; set; } = "(This mod is incompatible with your patch.)";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return Settings.PatchVersion < (value as int?) ? Incompatible : Compatible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
