using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;

namespace SalesPortal.Api.Application.Features.Commands.Product.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
       var result =  await productRepository.DeleteAsync(request.ProductId);

        if(result>0)
            return true;
        return false;   
       
    }
}
