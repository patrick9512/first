using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window 
    {
        public Window1(MainWindow mw)
        {
            InitializeComponent();
            DataContext = mw;
        }

        public void zapisz_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(tbName.Text, tbLastName.Text, 0);
            (DataContext as MainWindow).Users.Add(user);
            MessageBox.Show("Dodano nowego usera:" + user.imie + " " + user.nazwisko);
            (DataContext as MainWindow).SerializeUser();
            this.Close();
        }
    }
}
