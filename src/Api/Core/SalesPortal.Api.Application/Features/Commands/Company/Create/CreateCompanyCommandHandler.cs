using AutoMapper;
using MediatR;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Common.Infrastructure;
using SalesPortal.Common.Infrastructure.Exceptions;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Features.Commands.Company.Create;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
{
    private readonly ICompanyRepository companyRepository;
    private readonly IMapper mapper;

    public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        this.companyRepository = companyRepository;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var componyExist = await companyRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

        if (componyExist is not null)
            throw new DatabaseValidationException("User AlreadyExist");

        var dbCompany = mapper.Map<Domain.Models.Company>(request);
        var encPssword = PasswordEncrypter.EncryptPassord(dbCompany.Password);
        dbCompany.Password = encPssword;
        var rows = await companyRepository.AddAsync(dbCompany);
        if (rows > 0)
        {
            return dbCompany.Id;
        }

        return Guid.Empty;

    }
}
