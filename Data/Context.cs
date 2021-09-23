using Distribuidora_De_Bebidas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserPf> UsersPf { get; set; }

        public DbSet<UserPj> UsersPj { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<TypeOf> Types { get; set; }
    }
}
