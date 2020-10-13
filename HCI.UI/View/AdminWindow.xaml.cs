using HCI.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI.UI
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly Data.AppDbContext dbContext;
        private readonly User _user;
        public AdminWindow(User user)
        {
            InitializeComponent();
            dbContext = ((App)Application.Current).DbContext;
            Users.ItemsSource = dbContext.Users.ToList();
            _user = user;
        }

        private void UserSearchButton_Click(object sender, RoutedEventArgs e)
        {
            var matches = from m in dbContext.Users
                          where m.Username.Contains(UsernameSearch.Text)
                          select m;
            Users.ItemsSource = matches.ToList();
        }

        private void UpdateUsers_Click(object sender, RoutedEventArgs e)
        {
            var users = Users.ItemsSource;
            foreach (User user in users)
            {
                if (user.Username == null || user.Password == null || user.FirstName == null || user.LastName == null)
                {
                    var msg = "Fill all fields.";
                    if (((int)_user.Language) == 1)
                    {
                        msg = "Popunite sva polja.";
                    }
                    MessageBox.Show(msg);
                    return;
                }
                dbContext.Users.Update(user);
            }
            dbContext.SaveChanges();
        }
        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow(_user);
            main.Show();
            this.Close();
        }
    }
}
