using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naros_Ana_Maria_AdoptAPet.Models
{
    public class Pet
    {
        public int ID { get; set; }

        [Required, StringLength(50, MinimumLength= 2)]
        public string Name { get; set; }

        public string Breed { get; set; }
        public int Age { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Available Date")]
        public DateTime AvailableDate { get; set; }
       
        public int LocationID { get; set; }
        public Location Location { get; set; }
        [Display(Name = "Pet Type")]
        public ICollection<PetCategory> PetCategories{ get; set; }
    }
}
