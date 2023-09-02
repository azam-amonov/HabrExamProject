using Habr.Service.Domain.Commons;
using Habr.Service.Domain.Enums;
using Habr.Service.Service.Helpers;

namespace Habr.Service.Domain.Entities.User;

public class User: Auditable, IUser
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public UserRole Role { get; set; }
    public int Rank { get; set; }

    public User() : base()
    {
        
    }

    public User(int id, string fullName, string email, string password, bool isActive, UserRole role) 
                    : base(id)
    {
        FullName = fullName;
        Email = email;
        Password = PasswordHasher.Encrypt(password);
        IsActive = isActive;
        Role = role;
    }

    public override string ToString()
    {
        return $"{Id} {FullName} {Email}";
    }
    
}