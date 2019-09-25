using System;
using System.ComponentModel.DataAnnotations;

namespace ConsultorioWeb.Models
{
    public class Patient
    {
        public Guid Id { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do paciente")]
        public string Name { get; set; }

        public Patient()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
