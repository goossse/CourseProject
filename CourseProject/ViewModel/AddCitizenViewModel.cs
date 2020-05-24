using CourseProject.Model;
using CourseProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProject.ViewModel
{
    class AddCitizenViewModel : INotifyPropertyChanged
    {
        OffenceContext db;
        public Citizen Citizen { get; set; }
        RelayCommand addProtocolCommand;
        RelayCommand editProtocolCommand;
        IEnumerable<Protocol> protocols;
        IEnumerable<Protocol> Protocols
        {
            get { return protocols; }
            set
            {
                protocols = value;
                OnPropertyChanged("Protocols");
            }
        }

        public AddCitizenViewModel()
        {
            db = new OffenceContext();
            db.Citizens.Load();
            db.Protocols.Load();
        }
        public void CitizenDogr()
        {
            if(Citizen!= null)
            {
                Protocols = Citizen.Protocols.ToList();
            }
        }

        public ICommand AddProtocolCommand
        {
            get
            {
                return addProtocolCommand ??
                    (addProtocolCommand = new RelayCommand((o) =>
                    {
                        /*if (Citizen == null) return;*/
                        AddProtocolViewModel vm = new AddProtocolViewModel() { Protocol = new Protocol() { Citizen = Citizen } };
                        AddProtocolWindow addProtocolWindow = new AddProtocolWindow();
                        addProtocolWindow.DataContext = vm;
                        if (addProtocolWindow.ShowDialog() == true)
                        {
                            Protocol protocol = vm.Protocol;
                            Citizen.Protocols.Add(protocol);
                            Protocols = Citizen.Protocols.ToList();

                            db.SaveChanges();

                        }
                    }
                    ));
            }


        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
