using System.ComponentModel.DataAnnotations.Schema;

namespace MoscowApi.Database.Models;

[Table("users")]
public class User
{
    public Guid Uid { get; init; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Salt { get; set; } = null!;
}