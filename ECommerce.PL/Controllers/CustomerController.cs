using AutoMapper;
using ECommerce.BLL.Interfaces;
using ECommerce.BLL.Models;
using ECommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.PL.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRep repository;
        private readonly IMapper mapper;
        private readonly ICustomerRep c;

        public CustomerController(ICustomerRep repository,IMapper mapper,ICustomerRep c)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.c = c;
        }
        public IActionResult Index()
        {
            var data = repository.GetAll();
            return View(mapper.Map<IEnumerable<CustomerVmodel>>(data));
        }
        public IActionResult Details(int id)
        {
          var data=  repository.getProductById(id);
            return View(mapper.Map<CustomerVmodel>(data));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            var data = repository.getProductById(id);
            //ViewBag.OrderId = data.orderId;
            return View(mapper.Map<CustomerVmodel>(data));
        }
        [HttpPost]
        public IActionResult Edit(CustomerVmodel model)
        {
            
                repository.update(mapper.Map<Customer>(model));

                return RedirectToAction("Index");
            
            

        }
        public IActionResult delete(CustomerVmodel model)
        {

            try
            {
                repository.delete(mapper.Map<Customer>(model));


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }




        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(CustomerVmodel model)
        {
            repository.Create(mapper.Map<Customer>(model));
            return RedirectToAction("Index");
        }

        public IActionResult CheckProducts()
        {
            var customers = c.GetAll();
            ViewBag.cst = new SelectList(customers, "id", "name");
            return View();
        }
        [HttpPost]
        public JsonResult CheckProducts(int id)
        {
            var data = repository.ProductByCstId(id);
            return Json(data);
        }
    }
}
