using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Model
{
    public class Citizen
    {
        public int CitizenId { get; set; }
        private string citizenName;
        private string citizenSurname;
        private DateTime citizenDateOfBirth;

        public string CitizenName
        {
            get
            { return citizenName; }
            set
            {
                citizenName = value;
                OnPropertyChanged("CitizenName");
            }
        }
        public string CitizenSurname
        {
            get
            { return citizenSurname; }
            set
            {
                citizenSurname = value;
                OnPropertyChanged("citizenSurname");
            }
        }
        public DateTime CitizenDateOfBirth
        {
            get
            { return citizenDateOfBirth; }
            set
            {
                citizenDateOfBirth = value;
                OnPropertyChanged("CitizenDateOfBirth");
            }
        }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

/*        public override string ToString()
        {
            return $"Name: {CitizenName}\n" +
                   $"Surname: {CitizenSurname}";
        }*/
        public ObservableCollection<Protocol> Protocols { get; set; }
        public Citizen()
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
