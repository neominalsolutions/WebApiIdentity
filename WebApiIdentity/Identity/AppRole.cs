using Microsoft.AspNetCore.Identity;

namespace WebApiIdentity.Identity
{
  public class AppRole:IdentityRole
  {
    public string? Description { get; set; }

  }
}
