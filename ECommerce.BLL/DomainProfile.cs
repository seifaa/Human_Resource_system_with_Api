using AutoMapper;
using ECommerce.BLL.Models;
using ECommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL
{
  public  class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<product, ProductVModel>();
            CreateMap< ProductVModel, product>();

            CreateMap<CustomerVmodel, Customer>();
            CreateMap< Customer, CustomerVmodel>();

            CreateMap<OrderVmodel, Order>();
            CreateMap<Order, OrderVmodel>();

            CreateMap<OrderProduct, OrderProductVmodel>();
            CreateMap<OrderProductVmodel, OrderProduct>();

        }
    }
}
