using ClinicSystemWebAPI.Models.Domain;

namespace ClinicSystemWebAPI.Repository
{
    public interface IBulkPatientUploadRepository
    {
        Task AddPatientsAsync(IEnumerable<Patient> patients);

    }
}
