using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naros_Ana_Maria_AdoptAPet.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<PetCategory> PetCategories { get; set; }
    }
}
