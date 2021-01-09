using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naros_Ana_Maria_AdoptAPet.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Type Name")]
        public string CategoryName { get; set; }

        public ICollection<PetCategory> PetCategories { get; set; }
    }
}
