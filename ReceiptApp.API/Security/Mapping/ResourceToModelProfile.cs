using AutoMapper;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Services.Communication.Request;
using ReceiptApp.API.Security.Resources.Create;
using ReceiptApp.API.Security.Resources.Update;

namespace ReceiptApp.API.Security.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<CreateReceiptResource, Receipt>();
        CreateMap<UpdateReceiptResource, Receipt>();
        CreateMap<RegisterRequest, User>();
        //CreateMap<AuthRe, User>();
    }
}