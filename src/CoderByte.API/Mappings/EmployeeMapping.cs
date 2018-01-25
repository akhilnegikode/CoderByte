using CoderByte.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoderByte.API.Mappings
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee", "Deloitte");

            builder.HasKey(model => model.EmployeeNumber);

            builder.Property(model => model.EmployeeNumber)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
