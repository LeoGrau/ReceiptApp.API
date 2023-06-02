using AutoMapper;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Resources.Show;

namespace ReceiptApp.API.Security.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Receipt, ReceiptResource>()
            .ForMember(resource => resource.DocumentType, expression => 
                expression.MapFrom(receipt => receipt.DocumentType.ToString()))
            .ForMember(resource => resource.Currency, expression => 
                expression.MapFrom(receipt => receipt.Currency.ToString()));
        
        CreateMap<User, AuthResource>();
    }
}