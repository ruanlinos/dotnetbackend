using Microsoft.EntityFrameworkCore;

namespace dotnetapi.Model.Context {
    public class MySQLContext : DbContext {
        public MySQLContext (DbContextOptions<MySQLContext> options) : base (options) { }

        public DbSet<Person> persons { get; set; }
    }
}