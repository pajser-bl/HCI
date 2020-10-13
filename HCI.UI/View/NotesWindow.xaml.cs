using HCI.Data.Model;
using System;
using System.Windows;
using System.Linq;
using System.Collections.Generic;

namespace HCI.UI.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        private readonly Data.AppDbContext dbContext;
        private readonly User _user;
        private readonly DateTime _date;
        private List<Note> _notes;

        public NotesWindow(User user, object date)
        {
            InitializeComponent();
            dbContext = ((App)Application.Current).DbContext;
            _user = user;
            _date = (DateTime)date;
            Date.Text = _date.ToString("dd.MM.yyyy");
            var matches = from n in dbContext.Notes
                          where n.Datetime.Date == _date.Date && n.User.Id == _user.Id
                          select n;
            Notes.ItemsSource = _notes = matches.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var matches = from n in dbContext.Notes
                          where n.Datetime >= _date.Date && n.Datetime <= _date.Date.AddDays(1) && n.User.Id == _user.Id
                          select n;
            var remove = matches.ToList().Except((List<Note>)Notes.ItemsSource).ToList();
            var create = ((List<Note>)Notes.ItemsSource).Except(remove).ToList();
            foreach (Note r in remove)
            {
                dbContext.Remove(r);
            }
            dbContext.SaveChanges();
            foreach (Note c in create)
            {
                c.User = _user;
                if (c.Datetime == null || c.Name == null)
                {
                    var msg = "Fill all fields.";
                    if (((int)_user.Language) == 1)
                    {
                        msg = "Popunite sva polja.";
                    }
                    MessageBox.Show(msg);
                    return;
                }
                dbContext.Notes.Update(c);
            }
            dbContext.SaveChanges();
            var msga = "Notes updated.";
            if (((int)_user.Language) == 1)
            {
                msga = "Bilješke ažurirane.";
            }
            MessageBox.Show(msga);

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //var main = new MainWindow(_user);
            //main.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var main = new MainWindow(_user);
            main.Show();
        }
    }
}
