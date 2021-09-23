using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Models
{
    public class TypeOf
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Phone> TypeOfPhones { get; set; }

        public List<Address> TypeOfAddresses { get; set; }
    }
}
