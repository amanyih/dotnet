using Blog.Data;
using Microsoft.EntityFrameworkCore;

namespace UnitTest;

public class ContextBuilder{
    public static BlogDbContext BuildInMemoryContext(){
        var options = new DbContextOptionsBuilder<BlogDbContext>()
            .UseInMemoryDatabase(databaseName: "Blog")
            .Options;
        var context = new BlogDbContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }
}