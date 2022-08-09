using ECommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Interfaces
{
    public interface IOrderRep
    {
        public int Create(Order model);
        public Order getProductById(int id);
        public IEnumerable<Order> GetAll();

        // public void update(Order model);
        public void delete(Order model);

        public int count();

    }
}
