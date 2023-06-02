using System.ComponentModel.DataAnnotations;

namespace ReceiptApp.API.Security.Domain.Services.Communication.Request;

public class AuthRequest
{
   [Required] public string? Username { get; set; }
   [Required] public string? Password { get; set; }
}