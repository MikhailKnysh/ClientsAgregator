using ClientsAgregator_BLL.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientsAgregator_BLL
{

    public class ProductsBuyClientAndFeedback
    {
        private Controller _controller = new Controller();
        public List<ProductBuyClientModel> GetProductBuyClientAndFeedback(int id)
        {
            List<FeedbackModel> feedbacks = _controller.GetFeedbackModels();
            List<ProductBuyClientModel> productByClients = _controller.GetProductsBuyClientModels(id);

            for (int i = 0; i < productByClients.Count; ++i)
            {
                List<int> rate = new List<int>();
                 
                for (int j = 0; j < feedbacks.Count; ++j)
                {
                    if (productByClients[i].ProductId == feedbacks[j].ProductId && id == feedbacks[j].ClientId)
                    {
                        if (feedbacks[j].Rate > 0)
                        {
                            rate.Add(feedbacks[j].Rate);
                        }
                    }

                }

                productByClients[i].AVGRate = rate.Count > 0 ? Convert.ToString(Queryable.Average(rate.AsQueryable())) : "нет оценки";
            }

            return productByClients;
        }
    }
}
