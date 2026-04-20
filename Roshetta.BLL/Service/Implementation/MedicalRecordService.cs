using Microsoft.CodeAnalysis;
using Roshetta.DAL.Repo.Implementation;
using System.Diagnostics;

namespace Roshetta.BLL.Service.Implementation
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly MedicalRecordRepo _medicalrecordrepo;
        private readonly VisitRepo _visitrepo;
        private readonly PatientRepo _patientRepo;
        public MedicalRecordService(MedicalRecordRepo medicalrecordrepo, VisitRepo visitrepo, PatientRepo patientRepo)
        {
            _medicalrecordrepo = medicalrecordrepo;
            _visitrepo = visitrepo;
            _patientRepo = patientRepo;
        }

        public async Task<Result> AddAsync(int visitId, string UserId, MedicalRecordRequestDto request, CancellationToken cancellationToken = default)
        {
            //var md = await _medicalrecordrepo.GetByIdAsync(medicalRecordId, cancellationToken).FirstOrDefaultAsync();
            //if (md != null) return Result.Failure(MedicalRecordErrors.AlreadyExists);
            var visit = _visitrepo.GetById(visitId);
            if (visit == null) return Result.Failure(VisitErrors.NotFound);

            var medicalrecord = new MedicalRecord()
            {
                Diagnosis = request.Diagnosis,
                Prescription = request.Prescription,
                Notes = request.Notes,
                VisitId = visitId,
            };

            await _medicalrecordrepo.AddAsync(medicalrecord, cancellationToken);

            return Result.Success();
        }

        public async Task<Result<MedicalRecordResponseDto>> GetMedicalRecordByIdAsync(int id, CancellationToken cancellationToken)
        {
            var medicalrecord = await _medicalrecordrepo
                .GetByIdAsync(id, cancellationToken)
                .Select(m => new MedicalRecordResponseDto(
                    m.Id,
                    m.Diagnosis,
                    m.Notes,
                    m.Prescription
                ))
                .FirstOrDefaultAsync();

            if (medicalrecord == null) return Result.Failure<MedicalRecordResponseDto>(MedicalRecordErrors.NotFound);

            return Result.Success<MedicalRecordResponseDto>(medicalrecord);
        }

        public async Task<Result<IEnumerable<MedicalRecordResponseDto>>> GetMedicalRecordsPerPatientAsync(string PatientId, CancellationToken cancellationToken)
        {
            var patient = await _patientRepo
                .GetPatientByUserId(PatientId, cancellationToken)
                .FirstOrDefaultAsync();
            if (patient == null) return Result.Failure<IEnumerable<MedicalRecordResponseDto>>(PatientErrors.NotFound); 
            var medicalrecords = await _medicalrecordrepo
                .GetAllPerPatientAsync(PatientId, cancellationToken)
                .Select(m => new MedicalRecordResponseDto(
                        m.Id,
                        m.Diagnosis,
                        m.Notes,
                        m.Prescription
                    ))
                .ToListAsync();

            return Result.Success<IEnumerable<MedicalRecordResponseDto>>(medicalrecords);
        }

        public async Task<Result> UpdateAsync(string UsesrId, int MedicalRecordId, MedicalRecordRequestDto request, CancellationToken cancellationToken = default)
        {
            var medicalrecord = await _medicalrecordrepo
                .GetByIdAsync(MedicalRecordId)
                .FirstOrDefaultAsync();

            if (medicalrecord == null) return Result.Failure(MedicalRecordErrors.NotFound);

            medicalrecord.Prescription = request.Prescription;
            medicalrecord.Notes = request.Notes;
            medicalrecord.Diagnosis = request.Diagnosis;

            await _medicalrecordrepo.UpdateAsync(medicalrecord, cancellationToken);

            return Result.Success();
        }
    }
}
