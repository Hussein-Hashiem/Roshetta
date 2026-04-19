namespace Roshetta.DAL.Database.EntitiesConfigurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department { Id = 1, Name = "الطب الباطني" },
                new Department { Id = 2, Name = "طب الأطفال" },
                new Department { Id = 3, Name = "الجراحة العامة" },
                new Department { Id = 4, Name = "طب القلب والأوعية الدموية" },
                new Department { Id = 5, Name = "طب العظام" },
                new Department { Id = 6, Name = "طب النساء والتوليد" },
                new Department { Id = 7, Name = "الأمراض الجلدية" },
                new Department { Id = 8, Name = "طب الأنف والأذن والحنجرة" },
                new Department { Id = 9, Name = "طب العيون" },
                new Department { Id = 10, Name = "المخ والأعصاب" },
                new Department { Id = 11, Name = "طب الأسنان" },
                new Department { Id = 12, Name = "طب الأورام" },
                new Department { Id = 13, Name = "طب المسالك البولية" },
                new Department { Id = 14, Name = "طب النفسية والعصبية" },
                new Department { Id = 15, Name = "طب التخدير" },
                new Department { Id = 16, Name = "طب الطوارئ" },
                new Department { Id = 17, Name = "طب الأسرة" },
                new Department { Id = 18, Name = "الأشعة والتصوير الطبي" },
                new Department { Id = 19, Name = "الطب الطبيعي وإعادة التأهيل" },
                new Department { Id = 20, Name = "أمراض الدم" }
            );
        }
    }
}
