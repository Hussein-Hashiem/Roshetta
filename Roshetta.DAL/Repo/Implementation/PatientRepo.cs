namespace Roshetta.DAL.Repo.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _context;

        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Patient> GetPatientByUserId(string userId)
        {
            return _context.Patients
                .Where(v => v.UserId == userId && !v.IsDeleted)
                .AsNoTracking();
        }
    }
}
