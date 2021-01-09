using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Naros_Ana_Maria_AdoptAPet.Data;
using Naros_Ana_Maria_AdoptAPet.Models;

namespace Naros_Ana_Maria_AdoptAPet.Pages.Pets
{
    public class IndexModel : PageModel
    {
        private readonly Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext _context;

        public IndexModel(Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext context)
        {
            _context = context;
        }

        public IList<Pet> Pet { get;set; }
        public PetData PetD { get; set; }
        public int PetID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PetD = new PetData();
            PetD.Pets = await _context.Pet
                                            .Include(b => b.Location)
                                           .Include(b => b.PetCategories)
                                           .ThenInclude(b => b.Category)
                                           .AsNoTracking()
                                           .OrderBy(b => b.Name)
                                           .ToListAsync();

            if (id != null)
            {
                PetID = id.Value;
                Pet pet = PetD.Pets
                .Where(i => i.ID == id.Value).Single();
                PetD.Categories = pet.PetCategories.Select(s => s.Category);
            }

        }
    }
}
