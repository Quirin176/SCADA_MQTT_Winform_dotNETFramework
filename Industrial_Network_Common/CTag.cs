using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Industrial.Network.Common.Devices
{
    [DataContract]
    public class CTag : INotifyPropertyChanged
    {
        private string _TagName;

        private string _Address;

        private dynamic _Value;

        private string _Description;

        public delegate void EventValueChanged(dynamic value);

        public CTag()
        {

        }


        public CTag(string address, dynamic value)
        {
            this.Address = address;
            this.Value = value;
        }

        public CTag(string tagName, string address, dynamic value)
        {
            this.TagName = tagName;
            this.Address = address;
            this.Value = value;
        }

        public CTag(string tagName, string address, dynamic value, string description)
        {
            this.TagName = tagName;
            this.Address = address;
            this.Value = value;
            this.Description = description;
        }

        [DataMember]
        public string TagName
        {
            get { return _TagName; }
            set { _TagName = value; }
        }

        [DataMember]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        [DataMember]
        public dynamic Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                OnPropertyChanged("Value");
            }
        }

        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public EventValueChanged ValueChanged = null;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
            if (ValueChanged != null) ValueChanged(this.Value);
        }
    }
}
