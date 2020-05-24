using CourseProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject.View
{
    /// <summary>
    /// Логика взаимодействия для AddCitizenWindow.xaml
    /// </summary>
    public partial class AddCitizenWindow : Window
    {
        public AddCitizenWindow()
        {
            InitializeComponent();
            this.DataContext = new AddCitizenViewModel();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Add_Copy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
