

using Microsoft.Identity.Client;

namespace Roshetta.DAL.Repo.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _context;

        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient patient, CancellationToken cancellationToken)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _context.Patients.Where(p => p.Id == id && !p.IsDeleted)
                .ExecuteUpdateAsync(setter => setter.SetProperty(p => p.IsDeleted, true));
        }

        public IQueryable<Patient> GetAllAsync()
        {
            return _context.Patients.Where(p => !p.IsDeleted).Include(x => x.User).AsNoTracking();
        }

        public IQueryable<Patient> GetPatientByUserId(string userId)
        {
            return _context.Patients
                .Where(v => v.UserId == userId && !v.IsDeleted)
                .Include(x => x.User)
                .AsNoTracking();
        }
    }
}
