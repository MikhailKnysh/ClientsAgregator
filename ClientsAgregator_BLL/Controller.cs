using AutoMapper;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using System;
using System.Collections.Generic;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Queries;
using ClientsAgregator_DAL.Models;
using ClientsAgregator_DAL.Interface;

namespace ClientsAgregator_BLL 
{
    public class Controller 
    {
        IClientsHelper _clientsHelper;
        IProductsHelper _productsHelper;
        IOrdersHelper _ordersHelper;
        IMainsHelper _mainsHelper;

        public Controller(
            IClientsHelper clientsHelper = null,
            IProductsHelper productsHelper = null,
            IOrdersHelper ordersHelper = null,
            IMainsHelper mainsHelper = null)
        {

            _clientsHelper = clientsHelper ?? new ClientsHelper();
            _productsHelper = productsHelper ?? new ProductsHelper();
            _ordersHelper = ordersHelper ?? new OrdersHelper();
            _mainsHelper = mainsHelper ?? new MainsHelper();
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

            List<ClientsFullNameModel> clientModels = mapper.Map<List<ClientsFullNameModel>>(_ordersHelper.GetClientsFullNames());

            return clientModels;
        }

        public List<ProductTitleModel> GetProductTitlesModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductSubgroupDTO, ProductTitleModel>());
            Mapper mapper = new Mapper(config);

            List<ProductTitleModel> productTitleModel = mapper.Map<List<ProductTitleModel>>(_ordersHelper.GetProductTitles());

