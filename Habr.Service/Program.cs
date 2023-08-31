// See https://aka.ms/new-console-template for more information

using Habr.Service.Domain.Entities.User;
using Habr.Service.Domain.Enums;
using Habr.Service.Service.Services;

Console.WriteLine("Test");
var testUserSeervice = new UserService();
var result = 
                testUserSeervice.CreateAsync(new User(2, DateTime.Now, "testuser", "tes233@gmail.com", "psswprd@123",false, UserRole.User, 10)); 
Console.WriteLine($"Result: {result.Result}");