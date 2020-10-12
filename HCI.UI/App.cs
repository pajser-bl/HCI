using System;
using System.Windows;
using System.Windows.Threading;
using HCI.Data;
using Maintaineer.UI.Data;

namespace HCI.UI {
    public partial class App : Application
    {

        public AppDbContext DbContext { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var db = new AppDbContextFactory();
            DbContext = db.CreateDbContext(System.Array.Empty<string>());
        }
        public static void ChangeLanguage(int Index) {
            App.Current.Resources.MergedDictionaries[0].Source = Index switch
            {
                1 => new Uri("/Languages/sr-Latn-RS.xaml", UriKind.RelativeOrAbsolute),//Srb
                _ => new Uri("/Languages/en-US.xaml", UriKind.RelativeOrAbsolute),//Eng
            };
        }
        public static void ChangeTheme(int Index)
        {
            App.Current.Resources.MergedDictionaries[1].Source = Index switch
            {
                1 => new Uri("/Styles/green.xaml", UriKind.RelativeOrAbsolute),//Srb
                _ => new Uri("/Styles/dark.xaml", UriKind.RelativeOrAbsolute),//Eng
            };
        }
    }
}