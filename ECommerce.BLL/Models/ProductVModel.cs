using ECommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Models
{
   public class ProductVModel
    {
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
      //  public ICollection<OrderProduct> orderProducts { get; set; }


    }
}
