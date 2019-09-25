using System;
using System.ComponentModel.DataAnnotations;

namespace ConsultorioWeb.Models
{
    public class Attendance
    {
        public Guid Id { get; private set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do paciente")]
        public string Paciente { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do procedimento")]
        public string Procedimento { get; set; }

        public Attendance()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
