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

        public IQueryable<Doctor> GetDoctorByUserId(string userId, CancellationToken cancellationToken = default)
        {
            return _context.Doctors
                .AsNoTracking()
                .Where(v => v.UserId == userId && !v.IsDeleted);
        }

        public async Task UpdateAsync(string userId, Doctor request)
        {
            await _context.Doctors
                .Where(x => x.UserId == userId)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(x => x.Inof, request.Inof)
                .SetProperty(x => x.Department, request.Department)
                .SetProperty(x => x.Location, request.Location)
                .SetProperty(x => x.Price, request.Price)
                );

            await _context.Users
                .Where(x => x.Id == userId)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(x => x.PhoneNumber, request.User.PhoneNumber)
                .SetProperty(x => x.Name, request.User.Name)
                .SetProperty(x => x.DateOfBirth, request.User.DateOfBirth)
                );
        }
    }
}
