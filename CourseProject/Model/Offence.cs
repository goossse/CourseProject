using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseProject.Model
{
    public class Offence : INotifyPropertyChanged
    {
        public int OffenceId { get; set; }
        public string OffenceName
        {
            get
            { return OffenceName; }
            set
            {
                OffenceName = value;
                OnPropertyChanged("OffenceName");
            }
        }
        public decimal AmountOfFine
        {
            get
            { return AmountOfFine; }
            set
            {
                AmountOfFine = value;
                OnPropertyChanged("AmountOfFine");
            }
        }
        public ObservableCollection<ProtocoledOffence> ProtocoledOffences{ get; set; }
        public Offence()
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
