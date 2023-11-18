using Aps.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Aps.Api.ContextApp;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Information> Information { get; set; }
}
