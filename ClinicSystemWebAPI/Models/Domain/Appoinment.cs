using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicSystemWebAPI.Models.Domain
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Status { get; set; }

        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
    }
}
