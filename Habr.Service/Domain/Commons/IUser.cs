using Habr.Service.Domain.Enums;

namespace Habr.Service.Domain.Commons;

public interface IUser
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public UserRole Role { get; set; }
}