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
    public class IndexModel : PageModel
    {
        private readonly Rcp.Data.RcpContext _context;


        public IndexModel(Rcp.Data.RcpContext context)
        {
            _context = context;
        }

        public IList<Competitor> Competitor { get;set; }
        public async Task OnGetAsync()
        {
            Competitor = await _context.Competitor.ToListAsync();
        }
    }
}
