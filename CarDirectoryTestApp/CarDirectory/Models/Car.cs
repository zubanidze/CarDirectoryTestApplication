using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDirectoryTestApp.CarDirectory.Models
{


    internal class Car
    {
        public string Number { get;  set; }
        public string Brand { get;  set; }
        public string Model { get;  set; }
        public string Color { get;  set; }

        public string BodyType { get;  set; }
        public string EngineNumber { get;  set; }
        public int HorsePowers { get;  set; }
        public int YearOfProduction { get; set; }
        public bool IsChecked { get; set; }
        public DateTime DateTimeOfWrite { get; set; }
        public string AuthorName { get; set; }
        
    }
}
