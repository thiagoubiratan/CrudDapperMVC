using CrudDapperMVC.Domain.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudDapperMVC.Domain.Entities
{
    public class Client : EntityBase
    {
        [Required(ErrorMessage = "Nome Obrigatório")]
        [MaxLength(250, ErrorMessage = "Máximo de 250 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cpf Obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "E-mail Obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-Mail Válido")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone Obrigatório")]
        [DisplayName("Telefone")]
        public string Phone { get; set; }
    }
}
