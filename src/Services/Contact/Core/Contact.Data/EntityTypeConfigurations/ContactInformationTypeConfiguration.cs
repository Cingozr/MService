using Contact.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.Data.EntityTypeConfigurations
{
    public class ContactInformationTypeConfiguration : IEntityTypeConfiguration<ContactInformations>
    {
        public void Configure(EntityTypeBuilder<ContactInformations> builder)
        {
            builder.HasKey(x => x.Id);
        }

       
    }
}
