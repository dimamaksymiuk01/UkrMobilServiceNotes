using UkrMobilServiceNotes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UkrMobilServiceNotes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            EnsurePopulated();
        }

        public DbSet<Note> Notes { get; set; }

        private void EnsurePopulated()
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Note>().Property(user => user.Id).HasDefaultValueSql("NEWID()");
        }
    }
}