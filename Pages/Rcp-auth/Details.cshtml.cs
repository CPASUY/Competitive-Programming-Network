using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rcp.Data;
using Rcp.Models;

namespace Rcp.Pages.Rcp_auth
{
    public class DetailsModel : PageModel
    {
        private readonly Rcp.Data.RcpContext _context;

        public DetailsModel(Rcp.Data.RcpContext context)
        {
            _context = context;
        }

        public Competitor Competitor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Competitor = await _context.Competitor.FirstOrDefaultAsync(m => m.ID == id);

            if (Competitor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
