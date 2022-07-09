using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationControlSystem.src.model
{

    [Table("tb_patient")]
    public class PatientModel
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required , StringLength(70)]
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

        public PatientModel() { }

        public PatientModel(string name, int age, string cpf, string telephone, string address, string symptoms) 
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
