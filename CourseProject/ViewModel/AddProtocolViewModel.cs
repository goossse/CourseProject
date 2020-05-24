using CourseProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.View
{
    class AddProtocolViewModel : INotifyPropertyChanged
    {
        OffenceContext db;
        public Protocol Protocol { get; set; }
        IEnumerable<Offence> offences;

        IEnumerable<Offence> Offences
        {
            get { return offences; }
            set
            {
                offences = value;
                OnPropertyChanged("Offences");
            }
        }
        public AddProtocolViewModel()
        {
            db = new OffenceContext();
            db.Protocols.Load();
            db.Offences.Load();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
