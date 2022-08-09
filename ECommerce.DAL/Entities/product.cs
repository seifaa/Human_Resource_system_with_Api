using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Entities
{
    [Table("product")]
     public class product
    {
        public product()
        {
            
                this.orderProducts = new HashSet<OrderProduct>();
            
        }
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]

        public string color { get; set; }
        [Required]

        public string size { get; set; }
        [Required]

        public double price { get; set; }
        [Required]

        public int Quantity { get; set; }
        [Required]

        public string describtion { get; set; }
      

        public string ProductUser { get; set; }
        public ICollection<OrderProduct> orderProducts { get; set; }


    }
}
