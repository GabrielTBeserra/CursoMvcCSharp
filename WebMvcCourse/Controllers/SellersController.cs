using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMvcCourse.Models;
using WebMvcCourse.Models.ViewModels;
using WebMvcCourse.services;

namespace WebMvcCourse.Controllers
{
    public class SellersController : Controller
    {
        private readonly DepartmentService _departmentService;
        private readonly SellerService _sellerService;

        public SellersController(SellerService seller, DepartmentService departmentService)
        {
            _sellerService = seller;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel {Departments = departments};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new {Message = "Id not provided"});

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) RedirectToAction(nameof(Error), new {Message = "Id not found"});

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new {Message = "Id not provided"});

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return RedirectToAction(nameof(Error), new {Message = "Id not found"});

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new {Message = "Id not provided"});

            var obj = _sellerService.FindById(id.Value);

            if (obj == null) return RedirectToAction(nameof(Error), new {Message = "Id not found"});

            var departments = _departmentService.FindAll();

            var viewModel = new SellerFormViewModel
            {
                Seller = obj, Departments = departments
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id) return RedirectToAction(nameof(Error), new {Message = "Id mismatch"});

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new {e.Message});
            }
        }

        public IActionResult Error(string message)
        {
            var viewmodel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewmodel);
        }
    }
}