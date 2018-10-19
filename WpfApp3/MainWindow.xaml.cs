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
using System.Xml.Linq;
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

        XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<User>), new XmlRootAttribute("ArrayOfUser"));
        XElement UsersFromFile = XElement.Load(@"Users.xml");

        public MainWindow()
        {


            InitializeComponent();


            Users = LoadUser();
            DG1.ItemsSource = Users;
            


        }


        public ObservableCollection<User> LoadUsers()
        {

            XElement UsersFromFile = XElement.Load(@"Users.xml");
            //XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<User>), new XmlRootAttribute("ArrayOfUser"));
            StringReader stringReader = new StringReader(UsersFromFile.ToString());
            return (ObservableCollection<User>)xs.Deserialize(stringReader);
        }


        public StringReader ReadUsersFromFile()
        {
            //XElement UsersFromFile = XElement.Load(@"Users.xml");
            StringReader stringReader = new StringReader(UsersFromFile.ToString());
            return stringReader;
        }

        private ObservableCollection<User> LoadUser()
        {

            return (ObservableCollection<User>)xs.Deserialize(ReadUsersFromFile());
        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedUser = (sender as DataGrid).SelectedItem as User;
           // DG2.ItemsSource = SelectedUser.nvry;
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

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<User>));

            using (Stream s = File.Create("Users.xml"))
                xs.Serialize(s, Users);

        }

        public void SerializeUser ()
        {
            //  XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<User>));

            using (Stream s = File.Create("Users.xml"))
            xs.Serialize(s ,Users);
        }
    }
}
