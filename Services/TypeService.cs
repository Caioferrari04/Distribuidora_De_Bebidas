using Distribuidora_De_Bebidas.Data;
using Distribuidora_De_Bebidas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Services
{
    public class TypeService
    {
        Context context;
        public TypeService(Context context)
        {
            this.context = context;
        }
        public List<TypeOf> GetAll()
        {
            return context.Types.ToList();
        }
    }
}
