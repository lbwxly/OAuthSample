using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Core.Infrasructure
{
    public class AccountDataContext:DbContext
    {
        public AccountDataContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
