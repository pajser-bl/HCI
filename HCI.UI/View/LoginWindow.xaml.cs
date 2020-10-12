using HCI.Data;
using HCI.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly AppDbContext dbContext;

        public LoginWindow()
        {
            InitializeComponent();
            dbContext = ((App)Application.Current).DbContext;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void StackPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) {
                Login();
            }
        }
        private void Login()
        {
            User user = dbContext.Users.Where(u => u.Username.Equals(username.Text)).FirstOrDefault();
            if (user == null || user.Password.Equals(password.Password) == false)
            {
                MessageBox.Show("Bad login");
                return;
            }
            if (user.Administrator)
            {
                var admin = new AdminWindow(user);
                admin.Show();
            }
            else
            {
                var main = new MainWindow(user);
                main.Show();
            }
            this.Close();
        }
    }
}
