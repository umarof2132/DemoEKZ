using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DeMo
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Аренда> Аренда { get; set; }
        public virtual DbSet<Арендаторы> Арендаторы { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<Список_павильонов> Список_павильонов { get; set; }
        public virtual DbSet<Список_ТЦ> Список_ТЦ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Арендаторы>()
                .HasMany(e => e.Аренда)
                .WithRequired(e => e.Арендаторы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Сотрудники>()
                .HasMany(e => e.Аренда)
                .WithRequired(e => e.Сотрудники)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Список_павильонов>()
                .Property(e => e.стоимость_за_кв_м)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Список_павильонов>()
                .HasMany(e => e.Аренда)
                .WithRequired(e => e.Список_павильонов)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Список_ТЦ>()
                .Property(e => e.стоимость_постройки)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Список_ТЦ>()
                .HasMany(e => e.Список_павильонов)
                .WithRequired(e => e.Список_ТЦ)
                .HasForeignKey(e => e.ТЦ)
                .WillCascadeOnDelete(false);
        }
    }
}
