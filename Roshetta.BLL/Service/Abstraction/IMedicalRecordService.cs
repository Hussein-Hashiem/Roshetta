using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.BLL.Service.Abstraction
{
    public interface IMedicalRecordService
    {
        Task<Result<IEnumerable<MedicalRecordResponseDto>>> GetMedicalRecordsPerPatientAsync(string PatientId, CancellationToken cancellationToken);
        Task<Result<MedicalRecordResponseDto>> GetMedicalRecordByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result> AddAsync(int visitid, MedicalRecordRequestDto request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(int MedicalRecordId, MedicalRecordRequestDto request, CancellationToken cancellationToken = default);
    }
}
