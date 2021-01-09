using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Naros_Ana_Maria_AdoptAPet.Data;
using Naros_Ana_Maria_AdoptAPet.Models;

namespace Naros_Ana_Maria_AdoptAPet.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext _context;

        public CreateModel(Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
