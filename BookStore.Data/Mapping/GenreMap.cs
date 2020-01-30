using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Mapping
{
    public class GenreMap : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<GenreEntity> builder)
        {
            builder.ToTable("Genre");

            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
