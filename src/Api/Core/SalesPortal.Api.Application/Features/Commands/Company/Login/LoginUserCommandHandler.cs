using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Common.Infrastructure;
using SalesPortal.Common.Infrastructure.Exceptions;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesPortal.Api.Application.Features.Commands.Company.Login;

public class LoginCompanyCommandHandler : IRequestHandler<LoginCompanyCommand, LoginCompanyViewModel>
{
    private readonly IConfiguration configuration;
    private readonly ICompanyRepository companyRepository;
    private readonly IMapper mapper;

    public LoginCompanyCommandHandler(IConfiguration configuration, ICompanyRepository companyRepository, IMapper mapper)
    {
        this.configuration = configuration;
        this.companyRepository = companyRepository;
        this.mapper = mapper;
    }

    public async Task<LoginCompanyViewModel> Handle(LoginCompanyCommand request, CancellationToken cancellationToken)
    {
        var dbCompany = await companyRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

        if (dbCompany is null)
            throw new DatabaseValidationException("Company does not Exist!");

        var pass = PasswordEncrypter.EncryptPassord(request.Password);

        if (pass != dbCompany.Password)
            throw new DatabaseValidationException("Password Is Wrong");
        if (dbCompany.EmailConfirmed)
            throw new DatabaseValidationException("Email Address is not confirmed Yet!");

        var result = mapper.Map<LoginCompanyViewModel>(dbCompany);


        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, dbCompany.Id.ToString()),
            new Claim(ClaimTypes.Email,  dbCompany.EmailAddress),
            new Claim(ClaimTypes.Name, dbCompany.CompanyName),
            new Claim(ClaimTypes.GivenName, dbCompany.FirstName),
            new Claim(ClaimTypes.Surname, dbCompany.LastName),

        };

        result.Token = GenerateToken(claims);
        return result;
    }


    private string GenerateToken(Claim[] claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthConfig:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(10);

        var token = new JwtSecurityToken(claims: claims,
                                         signingCredentials: creds,
                                         expires: expires,
                                         notBefore: DateTime.Now);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
