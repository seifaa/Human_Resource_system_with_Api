using AutoMapper;
using ECommerce.BLL.Interfaces;
using ECommerce.BLL.Models;
using ECommerce.BLL.Repository;
using ECommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.PL.Controllers
{
    public class productController : Controller
    {
        private readonly IproductRep _repository;
        private readonly IMapper mapper;

        //ProductRep _repository = new ProductRep();
        public productController(IproductRep repository,IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
           var data= _repository.GetAll();
            return View(mapper.Map<IEnumerable<ProductVModel>>( data));
        }

        public IActionResult Details(int id)
        {
         var data= _repository.getProductById(id);

            return View (mapper.Map<ProductVModel>( data));
        }

        public IActionResult Edit(int id)
        {

            var data = _repository.getProductById(id);

            return View(mapper.Map<ProductVModel>(data));


        }
        [HttpPost]
        public IActionResult Edit(ProductVModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.update(mapper.Map<product>( model));

                return RedirectToAction("Index");
            }
            else return View(model);

        }
        public IActionResult Delete(int id)
        {
            var data = _repository.getProductById(id);
            _repository.delete(data);
            return RedirectToAction("index");

        }
        public IActionResult Create()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Create(ProductVModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(mapper.Map<product>( model));

                return RedirectToAction("Index");
            }
            else return View(model);

        }

        public IActionResult InStock()
        {
            var data = _repository.GetAll();
            ViewBag.prod = new SelectList(data, "id", "name");
            return View();
        }
        [HttpPost]
        public JsonResult InStock(int id)
        {
            var data = _repository.getProductById(id);
            return Json(data.Quantity);
        }
    }
}
