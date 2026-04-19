namespace Roshetta.DAL.Repo.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Doctor> GetDoctorByUserId(string userId)
        {
            return _context.Doctors
                .AsNoTracking()
                .Where(v => v.UserId == userId && !v.IsDeleted);
        }
    }
}
