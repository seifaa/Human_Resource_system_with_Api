using ECommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Interfaces
{
 public   interface IOrderProduct
    {
        public void Create(int OrderId, int ProductId);
            public OrderProduct getProductById(int id);
        public IEnumerable<OrderProduct> GetAll();
        public void update(OrderProduct model);
        public void delete(OrderProduct model);
        
    }
}
