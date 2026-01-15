namespace BarberFlow.Core.Domain.Entities;

public class ScheduleException : BaseEntity
{
    public Guid BarbershopId { get; set; }
    public Barbershop Barbershop { get; set; } = null!;
    public DateOnly Date { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
    public bool IsClosed { get; set; }
    public string? Reason { get; set; } = string.Empty;
}
