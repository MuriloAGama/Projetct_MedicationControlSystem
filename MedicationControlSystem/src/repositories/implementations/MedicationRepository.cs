using MedicationControlSystem.src.data;
using MedicationControlSystem.src.dtos;
using MedicationControlSystem.src.model;
using MedicationControlSystem.src.utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MedicationControlSystem.src.utils.Utility;

namespace MedicationControlSystem.src.repositories.implementations
{
    public class MedicationRepository : IMedication
    {

        #region Attribute

        private readonly MCSystemContext _context;

        #endregion

        #region Constructor
        public MedicationRepository(MCSystemContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task DeleteMedicationAsync(int id)
        {
            _context.Medication.Remove(await GetMedicationByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<MedicationModel>> GetAllMedicationAsync(RemedyType remedyType)
        {
         switch (remedyType)
            {
                case RemedyType.Default:
                    return await _context.Medication
                        .ToListAsync();

                case RemedyType.Reference:
                    return await _context.Medication
                        .ToListAsync();

                case RemedyType.Generics:
                    return await _context.Medication
                        .ToListAsync();

                case RemedyType.Similar:
                    return await _context.Medication
                        .ToListAsync();

                        default:
                    return await _context.Medication
                        .ToListAsync();

            }   
        }

        public async Task<MedicationModel> GetMedicationByIdAsync(int id)
        {
            return await _context.Medication.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task NewMedicationAsync(NewMedicationDTO medication)
        {
            await _context.Medication.AddAsync(new MedicationModel
            {
                RemedyName = medication.RemedyName,
                RemedyType = medication.RemedyType,
                Provider = medication.Provider,
                Description = medication.Description
                
                
            });
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMedicationAsync(UpdateMedicationDTO UpdateMedication)
        {
            MedicationModel MedicationExistent = await GetMedicationByIdAsync(UpdateMedication.Id);
            MedicationExistent.RemedyName = UpdateMedication.RemedyName;
            MedicationExistent.RemedyType = UpdateMedication.RemedyType;
            MedicationExistent.Provider = UpdateMedication.Provider;
            MedicationExistent.Description = UpdateMedication.Description;
            _context.Medication.Update(MedicationExistent);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
