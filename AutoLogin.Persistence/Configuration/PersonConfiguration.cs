using AutoLogin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoLogin.Persistence.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("persons");
        }
    }
}
