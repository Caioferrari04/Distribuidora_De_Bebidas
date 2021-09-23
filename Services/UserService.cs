using Distribuidora_De_Bebidas.Data;
using Distribuidora_De_Bebidas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Services
{
    public class UserService : IUserService
    {
        Context context;
        public UserService(Context context)
        {
            this.context = context;
        }

        public dynamic CreateUser(DisplayModel input)
        {
            User user;

            if (input.Cnpj != null)
            {
                user = new UserPj()
                {
                    Id = input.Id,
                    UserName = input.UserName,
                    Email = input.Email,
                    Password = input.Password,
                    Cep = input.Cep,
                    BirthDate = input.BirthDate,
                    Cnpj = input.Cnpj,
                    Phones = new List<Phone>(),
                    Addresses = new List<Address>()
                };
            }
            else
            {
                user = new UserPf()
                {
                    Id = input.Id,
                    UserName = input.UserName,
                    Email = input.Email,
                    Password = input.Password,
                    Cep = input.Cep,
                    BirthDate = input.BirthDate,
                    Cpf = input.Cpf,
                    Rg = input.Rg,
                    Phones = new List<Phone>(),
                    Addresses = new List<Address>()
                };
            }
            user.Phones.Add(new Phone
            {
                Number = input.Phones == null ? null : input.Phones[0],
                TypeOfId = input.TypePhoneId
            });
            user.Addresses.Add(new Address
            {
                Text = input.Addresses == null ? null : input.Addresses[0],
                TypeOfAddressId = input.TypeAdressId
            });
            return user;
        }

        public bool Create(dynamic user)
        {
            try
            {
                if(user is UserPf)
                {
                    context.UsersPf.Add(user);
                    context.Phones.Add(user.Phones[0]);
                    context.Addresses.Add(user.Addresses[0]);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    context.UsersPj.Add(user);
                    context.Phones.Add(user.Phones[0]);
                    context.Addresses.Add(user.Addresses[0]);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                dynamic user = GetUser(Id);
                if (user is UserPf)
                {
                    context.UsersPf.Remove(user);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    context.UsersPj.Remove(user);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public dynamic GetUser(int Id)
        {
            UserPf userPf = GetUserPf(Id);
            if (userPf != null) return userPf;
            UserPj userPj = GetUserPj(Id);
            if (userPj != null) return userPj;
            else throw new InvalidOperationException();
        }

        public UserPf GetUserPf(int Id)
        {
            return context.UsersPf.Include(u => u.Phones).ThenInclude(t => t.TypeOfPhone).Include(u => u.Addresses).ThenInclude(t => t.TypeOfAddress).FirstOrDefault(u => u.Id == Id);
        }

        public UserPj GetUserPj(int Id)
        {
            return context.UsersPj.Include(u => u.Phones).ThenInclude(t => t.TypeOfPhone).Include(u => u.Addresses).ThenInclude(t => t.TypeOfAddress).Include(u => u.Phones).Include(u => u.Addresses).FirstOrDefault(u => u.Id == Id);
        }

        public bool Update(dynamic user)
        {
            try
            {
                if (user is UserPf)
                {
                    user.Phones = null;
                    user.Addresses = null;
                    context.UsersPf.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    user.Phones = null;
                    user.Addresses = null;
                    context.UsersPj.Update(user);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
