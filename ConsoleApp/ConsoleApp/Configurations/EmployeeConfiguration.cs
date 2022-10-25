using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConsoleApp.Models;

namespace ConsoleApp.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.name).HasMaxLength(100).IsRequired(true);
            builder.Property(note => note.surname).HasMaxLength(100).IsRequired(true);
        }
    }
}
