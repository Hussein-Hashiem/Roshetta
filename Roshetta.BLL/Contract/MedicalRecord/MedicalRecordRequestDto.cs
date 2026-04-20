using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.BLL.Contract.MedicalRecord
{
    public record MedicalRecordRequestDto
    (
        int Id,
        int VisitId,
        string Diagnosis,
        string Notes,
        string Prescription
    );
}
