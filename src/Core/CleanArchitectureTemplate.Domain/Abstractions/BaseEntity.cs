using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureTemplate.Domain.Abstractions;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        this.Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
