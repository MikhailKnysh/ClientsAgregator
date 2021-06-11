using AutoMapper;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using System;
using System.Collections.Generic;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Queries;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL
{
    public class Controller
    {
        private ClientsHelper clientsHelper;
        private ProductsHelper productsHelper;
        private OrdersHelper ordersHelper;
        private MainsHalper mainsHalper;

        public Controller()
        {
            clientsHelper = new ClientsHelper();
            productsHelper = new ProductsHelper();
            ordersHelper = new OrdersHelper();
            mainsHalper = new MainsHalper();
        }

        public List<ClientsFullNameModel> GetClientsFullNameModels()
        {
            var config = new MapperConfiguration(
            cfg => cfg
            .CreateMap<ClientFullNameDTO, ClientsFullNameModel>()
            .ForMember(dest => dest.FullName, option => option
            .MapFrom(source => $"{source.LastName} {source.FirstName} {source.MiddleName}")
            ));

            Mapper mapper = new Mapper(config);

            List<ClientsFullNameModel> clientModels = mapper.Map<List<ClientsFullNameModel>>(ordersHelper.GetClientsFullNames());

            return clientModels;
        }

        public List<ProductTitleModel> GetProductTitlesModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductSubgroupDTO, ProductTitleModel>());
            Mapper mapper = new Mapper(config);

            List<ProductTitleModel> productTitleModel = mapper.Map<List<ProductTitleModel>>(ordersHelper.GetProductTitles());

            return productTitleModel;
        }

        public List<StatusModel> GetStatusModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusDTO, StatusModel>());
            Mapper mapper = new Mapper(config);

            List<StatusModel> statusModels = mapper.Map<List<StatusModel>>(ordersHelper.GetStatusTitles());

            return statusModels;
        }

        public void AddOrder(NewOrderInfoModel newOrderInfoModel)
        {
            if (newOrderInfoModel.ProductsInOrder.Count > 0)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<NewOrderInfoModel, OrderDTO>());
                Mapper mapper = new Mapper(config);

                OrderDTO order = mapper.Map<OrderDTO>(newOrderInfoModel);

                List<ProductInOrderModel> productInOrderModels = newOrderInfoModel.ProductsInOrder;

                config = new MapperConfiguration(
                    cfg => cfg
                    .CreateMap<ProductInOrderModel, ProductDTO>()
                    .ForMember(dest => dest.Id, option => option.MapFrom(source => source.ProductId))
                    .ForMember(dest => dest.Title, option => option.MapFrom(source => source.ProductTitle))
                    .ForMember(dest => dest.MeasureId, option => option.MapFrom(source => source.MeasureUnitId))
                    );
                mapper = new Mapper(config);

                List<ProductDTO> products = mapper.Map<List<ProductDTO>>(productInOrderModels);

                config = new MapperConfiguration(cfg => cfg.CreateMap<ProductInOrderModel, Product_OrderDTO>());
                mapper = new Mapper(config);

                List<Product_OrderDTO> productsOrder = mapper.Map<List<Product_OrderDTO>>(productInOrderModels);

                ordersHelper.AddOrder(productsOrder, order);
            }
            else
            {
                throw new ArgumentException("Product list is empty!");
            }
        }

        public void DeleteOrder(int orderId)
        {
            ordersHelper.DeleteOrder(orderId);
        }

        public List<ProductInfoModel> GetProductInfoModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductInfoDTO, ProductInfoModel>());
            Mapper mapper = new Mapper(config);

            List<ProductInfoModel> productInfoModels = mapper.Map<List<ProductInfoModel>>(productsHelper.GetProductsInfo());

            return productInfoModels;
        }

        public List<GroupInfoModel> GetGroups()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoModel>());
            Mapper mapper = new Mapper(config);

            List<GroupInfoModel> groupModels = mapper.Map<List<GroupInfoModel>>(productsHelper.GetGroups());

            return groupModels;
        }

        public List<SubgroupInfoModel> GetSubgroupsInfoByGroupId(int groupId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SubgroupDTO, SubgroupInfoModel>());
            Mapper mapper = new Mapper(config);

            List<SubgroupInfoModel> subgroupModels = mapper.Map<List<SubgroupInfoModel>>(productsHelper.GetSubgroupsInfoByGroupId(groupId));

            return subgroupModels;
        }

        public List<MeasureUnitInfoModel> GetMeasureUnit()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MeasureUnitDTO, MeasureUnitInfoModel>());
            Mapper mapper = new Mapper(config);

            List<MeasureUnitInfoModel> measureModels = mapper.Map<List<MeasureUnitInfoModel>>(productsHelper.GetMeasureUnits());

            return measureModels;
        }

        public void AddProduct(AddingProductModel addingProductModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddingProductModel, ProductDTO>());
            Mapper mapper = new Mapper(config);

            ProductDTO product = mapper.Map<ProductDTO>(addingProductModel);

            int productId = productsHelper.AddProduct(product);
            productsHelper.AddProductSubgroup(productId, addingProductModel.SubgroupId);
        }

        public void AddGroup(string groupTitle)
        {
            productsHelper.AddProductGroup(groupTitle);
        }

        public void AddMeasureUnuit(string measureUnitTitle)
        {
            productsHelper.AddMeasureUnits(measureUnitTitle);
        }

        public void AddSubgropGroup(int groupId, string subgroupTitle)
        {
            int subgroupId = productsHelper.AddProductSubgroup(subgroupTitle);
            productsHelper.AddSubgroupGroup(subgroupId, groupId);
        }

        public void DeleteProduct(int productId)
        {
            productsHelper.DeleteProductSubgroupByProductId(productId);
            productsHelper.DeleteProductById(productId);
        }

        public List<OrdersInfoModel> GetOrderModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrdersInfoDTO, OrdersInfoModel>());
            Mapper mapper = new Mapper(config);

            List<OrdersInfoModel> orderModels = mapper.Map<List<OrdersInfoModel>>(ordersHelper.GetOrdersInfo());

            return orderModels;
        }

        public void AddClientDTO(AddClientModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddClientModel, AddClientDTO>());
            Mapper mapper = new Mapper(config);

            AddClientDTO clientDTO = mapper.Map<AddClientModel, AddClientDTO>(model);
            clientsHelper.AddClient(clientDTO);
        }

        public void UpdateClientDTO(AddClientModel model, int Id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddClientModel, AddClientDTO>());
            Mapper mapper = new Mapper(config);


            AddClientDTO clientDTO = mapper.Map<AddClientModel, AddClientDTO>(model);

            clientsHelper.UpdateClientById(clientDTO, Id);
        }

        public List<ClientModel> GetClientsModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientModel>());
            Mapper mapper = new Mapper(config);

            List<ClientModel> clientModels = mapper.Map<List<ClientModel>>(clientsHelper.GetClients());

            return clientModels;
        }

        public List<ProductBuyClientModel> GetProductsBuyClientModels(int Id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductsBuyClientDTO, ProductBuyClientModel>());
            Mapper mapper = new Mapper(config);

            List<ProductBuyClientModel> productModels = mapper.Map<List<ProductBuyClientModel>>(clientsHelper.GetProductsBuyClient(Id));

            return productModels;
        }

        public ClientModel GetClientByIdModels(int Id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientModel>());
            Mapper mapper = new Mapper(config);

            ClientModel clientByIdModels = mapper.Map<ClientModel>(clientsHelper.GetClientById(Id));

            return clientByIdModels;
        }

        public List<BulkStatusModel> GetBulkStatusesModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BulkStatusDTO, BulkStatusModel>());
            Mapper mapper = new Mapper(config);

            List<BulkStatusModel> bulkStatusModel = mapper.Map<List<BulkStatusModel>>(clientsHelper.GetBulkStatuses());

            return bulkStatusModel;
        }

        public ProductInfoModel GetProductInfoModel(int productId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductInfoDTO, ProductInfoModel>());
            Mapper mapper = new Mapper(config);

            ProductInfoModel productInfoModel = mapper.Map<ProductInfoModel>(productsHelper.GetProductInfoById(productId));

            return productInfoModel;
        }
        public List<ProductsSubgropModel> GetProductsSubgroupModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductSubgroupDTO, ProductsSubgropModel>());
            Mapper mapper = new Mapper(config);

            List<ProductsSubgropModel> productsSubgroupModels = mapper.Map<List<ProductsSubgropModel>>(mainsHalper.GetProductsSubgroup());

            return productsSubgroupModels;
        }

        public List<InterestedClientInfoByProductModel> GetInterestedClientInfoByProduct(int productId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InterestedClientInfoByProductDTO, InterestedClientInfoByProductModel>());
            Mapper mapper = new Mapper(config);

            List<InterestedClientInfoByProductModel> clientByIdModels = mapper.Map<List<InterestedClientInfoByProductModel>>(mainsHalper.GetInterestedClientInfoByProduct(productId));

            return clientByIdModels;
        }

        public List<InterestedClientInfoByProductModel> GetInterestedClientInfoBySubgroup(int subgroupId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InterestedClientInfoByProductDTO, InterestedClientInfoByProductModel>());
            Mapper mapper = new Mapper(config);

            List<InterestedClientInfoByProductModel> clientByIdModels = mapper.Map<List<InterestedClientInfoByProductModel>>(mainsHalper.GetInterestedClientInfoBySubgroup(subgroupId));

            return clientByIdModels;
        }


        public int GetSpendMoneyCountByClientIdModels(int Id)
        {
            int SpendMoneyCount = clientsHelper.GetSpendMoneyCountByClientId(Id);
            return SpendMoneyCount;
        }

        public List<FeedbackModel> GetFeedbackModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDTO, FeedbackModel>());
            Mapper mapper = new Mapper(config);

            List<FeedbackModel> feedback = mapper.Map<List<FeedbackModel>>(clientsHelper.GetFeedback());

            return feedback;
        }
    }
}