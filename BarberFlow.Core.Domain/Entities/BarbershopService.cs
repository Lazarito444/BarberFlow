namespace BarberFlow.Core.Domain.Entities;

public class BarbershopService : BaseEntity
{
    public Guid BarbershopId { get; set; }
    public Barbershop Barbershop { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DurationInMinutes { get; set; }
    public bool IsActive { get; set; }
}
