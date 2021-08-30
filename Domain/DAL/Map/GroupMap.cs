using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Core.DAL.Map
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("group");
            builder.Property(e => e.ID).HasColumnName("id");
            builder.Property(e => e.FiliationID).HasColumnName("filiation_id");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.DateCreate).HasColumnName("date_create");
            builder.Property(e => e.DateModify).HasColumnName("date_modify");
        }
    }
}