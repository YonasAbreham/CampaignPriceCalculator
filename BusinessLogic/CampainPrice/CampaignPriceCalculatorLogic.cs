using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public class CampaignPriceCalculatorLogic
    {
        public  static decimal CalculateByComboCampaignPrice(ComboCampaign cpn,  List<Product> products)
        {
            decimal price = 0;

            var campaignProds = products.Where(p => cpn.Products.Any(p1 => p.EAN == p1)).ToList();

            var noOfPairs = campaignProds.Count / 2;
            price += noOfPairs * cpn.CampaignPrice;

            if (campaignProds.Count % 2 != 0)
            {
                price += campaignProds.Last().Price;

            }

            price += products.Except(campaignProds).Select(p => p.Price).Sum();

            return price;
        }

        /*
        public static decimal CalculatePrice(ComboCampaign cpn, List<Product> products)
        {
            decimal price = 0;

            var distinctCampaignProds = products.Where(p => cpn.Products.Any(p1 => p.EAN == p1)).Distinct().ToList();

            var noOfPairs = distinctCampaignProds.Count / 2;
            price += noOfPairs * cpn.CampaignPrice;

            if (distinctCampaignProds.Count % 2 != 0)
            {
                price += distinctCampaignProds.Last().Price;

            }

            //price += products.Except(distinctCampaignProds).Select(p => p.Price).Sum();

            foreach (var product in products)
            {
                if (!distinctCampaignProds.Any(p2 => p2 == product))
                    price += product.EAN;
            }

            return price;
        }
        */

        public static decimal CalculateByVolumeCampaignPrice(VolumeCampaign cpn, List<Product> products)
        {
            decimal price = 0;

            var groups = products.GroupBy(p => p.EAN);

            foreach (var group in groups)
            {
                VolumePrice? volumePrice = cpn.VolumePrices.SingleOrDefault(v => v.EAN == group.Key);

                if (volumePrice == null || group.Count() < volumePrice.MinimumItems)
                {
                    price += group.Select(p => p.Price).Sum();
                    continue;
                }

                var noOfBatches = group.Count() / volumePrice.MinimumItems;
                price += noOfBatches * volumePrice.Price;
            }

            return price;
        }

    }
}
