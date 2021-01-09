using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Naros_Ana_Maria_AdoptAPet.Data;
using Naros_Ana_Maria_AdoptAPet.Models;

namespace Naros_Ana_Maria_AdoptAPet.Pages.Pets
{
    public class EditModel : PetCategoriesPageModel
    {
        private readonly Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext _context;

        public EditModel(Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pet Pet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pet = await _context.Pet
                .Include(b => b.Location)
                .Include(b => b.PetCategories).
                ThenInclude(b => b.Category)
                .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            if (Pet == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Pet);
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "LocationName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int ? id, string [] selectedCategories)
        {

            if (id == null)
            {
                return NotFound();
            }
            var petToUpdate = await _context.Pet
            .Include(i => i.Location)
            .Include(i => i.PetCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (petToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Pet>(
            petToUpdate,
            "Pet",
            i => i.Photo,
            i => i.Name, i => i.Breed,
            i => i.Age, i => i.AvailableDate, i => i.Location))
            {
                UpdatePetCategories(_context, selectedCategories, petToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdatePetCategories(_context, selectedCategories, petToUpdate);
            PopulateAssignedCategoryData(_context, petToUpdate);
            return Page();
        

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(Pet.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PetExists(int id)
        {
            return _context.Pet.Any(e => e.ID == id);
        }
    }
}
