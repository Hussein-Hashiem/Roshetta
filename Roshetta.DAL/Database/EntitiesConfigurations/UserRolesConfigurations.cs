using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.DAL.Database.EntitiesConfigurations
{
    public class UserRolesConfigurations : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                UserId = DefaultUsers.AdminId,
                RoleId = DefaultRoles.AdminRoleId,
            });
        }
    }
}
