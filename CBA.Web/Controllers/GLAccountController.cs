using CBA.Core.Models;
using CBA.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CBA.Web.Controllers
{
    public class GLAccountController : Controller
    {
        private readonly IGLAccountDAO _glAccount;

        public GLAccountController(IGLAccountDAO glAccount)
        {
            _glAccount = glAccount;
        }

        public IActionResult Index()
        {
            var gLAccounts = _glAccount.GetAllGLAccounts();
            return View(gLAccounts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GLAccount model, GLAccount glAccount)
        {
            if (ModelState.IsValid)
            {
                GLAccount newGLAccount = new()
                {
                    Id = model.Id,
                    AccountName = model.AccountName,
                    AccountBalance = model.AccountBalance,
                    AccountCode = _glAccount.CreateGlCategoryCode(glAccount),
                    Status = model.Status,
                    Categories = model.Categories,
                    //GLAccountAccount = model.GLAccountAccount,
                };

                _glAccount.Save(newGLAccount);
                //return RedirectToAction("index", new { id = newUser.Id });
                return RedirectToAction("index", "GLAccount", new { area = "" });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var gLAccount = _glAccount.RetrieveById(id);
            GLAccount editUserViewModel = new GLAccount()
            {
                //GLAccountId = gLAccount.GLAccountId,
                AccountName = gLAccount.AccountName,
                Status = gLAccount.Status,
                AccountCode = gLAccount.AccountCode,
                Categories = gLAccount.Categories,
                AccountBalance = gLAccount.AccountBalance,
            };
            return View(editUserViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var gLAccount = _glAccount.RetrieveById(id);
            GLAccount editUserViewModel = new GLAccount()
            {
                //GLAccountId = gLAccount.GLAccountId,
                AccountName = gLAccount.AccountName,
                Status = gLAccount.Status,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(GLAccount model)
        {
            if (ModelState.IsValid)
            {
                GLAccount gLAccount = _glAccount.RetrieveById(model.Id);
                //Console.WriteLine(model.Id);
                //gLAccount.GLAccountId = model.GLAccountId;
                gLAccount.AccountName = model.AccountName;
                gLAccount.Status = model.Status;

                GLAccount updatedGLAccount = _glAccount.UpdateGLAccount(gLAccount);

                return RedirectToAction("index", "GLAccount", new { area = "" });
            }

            return View(model);
        }
    }
}
