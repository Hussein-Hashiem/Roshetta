using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.BLL.Contract.Patient
{
    public class PatientDto
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        //public string Image { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
    }
}
