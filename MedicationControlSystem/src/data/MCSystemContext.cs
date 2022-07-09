
using MedicationControlSystem.src.model;
using Microsoft.EntityFrameworkCore;

namespace MedicationControlSystem.src.data
{
    public class MCSystemContext : DbContext
    {
        public DbSet<MedicationModel> Medication { get; set; }
        public DbSet<PatientModel> Patient { get; set; }

        public MCSystemContext(DbContextOptions<MCSystemContext> opt) : base(opt)
        {

        }
    }
}
