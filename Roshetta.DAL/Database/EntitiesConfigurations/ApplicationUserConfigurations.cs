
namespace Roshetta.DAL.Database.EntitiesConfigurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(100);

            builder.Property(x => x.Image)
                .HasMaxLength(256);

            builder.Property(x => x.Gender)
                .HasConversion<string>();

            builder.HasData( new ApplicationUser
            {
                Id = DefaultUsers.AdminId,
                Name = "Roshetta Admin",
                Email = DefaultUsers.AdminEmail,
                NormalizedEmail = DefaultUsers.AdminEmail.ToUpper(),
                UserName = DefaultUsers.AdminEmail,
                NormalizedUserName = DefaultUsers.AdminEmail.ToUpper(),
                SecurityStamp = DefaultUsers.AdminSecurityStamp,
                ConcurrencyStamp = DefaultUsers.AdminConcurrencyStamp,
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAENe4Th1Gfr+BucundJvm/IF49pqZnSmePON6MVYCXVl8wgjKhfdUkGulYOWbehXbPw=="
            });

        }

    }
}
