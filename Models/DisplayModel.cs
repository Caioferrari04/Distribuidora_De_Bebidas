using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Models
{
    public class DisplayModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe seu nome!", AllowEmptyStrings = false)]
        [Display(Name = "Nome de usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe seu email!", AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha!", AllowEmptyStrings = false)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Informe sua data de nascimento!")]
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Informe seu CEP!")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "Endereço")]
        public List<string> Addresses { get; set; }

        [Display(Name = "Tipo de endereço")]
        public int TypeAdressId { get; set; }

        [Display(Name = "Números de contato")]
        public List<string> Phones { get; set; }

        [Display(Name = "Tipo do número")]
        public int TypePhoneId { get; set; }
    }
}
