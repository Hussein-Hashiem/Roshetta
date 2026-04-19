namespace Roshetta.DAL.Database.EntitiesConfigurations
{
    public class DoctorScheduleConfigurations : IEntityTypeConfiguration<DoctorSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
        {
            builder.HasIndex(d => new { d.DoctorId, d.Day })
                .IsUnique();

            builder.Property(x => x.Day)
                .HasConversion<string>();
        }
    }
}
