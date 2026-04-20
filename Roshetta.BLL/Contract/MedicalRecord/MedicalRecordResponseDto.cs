using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.BLL.Contract.MedicalRecord
{
    public record MedicalRecordResponseDto
    (
        int id,
        string Diagnosis,
        string Notes,
        string Prescription
    );
}
