using Distribuidora_De_Bebidas.Models;
using Distribuidora_De_Bebidas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora_De_Bebidas.Controllers
{
    public class HomeController : Controller
    {
        IUserService service;
        TypeService typeService;
        public HomeController(IUserService service, TypeService typeService)
        {
            this.service = service;
            this.typeService = typeService;
        }

        public IActionResult Index()
        {
            return View(service.GetAll());
        }

        public IActionResult ReadSingle(int Id)
        {
            dynamic User = service.GetUser(Id);
            DisplayModel display = new DisplayModel()
            {
                Id = User.Id,
                UserName = User.UserName,
                BirthDate = User.BirthDate,
                Email = User.Email,
                Password = User.Password,
                Cep = User.Cep,
                Cnpj = User is UserPj ? User.Cnpj : null,
                Cpf = User is UserPf ? User.Cpf : null,
                Rg = User is UserPf ? User.Rg : null,
                Phones = new List<string>(),
                Addresses = new List<string>()
            };
            foreach(Phone phone in User.Phones)
                display.Phones.Add(phone.Number + "(" + phone.TypeOfPhone.Name + ")");
            foreach (Address address in User.Addresses)
                display.Addresses.Add(address.Text + "(" + address.TypeOfAddress.Name + ")");
            return View(display);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var tipos = typeService.GetAll();
            ViewBag.tipos = new SelectList(tipos, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DisplayModel input)
        {
            var types = typeService.GetAll();
            ViewBag.tipos = new SelectList(types, "Id", "Name", input.TypeAdressId);
            if (!ModelState.IsValid) return View(input);

            dynamic user = service.CreateUser(input);
            return service.Create(user) ? RedirectToAction(nameof(Index)) : View(input);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            
            var types = typeService.GetAll();
            var user = service.GetUser(Id);
            DisplayModel display = DisplayBuilder(user);
            ViewBag.typePhone = new SelectList(types, "Id", "Name");
            return View(display);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DisplayModel input)
        {
            var types = typeService.GetAll();
            ViewBag.typePhone = new SelectList(types, "Id", "Name");
            if (!ModelState.IsValid) {
                var userBack = service.GetUser(input.Id);
                input = DisplayBuilder(userBack);
                return View(input); 
            }
            dynamic user = service.CreateUser(input);
            return service.Update(user) ? RedirectToAction(nameof(Index)) : View(input);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            service.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

        public DisplayModel DisplayBuilder(dynamic user)
        {
            DisplayModel display = new DisplayModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Password = user.Password,
                Cep = user.Cep,
                Cnpj = user is UserPj ? user.Cnpj : null,
                Cpf = user is UserPf ? user.Cpf : null,
                Rg = user is UserPf ? user.Rg : null,
                Phones = new List<string>(),
                Addresses = new List<string>()
            };
            foreach (Phone phone in user.Phones)
                display.Phones.Add(phone.Number);
            foreach (Address address in user.Addresses)
                display.Addresses.Add(address.Text);
            return display;
        }
    }
}
