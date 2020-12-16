using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project_Work.Entities
{
    class ExchangeController
    {
        public IExchangeManager ExchangeManager { get; set; }
        public ExchangeController()
        {
            ExchangeManager = new ExchangeManager();
        }

        public RateData AddFavorites(string favorite, decimal value)
        {
            //validation of favorite

            
            var exchange = new RateData()
            {
                Currency = favorite,
                Value = value
            };

            var newExchange = ExchangeManager.CreateExchange(exchange);
            return newExchange;
        }
    }
}
