using BarberFlow.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberFlow.Infrastructure.Data.EntityConfigurations;

internal class BarbershopConfig : BaseEntityConfig<Barbershop>
{
    public override void Configure(EntityTypeBuilder<Barbershop> builder)
    {
        base.Configure(builder);


    }
}
