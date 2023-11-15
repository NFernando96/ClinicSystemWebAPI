﻿using System.Text.Json.Serialization;

namespace ClinicSystemWebAPI.Models.Domain
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public ICollection<Appointment>? Appoinments { get; set; }
    }
}
