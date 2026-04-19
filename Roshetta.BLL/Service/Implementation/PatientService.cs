using Roshetta.BLL.Contract.Patient;
using Roshetta.DAL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.BLL.Service.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo patientRepo;
        public PatientService(IPatientRepo patientRepo)
        {
            this.patientRepo = patientRepo;
        }

        public async Task<Result> AddAsync(string userId, PatientDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<PatientDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result<PatientDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
