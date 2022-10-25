using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Room
    {
        public int id { get; set; }
        public string numOfRoom { get; set; }
        public int buildingID { get; set; }
        public string description { get; set; }
        public int square { get; set; }

        public List<Rent> rents { get; set; }
    }
}
