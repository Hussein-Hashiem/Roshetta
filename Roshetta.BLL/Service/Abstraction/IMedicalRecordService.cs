using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.BLL.Service.Abstraction
{
    public interface IMedicalRecordService
    {
        Task<Result<IEnumerable<MedicalRecordResponseDto>>> GetMedicalRecordsPerPatientAsync(string PatientId, CancellationToken cancellationToken);
        Task<Result<MedicalRecordResponseDto>> GetMedicalRecordByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result> AddAsync(int visitId, string UserId, MedicalRecordRequestDto request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(string UserId, int MedicalRecordId, MedicalRecordRequestDto request, CancellationToken cancellationToken = default);
    }
}
