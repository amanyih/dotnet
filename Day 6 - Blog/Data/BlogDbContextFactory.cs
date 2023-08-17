using Blog.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Blog.Data;

public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
{
    public BlogDbContext CreateDbContext(string[] args)
    {

        var builder = new DbContextOptionsBuilder<BlogDbContext>();
        var connectionString = "Host=localhost:5432;Database=blog;Username=postgres;Password=postsqlgre;";

        builder.UseNpgsql(connectionString);

        return new BlogDbContext(builder.Options);
    }
}