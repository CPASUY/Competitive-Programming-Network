using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rcp.Models;

namespace Rcp.Data
{
    public class RcpContext : DbContext
    {
        public RcpContext (DbContextOptions<RcpContext> options)
            : base(options)
        {
        }

        public DbSet<Rcp.Models.Competitor> Competitor { get; set; }
    }
}
