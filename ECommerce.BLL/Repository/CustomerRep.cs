using ECommerce.BLL.Interfaces;
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
    public class CustomerRep : ICustomerRep
    {
        private readonly ProductContext db;

        public CustomerRep(ProductContext db)
        {
            this.db = db;
        }
        public void Create(Customer model)
        {
            db.customers.Add(model);
            db.SaveChanges();
        }

        public void delete(Customer model)
        {
            db.customers.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            var data = db.customers.Select(a => a);
            return data;


        }

        public Customer getProductById(int id)
        {
            var data = db.customers.Include(a=>a.order).Where(a => a.id == id).FirstOrDefault();
            return data;
        }

        public IEnumerable<product> ProductByCstId(int CstId)
        {
            var data = db.customers.Where(a => a.id == CstId).Join(
                db.orderProducts,

                a => a.id,
                b => b.order.CustomerId,

                (a, b) => new product()
                {
                    id = b.product.id,
                    color = b.product.color,
                    describtion = b.product.describtion,
                    price = b.product.price,
                    name = b.product.name,
                    size = b.product.size,
                    Quantity = b.product.Quantity,
                    ProductUser = b.product.ProductUser,

                }

                );
            return (data);
           
        }

        public void update(Customer model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
