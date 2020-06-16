using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APBDKolokwumDrugie.Models
{
    public partial class ProbneKolAPBD2Context : DbContext
    {
        public ProbneKolAPBD2Context()
        {
        }

        public ProbneKolAPBD2Context(DbContextOptions<ProbneKolAPBD2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Candy> Candy { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderCandy> OrderCandy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5G2FL6J\\SQLEXPRESS;Initial Catalog=ProbneKolAPBD2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candy>(entity =>
            {
                entity.HasKey(e => e.IdCandy)
                    .HasName("Candy_pk");

                entity.Property(e => e.IdCandy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("Customer_pk");

                entity.Property(e => e.IdCustomer).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("Employee_pk");

                entity.Property(e => e.IdEmployee).ValueGeneratedNever();

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("Order_pk");

                entity.Property(e => e.IdOrder).ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasColumnName("comments")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerIdCustomer).HasColumnName("Customer_IdCustomer");

                entity.Property(e => e.DateIn)
                    .HasColumnName("dateIn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOut)
                    .HasColumnName("dateOut")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeIdEmployee).HasColumnName("Employee_IdEmployee");

                entity.HasOne(d => d.CustomerIdCustomerNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerIdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Customer");

                entity.HasOne(d => d.EmployeeIdEmployeeNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.EmployeeIdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Employee");
            });

            modelBuilder.Entity<OrderCandy>(entity =>
            {
                entity.HasKey(e => new { e.CandyIdCandy, e.OrderIdOrder })
                    .HasName("Order_Candy_pk");

                entity.ToTable("Order_Candy");

                entity.Property(e => e.CandyIdCandy).HasColumnName("Candy_IdCandy");

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_IdOrder");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasColumnName("comments")
                    .HasMaxLength(300);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.CandyIdCandyNavigation)
                    .WithMany(p => p.OrderCandy)
                    .HasForeignKey(d => d.CandyIdCandy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Candy_Candy");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.OrderCandy)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Candy_Order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
