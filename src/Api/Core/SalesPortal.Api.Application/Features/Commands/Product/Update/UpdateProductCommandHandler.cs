using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Common.Infrastructure.Exceptions;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Commands.Product.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var query = productRepository.AsQueryable();

        query = query.Include(p => p.SalesUnits)
                .ThenInclude(P => P.Envanter);

       var dbproduct =await query.Where(p => p.SalesUnits.Any(p => p.Envanter.CompanyId == request.CompanyId)).FirstOrDefaultAsync();

        if (dbproduct is null)
            throw new DatabaseValidationException("Product not found");
         
        dbproduct.CreatedDate = DateTime.Now;
        dbproduct.Description = request.Description;
        dbproduct.Name = request.Name;
        dbproduct.Price = request.Price;
        dbproduct.SalesUnits = mapper.Map<List<Domain.Models.SalesUnit>>(request.SalesUnits);
        dbproduct.CategoryId = request.CategoryId;

        var updated = await productRepository.UpdateAsync(dbproduct);
        if(updated > 0)
        {
            return true;
        }
        return false;
    }
}
