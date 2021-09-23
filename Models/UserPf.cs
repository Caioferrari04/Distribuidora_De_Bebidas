using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Models
{
    public class UserPf : User
    {
        public string Cpf { get; set; }

        public string Rg { get; set; }
    }
}
