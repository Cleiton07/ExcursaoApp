using ExcursaoApp.Domain.Entities.User;
using ExcursaoApp.Domain.Enums;
using ExcursaoApp.Persistence.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExcursaoApp.Persistence.Mappings;

public class UserMap : EntityMap<UserEntity>
{
    protected override string TableName => "Users";

    public override void MapEntity(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Property(x => x.Email).HasMaxLength(UserEntity.EmailMaxLength).IsRequired();
        builder.Property(x => x.EncryptedPassword).IsRequired();
        builder.Property(x => x.FullName).HasMaxLength(UserEntity.FullNameMaxLength).IsRequired();
        builder.Property(x => x.PhoneNumber).HasMaxLength(UserEntity.PhoneNumberMaxLength).IsRequired();
        builder.Property(x => x.Profile).HasMaxLength(50).HasConversion(new EnumToStringConverter<UserProfile>()).IsRequired();

        builder.HasIndex(x => x.Email).IsUnique();
    }
}