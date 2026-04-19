namespace Roshetta.DAL.Database.EntitiesConfigurations
{
    public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(x => x.Price)
                .HasPrecision(10, 2);
        }
    }
}
