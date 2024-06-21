using ExcursaoApp.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExcursaoApp.Database.Mappings.Base;

public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(typeof(TEntity).Name);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreatedAtUtc).IsRequired();
    }

    public abstract void MapEntity(EntityTypeBuilder<TEntity> builder);
}