using HCI.Data.Model;
using HCI.UI.View;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace HCI.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty CurrentDateProperty = DependencyProperty.Register("CurrentDate", typeof(DateTime), typeof(MainWindow));

        public event EventHandler<DayChangedEventArgs> DayChanged;
        private readonly Data.AppDbContext dbContext;

        public DateTime CurrentDate
        {
            get { return (DateTime)GetValue(CurrentDateProperty); }
            set { SetValue(CurrentDateProperty, value); }
        }

        //public ObservableCollection<Day> Days { get; private set; }

        protected readonly User _user;
        public MainWindow(User user)
        {
            InitializeComponent();
            _user = user;
            dbContext = ((App)Application.Current).DbContext;


            for (int i = -50; i < 50; i++)
            {
                cboYear.Items.Add(DateTime.Today.AddYears(i).Year);
            }

            cboMonth.SelectedItem = cboMonth.Items[DateTime.Today.Month - 1];
            cboYear.SelectedItem = DateTime.Today.Year;

            cboMonth.SelectionChanged += (o, e) => RefreshCalendar();
            cboYear.SelectionChanged += (o, e) => RefreshCalendar();

            CurrentDate = DateTime.Today;

            BuildCalendar(DateTime.Today);
        }

     
        public void BuildCalendar(DateTime targetDate)
        {
            var days = new List<Day>();
            DateTime d = new DateTime(targetDate.Year, targetDate.Month, 1);
            int offset = DayOfWeekNumber(d.DayOfWeek);
            if (offset != 1) d = d.AddDays(-offset);
            var matches=from n in dbContext.Notes
                        where n.User.Id==_user.Id && n.Datetime>=targetDate.AddDays(-30) && n.Datetime<=targetDate.AddDays(30)
                        select n.Datetime.Date;
            var daysWithNotes = matches.ToList();
            for (int box = 1; box <= 42; box++)
            {
                Day day = new Day { Date = d, Enabled = true, IsTargetMonth = targetDate.Month == d.Month };
                day.PropertyChanged += Day_Changed;
                day.IsToday = d == DateTime.Today;
                day.HasNote = !daysWithNotes.Contains(d.Date);
                days.Add(day);
                d = d.AddDays(1);
            }
            Days.ItemsSource = days;
        }

        private void RefreshCalendar()
        {
            if (cboYear.SelectedItem == null) return;
            if (cboMonth.SelectedItem == null) return;

            int year = (int)cboYear.SelectedItem;

            int month = cboMonth.SelectedIndex + 1;

            DateTime targetDate = new DateTime(year, month, 1);

            BuildCalendar(targetDate);
        }

        private void Calendar_DayChanged(object sender, DayChangedEventArgs e)
        {
            // empty
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsWindow(this._user);
            settings.ShowDialog();
        }
        private void Day_Changed(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Notes") return;
            if (DayChanged == null) return;

            DayChanged(this, new DayChangedEventArgs(sender as Day));
        }

        private static int DayOfWeekNumber(DayOfWeek dow)
        {
            return Convert.ToInt32(dow.ToString("D"));
        }

        private void Button_Click_Day(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var date = b.CommandParameter;
            var noteW = new NotesWindow( _user,date);
            noteW.Show();
            this.Close();
        }
    }
    public class DayChangedEventArgs : EventArgs
    {
        public Day Day { get; private set; }

        public DayChangedEventArgs(Day day)
        {
            this.Day = day;
        }
    }

    
}
