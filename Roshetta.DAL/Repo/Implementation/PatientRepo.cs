namespace Roshetta.DAL.Repo.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _context;

        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(string userId, CancellationToken cancellationToken = default)
        {
            await _context.Patients.Where(p => p.UserId == userId && !p.IsDeleted)
                .ExecuteUpdateAsync(setter => setter.SetProperty(p => p.IsDeleted, true));
        }

        public IQueryable<Patient> GetAll(CancellationToken cancellationToken = default)
        {
            return _context.Patients
                .AsNoTracking()
                .Where(p => !p.IsDeleted)
                .Include(x => x.User);
        }

        public IQueryable<Patient> GetPatientByUserId(string userId, CancellationToken cancellationToken = default)
        {
            return _context.Patients
                .AsNoTracking()
                .Where(v => v.UserId == userId && !v.IsDeleted);
        }
        public async Task UpdateAsync(string userId, Patient patient, CancellationToken cancellationToken = default)
        {
            await _context.Users
                .Where(p => p.Id == userId && !p.IsDeleted)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(p => p.Name, patient.User.Name)
                .SetProperty(p => p.PhoneNumber, patient.User.PhoneNumber)
                .SetProperty(p => p.DateOfBirth, patient.User.DateOfBirth)
                .SetProperty(p => p.Gender, patient.User.Gender)
                );
        }
    }
}
