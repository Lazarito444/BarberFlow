namespace BarberFlow.Core.Domain.Entities;

public class BarbershopImage : BaseEntity
{
    public Guid BarbershopId { get; set; }
    public Barbershop Barbershop { get; set; } = null!;
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsPrimary { get; set; }
}
