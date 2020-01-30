using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Mapping
{
    public class BookMap : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            // creating table of boof
            builder.ToTable("Book");

            builder.HasKey(bk => bk.Id);
            builder.Property(bk => bk.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(bk => bk.Price)
                .IsRequired();
            builder.Property(bk => bk.Quantity);
        }
    }
}
