// See https://aka.ms/new-console-template for more information

using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Service.Services;

Console.WriteLine("Test");

var blogService = new BlogPostService();
var blogPost = await blogService.CreateAsync(new BlogPost(2,"Test","title23",new BlogPostCategory(3)));
Console.WriteLine(blogPost);