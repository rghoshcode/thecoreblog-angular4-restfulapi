using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TCB.API.Models
{
    public partial class TestAppDBContext : DbContext
    {
        public virtual DbSet<Blog1> Blog1 { get; set; }

        public TestAppDBContext(DbContextOptions<TestAppDBContext> options) : base(options)
        { }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=TestAppDB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog1>(entity =>
            {
                entity.HasKey(e => e.BlogId);

                entity.Property(e => e.BlogId).ValueGeneratedNever();

                entity.Property(e => e.BlogAuthor).HasMaxLength(50);

                entity.Property(e => e.BlogContent).HasMaxLength(50);

                entity.Property(e => e.BlogName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
