using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseProject.Model
{
    public class ProtocoledOffence : INotifyPropertyChanged
    {
        public int ProtocoledOffenceId { get; set; }
        public int? ProtocolId { get; set; }
        public Protocol Protocol { get; set; }
        public int? OffenceId { get; set; }
        public Offence Offence { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
