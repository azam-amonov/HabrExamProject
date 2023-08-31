// See https://aka.ms/new-console-template for more information

using Habr.Service.Domain.Entities.User;
using Habr.Service.Domain.Enums;
using Habr.Service.Service.Services;

Console.WriteLine("Test");
var testUserSeervice = new UserService();

// var result = 
//                 testUserSeervice.CreateAsync(new User(2, DateTime.Now, "testuser", "tes233@gmail.com", "psswprd@123",false, UserRole.User, 10)); 
// var result = 
//                 testUserSeervice.UpdateAsync(new User(2, DateTime.Now, "Anna Cabanna", "Cabanna233@gmail.com", "psswprd@123",false, UserRole.Administrator, 15));
var result = testUserSeervice.DeleteByIdAsync(2);

Console.WriteLine($"Status code: {result.Result.StatusCode}\n" +
                  $"Message: {result.Result.Message}\n" +
                  $"Data: {result.Result.Data}");