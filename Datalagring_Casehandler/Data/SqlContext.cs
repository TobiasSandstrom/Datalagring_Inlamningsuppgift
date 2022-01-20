using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Datalagring_Casehandler.Entities;

namespace Datalagring_Casehandler.Data
{
    public partial class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Case> Cases { get; set; } = null!;
        public virtual DbSet<CaseStatus> CaseStatuses { get; set; } = null!;
        public virtual DbSet<Casemanager> Casemanagers { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;
        public virtual DbSet<CustomerContactInfo> CustomerContactInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Tobia\\OneDrive\\Skrivbord\\Dokument\\Skola\\4_Datalagring\\Datalagring_Tenta\\Datalagring_Casehandler\\Data\\CaseHandler_Database.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Case>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cases__CustomerI__5812160E");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Cases__ManagerId__571DF1D5");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cases__StatusId__5629CD9C");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.SocialSecurityNumber).IsFixedLength();

                entity.HasOne(d => d.Adress)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AdressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customers__Adres__52593CB8");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customers__Conta__534D60F1");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.Property(e => e.ZipCode).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
