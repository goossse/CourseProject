using CourseProject.Model;
using CourseProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;


namespace CourseProject.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        OffenceContext db;
        RelayCommand addCitizenCommand;
        RelayCommand editCitizenCommand;
        RelayCommand deleteCitizenCommand;

        RelayCommand addProtocolCommand;
        RelayCommand editProtocolCommand;
        RelayCommand deleteProtocolCommand;

        private Citizen selectedItem;
        public Citizen SelectedItem
        {
            get
            { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }

        IEnumerable<Citizen> citizens;
        public IEnumerable<Citizen> Citizens
        {
            get { return citizens; }
            set
            {
                citizens = value;
                NotifyPropertyChanged("Citizens");
            }
        }
        IEnumerable<Protocol> protocols;
        public IEnumerable<Protocol> Protocols
        {
                get { return protocols; }
                set
            {
                    protocols = value;
                    NotifyPropertyChanged("Protocols");
                }
        }
      

        public MainViewModel()
        {
            db = new OffenceContext();
            db.Citizens.Load();
            db.Protocols.Load();
            //syuda dobavit' sho nado 
            Citizens = db.Citizens.Local.ToBindingList();
        }

        public RelayCommand DeleteCitizenCommand
        {
            get
            {
                return deleteCitizenCommand ??
                    (deleteCitizenCommand = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Citizen citizen = selectedItem as Citizen;
                        db.Citizens.Remove(citizen);
                        db.SaveChanges();
                    }));
            }
        }

        public RelayCommand AddCitizenCommand
        {
            get
            {
                return addCitizenCommand ??
                    (addCitizenCommand = new RelayCommand((o) =>
                    {
                        AddCitizenWindow addCitizenWindow = new AddCitizenWindow();
                        AddCitizenViewModel vm = new AddCitizenViewModel() { Citizen = new Citizen() };
                        addCitizenWindow.DataContext = vm;

                        if (addCitizenWindow.ShowDialog() == true)
                        {
                            Citizen citizen = vm.Citizen;
                            db.Citizens.Add(citizen);
                            db.SaveChanges();
                        }
                    }));
            }
        }
        public RelayCommand EditCitizenCommand
        {
            get
            {
                return editCitizenCommand ??
                    (editCitizenCommand = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Citizen citizen = selectedItem as Citizen;
                        var vm = new AddCitizenViewModel() { Citizen = citizen };
                        var citizenWindow = new AddCitizenWindow();
                        vm.CitizenDogr();
                        citizenWindow.DataContext = vm;
                        if (citizenWindow.ShowDialog() == true)
                        {
                            citizen = db.Citizens.Find(vm.Citizen.CitizenId);
                            if (citizen != null)
                            {
                                citizen.CitizenId = vm.Citizen.CitizenId;
                                citizen.CitizenName = vm.Citizen.CitizenName;
                                citizen.CitizenSurname = vm.Citizen.CitizenSurname;
                                citizen.CitizenDateOfBirth = vm.Citizen.CitizenDateOfBirth;
                                citizen.GenderId = vm.Citizen.GenderId;
                                citizen.Protocols = vm.Citizen.Protocols;

                                db.Entry(citizen).State = EntityState.Modified;
                                db.SaveChanges();

                            }
                        }
                    }
                    ));

            }
        }

        public RelayCommand DeleteProtocolCommand
        {
            get
            {
                return deleteProtocolCommand ??
                    (deleteProtocolCommand = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Protocol protocol = selectedItem as Protocol;
                        db.Protocols.Remove(protocol);

                        db.SaveChanges();
                    }));
            }
        }

/*        public RelayCommand AddProtocolCommand
        {
            get
            {
                return addProtocolCommand ??
                    (addProtocolCommand = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Citizen citizen = selectedItem as Citizen;
                        var vm = new AddProtocolViewModel() { Protocol = new Protocol() { Citizen = citizen } };
                        if (AddProtocolWindow.ShowDialog() == true)
                        {
                            Protocol protocol = vm.Protocol;
                            citizen.Protocols.Add(protocol);
                            protocols = citizen.Protocols.ToList();
                            db.SaveChanges();
                        }
                    }));
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
