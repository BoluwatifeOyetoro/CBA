using CBA.Core.Models;
using CBA.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CBA.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerDAO _customer;
        public CustomerController(ICustomerDAO customer)
        {
            _customer = customer;
        }


        public IActionResult Index()
        {
            var customers = _customer.GetAllCustomers();
            return View(customers);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            Customer customer = _customer.Delete(id);
            return RedirectToAction("index", "customer", new { area = "" });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                Customer newCustomer = new()
                {
                    Id = model.Id,
                    NewCustomerId = _customer.GenerateCustomerId(model.NewCustomerId),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Email = model.Email,
                    Status = model.Status,
                    //CustomerAccount = model.CustomerAccount,
                };

                _customer.Save(newCustomer);
                //return RedirectToAction("index", new { id = newUser.Id });
                return RedirectToAction("index", "customer", new { area = "" });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var customer = _customer.RetrieveById(id);
            Customer editUserViewModel = new Customer()
            {
                //CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Gender = customer.Gender,
                Email = customer.Email,
                Status = customer.Status,
                CustomerAccount = customer.CustomerAccount,
            };
            return View(editUserViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _customer.RetrieveById(id);
            Customer editUserViewModel = new Customer()
            {
                //CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Gender = customer.Gender,
                Email = customer.Email,
                Status = customer.Status,
                CustomerAccount = customer.CustomerAccount,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(Customer model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _customer.RetrieveById(model.Id);
                //Console.WriteLine(model.Id);
                //customer.CustomerId = model.CustomerId;
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Gender = model.Gender;
                customer.Email = model.Email;
                customer.Status = model.Status;
                customer.CustomerAccount = model.CustomerAccount;

                Customer updatedCustomer = _customer.UpdateCustomer(customer);

                return RedirectToAction("index", "customer", new { area = "" });
            }

            return View(model);
        }
    }
}
