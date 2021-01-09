using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naros_Ana_Maria_AdoptAPet.Models
{
    public class Location
    {
        public int ID {get; set;}
        public string LocationName { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
