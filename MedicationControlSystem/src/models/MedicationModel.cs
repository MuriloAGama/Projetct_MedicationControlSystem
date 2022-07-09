using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MedicationControlSystem.src.utils.Utility;

namespace MedicationControlSystem.src.model
{

    [Table("tb_medication")]
    public class MedicationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string RemedyName { get; set; }

        [Required]
        public RemedyType RemedyType { get; set; }

        [Required, StringLength(50)]
        public string Provider { get; set; }

        [Required, StringLength(150)]
        public string Description { get; set; }

        [ForeignKey("FK_Patient")]
        public PatientModel Patient { get; set; }

        public MedicationModel() { }

        public MedicationModel(string remedyName, RemedyType remedyType, string provider, string description)
        {
            RemedyName = remedyName;
            RemedyType = remedyType;
            Provider = provider;
            Description = description;
        }
    }
}
