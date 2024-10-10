using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Domain.UserAgg;

namespace OA.Infrastructure.EFCore.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Phone);
            builder.Property(x => x.Email);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.DateCreated);
        }
    }
}
