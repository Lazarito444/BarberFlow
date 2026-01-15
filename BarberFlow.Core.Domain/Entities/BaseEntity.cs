namespace BarberFlow.Core.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAtUtc { get; set; }
    public Guid UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}
