using Blog.Models;

using Microsoft.EntityFrameworkCore;
namespace Blog.Data;

public class BlogDbContext : DbContext {

    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options){
        Console.WriteLine("BlogDbContext");
    }
    public virtual DbSet<Comment> Comments {get; set;}
    public virtual DbSet<Post> Posts {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity =>{
            entity.HasOne(c => c.Post).WithMany(c => c.Comments).HasForeignKey(x => x.PostId);
        });
    }
}