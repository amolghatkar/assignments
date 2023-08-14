using CornerStoneWeb.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CornerStoneWeb.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
