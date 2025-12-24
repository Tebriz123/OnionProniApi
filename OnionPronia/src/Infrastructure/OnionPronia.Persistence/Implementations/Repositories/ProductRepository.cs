using OnionPronia.Appilication.Interfaces.Repositories;
using OnionPronia.Domain.Entities;
using OnionPronia.Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistence.Implementations.Repositories
{
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context) : base(context) { }

    }
}
