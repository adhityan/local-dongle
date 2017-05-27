using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LocalDongle.Structs
{
    class ContactsListItem : INotifyPropertyChanged
    {
        private long id;
        private string name;
        private string phone;
        private string designation;

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

        public string Phone
        {
            get { return this.phone; }

            set
            {
                if (value != this.phone)
                {
                    this.phone = value;
                    NotifyPropertyChanged("Phone");
                }
            }
        }

        public string Designation
        {
            get { return this.designation; }

            set
            {
                if (value != this.designation)
                {
                    this.designation = value;
                    NotifyPropertyChanged("Designation");
                }
            }
        }

        public ContactsListItem(long id, string name, string phone, string designation)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.designation = designation;
        }
    }
}
