using ECommerce.BLL.Interfaces;
using ECommerce.DAL.Database;
using ECommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Repository
{
    public class OrderProductRep : IOrderProduct
    {
        private readonly ProductContext db;

        public OrderProductRep(ProductContext db)
        {
            this.db = db;
        }


        public void Create(int OrderId, int ProductId)
        {
            var data = new OrderProduct() { orderId = OrderId, ProductId = ProductId };
            db.orderProducts.Add(data);
            db.SaveChanges();
       }

        public void delete(OrderProduct model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderProduct> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderProduct getProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void update(OrderProduct model)
        {
            throw new NotImplementedException();
        }
    }
}
