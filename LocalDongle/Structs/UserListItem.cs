using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LocalDongle.Structs
{
    class UserListItem : INotifyPropertyChanged
    {
        private long id;
        private string name;

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

        public string Name
        {
            get { return this.name; }

            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public UserListItem(long id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
