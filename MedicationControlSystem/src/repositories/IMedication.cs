using MedicationControlSystem.src.dtos;
using MedicationControlSystem.src.model;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MedicationControlSystem.src.utils.Utility;

namespace MedicationControlSystem.src.repositories
{
    public interface IMedication
    {
        Task NewMedicationAsync(NewMedicationDTO medication);
        Task UpdateMedicationAsync(UpdateMedicationDTO UpdateMedication);
        Task DeleteMedicationAsync(int id);
        Task<MedicationModel> GetMedicationByIdAsync(int id);
        Task<List<MedicationModel>> GetAllMedicationAsync(RemedyType remedyType);
    }
}
