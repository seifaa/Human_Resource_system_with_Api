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
    public class OrderController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOrderRep repository;
        private readonly IproductRep p;
        private readonly ICustomerRep c;
        private readonly IOrderProduct op;

        public OrderController(IMapper mapper,
            IOrderRep repository,IproductRep p,ICustomerRep c,IOrderProduct op)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.p = p;
            this.c = c;
            this.op = op;
        }
       
        public IActionResult Index()
        {
            var data = repository.GetAll();
            return View(mapper.Map<IEnumerable<OrderVmodel>>( data));
        }
        public IActionResult Create()
        {
            var customers = c.GetAll();
            var products = p.GetAll();
            ViewBag.cst = new SelectList(customers, "id", "name");
            ViewBag.prod = new SelectList(products, "id", "name");

            return View();


        }
        [HttpPost]
        public IActionResult Create(OrderVmodel model)
        {
           
         var data=   repository.Create(mapper.Map<Order>(model));

            foreach (var item in model.ProductsId)
            {
                op.Create(data, item);

            }
           
                return RedirectToAction("Index");
            
        }
        public IActionResult Delete(int id)
        {
            var data = repository.getProductById(id);
            repository.delete(data);
            return RedirectToAction("index");

        }
     
        public IActionResult Details(int id)
        {
            var data = repository.getProductById(id);

            return View(mapper.Map<OrderVmodel>(data));
        }
        public JsonResult Count()
        {
           var data= repository.count();
            return Json(data);
        }
    }
}
