using ChildRecordCareSystem.Areas.Identity.Data;
using ChildRecordCareSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChildRecordCareSystem.Areas.Identity.Data;

public class ChildRecordCareSystemContext : IdentityDbContext<ChildRecordCareSystemUser>
{
    public ChildRecordCareSystemContext(DbContextOptions<ChildRecordCareSystemContext> options)
        : base(options)
    {
    }
    public DbSet<Child> Children { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
