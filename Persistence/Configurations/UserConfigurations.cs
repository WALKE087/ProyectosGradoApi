using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;
internal sealed class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id);
        builder.Property(user => user.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(user => user.Password)
            .IsRequired();
    }
}
