using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public  partial class MainWindow : Window
    {
        public ObservableCollection<User> Users = new ObservableCollection<User>();
        public User SelectedUser { get; set; }
        
        public MainWindow()
        {
            User Patryk = new User("patryk", "xxxxx", 3 );
            User Zbyszek = new User("Zbyszek", "Kowalski", 5);

            //  Patryk.nvry first = new NVR("NVR 7", "01.01.2018", "10.01.2018", "Client", "Z270", "8GB", "2");



            Users.Add(Patryk);



            InitializeComponent();
            
            Patryk.nvry.Add(new NVR("NVR 7", "01.01.2018", "10.01.2018", "Client", "Z270", "8GB", "2"));
            Patryk.nvry.Add(new NVR("NVR 7-T", "01.02.2018", "10.02.2018", "Server", "Z270", "8GB", "1"));
            Zbyszek.nvry.Add(new NVR("NVR 7-T", "01.02.2018", "10.02.2018", "Server", "Z270", "8GB", "1"));


            
            DG1.ItemsSource = Users;
            


        }





        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedUser = (sender as DataGrid).SelectedItem as User;
            DG2.ItemsSource = SelectedUser.nvry;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 NewWindow = new Window1(this);
            NewWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = null;
            DG1.ItemsSource = Users;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<User>));

            using (Stream s = File.Create("Users.xml"))
                xs.Serialize(s, Users);

        }
    }
}
