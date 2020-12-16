using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            if (!ValidateFavorite(favorite))
            {
                throw new ValidationException("Hiba a név hosszában");
            }
            if (!ValidateValue(value))
            {
                throw new ValidationException("Hiba az érték nagyságában");
            }


            var exchange = new RateData()
            {
                Currency = favorite,
                Value = value
            };

            var newExchange = ExchangeManager.CreateExchange(exchange);
            return newExchange;
        }
        public bool ValidateFavorite(string favorite)
        {
            bool decision = true;
            if (favorite.Length > 3)
            {
                decision = false;
            }
            if (favorite=="")
            {
                decision = false;
            }

            return decision;
        }
        public bool ValidateValue(decimal value)
        {
            bool decision = true;
            if (value<0)
            {
                decision = false;
            }
            else if (value>1000)
            {
                decision = false;
            }
            

            return decision;
        }
    }
}
