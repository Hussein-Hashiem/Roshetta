namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IMedicalRecordRepo
    {
        Task AddSync (MedicalRecord medicalRecord, CancellationToken cancellationToken);
        Task UpdateSync (MedicalRecord medicalRecord, CancellationToken cancellationToken);
        Task DeleteSync (int id, CancellationToken cancellationToken);
        IQueryable<MedicalRecord> GetAll ();
        IQueryable<MedicalRecord> GetById (int id);
    }
}