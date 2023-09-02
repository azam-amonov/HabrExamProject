// See https://aka.ms/new-console-template for more information

using System.Net;
using Habr.Service.DataAccses.Constans;
using Habr.Service.Domain.Entities;
using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Domain.Entities.Comments;
using Habr.Service.Domain.Enums;
using Habr.Service.Service.Services;

Console.WriteLine("Test");
var userServive = new UserService();
await userServive.CreateAsync(new User("John","john@example.com", "john@123", true, UserRole.Administrator,12));
var postService = new BlogPostService();
var commentsService = new CommentService();

// await postService.CreateAsync(new BlogPost(21, "John", "John"));
// await commentsService.CreateAsync(new Comment(1,2,3,"comments"));