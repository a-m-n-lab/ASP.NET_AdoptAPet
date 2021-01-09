using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Naros_Ana_Maria_AdoptAPet.Data;
using Naros_Ana_Maria_AdoptAPet.Models;


namespace Naros_Ana_Maria_AdoptAPet.Pages.Pets
{
    public class CreateModel : PetCategoriesPageModel
    {
        private readonly Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext _context;

        public CreateModel(Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "LocationName");
            var pet = new Pet();
            pet.PetCategories = new List<PetCategory>();
            PopulateAssignedCategoryData(_context, pet);
            return Page();
        }

        [BindProperty]
        public Pet Pet { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string [] selectedCategories)
        {
                   
                var newPet = new Pet();
                if (selectedCategories != null)
                {
                    newPet.PetCategories = new List<PetCategory>();
                    foreach (var cat in selectedCategories)
                    {
                        var catToAdd = new PetCategory
                        {
                            CategoryID = int.Parse(cat)
                        };
                        newPet.PetCategories.Add(catToAdd);
                    }
                }
                if (await TryUpdateModelAsync<Pet>(
                newPet,
                "Pet",
                i => i.Name, i => i.Breed, i => i.Age, i => i.AvailableDate, i => i.LocationID, i => i.Photo))
                {
                    _context.Pet.Add(newPet);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                PopulateAssignedCategoryData(_context, newPet);
                return Page();
            
          
        }
    }
}
