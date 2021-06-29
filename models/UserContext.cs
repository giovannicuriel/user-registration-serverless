using user_registration.models;
using Microsoft.EntityFrameworkCore;

namespace serverless_sample.models
{
    public class UserContext : DbContext
    {
        private DbSet<Person> PersonDb { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySQL("server=172.16.1.2;database=userregistration;user=root;password=root");
    }
}
