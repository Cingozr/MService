using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Data.EntityTypeConfigurations
{
    public class ContactInformationTypeConfiguration : IEntityTypeConfiguration<ContactInformations>
    {
        public void Configure(EntityTypeBuilder<ContactInformations> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Contact.ContactInformation");
        }
    }
}
