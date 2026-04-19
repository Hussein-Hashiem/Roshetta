namespace Roshetta.DAL.Database.EntitiesConfigurations
{
    public class VisitsConfigurations : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.Property(x => x.Status)
                    .HasConversion<string>();
        }
    }
}