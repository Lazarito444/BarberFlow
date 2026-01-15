using BarberFlow.Core.Domain.Entities;
using BarberFlow.Infrastructure.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberFlow.Infrastructure.Data.EntityConfigurations;

internal class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedBy)
            .HasDefaultValue(Guid.Empty);

        builder.Property(e => e.UpdatedBy)
            .HasDefaultValue(Guid.Empty);

        builder.HasQueryFilter(AppQueryFilters.SoftDeleteFilter, e => !e.IsDeleted);
    }
}
