using Distribuidora_De_Bebidas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Services
{
    public interface IUserService
    {
        public dynamic GetUser(int Id);

        public List<User> GetAll();

        public dynamic CreateUser(DisplayModel input);

        public bool Create(dynamic user);

        public bool Update(dynamic user);

        public bool Delete(int Id);
    }
}
