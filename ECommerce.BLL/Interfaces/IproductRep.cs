using ECommerce.BLL.Models;
using ECommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Interfaces
{
  public interface IproductRep
    {
        public void Create(product model);
        public product getProductById(int id);
        public IEnumerable<product> GetAll();
        public void update(product model);
        public void delete(product model);






    }
}
