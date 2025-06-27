using System;
using System.Collections.Generic;
using Infrastructure_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_DAL.Persistence;

public partial class BankSystemDb3Context : DbContext
{
    public BankSystemDb3Context()
    {
    }

    public BankSystemDb3Context(DbContextOptions<BankSystemDb3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    public virtual DbSet<TransferHistory> TransferHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=BankSystemDB3;User Id=sa;Password=sa123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientID).HasName("PK__Clients__E67E1A047CBED006");

            entity.HasIndex(e => e.PersonID, "UQ__Clients__AA2FFB846F611C96").IsUnique();

            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PinCode).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Person).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.PersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clients__PersonI__4CA06362");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Countrie__3214EC275B469B79");

            entity.HasIndex(e => e.Name, "UQ__Countrie__737584F62C7401BE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeID).HasName("PK__Employee__7AD04FF132614FD6");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CreatedByUserID)
                .HasConstraintName("FK__Employees__Creat__4F7CD00D");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobTitleID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__JobTi__4E88ABD4");

            entity.HasOne(d => d.Person).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__Perso__4D94879B");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.JobID).HasName("PK__JobTitle__056690E2A12CE555");

            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__People__3214EC27CC84B102");

            entity.HasIndex(e => e.NationalNo, "UQ__People__E9AA1A65B7CAEA6D").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DateOfbirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.NationalNo).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.NationalityCountry).WithMany(p => p.People)
                .HasForeignKey(d => d.NationalityCountryID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__People__National__4BAC3F29");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionID).HasName("PK__Transact__55433A4B330B4A31");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ClientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Clien__5535A963");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CreatedByUserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Creat__5629CD9C");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TransactionTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Trans__5441852A");

            entity.HasOne(d => d.Transfer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TransferID)
                .HasConstraintName("FK__Transacti__Trans__571DF1D5");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.TransactionTypeID).HasName("PK__Transact__20266CEB1117A698");

            entity.ToTable("TransactionType");

            entity.HasIndex(e => e.TransactionName, "UQ__Transact__5ACC27A62B709F54").IsUnique();

            entity.Property(e => e.TransactionTypeID).ValueGeneratedNever();
            entity.Property(e => e.TransactionDescription).HasMaxLength(255);
            entity.Property(e => e.TransactionFees).HasColumnType("smallmoney");
            entity.Property(e => e.TransactionName).HasMaxLength(100);
        });

        modelBuilder.Entity<TransferHistory>(entity =>
        {
            entity.HasKey(e => e.TransferID).HasName("PK__Transfer__95490171C58AB1F0");

            entity.ToTable("TransferHistory");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.TransferDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.TransferHistories)
                .HasForeignKey(d => d.CreatedByUserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TransferH__Creat__534D60F1");

            entity.HasOne(d => d.FromClient).WithMany(p => p.TransferHistoryFromClients)
                .HasForeignKey(d => d.FromClientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TransferH__FromC__5165187F");

            entity.HasOne(d => d.ToClient).WithMany(p => p.TransferHistoryToClients)
                .HasForeignKey(d => d.ToClientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TransferH__ToCli__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK__Users__1788CCAC2138071D");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F284568BA82B5A").IsUnique();

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__EmployeeI__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
