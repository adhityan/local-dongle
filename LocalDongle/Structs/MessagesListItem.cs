using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LocalDongle.Structs
{
    class MessagesListItem : INotifyPropertyChanged
    {
        private long id;
        private string source;
        private string message;
        private DateTime timestamp;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public long ID
        {
            get { return this.id; }

            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        public string Message
        {
            get { return this.message; }

            set
            {
                if (value != this.message)
                {
                    this.message = value;
                    NotifyPropertyChanged("Message");
                }
            }
        }

        public DateTime Timestamp
        {
            get { return this.timestamp; }

            set
            {
                if (value != this.timestamp)
                {
                    this.timestamp = value;
                    NotifyPropertyChanged("Timestamp");
                }
            }
        }

        public string Source
        {
            get { return this.source; }

            set
            {
                if (value != this.source)
                {
                    this.source = value;
                    NotifyPropertyChanged("Source");
                }
            }
        }

        public MessagesListItem(long id, string source, string message, DateTime timestamp)
        {
            this.id = id;
            this.source = source;
            this.message = message;
            this.timestamp = timestamp;
        }
    }
}
