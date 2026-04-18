using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.DAL.Repo.Implementation
{
    public class MedicalRecordRepo : IMedicalRecordRepo
    {
        private readonly ApplicationDbContext _context;
        public MedicalRecordRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSync(MedicalRecord medicalRecord, CancellationToken cancellationToken)
        {
            await _context.MedicalRecords.AddAsync(medicalRecord, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSync(int id, CancellationToken cancellationToken)
        {
            await _context.MedicalRecords.Where(m => m.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(r => r.IsDeleted, true));
        }

        public IQueryable<MedicalRecord> GetAll()
        {
            return _context.MedicalRecords.Where(m => !m.IsDeleted).AsNoTracking();
        }

        public IQueryable<MedicalRecord> GetById(int id)
        {
            return _context.MedicalRecords.Where(m => m.Id == id && !m.IsDeleted).AsNoTracking();
        }

        public Task UpdateSync(MedicalRecord medicalRecord, CancellationToken cancellationToken)
        {
            return _context.MedicalRecords.Where(m => m.Id == medicalRecord.Id).ExecuteUpdateAsync(setter => setter
                .SetProperty(m => m.Diagnosis, medicalRecord.Diagnosis)
                .SetProperty(m => m.Prescription, medicalRecord.Prescription)
                .SetProperty(m => m.Notes, medicalRecord.Notes));
        }
    }
}
