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
        public static bool SignedIn { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Tryusername { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Trypassword { get; set; }
        [BindProperty(SupportsGet = true)]
        public Competitor SignedUser { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool SigningOut { get; set; }



        public IndexModel(Rcp.Data.RcpContext context)
        {
            _context = context;
        }

        public IList<Competitor> Competitor { get;set; }
        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }
        public string UsernameLogged { get; set; }
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Username) & !string.IsNullOrEmpty(Password))
            {
                var userLogged = _context.Competitor.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                if (userLogged is null)
                {
                    UsernameLogged = string.Empty;
                }
                else
                {
                    UsernameLogged = userLogged.Username;
                    HttpContext.Session.SetString("Username", userLogged.Username);
                }
            }
            else
            {
                UsernameLogged = "";
            }
            Competitor = await _context.Competitor.ToListAsync();

        }
    }
}
