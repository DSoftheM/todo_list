using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain;

namespace TodoList.DAL.Configurations;

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasDefaultValue("Без заголовка");
        builder.Property(x => x.Description).HasDefaultValue("Без описания");
    }
}