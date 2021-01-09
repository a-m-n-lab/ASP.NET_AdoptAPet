using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naros_Ana_Maria_AdoptAPet.Models
{
    public class Location
    {
        public int ID {get; set;}
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
