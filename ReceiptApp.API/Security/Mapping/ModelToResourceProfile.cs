using AutoMapper;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Resources.Show;

namespace ReceiptApp.API.Security.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Receipt, ReceiptResource>();
        CreateMap<User, AuthResource>();
    }
}