using ExcursaoApp.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExcursaoApp.Persistence.Mappings.Base;

public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    protected abstract string TableName { get; }

    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(TableName);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreatedAtUtc).IsRequired();
        MapEntity(builder);
    }

    public abstract void MapEntity(EntityTypeBuilder<TEntity> builder);
}