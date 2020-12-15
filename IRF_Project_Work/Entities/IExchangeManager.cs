using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project_Work.Entities
{
    public interface IExchangeManager
    {
         BindingList<RateData> Exchanges { get; }
        RateData CreateExchange(RateData exchange);
    }
}
