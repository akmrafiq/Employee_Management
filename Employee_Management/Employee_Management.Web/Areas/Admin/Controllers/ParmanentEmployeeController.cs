using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Management.Core.Services;
using Employee_Management.Web.Areas.Admin.Models;
using Employee_Management.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Web.Areas.Admin.Controllers
{
    public class ParmanentEmployeeController : Controller
    {
        private IParmanentEmployeeService _parmanentEmployeeService;
        public ParmanentEmployeeController(IParmanentEmployeeService parmanentEmployeeService)
        {
            _parmanentEmployeeService = parmanentEmployeeService;
        }
        public IActionResult Index()
        {
            var model = new ParmanentEmployeeViewModel();
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new ParmanentEmployeeUpdateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ParmanentEmployeeUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewParmanentEmployee();
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new ParmanentEmployeeUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ParmanentEmployeeUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditParmanentEmployee();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new ParmanentEmployeeViewModel();
            model.Delete(id);
            return LocalRedirect("Index");
        }

        public IActionResult GetParmanentEmployee()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ParmanentEmployeeViewModel();
            var data = model.GetEmployees(tableModel);
            return Json(data);
        }
    }
}