using ECommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Interfaces
{
  public  interface ICustomerRep
    {
        public void Create(Customer model);
        public Customer getProductById(int id);
        public IEnumerable<Customer> GetAll();
        public void update(Customer model);
        public void delete(Customer model);
        public IEnumerable<product> ProductByCstId(int CstId);
    }
}
