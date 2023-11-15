namespace ClinicSystemWebAPI.Models.DTO
{
    public class AppointmentDTOPost
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public string Status { get; set; }

        public int PatientId { get; set; }


    }
}
