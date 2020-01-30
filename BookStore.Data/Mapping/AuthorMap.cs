using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder.ToTable("Author");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

          
        }
    }
}
