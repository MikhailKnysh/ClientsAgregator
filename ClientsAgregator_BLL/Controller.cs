using AutoMapper;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Models;
using ClientsAgregator_DAL.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL
{
    public class Controller
    {
        public List<OrdersInfoModel> GetOrderModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrdersInfoDTO, OrdersInfoModel>());
            Mapper mapper = new Mapper(config);

            List<OrdersInfoModel> orderModels = mapper.Map<List<OrdersInfoModel>>(OrdersHelper.GetOrdersInfo());

            return orderModels;
        }

        public List<ClientsFullNameModel> GetClientsFullNameModels()
        {
            var config = new MapperConfiguration(
            cfg => cfg
            .CreateMap<ClientFullNameDTO, ClientsFullNameModel>()
            .ForMember(dest => dest.FullName, option => option
            .MapFrom(source =>$"{source.LastName} {source.FirstName} {source.MiddleName}")
            ));

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

        public List<StatusModel> GetStatusModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusDTO, StatusModel>());
            Mapper mapper = new Mapper(config);

            List<StatusModel> statusModels = mapper.Map<List<StatusModel>>(OrdersHelper.GetStatusTitles());

            return statusModels;
        }

        public void AddOrder(NewOrderInfoModel newOrderInfoModel)
        {
            if (newOrderInfoModel.productsInOrder.Count > 0)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<NewOrderInfoModel, OrderDTO>());
                Mapper mapper = new Mapper(config);

                OrderDTO order = mapper.Map<OrderDTO>(newOrderInfoModel);

                List<ProductInOrderModel> productInOrderModels = newOrderInfoModel.productsInOrder;

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

                OrdersHelper.AddOrder(productsOrder, order);
            }
            else
            {
                throw new ArgumentException("Product list is empty!");
            }
        }

        public void DeleteOrder(int orderId)
        {
            OrdersHelper.DeleteOrder(orderId);
        }

        public List<ProductInfoModel> GetProductInfoModels()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductInfoDTO, ProductInfoModel>());
            Mapper mapper = new Mapper(config);

            List<ProductInfoModel> productInfoModels = mapper.Map<List<ProductInfoModel>>(ProductsHelper.GetProductsInfo());

            return productInfoModels;
        }

        public List<GroupInfoModel> GetGroups()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoModel>());
            Mapper mapper = new Mapper(config);

            List<GroupInfoModel> groupModels = mapper.Map<List<GroupInfoModel>>(ProductsHelper.GetGroups());

            return groupModels;
        }

        public List<SubgroupInfoModel> GetSubgroupsInfoByGroupId(int groupId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SubgroupDTO, SubgroupInfoModel>());
            Mapper mapper = new Mapper(config);

            List<SubgroupInfoModel> subgroupModels = mapper.Map<List<SubgroupInfoModel>>(ProductsHelper.GetSubgroupsInfoByGroupId(groupId));

            return subgroupModels;
        }

        public List<MeasureUnitInfoModel> GetMeasureUnit()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MeasureUnitDTO, MeasureUnitInfoModel>());
            Mapper mapper = new Mapper(config);

            List<MeasureUnitInfoModel> measureModels = mapper.Map<List<MeasureUnitInfoModel>>(ProductsHelper.GetMeasureUnits());

            return measureModels;
        }

        public void AddProduct(AddingProductModel addingProductModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddingProductModel, ProductDTO>());
            Mapper mapper = new Mapper(config);

            ProductDTO product = mapper.Map<ProductDTO>(addingProductModel);

            int productId = ProductsHelper.AddProduct(product);
            ProductsHelper.AddProductSubgroup(productId, addingProductModel.SubgroupId);
        }

        public void AddGroup(string groupTitle)
        {
            ProductsHelper.AddProductGroup(groupTitle); 
        }

        public void AddSubgropGroup(int groupId, string subgroupTitle)
        {
            int subgroupId =  ProductsHelper.AddProductSubgroup(subgroupTitle);
            ProductsHelper.AddSubgroupGroup(subgroupId, groupId);
        }

        public void DeleteProduct(int productId)
        {
            ProductsHelper.DeleteProductSubgroupByProductId(productId);
            ProductsHelper.DeleteProductById(productId);
        }

    }
}
