using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiIdentity.Identity
{
  public class AppIdentityContext:IdentityDbContext<AppUser,AppRole,string>
  {

    public AppIdentityContext(DbContextOptions<AppIdentityContext> opt):base(opt) 
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<AppUser>().ToTable("Users");
      builder.Entity<AppRole>().ToTable("Roles");
      builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
      builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims"); // user tanımı yetkiler.
      builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims"); // role tanımlı yetkiler.
      builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins"); // login geçmişi
      builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens"); // email,parola reset token key. generate edilen kodlar bu tabloda tutulur.

      
    }
  }
}
