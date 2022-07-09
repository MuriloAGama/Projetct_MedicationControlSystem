using System.ComponentModel.DataAnnotations;
using static MedicationControlSystem.src.utils.Utility;

namespace MedicationControlSystem.src.dtos
{
    public class NewMedicationDTO
    {
        [Required, StringLength(30)]
        public string RemedyName { get; set; }

        [Required]
        public RemedyType RemedyType { get; set; }

        [Required, StringLength(50)]
        public string Provider { get; set; }

        [Required, StringLength(150)]
        public string Description { get; set; }


        public NewMedicationDTO(string remedyName, RemedyType remedyType, string provider, string description)
        {
            RemedyName = remedyName;
            RemedyType = remedyType;
            Provider = provider;
            Description = description;
        }
    }

        public class UpdateMedicationDTO
        {
            [Required]
            public int Id { get; set; }

            [Required, StringLength(30)]
            public string RemedyName { get; set; }

            [Required]
            public RemedyType RemedyType { get; set; }

            [Required, StringLength(50)]
            public string Provider { get; set; }

            [Required, StringLength(150)]
            public string Description { get; set; }


            public UpdateMedicationDTO(string remedyName, RemedyType remedyType, string provider, string description)
            {
                RemedyName = remedyName;
                RemedyType = remedyType;
                Provider = provider;
                Description = description;
            }
        }
    }

