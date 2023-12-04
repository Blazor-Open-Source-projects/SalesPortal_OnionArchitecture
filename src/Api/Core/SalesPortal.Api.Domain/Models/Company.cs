using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPortal.Api.Domain.Models;

public class Company : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public string EmailAddress { get; set; }
    public bool   EmailConfirmed { get; set; }
    public string Password { get; set; }


    public virtual ICollection<Envanter> Envanters { get; set; }

}
