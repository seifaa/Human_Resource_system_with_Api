using AutoMapper;
using ECommerce.BLL.Interfaces;
using ECommerce.BLL.Models;
using ECommerce.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IproductRep _repository;
        private readonly IMapper mapper;

        //ProductRep _repository = new ProductRep();
        public ProductApiController(IproductRep repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Products")]
        public IActionResult GetProducts()
        {
            try
            {
                var data = _repository.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {

                return NotFound();
            }
           

        }
        [HttpGet]
        [Route("Names")]
        public IActionResult Display()
        {
            string[] names = { "aa", "bb" };
            return Ok(names);
        }



        [HttpPost]
        [Route("AddProduct")]
        public IActionResult Create(ProductVModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(mapper.Map<product>(model));
                var data = _repository.GetAll();
                return Ok(data);
            }
            else  return NotFound();

        }



        [HttpPut]
        [Route("Edite")]
        public IActionResult Edit(ProductVModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.update(mapper.Map<product>(model));
                var data = _repository.GetAll();
                return Ok(data);
            }
            else return NotFound();

        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data1 = _repository.getProductById(id);
            _repository.delete(data1);
            var data = _repository.GetAll();
            return Ok(data);

        }

    }
}
