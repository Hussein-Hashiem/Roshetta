namespace Roshetta.DAL.Database.EntitiesConfigurations
{
    public class RolesConfigurations : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData([
                new ApplicationRole
                {
                    Id = DefaultRoles.AdminRoleId,
                    Name = DefaultRoles.Admin,
                    NormalizedName = DefaultRoles.Admin.ToUpper(),
                    ConcurrencyStamp = DefaultRoles.AdminRoleConcurrencyStamp,
                },  
                new ApplicationRole
                {
                    Id = DefaultRoles.DoctorRoleId,
                    Name = DefaultRoles.Doctor,
                    NormalizedName = DefaultRoles.Doctor.ToUpper(),
                    ConcurrencyStamp = DefaultRoles.DoctorRoleConcurrencyStamp,
                },
                new ApplicationRole
                {
                    Id = DefaultRoles.PatientRoleId,
                    Name = DefaultRoles.Patient,
                    NormalizedName = DefaultRoles.Patient.ToUpper(),
                    ConcurrencyStamp = DefaultRoles.PatientRoleConcurrencyStamp
                }
            ]);
        }
    }
}
