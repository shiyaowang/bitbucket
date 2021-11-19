using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameAPI.Models
{
    public class NameDatailContext:DbContext
    {
        public NameDatailContext(DbContextOptions<NameDatailContext> options):base(options)
        {

        }
        public DbSet<NameDetail> NameDetails { get; set; }
    }
}
