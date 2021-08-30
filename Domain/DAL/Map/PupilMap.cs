using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Core.DAL.Map
{
    public class PupilMap : IEntityTypeConfiguration<Pupil>
    {
        public void Configure(EntityTypeBuilder<Pupil> builder)
        {
            builder.ToTable("pupil");
            builder.Property(e => e.ID).HasColumnName("id");
            builder.Property(e => e.GroupID).HasColumnName("group_id");
            builder.Property(e => e.FirstName).HasColumnName("first_name");
            builder.Property(e => e.LastName).HasColumnName("last_name");
            builder.Property(e => e.PatronymicName).HasColumnName("patronymic_name");
            builder.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            builder.Property(e => e.Parents).HasColumnName("parents");
            builder.Property(e => e.ContactPhones).HasColumnName("contact_phones");
            builder.Property(e => e.IsActive).HasColumnName("is_active");
            builder.Property(e => e.DateCreate).HasColumnName("date_create");
            builder.Property(e => e.DateModify).HasColumnName("date_modify");
        }
    }
}