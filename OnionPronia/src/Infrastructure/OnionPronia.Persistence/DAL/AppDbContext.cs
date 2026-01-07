using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Domain.Entities;
using OnionPronia.Persistence.Configurations;
using OnionPronia.Persistence.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistence.DAL
{
    internal class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyAllQueryFilters();

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            _setDateTime();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void _setDateTime()
        {
            var datas = ChangeTracker.Entries<BaseAccountableEntity>();
            foreach (var entry in datas)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        var isDeleteChanged = entry.OriginalValues.GetValue<bool>(nameof(Category.IsDeleted))
                            != entry.CurrentValues.GetValue<bool>(nameof(Category.IsDeleted));
                        if (!isDeleteChanged)
                        {
                            entry.Entity.UpdatedAt = DateTime.UtcNow;
                        }

                        break;

                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                }
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }



    }
}
