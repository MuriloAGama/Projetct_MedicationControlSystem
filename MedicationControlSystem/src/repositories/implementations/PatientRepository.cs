using MedicationControlSystem.src.data;
using MedicationControlSystem.src.dtos;
using MedicationControlSystem.src.model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationControlSystem.src.repositories.implementations
{
    public class PatientRepository : IPatient
    {

        #region Attribute

        private readonly MCSystemContext _context;

        #endregion

        #region Constructor

        public PatientRepository(MCSystemContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods
        public async Task DeletePatientAsync(int id)
        {
            _context.Patient.Remove(await GetPatientByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<PatientModel>> GetAllPatientsAsync(string name)
        {
            return await _context.Patient
                .Where(p => p.Name==name)
                .ToListAsync();
        }

        public async Task<PatientModel> GetPatientByIdAsync(int id)
        {
            return await _context.Patient.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task NewPatientAsync(NewPatientDTO patient)
        {
            await _context.Patient.AddAsync(new PatientModel
            {
                Name = patient.Name,
                Age = patient.Age,
                CPF = patient.CPF,
                Address = patient.Address,
                Telephone = patient.Telephone,
                Symptoms = patient.Symptoms,
            });
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatientAsync(UpdatePatientDTO patient)
        {
            PatientModel existingPatient = await GetPatientByIdAsync(patient.Id);
            existingPatient.Name = patient.Name;
            existingPatient.Age = patient.Age;
            existingPatient.CPF = patient.CPF;
            existingPatient.Address = patient.Address;
            existingPatient.Telephone = patient.Telephone;
            existingPatient.Symptoms = patient.Symptoms;
            _context.Patient.Update(existingPatient);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
