using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Models;
using System.Collections.Generic;

namespace ClientsAgregator_DAL.Interface
{
    public interface IProductsHelper
    {
        public List<ProductInfoDTO> GetProductsInfo();
        public List<GroupDTO> GetGroups();
        public List<SubgroupDTO> GetSubgroupsInfoByGroupId(int groupId);
        public List<MeasureUnitDTO> GetMeasureUnits();
        public void AddMeasureUnits(string Title);
        public int AddProduct(ProductDTO product);
        public void AddProductSubgroup(int productId, int subgroupId);
        public void AddProductGroup(string Title);
        public int AddProductSubgroup(string Title);
        public void AddSubgroupGroup(int SubgroupId, int GroupId);
        public void DeleteProductById(int productId);
        public void DeleteProductSubgroupByProductId(int productId);
        public ProductInfoDTO GetProductInfoById(int productId);
    }
}
