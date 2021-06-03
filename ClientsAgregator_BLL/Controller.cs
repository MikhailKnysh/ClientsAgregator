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

        public List<ClientsFullNameModel> GetClientsFullNameModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientFullNameDTO, ClientsFullNameModel>()
            .ForMember(dest => dest.FullName, option => option
            .MapFrom(source =>$"{source.LastName} {source.FirstName} {source.MiddleName}")));

            Mapper mapper = new Mapper(config);

            List<ClientsFullNameModel> clientModels = mapper.Map<List<ClientsFullNameModel>>(OrdersHelper.GetClientsFullNames());

            return clientModels;
        }

        public List<ProductTitleModel> GetProductTitlesModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductTitleDTO, ProductTitleModel>());
            Mapper mapper = new Mapper(config);

            List<ProductTitleModel> productTitleModel = mapper.Map<List<ProductTitleModel>>(OrdersHelper.GetProductTitles());

            return productTitleModel;
        }


    }
}
