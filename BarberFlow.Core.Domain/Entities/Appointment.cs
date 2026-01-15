namespace BarberFlow.Core.Domain.Entities;

public class Appointment : BaseEntity
{
    public Guid BarbershopId { get; set; }
    public Barbershop Barbershop { get; set; } = null!;
    public Guid ServiceId { get; set; }
    public BarbershopService Service { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public AppointmentStatus Status { get; set; }
}
