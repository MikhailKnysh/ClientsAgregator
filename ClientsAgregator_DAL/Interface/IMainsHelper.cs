using ClientsAgregator_DAL.CustomModels;
using System.Collections.Generic;

namespace ClientsAgregator_DAL.Interface
{
    public interface IMainsHelper
    {
        public List<ProductSubgroupDTO> GetProductsSubgroup();
        public List<InterestedClientInfoByProductDTO> GetInterestedClientInfoByProduct(int productId);
        public List<InterestedClientInfoByProductDTO> GetInterestedClientInfoBySubgroup(int subgroupId);
    }
}
