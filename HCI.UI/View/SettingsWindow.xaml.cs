using HCI.Data.Model;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace HCI.UI
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private readonly Data.AppDbContext dbContext;
        private readonly User User;
        public SettingsWindow(User user)
        {
            InitializeComponent();
            dbContext = ((App)Application.Current).DbContext;
            User = user;
            LanguageComboBox.SelectedIndex=((int)user.Language);
            ThemeComboBox.SelectedIndex=((int)user.Theme);
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.ChangeLanguage(LanguageComboBox.SelectedIndex);
            User.Language = (Language)LanguageComboBox.SelectedIndex;
            dbContext.Update(User);
            dbContext.SaveChanges();
        }

        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.ChangeTheme(ThemeComboBox.SelectedIndex);
            User.Theme = (Theme)ThemeComboBox.SelectedIndex;
            dbContext.Update(User);
            dbContext.SaveChanges();
        }
    }
}
