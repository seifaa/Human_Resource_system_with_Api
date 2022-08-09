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
  public  class OrderRep:IOrderRep
    {
        private readonly ProductContext db;

        public OrderRep(ProductContext db)
        {
            this.db = db;
        }

        public int count()
        {
           return db.orders.Count();

        }

        public int Create(Order model)
        {
            db.orders.Add(model);
            db.SaveChanges();
            return model.id;
;        }

        public void delete(Order model)
        {
            db.orders.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var data = db.orders.Include(a=>a.Customer).
                Include(a=>a.orderProducts).
                ThenInclude(a=>a.product).Select(a => a);
            return data;
        }

        public Order getProductById(int id)
        {
            var data = db.orders.Include(a=>a.Customer).Where(a => a.id == id).FirstOrDefault();
            return data;
        }
    }
}
