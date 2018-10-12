using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class User
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int liczbaKompow { get; set; }

        public List<NVR> nvry = new List<NVR>();


        public User() { }

        public User(string name, string lastName, int lKomp)
        {
            this.imie = name;
            this.nazwisko = lastName;
            this.liczbaKompow = lKomp;
        }

        
    }

}
