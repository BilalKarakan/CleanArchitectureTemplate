using CleanArchitectureTemplate.Domain.Abstractions;
using CleanArchitectureTemplate.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureTemplate.Domain.Entitie;

public class UserRole : BaseEntity
{
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public Role Role { get; set; }
}
