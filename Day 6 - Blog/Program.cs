// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog;

var context = new BlogDbContextFactory().CreateDbContext(args);

var blogApp = new BlogApp(context);

blogApp.Run();