using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebNews.Infrastructure.IdentityContext;

public class IdentityContext : IdentityDbContext<IdentityUser>
{
     public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {       
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
