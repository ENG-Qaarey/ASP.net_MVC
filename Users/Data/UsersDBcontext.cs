using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users.Data
{
    public class UsersDBcontext : DbContext
    {
        public UsersDBcontext(DbContextOptions<UsersDBcontext> options)
            : base(options)
        {
        }

        public DbSet<UsersModel> Users { get; set; }
        public DbSet<StudentsModel> Students { get; set; }
        public DbSet<TeachersModel> Teachers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
