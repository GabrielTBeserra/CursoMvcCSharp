using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebMvcCourse.Models;
using WebMvcCourse.Models.ViewModels;
using WebMvcCourse.services;
using WebMvcCourse.services.Exceptions;

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
            if (id == null) return NotFound();

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return NotFound();

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
            if (id == null) return NotFound();

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return NotFound();

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var obj = _sellerService.FindById(id.Value);
            
            if (obj == null) return NotFound();

            List<Department> departments = _departmentService.FindAll();

            SellerFormViewModel viewModel = new SellerFormViewModel()
            {
                Seller = obj, Departments = departments
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}