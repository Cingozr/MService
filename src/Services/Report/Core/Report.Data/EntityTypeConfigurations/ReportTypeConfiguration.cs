using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.Data.Entities;

namespace Report.Data.EntityTypeConfigurations
{
    public class ReportTypeConfiguration : IEntityTypeConfiguration<Reports>
    {
        public void Configure(EntityTypeBuilder<Reports> builder)
        {
            builder.HasKey(x => x.UUID);
        }
    }
}
