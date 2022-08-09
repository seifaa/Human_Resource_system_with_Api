using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Entities
{
   public class OrderProduct
    {
        [ForeignKey("order")]
        public int orderId { get; set; }
        public Order order { get; set; }
        [ForeignKey("product")]

        public int ProductId { get; set; }
        public product product { get; set; }
    }
}
