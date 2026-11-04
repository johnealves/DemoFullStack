using DemoFullstack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoFullstack.Infrastructure.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var ticket = modelBuilder.Entity<Ticket>();

            ticket.ToTable("Tickets");

            ticket.HasKey(t => t.Id);

            ticket.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(Ticket.MaxTitleLength);

            ticket.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(Ticket.MaxDescriptionLength);

            ticket.Property(t => t.Resolution)
                .HasMaxLength(Ticket.MaxResolutionLength);

            ticket.Property(t => t.Priority)
                .IsRequired();

            ticket.Property(t => t.Status)
                .IsRequired();
        }
    }
}
