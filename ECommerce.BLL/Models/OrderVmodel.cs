using ECommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Models
{
   public class OrderVmodel
    {
        
        public int id { get; set; }
        public DateTime orderTime { get; set; }

        public IEnumerable<int> ProductsId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderProduct> orderProducts { get; set; }
    }
}
