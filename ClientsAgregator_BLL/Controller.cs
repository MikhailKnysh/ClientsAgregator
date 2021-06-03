using AutoMapper;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL
{
    public class Controller
    {
        public List<OrderModel> GetOrderModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrdersInfoDTO, OrderModel>());
            Mapper mapper = new Mapper(config);

            List<OrderModel> orderModels = mapper.Map<List<OrderModel>>(OrdersHelper.GetOrdersInfo());

            return orderModels;
        }
    }
}
