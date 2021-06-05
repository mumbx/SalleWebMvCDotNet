using Microsoft.AspNetCore.Mvc;
using SallesWebMVC.Models;
using SallesWebMVC.Models.ViewModels;
using SallesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SallesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerServices _sellerServices;
        private readonly DepartmentServices _departmentServices;

        public SellersController(SellerServices sellerServices, DepartmentServices departmentServices)
        {
            _sellerServices = sellerServices;
            _departmentServices = departmentServices;
        }
        public IActionResult Index()
        {

            var list = _sellerServices.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentServices.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiforgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerServices.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
       


    }
}
