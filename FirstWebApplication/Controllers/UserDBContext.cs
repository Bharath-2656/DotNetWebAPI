using Microsoft.EntityFrameworkCore;

namespace FirstWebApplication.Controllers
{
    public class UserDBContext: DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }

        //Create Table here
        public DbSet<User> Users { get; set; }
    }
}
