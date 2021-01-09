using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Naros_Ana_Maria_AdoptAPet.Data;
using Naros_Ana_Maria_AdoptAPet.Models;

namespace Naros_Ana_Maria_AdoptAPet.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext _context;

        public DetailsModel(Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
