using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.BLL.Errors
{
    public static class MedicalRecordErrors
    {
        public static Error NotFound
            = new Error("MedicalRecord.NotFound", "MedicalRecord not found", ErrorType.NotFound);
        public static Error AlreadyExists
            = new Error("MedicalRecord.AlreadyExists", "MedicalRecord Already Exists", ErrorType.BadRequest);
        // Conflict??
    }
}
