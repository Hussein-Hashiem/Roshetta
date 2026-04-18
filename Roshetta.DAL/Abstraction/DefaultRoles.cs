using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.DAL.Abstraction
{
    public static class DefaultRoles
    {
        public const string Admin = nameof(Admin);
        public const string AdminRoleId = "bb6910c9-086a-4e24-a8bd-9156e87bf5ef";
        public const string AdminRoleConcurrencyStamp = "c9ddd2a8-2087-493e-b641-ad9aba91fb95";

        public const string Doctor = nameof(Doctor);
        public const string DoctorRoleId = "cdfc2f5c-f867-42d9-b634-e9b9eb90d209";
        public const string DoctorRoleConcurrencyStamp = "4f2de27c-5755-4e8d-a31b-338a6e7bd56a";

        public const string Patient = nameof(Patient);
        public const string PatientRoleId = "9626068b-2949-4339-920a-1fbed2e19250";
        public const string PatientRoleConcurrencyStamp = "b1c1b730-cb63-4597-9a36-b895f01dd197";
    }
}
