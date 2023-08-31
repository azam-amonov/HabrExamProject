using Habr.Service.Domain.Commons;
using Habr.Service.Domain.Enums;

namespace Habr.Service.Domain.Entities.User;

public class User: Auditable, IUser
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public UserRole Role { get; set; }
    public int Rank { get; set; }

    public User(int id, DateTime updatedTime, string fullName, string email, string password, bool isActive, UserRole role, int rank) 
                    : base(id, updatedTime)
    {
        FullName = fullName;
        Email = email;
        Password = password;
        IsActive = isActive;
        Role = role;
        Rank = rank;
    }
}