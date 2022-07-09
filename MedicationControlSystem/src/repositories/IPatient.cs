using MedicationControlSystem.src.dtos;
using MedicationControlSystem.src.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationControlSystem.src.repositories
{
    public interface IPatient
    {
        Task NewPatientAsync(NewPatientDTO patient);
        Task UpdatePatientAsync(UpdatePatientDTO UpdatePatient);
        Task DeletePatientAsync(int id);
        Task<PatientModel> GetPatientByIdAsync(int id);
        Task<List<PatientModel>> GetAllPatientsAsync(string name);
    }
}
