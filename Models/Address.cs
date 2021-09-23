using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int UserId { get; set; }

        public User UserAddress { get; set; }

        public int TypeOfAddressId { get; set; }

        public TypeOf TypeOfAddress { get; set; }
    }
}
