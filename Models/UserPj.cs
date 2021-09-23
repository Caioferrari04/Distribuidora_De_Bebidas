using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Models
{
    public class UserPj : User
    {
        public string Cnpj { get; set; }
    }
}
