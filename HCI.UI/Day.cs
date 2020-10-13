using HCI.Data.Model;
using System;
using System.ComponentModel;

namespace HCI.UI
{
    public class Day : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime date;
        private bool hasNote;
        private bool enabled;
        private bool isTargetMonth;
        private bool isToday;

        public bool HasNote
        {
            get {
                return hasNote;
            }
            set {
                hasNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasNote)));
            }
        }

        public bool IsToday
        {
            get { return isToday; }
            set
            {
                isToday = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsToday)));
            }
        }

        public bool IsTargetMonth
        {
            get { return isTargetMonth; }
            set
            {
                isTargetMonth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsTargetMonth)));
            }
        }

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Enabled)));
            }
        }

        
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
            }
        }
    }
}
