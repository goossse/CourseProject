using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseProject.Model
{
    public class Gender : INotifyPropertyChanged
    {
        public int GenderId { get; set; }
        public string GenderName
        {
            get
            { return GenderName; }
            set
            {
                GenderName = value;
                OnPropertyChanged("GenderName");
            }
        }
        public ObservableCollection<Citizen> Citizens { get; set; }
        public ObservableCollection<Policeman> Policemen { get; set; }
        public Gender()
        {
            Citizens = new ObservableCollection<Citizen>();
            Policemen = new ObservableCollection<Policeman>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
