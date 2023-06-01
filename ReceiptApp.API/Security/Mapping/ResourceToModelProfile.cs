using AutoMapper;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Resources.Create;

namespace ReceiptApp.API.Security.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<CreateReceiptResource, Receipt>();
    }
}