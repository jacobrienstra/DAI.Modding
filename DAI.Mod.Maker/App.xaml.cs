using System;
using System.Windows;
using System.Windows.Threading;

namespace DAI.Mod.Maker {
    public partial class App : Application {

        private static void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            FrmException ex = new FrmException(e.Exception);
            e.Handled = true;
            ex.ShowDialog();
            Application.Current.Shutdown();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
        }
    }
}
