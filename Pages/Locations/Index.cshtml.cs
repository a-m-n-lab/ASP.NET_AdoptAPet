using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Naros_Ana_Maria_AdoptAPet.Data;
using Naros_Ana_Maria_AdoptAPet.Models;

namespace Naros_Ana_Maria_AdoptAPet.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext _context;

        public IndexModel(Naros_Ana_Maria_AdoptAPet.Data.Naros_Ana_Maria_AdoptAPetContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; }

        public async Task OnGetAsync()
        {
            Location = await _context.Location.ToListAsync();
        }
    }
}
