using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.BLL.Service.Abstraction
{
    public interface IMedicalRecordService
    {
        Task<Result<IEnumerable<MedicalRecordResponseDto>>> GetMedicalRecordsPerPatientAsync(int PatientId, CancellationToken cancellationToken);
        Task<Result<MedicalRecordResponseDto>> GetMedicalRecordByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result> AddAsync(MedicalRecordRequestDto request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(int MedicalRecordId, MedicalRecordRequestDto request, CancellationToken cancellationToken = default);
    }
}
