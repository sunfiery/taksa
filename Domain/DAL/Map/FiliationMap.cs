using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Core.DAL.Map
{
    public class FiliationMap : IEntityTypeConfiguration<Filiation>
    {
        public void Configure(EntityTypeBuilder<Filiation> builder)
        {
            builder.ToTable("filiation");
            builder.Property(e => e.ID).HasColumnName("id");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Address).HasColumnName("address");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.DateCreate).HasColumnName("date_create");
            builder.Property(e => e.DateModify).HasColumnName("date_modify");
        }
    }
}