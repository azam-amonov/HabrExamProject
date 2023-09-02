// See https://aka.ms/new-console-template for more information

using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Domain.Entities.User;
using Habr.Service.Domain.Enums;
using Habr.Service.Service.Services;

Console.WriteLine("Test");

var blogService = new BlogPostService();
var blogPost = await blogService.CreateAsync(new BlogPost(644,"Test","title23"));
Console.WriteLine(blogPost);

// var userService = new UserService();
// var user = await userService.CreateAsync(new User(119, "test", "username@example.com","password123@", true, UserRole.User, 23));
// Console.WriteLine(user);