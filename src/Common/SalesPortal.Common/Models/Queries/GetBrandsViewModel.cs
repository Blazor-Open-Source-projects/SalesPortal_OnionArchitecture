using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPortal.Common.Models.Queries
{
    public class GetBrandsViewModel
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
    }
}
