using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainingDay2.Api.Models.Entities
{
    public partial class TrainingContext : DbContext
    {
        public TrainingContext()
        {
        }

        public TrainingContext(DbContextOptions<TrainingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactTag> ContactTag { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => e.Company);

                entity.HasIndex(e => e.FirstName);

                entity.HasIndex(e => e.LastName);

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.JobTitle).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.LinkedIn).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Skype).HasMaxLength(255);
            });

            modelBuilder.Entity<ContactTag>(entity =>
            {
                entity.HasIndex(e => e.ContactId)
                    .HasName("IX_ContactTag_ByContact");

                entity.HasIndex(e => e.TagId)
                    .HasName("IX_ContactTag_ByTag");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactTag)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactTag_Contact");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ContactTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactTag_Tag");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => e.Name);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
