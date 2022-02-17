namespace Inflow.Modules.Customers.Core.Dto;

public class CustomerDetailsDto: CustomerDto
{
    public string Notes { get; set; }
    public string Address { get; set; }
    public IdentityDto IdentityDto { get; set; }

}