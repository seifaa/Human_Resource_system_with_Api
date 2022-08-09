using ECommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Models
{
   public class OrderProductVmodel
    {
        public int orderId { get; set; }
        public Order order { get; set; }

        public int ProductId { get; set; }
        public product product { get; set; }
    }
}