            return productTitleModel;
        }

        public List<StatusModel> GetStatusModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusDTO, StatusModel>());
            Mapper mapper = new Mapper(config);

            List<StatusModel> statusModels = mapper.Map<List<StatusModel>>(_ordersHelper.GetStatusTitles());

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

                config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackModel, FeedbackDTO>());
                mapper = new Mapper(config);

                _ordersHelper.AddOrder(productsOrder, order);
            }
            else
            {
                throw new ArgumentException("Product list is empty!");
            }
        }

        public void UpdateOrder(NewOrderInfoModel newOrderInfoModel, int orderId, List<FeedbackModel> feedbackModels)
        {
            if (newOrderInfoModel.ProductsInOrder.Count > 0)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<NewOrderInfoModel, OrderDTO>());
                Mapper mapper = new Mapper(config);

                OrderDTO order = mapper.Map<OrderDTO>(newOrderInfoModel);
                order.Id = orderId;

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
                foreach (Product_OrderDTO p in productsOrder)
                {
                    p.OrderId = orderId;
                }

                config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackModel, FeedbackDTO>());
                mapper = new Mapper(config);

                List<FeedbackDTO> feedbackDTOs = mapper.Map<List<FeedbackDTO>>(feedbackModels);

                _ordersHelper.UpdateOrder(productsOrder, order, feedbackDTOs);
            }
            else
            {
                throw new ArgumentException("Product list is empty!");
            }
        }

        public void DeleteOrder(int orderId)
        {
            _ordersHelper.DeleteOrder(orderId);
        }

        public List<ProductInfoModel> GetProductInfoModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductInfoDTO, ProductInfoModel>());
            Mapper mapper = new Mapper(config);

            List<ProductInfoModel> productInfoModels = mapper.Map<List<ProductInfoModel>>(_productsHelper.GetProductsInfo());

            return productInfoModels;
        }

        public List<GroupInfoModel> GetGroups()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoModel>());
            Mapper mapper = new Mapper(config);

            List<GroupInfoModel> groupModels = mapper.Map<List<GroupInfoModel>>(_productsHelper.GetGroups());

            return groupModels;
        }

        public List<SubgroupInfoModel> GetSubgroupsInfoByGroupId(int groupId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SubgroupDTO, SubgroupInfoModel>());
            Mapper mapper = new Mapper(config);

            List<SubgroupInfoModel> subgroupModels = mapper.Map<List<SubgroupInfoModel>>(_productsHelper.GetSubgroupsInfoByGroupId(groupId));

            return subgroupModels;
        }

        public List<MeasureUnitInfoModel> GetMeasureUnit()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MeasureUnitDTO, MeasureUnitInfoModel>());
            Mapper mapper = new Mapper(config);

            List<MeasureUnitInfoModel> measureModels = mapper.Map<List<MeasureUnitInfoModel>>(_productsHelper.GetMeasureUnits());

            return measureModels;
        }

        public void AddProduct(AddingProductModel addingProductModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddingProductModel, ProductDTO>());
            Mapper mapper = new Mapper(config);

            ProductDTO product = mapper.Map<ProductDTO>(addingProductModel);

            int productId = _productsHelper.AddProduct(product);
            _productsHelper.AddProductSubgroup(productId, addingProductModel.SubgroupId);
        }

        public void AddGroup(string groupTitle)
        {
            _productsHelper.AddProductGroup(groupTitle);
        }

        public void AddMeasureUnuit(string measureUnitTitle)
        {
            _productsHelper.AddMeasureUnits(measureUnitTitle);
        }

        public void AddSubgropGroup(int groupId, string subgroupTitle)
        {
            int subgroupId = _productsHelper.AddProductSubgroup(subgroupTitle);
            _productsHelper.AddSubgroupGroup(subgroupId, groupId);
        }

        public void DeleteProduct(int productId)
        {
            _productsHelper.DeleteProductById(productId);
        }

        public List<OrdersInfoModel> GetOrderModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrdersInfoDTO, OrdersInfoModel>());
            Mapper mapper = new Mapper(config);

            List<OrdersInfoModel> orderModels = mapper.Map<List<OrdersInfoModel>>(_ordersHelper.GetOrdersInfo());

            return orderModels;
        }

        public void AddClientDTO(AddClientModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddClientModel, AddClientDTO>());
            Mapper mapper = new Mapper(config);

            AddClientDTO clientDTO = mapper.Map<AddClientModel, AddClientDTO>(model);
            _clientsHelper.AddClient(clientDTO);
        }

        public void UpdateClientDTO(AddClientModel model, int Id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddClientModel, AddClientDTO>());
            Mapper mapper = new Mapper(config);

            AddClientDTO clientDTO = mapper.Map<AddClientModel, AddClientDTO>(model);

            _clientsHelper.UpdateClientById(clientDTO, Id);
        }

        public List<ClientModel> GetClientsModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientModel>());
            Mapper mapper = new Mapper(config);

            List<ClientModel> clientModels = mapper.Map<List<ClientModel>>(_clientsHelper.GetClients());

            return clientModels;
        }

        public List<ProductBuyClientModel> GetProductsBuyClientModels(int Id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductsBuyClientDTO, ProductBuyClientModel>());
            Mapper mapper = new Mapper(config);

            List<ProductBuyClientModel> productModels = mapper.Map<List<ProductBuyClientModel>>(_clientsHelper.GetProductsBuyClient(Id));

            return productModels;
        }

        public ClientModel GetClientByIdModels(int Id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientModel>());
            Mapper mapper = new Mapper(config);

            ClientModel clientByIdModels = mapper.Map<ClientModel>(_clientsHelper.GetClientById(Id));

            return clientByIdModels;
        }

        public List<BulkStatusModel> GetBulkStatusesModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BulkStatusDTO, BulkStatusModel>());
            Mapper mapper = new Mapper(config);

            List<BulkStatusModel> bulkStatusModel = mapper.Map<List<BulkStatusModel>>(_clientsHelper.GetBulkStatuses());

            return bulkStatusModel;
        }

        public ProductInfoModel GetProductInfoModel(int productId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductInfoDTO, ProductInfoModel>());
            Mapper mapper = new Mapper(config);

            ProductInfoModel productInfoModel = mapper.Map<ProductInfoModel>(_productsHelper.GetProductInfoById(productId));

            return productInfoModel;
        }

        public List<ProductsSubgropModel> GetProductsSubgroupModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductSubgroupDTO, ProductsSubgropModel>());
            Mapper mapper = new Mapper(config);

            List<ProductsSubgropModel> productsSubgroupModels = mapper.Map<List<ProductsSubgropModel>>(_mainsHelper.GetProductsSubgroup());

            return productsSubgroupModels;
        }

        public List<InterestedClientInfoByProductModel> GetInterestedClientInfoByProduct(int productId)
        {
            var config = new MapperConfiguration(
                cfg => cfg
                .CreateMap<InterestedClientInfoByProductDTO, InterestedClientInfoByProductModel>()
                .ForMember(dest => dest.AVGRate, option => option.MapFrom(source => (source.AVGRate < 1) ? ("Нет оценки"):(source.AVGRate.ToString())))
                );
            Mapper mapper = new Mapper(config);

            List<InterestedClientInfoByProductModel> clientByIdModels 
                = mapper.Map<List<InterestedClientInfoByProductModel>>(_mainsHelper.GetInterestedClientInfoByProduct(productId));

            return clientByIdModels;
        }

        public List<InterestedClientInfoByProductModel> GetInterestedClientInfoBySubgroup(int subgroupId)
        {
            var config = new MapperConfiguration(
                cfg => cfg
                .CreateMap<InterestedClientInfoByProductDTO, InterestedClientInfoByProductModel>()
                .ForMember(dest => dest.AVGRate, option => option.MapFrom(source => (source.AVGRate < 1) ? ("Нет оценки") : (source.AVGRate.ToString())))
                );
            Mapper mapper = new Mapper(config);

            List<InterestedClientInfoByProductModel> clientByIdModels = mapper.Map<List<InterestedClientInfoByProductModel>>(_mainsHelper.GetInterestedClientInfoBySubgroup(subgroupId));

            return clientByIdModels;
        }

        public int GetSpendMoneyCountByClientIdModels(int Id)
        {
            int SpendMoneyCount = _clientsHelper.GetSpendMoneyCountByClientId(Id);
            return SpendMoneyCount;
        }
        
        public List<FeedbackModel> GetFeedbackModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDTO, FeedbackModel>());
            Mapper mapper = new Mapper(config);

            List<FeedbackModel> feedback = mapper.Map<List<FeedbackModel>>(_clientsHelper.GetFeedbacks());

            return feedback;
        }

        public OrderModel GetOrdersInfoById(int orderId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderModel>());
            Mapper mapper = new Mapper(config);

            OrderModel orderModel = mapper.Map<OrderModel>(_ordersHelper.GetOrdersInfoById(orderId));

            return orderModel;
        }

        public List<ProductInOrderModel> GetProductsInOrderByOrderId(int orderId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductInOrderDTO, ProductInOrderModel>()
            .ForMember(dest => dest.ProductReview, option => option.MapFrom(source => source.OrderReview)));
            Mapper mapper = new Mapper(config);

            List<ProductInOrderModel> productsInOrder = mapper.Map<List<ProductInOrderModel>>(_ordersHelper.GetProductsInOrderByOrderIdNew(orderId));

            return productsInOrder;
        }
    }
}