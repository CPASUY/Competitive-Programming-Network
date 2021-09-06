using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rcp.Data;
using Rcp.Models;

namespace Rcp.Pages.Rcp_auth
{
    public class IndexModel : PageModel
    {
        private readonly Rcp.Data.RcpContext _context;
        [BindProperty(SupportsGet = true)]
        public bool Out { get; set; }
        [BindProperty(SupportsGet = true)]
        public static bool In { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Ulogin { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Plogin { get; set; }
        [BindProperty(SupportsGet = true)]
        public Competitor User { get; set; }



            public IndexModel(Rcp.Data.RcpContext context)
        {
            _context = context;
        }

        public IList<Competitor> Competitor { get;set; }
        public async Task OnGetAsync()
        {
            Competitor = await _context.Competitor.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Out)
            {
                In = false;
                User = null;
            }
            else
            {
                User = await _context.Competitor.FirstOrDefaultAsync(x => x.Username == Ulogin&& x.Password == Plogin);

                if (User == null)
                {
                    return Page();
                }
                In = true;
                Competitor = await _context.Competitor.ToListAsync();

            }
            return Page();
        }
    }
}
