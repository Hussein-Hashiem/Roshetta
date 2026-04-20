namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IMedicalRecordRepo
    {
        Task AddAsync (MedicalRecord medicalRecord, CancellationToken cancellationToken = default);
        Task UpdateAsync (MedicalRecord medicalRecord, CancellationToken cancellationToken = default);
        Task DeleteAsync (int id, CancellationToken cancellationToken = default);
        IQueryable<MedicalRecord> GetAllPerPatientAsync(string PatientId, CancellationToken cancellationToken = default);
        IQueryable<MedicalRecord> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}