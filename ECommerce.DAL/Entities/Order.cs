using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Entities
{
   public class Order
    {
        public Order()
        {
            this.orderProducts = new HashSet<OrderProduct>();
        }
        public int id { get; set; }
        public DateTime orderTime { get; set; }
        [ForeignKey("Customer")]

        public int CustomerId { get; set; } 

        public virtual Customer Customer { get; set; }
        public ICollection<OrderProduct> orderProducts { get; set; }
    }
}
