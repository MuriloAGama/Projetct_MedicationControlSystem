using System.ComponentModel.DataAnnotations;

namespace MedicationControlSystem.src.dtos
{
    public class NewPatientDTO
    {
        [Required, StringLength(70)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required, StringLength(20)]
        public string CPF { get; set; }

        [Required, StringLength(15)]
        public string Telephone { get; set; }

        [Required, StringLength(70)]
        public string Address { get; set; }

        [StringLength(250)]
        public string Symptoms { get; set; }

        public NewPatientDTO(string name, int age, string cpf, string telephone, string address, string symptoms)
        {
            Name = name;
            Age = age;
            CPF = cpf;
            Telephone = telephone;
            Address = address;
            Symptoms = symptoms;
        }
    }

    public class UpdatePatientDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(70)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required, StringLength(20)]
        public string CPF { get; set; }

        [Required, StringLength(15)]
        public string Telephone { get; set; }

        [Required, StringLength(70)]
        public string Address { get; set; }

        [StringLength(250)]
        public string Symptoms { get; set; }

        public UpdatePatientDTO(string name, int age, string cpf, string telephone, string address, string symptoms)
        {
            Name = name;
            Age = age;
            CPF = cpf;
            Telephone = telephone;
            Address = address;
            Symptoms = symptoms;
        }

    }
}
