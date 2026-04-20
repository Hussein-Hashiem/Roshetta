using Roshetta.BLL.Contract.Patient;
using Roshetta.DAL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Roshetta.BLL.Service.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;
        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<Result> DeleteAsync(string UserId, CancellationToken cancellationToken = default)
        {
            var patient = await _patientRepo.GetPatientByUserId(UserId, cancellationToken).FirstOrDefaultAsync();
            if (patient == null) return Result.Failure(UserErrors.NotFouond);

            await _patientRepo.DeleteAsync(UserId, cancellationToken);

            return Result.Success();
        }

        public async Task<Result<IEnumerable<PatientDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var patients = await _patientRepo.GetAll()
                .Select(f => new PatientDto(
                    f.User.Name,
                    f.User.Image,
                    f.User.DateOfBirth,
                    f.User.Gender.ToString()
                )).ToListAsync();
            return Result.Success<IEnumerable<PatientDto>>(patients); ;
        }

        public async Task<Result<PatientDto>> GetByIdAsync(string UserId, CancellationToken cancellationToken = default)
        {
            var patient = await _patientRepo.GetPatientByUserId(UserId)
                .Select(patient => new PatientDto(
                    patient.User.Name,
                    patient.User.PhoneNumber!,
                    patient.User.DateOfBirth,
                    patient.User.Gender.ToString()
                )).FirstOrDefaultAsync();

            if(patient is null)
                Result.Failure<PatientDto>(UserErrors.NotFouond);

            return Result.Success<PatientDto>(patient!);
        }

        public async Task<Result> UpdateAsync(string userId, PatientDto patientDto, CancellationToken cancellationToken = default)
        {
            var patient = new Patient()
            {
                User = new ApplicationUser()
                {
                    Name = patientDto.Name,
                    PhoneNumber = patientDto.PhoneNumber,
                    DateOfBirth = patientDto.DateOfBirth,
                    Gender = (patientDto.Gender.ToUpper() == "FEMALE" ? Gender.Female : Gender.Male)
                }
            };

            await _patientRepo.UpdateAsync(userId, patient, cancellationToken);
            return Result.Success();
        }
    }
}
