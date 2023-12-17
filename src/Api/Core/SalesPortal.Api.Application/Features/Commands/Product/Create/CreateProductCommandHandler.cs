using AutoMapper;
using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Commands.Product.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;

    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var dbEntry = mapper.Map<SalesProduct>(request);
        await productRepository.AddAsync(dbEntry);
        return dbEntry.Id;
    }
}
