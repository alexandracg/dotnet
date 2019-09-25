using System;
using System.ComponentModel.DataAnnotations;

namespace ConsultorioWeb.Models
{
    public class Procedure
    {
        public Guid Id { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do procedimento")]
        public string Name { get; set; }

        public Procedure(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }
    }
}
