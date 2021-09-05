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
    public class DeleteModel : PageModel
    {
        private readonly Rcp.Data.RcpContext _context;

        public DeleteModel(Rcp.Data.RcpContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Competitor = await _context.Competitor.FindAsync(id);

            if (Competitor != null)
            {
                _context.Competitor.Remove(Competitor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
