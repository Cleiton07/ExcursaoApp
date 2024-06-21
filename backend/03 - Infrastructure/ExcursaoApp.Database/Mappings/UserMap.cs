using ExcursaoApp.Database.Mappings.Base;
using ExcursaoApp.Domain.Entities.User;
using ExcursaoApp.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExcursaoApp.Database.Mappings;

public class UserMap : EntityMap<UserEntity>
{
    public override void MapEntity(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Property(x => x.Email).HasMaxLength(UserEntity.EmailMaxLength).IsRequired();
        builder.Property(x => x.EncryptedPassword).IsRequired();
        builder.Property(x => x.FullName).HasMaxLength(UserEntity.FullNameMaxLength).IsRequired();
        builder.Property(x => x.PhoneNumber).HasMaxLength(UserEntity.PhoneNumberMaxLength).IsRequired();
        builder.Property(x => x.Profile).HasMaxLength(50).HasConversion(new EnumToStringConverter<UserProfile>()).IsRequired();
    }
}