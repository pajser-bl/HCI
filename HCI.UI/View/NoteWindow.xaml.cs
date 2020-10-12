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

namespace HCI.UI.View
{
    /// <summary>
    /// Interaction logic for NoteWindow.xaml
    /// </summary>
    public partial class NoteWindow : Window
    {

        private readonly Data.AppDbContext dbContext;

        public NoteWindow(object date,User user)
        {
            InitializeComponent();
            dbContext = ((App)Application.Current).DbContext;
            var note = dbContext.Notes.Where(x => x.User.Id == user.Id).Where(x => x.Datetime.Date.Equals(date));
            Date.Text = ((DateTime)date).ToString("dd.MM.yyyy");
        }
    }
}
