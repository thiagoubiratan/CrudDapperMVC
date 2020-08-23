using CrudDapperMVC.Model.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudDapperMVC.Model
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

        [Required(ErrorMessage = "Cep Obrigatório")]
        [DisplayName("Cep")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Logradouro Obrigatório")]
        [MaxLength(180, ErrorMessage = "Máximo de 180 caracteres")]
        [DisplayName("Logradouro")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Número Obrigatório")]
        [DisplayName("Número")]
        public int Number { get; set; }

        [MaxLength(180, ErrorMessage = "Máximo de 180 caracteres")]
        [DisplayName("Complemento")]
        public string AddressComplement { get; set; }

        [Required(ErrorMessage = "Cidade Obrigatório")]
        [MaxLength(180, ErrorMessage = "Máximo de 80 caracteres")]
        [DisplayName("Cidade")]
        public string City { get; set; }

        [Required(ErrorMessage = "Bairro Obrigatório")]
        [MaxLength(80, ErrorMessage = "Máximo de 80 caracteres")]
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "UF Obrigatório")]
        [MaxLength(2, ErrorMessage = "Máximo de 2 caracteres")]
        [DisplayName("UF")]
        public string State { get; set; }
    }
}