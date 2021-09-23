using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public int UserId { get; set; }

        public User PhoneUser { get; set; }

        public int TypeOfId { get; set; }

        public TypeOf TypeOfPhone { get; set; }
    }
}
