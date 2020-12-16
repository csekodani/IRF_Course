using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project_Work.Entities
{
    public class ExchangeManager:IExchangeManager
    {
        public BindingList<RateData> Exchanges { get; } = new BindingList<RateData>();

        public RateData CreateExchange(RateData exchange)
        {
            var oldExchange = (from a in Exchanges
                              where a.Value.Equals(exchange.Value)
                              select a).FirstOrDefault();

            if (oldExchange != null)
                throw new ApplicationException(
                    "Már létezik ilyen valuta a listában!");

            Exchanges.Add(exchange);

            return exchange;
        }
    }
}
