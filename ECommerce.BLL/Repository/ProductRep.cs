using AutoMapper;
using ECommerce.BLL.Interfaces;
using ECommerce.BLL.Models;
using ECommerce.DAL.Database;
using ECommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Repository
{
    public class ProductRep : IproductRep
    {
        private readonly ProductContext db;
        private readonly IMapper mapper;

        //ProductContext db = new ProductContext();
        public ProductRep(ProductContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="Product model"></param>
        public void Create(product model)
        {
        //    product p = new product();
        //    p.id = model.id;
        //    p.name = model.name;
        //    p.color = model.color;
        //    p.size = model.size;
        //    p.Quantity = model.Quantity;
        //    p.describtion = model.describtion;
        //    p.price = model.price;
        //    p.ProductUser = model.ProductUser;
            db.Products.Add(model);
            db.SaveChanges();

        }




        /// <summary>
        /// delete
        /// </summary>
        /// <param name="model"></param>
        public void delete(product model)
        {
            //product p = new product();
            //p.id = model.id;
            //p.name = model.name;
            //p.color = model.color;
            //p.size = model.size;
            //p.Quantity = model.Quantity;
            //p.describtion = model.describtion;
            //p.price = model.price;
            //p.ProductUser = model.ProductUser;
            db.Products.Remove(model);
            db.SaveChanges();
        }



        /// <summary>
        /// Method to get all Products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<product> GetAll()
        {
            var data = db.Products.Select(a => a);

            return (data);

        }



        /// <summary>
        /// Methode to get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public product getProductById(int id)
        {
            var data = db.Products.Where(a => a.id == id).FirstOrDefault();
            //ProductVModel p = new ProductVModel()
            //{
            //    id = data.id,
            //    name = data.name,
            //    color = data.color,
            //    size = data.size,
            //    describtion = data.describtion,
            //    price = data.price,
            //    Quantity = data.Quantity,
            //    ProductUser = data.ProductUser
            //};
            return (data);
            }




        /// <summary>
        /// update
        /// </summary>
        /// <param name="model"></param>
        public void update(product model)
        {
            //product p = new product();
            //p.id = model.id;
            //p.name = model.name;
            //p.color = model.color;
            //p.size = model.size;
            //p.Quantity = model.Quantity;
            //p.describtion = model.describtion;
            //p.price = model.price;
            //p.ProductUser = model.ProductUser;

            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();


        }
    }
}
