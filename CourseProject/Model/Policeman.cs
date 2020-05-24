
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace CourseProject.Model 
{
    public class Policeman : INotifyPropertyChanged
    {
        public int PolicemanId { get; set; }
        public string PolicemanName
        {
            get
            { return PolicemanName; }
            set
            {
                PolicemanName = value;
                OnPropertyChanged("PolicemanName");
            }
        }
        public string PolicemanSurname
        {
            get
            { return PolicemanSurname; }
            set
            {
                PolicemanSurname = value;
                OnPropertyChanged("PolicemanSurname");
            }
        }
        public int PolicemanSertificateNumber
        {
            get
            { return PolicemanSertificateNumber; }
            set
            {
                PolicemanSertificateNumber = value;
                OnPropertyChanged("PolicemanSertificateNumber");
            }
        }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
        public ObservableCollection<Protocol> Protocols { get; set; }
        public Policeman()
        {
            Protocols = new ObservableCollection<Protocol>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
