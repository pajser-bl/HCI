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
            switch (Index)
            {
                default:
                case 0:
                        //Eng
                        App.Current.Resources.MergedDictionaries[0].Source = new Uri("/Languages/en-US.xaml", UriKind.RelativeOrAbsolute);
                    break;
                case 1:
                        //Srb
                        App.Current.Resources.MergedDictionaries[0].Source = new Uri("/Languages/sr-Latn-RS.xaml", UriKind.RelativeOrAbsolute);
                        break;
            }
        }
        public static void ChangeTheme(int Index)
        {
            switch (Index)
            {
                default:
                case 0:
                        //Eng
                        App.Current.Resources.MergedDictionaries[1].Source = new Uri("/Styles/dark.xaml", UriKind.RelativeOrAbsolute);
                        break;
                case 1:
                        //Srb
                        App.Current.Resources.MergedDictionaries[1].Source = new Uri("/Styles/green.xaml", UriKind.RelativeOrAbsolute);
                        break;
            }

        }
    }
}