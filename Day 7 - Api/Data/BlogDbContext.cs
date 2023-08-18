using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>(entity =>{
            entity.HasMany(t => t.Comments)
                .WithOne(t => t.Post)
                .HasForeignKey(t => t.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
    }
}