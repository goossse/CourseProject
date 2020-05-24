using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseProject.Model
{
    public class Post : INotifyPropertyChanged
    {
        public int PostId { get; set; }
        public string PostName
        {
            get
            { return PostName; }
            set
            {
                PostName = value;
                OnPropertyChanged("PostName");
            }
        }
        public ObservableCollection<Policeman> Policemen { get; set; }
        public Post()
        {
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
