using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseProject.Model
{
    public class Protocol : INotifyPropertyChanged
    {
        public int ProtocolId { get; set; }
        private DateTime protocolDate;
        private string protocolPlace;
        private bool protocolIsPunished;
        public DateTime ProtocolDate
        {
            get
            { return protocolDate; }
            set
            {
                protocolDate = value;
                OnPropertyChanged("ProtocolDate");
            }
        }
        public string ProtocolPlace
        {
            get
            { return protocolPlace; }
            set
            {
                protocolPlace = value;
                OnPropertyChanged("ProtocolPlace");
            }
        }
        public bool ProtocolIsPunished
        {
            get
            { return protocolIsPunished; }
            set
            {
                protocolIsPunished = value;
                OnPropertyChanged("ProtocolIsPunished");
            }
        }

        public int? PolicemanId { get; set; }
        public virtual Policeman Policeman { get; set; }
        public int? CitizenId { get; set; }
        public virtual Citizen Citizen { get; set; }

        public ObservableCollection<ProtocoledOffence> ProtocoledOffences { get; set; }
        public Protocol()
        {
            ProtocoledOffences = new ObservableCollection<ProtocoledOffence>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
