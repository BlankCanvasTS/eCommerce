using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eCommerceProject.Models;

namespace eCommerceProject.Data
{
    public class eCommerceProjectContext : DbContext
    {
        public eCommerceProjectContext (DbContextOptions<eCommerceProjectContext> options)
            : base(options)
        {
        }

        public DbSet<eCommerceProject.Models.CreateAccountModel> CreateAccountModel { get; set; } = default!;
    }
}
