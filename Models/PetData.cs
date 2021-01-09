using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naros_Ana_Maria_AdoptAPet.Models
{
    public class PetData
    {
        public IEnumerable<Pet> Pets { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<PetCategory> PetCategories { get; set; }
    }
}
