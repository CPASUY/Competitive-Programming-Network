using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rcp.Data;
using Rcp.Models;

namespace Rcp.Pages.Rcp_auth
{
    public class EditModel : PageModel
    {
        private readonly Rcp.Data.RcpContext _context;

        public EditModel(Rcp.Data.RcpContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Competitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitorExists(Competitor.ID))
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

        private bool CompetitorExists(int id)
        {
            return _context.Competitor.Any(e => e.ID == id);
        }
    }
}
