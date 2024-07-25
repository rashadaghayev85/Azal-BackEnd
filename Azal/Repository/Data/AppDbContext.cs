using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogTranslate> BlogTranslates { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<AirportTranslate> AirportTranslates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.BlogTranslates)
                .WithOne(bt => bt.Blog)
                .HasForeignKey(bt => bt.BlogId);

            modelBuilder.Entity<BlogTranslate>()
                .HasOne(bt => bt.Language)
                .WithMany()
                .HasForeignKey(bt => bt.LanguageId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
