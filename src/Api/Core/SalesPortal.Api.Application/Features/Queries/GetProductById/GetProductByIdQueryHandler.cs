using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Common.Infrastructure.Exceptions;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, CreateProductCommand>
{
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;

    public GetProductByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }

    public async Task<CreateProductCommand> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var query = productRepository.AsQueryable();

        query = query.Include(x => x.SalesUnits)
                     .ThenInclude(x => x.Envanter);

        query = query.Where(x => x.SalesUnits.Any(x => x.Envanter.CompanyId == request.CompanyId));

        var product =await query.FirstOrDefaultAsync(x=> x.Id == request.ProductId);

        if (product == null)
            throw new DatabaseValidationException("You dont have any item to see");

        var data = mapper.Map<CreateProductCommand>(product);

        return data;
    }
}
