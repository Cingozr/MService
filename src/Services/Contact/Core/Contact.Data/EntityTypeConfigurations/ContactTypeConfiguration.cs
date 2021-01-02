using Contact.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Contact.Data.EntityTypeConfigurations
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> builder)
        {
            builder.HasKey(x => x.UUID);
        }
    }
}
