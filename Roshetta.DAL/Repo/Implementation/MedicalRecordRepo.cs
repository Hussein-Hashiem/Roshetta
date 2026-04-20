namespace Roshetta.DAL.Repo.Implementation
{
    public class MedicalRecordRepo : IMedicalRecordRepo
    {
        private readonly ApplicationDbContext _context;
        public MedicalRecordRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MedicalRecord medicalRecord, CancellationToken cancellationToken = default)
        {
            await _context.MedicalRecords.AddAsync(medicalRecord, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _context.MedicalRecords
                .Where(m => m.Id == id)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(r => r.IsDeleted, true));
        }

        public IQueryable<MedicalRecord> GetAllPerPatientAsync(int PatientId, CancellationToken cancellationToken = default)
        {
            return _context.MedicalRecords
                .Where(m => !m.IsDeleted && m.Visit.PatientId == PatientId)
                .AsNoTracking();
        }
        /// Shaaban, do some work here
        public IQueryable<MedicalRecord> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.MedicalRecords
                .Where(m => m.Id == id && !m.IsDeleted)
                .AsNoTracking();
        }

        public Task UpdateAsync(MedicalRecord medicalRecord, CancellationToken cancellationToken = default)
        {
            return _context.MedicalRecords
                .Where(m => m.Id == medicalRecord.Id)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(m => m.Diagnosis, medicalRecord.Diagnosis)
                .SetProperty(m => m.Prescription, medicalRecord.Prescription)
                .SetProperty(m => m.Notes, medicalRecord.Notes));
        }
    }
}
