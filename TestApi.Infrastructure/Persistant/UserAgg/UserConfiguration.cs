using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApi.Domain;

namespace TestApi.Infrastructure.Persistant.UserAgg;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "user");

        builder.Property(b => b.Name)
            .IsRequired()
           .HasMaxLength(80);

        builder.Property(b => b.Password)
            .IsRequired()
            .HasMaxLength(50);

        builder.OwnsMany(a => a.UserTokens, option =>
        {
            option.ToTable("Tokens", "user");
            option.HasKey(a => a.Id);

            option.Property(a => a.HashedJwtToken)
                 .IsRequired().HasMaxLength(250);
        });
    }
}