// See https://aka.ms/new-console-template for more information

using Habr.Service.Domain.Entities.User;
using Habr.Service.Domain.Enums;
using Habr.Service.Service.Helpers;
using Habr.Service.Service.Services;

Console.WriteLine("Test");
var testUserSeervice = new UserService();

// var result = 
//                 testUserSeervice.CreateAsync(new User(88, DateTime.Now, "Azizbek", "azizbek@gmail.com", "azizbek@123",true, UserRole.Moderator, 10)); 
// var result = 
//                 testUserSeervice.UpdateAsync(new User(2, DateTime.Now, "Anna Cabanna", "Cabanna233@gmail.com", "psswprd@123",false, UserRole.Administrator, 15));
// var result = testUserSeervice.DeleteByIdAsync(2);
// var result = testUserSeervice.GetByIdAsync(1);

// Console.WriteLine(result.Result);

var hashed = PasswordHasher.Encrypt("password123");
var hashed2 = PasswordHasher.Encrypt("password123");
Console.WriteLine(hashed);
Console.WriteLine(hashed2);
Console.WriteLine(PasswordHasher.Verify(hashed, "password123"));
Console.WriteLine(PasswordHasher.Verify(hashed2, "password123"));
