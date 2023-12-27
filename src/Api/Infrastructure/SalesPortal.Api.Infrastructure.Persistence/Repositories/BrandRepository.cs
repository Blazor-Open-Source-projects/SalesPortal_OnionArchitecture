using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Api.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPortal.Api.Infrastructure.Persistence.Repositories
{
    public class BrandRepository : GenericRepository<Brand>,IBrandRepository
    {
        public BrandRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
