using CBA.Core.Models;
using CBA.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CBA.Web.Controllers
{
    public class CustomerAccountController : Controller
    {
        private readonly ICustomerAccountDAO _operations;
        public CustomerAccountController(ICustomerAccountDAO operations)
        {
            _operations = operations;
        }


        public IActionResult Index()
        {
            var customerAccounts = _operations.GetAllCustomerAccounts();
            return View(customerAccounts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerAccount model)
        {
            if (ModelState.IsValid)
            {
                CustomerAccount newCustomerAccount = new()
                {
                    Id = model.Id,
                    Customer = model.Customer,
                    Status = model.Status,
                    //CustomerAccountAccount = model.CustomerAccountAccount,
                };

                _operations.Save(newCustomerAccount);
                //return RedirectToAction("index", new { id = newUser.Id });
                return RedirectToAction("index", "CustomerAccount", new { area = "" });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var customerAccount = _operations.RetrieveById(id);
            CustomerAccount editUserViewModel = new CustomerAccount()
            {
                //CustomerAccountId = customerAccount.CustomerAccountId,
                Customer = customerAccount.Customer,
                Status = customerAccount.Status,
            };
            return View(editUserViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customerAccount = _operations.RetrieveById(id);
            CustomerAccount editUserViewModel = new CustomerAccount()
            {
                //CustomerAccountId = customerAccount.CustomerAccountId,
                Customer = customerAccount.Customer,
                Status = customerAccount.Status,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CustomerAccount model)
        {
            if (ModelState.IsValid)
            {
                CustomerAccount customerAccount = _operations.RetrieveById(model.Id);
                //Console.WriteLine(model.Id);
                //customerAccount.CustomerAccountId = model.CustomerAccountId;
                customerAccount.Customer = model.Customer;
                customerAccount.Status = model.Status;

                CustomerAccount updatedCustomerAccount = _operations.UpdateCustomerAccount(customerAccount);

                return RedirectToAction("index", "CustomerAccount", new { area = "" });
            }

            return View(model);
        }
    }
}
