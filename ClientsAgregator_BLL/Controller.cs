using AutoMapper;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Queries;
using ClientsAgregator_DAL.Models;
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

        public void AddClientDTO(AddClientModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddClientModel, AddClientDTO>());
            Mapper mapper = new Mapper(config);

            AddClientDTO clientDTO = mapper.Map<AddClientModel, AddClientDTO>(model);
            ClientsHelper.AddClient(clientDTO);
        }

        public List<ClientModel> GetClientsModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientModel>());
            Mapper mapper = new Mapper(config);

            List<ClientModel> clientModels = mapper.Map<List<ClientModel>>(ClientsHelper.GetClients());

            return clientModels;
        }
    }
}
