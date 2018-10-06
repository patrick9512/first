using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class NVR
    {
       // public User Owner { get; set; }
        public string NVRName { get; set; }
        public string NVRStartDate { get; set; }
        public string NVREndDate { get; set; }
        public string NVRType { get; set; }
        public string NVRMotherboard { get; set; }
        public string NVRMemory { get; set; }
        public string NVRGraphicsNumber { get; set; }

        public NVR (/*string own*/ string nname, string nsdate, string nedate, 
            string ntype, string nmb, string nmem, string ngnum)
        {
           // this.Owner = own;
            NVRName = nname;
            NVRStartDate = nsdate;
            NVREndDate = NVREndDate;
            NVRType = ntype;
            NVRMotherboard = nmb;
            NVRMemory = nmem;
            NVRGraphicsNumber = ngnum;
        }

    }
}
