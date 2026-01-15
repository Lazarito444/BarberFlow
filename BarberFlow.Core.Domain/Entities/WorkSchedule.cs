namespace BarberFlow.Core.Domain.Entities;

public class WorkSchedule : BaseEntity
{
    public Guid BarbershopId { get; set; }
    public Barbershop Barbershop { get; set; } = null!;
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public bool IsActive { get; set; }
}
