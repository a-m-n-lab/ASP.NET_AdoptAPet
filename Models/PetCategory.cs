using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naros_Ana_Maria_AdoptAPet.Models
{
    public class PetCategory
    {
        public int ID { get; set; }
        public int PetID { get; set; }
        public Pet Pet { get; set; }
        [Display(Name = "Type ID")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
