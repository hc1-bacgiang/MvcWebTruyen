using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcWebTruyen.Models;

namespace MvcWebTruyen.Data
{
    public class MvcWebTruyenContext : DbContext
    {
        public MvcWebTruyenContext (DbContextOptions<MvcWebTruyenContext> options)
            : base(options)
        {
        }

        public DbSet<MvcWebTruyen.Models.Truyen> Truyen { get; set; } = default!;
    }
}
