using ClinicSystemWebAPI.Data;
using ClinicSystemWebAPI.Models.Domain;

namespace ClinicSystemWebAPI.Repository
{
    public class BulkPatientUploadRepository : IBulkPatientUploadRepository
    {
        private readonly ClinicWebDbContext _context;

        public BulkPatientUploadRepository(ClinicWebDbContext context)
        {
            _context = context;
        }

        public async Task AddPatientsAsync(IEnumerable<Patient> patients)
        {
            if (patients == null)
            {
                throw new ArgumentNullException(nameof(patients), "No patient collection");
            }

            try
            {
                await _context.Patients.AddRangeAsync(patients);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to add patients!");
            }
        }
    }
}
