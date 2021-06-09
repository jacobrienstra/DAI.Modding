using System;
using System.Globalization;
using System.Windows.Data;

namespace DAI.Mod.Manager.Utilities {
    public class MinPatchVersionToMessageConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return Settings.PatchVersion < (value as int?) ? "(This mod is incompatible with your patch.)" : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }

    public class MinPatchVersionToStringConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return Settings.PatchVersion < (value as int?) ? (value as int?).ToString() : "None";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }

    public class ManagerViewModelToUpButtonIsEnabledConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            ManagerViewModel? viewModel = value as ManagerViewModel;
            if (viewModel == null || viewModel.SelectedMod == null) return false;
            return !viewModel.SelectedMod.IsOfficialPatch && viewModel.SelectedMod.Index != 0; // should be redundant, technically
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }

    public class ManagerViewModelToDownButtonIsEnabledConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            ManagerViewModel viewModel = value as ManagerViewModel;
            if (viewModel == null || viewModel.SelectedMod == null) return false;
            return !viewModel.SelectedMod.IsOfficialPatch && viewModel.SelectedMod.Index != viewModel.UserModList.Count - 1;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }

    public class SelectedModToConfigureButtonIsEnabledConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            ModContainer? modContainer = value as ModContainer;
            if (modContainer == null) return false;
            return modContainer.IsDAIMod() && modContainer.Mod.ScriptObject != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
    
    public class SelectedModToChangeStatusButtonIsEnabledConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            ModContainer selectedMod = value as ModContainer;
            if (selectedMod == null) return false;
            return !selectedMod.IsOfficialPatch && (selectedMod.MinPatchVersion == -1 || Settings.PatchVersion >= selectedMod.MinPatchVersion);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }

}
