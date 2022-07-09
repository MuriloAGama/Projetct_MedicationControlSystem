using MedicationControlSystem.src.dtos;
using System.Threading.Tasks;

namespace MedicationControlSystem.src.services
{
    public interface IAuthentication
    {
        Task CreateUserWithoutDuplicateAsync(NewPatientDTO patient);
    }
}
