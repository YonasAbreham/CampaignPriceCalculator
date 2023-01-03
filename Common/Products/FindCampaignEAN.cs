using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Products
{
    public class FindCampaignEAN
    {
        List<Product> prods = new List<Product>() {
           new Product(){ EAN = 5000112637922,Price = 40},
           new Product(){ EAN = 5000112637939, Price = 45 },
           new Product() { EAN = 7310865004703,Price = 50},
           new Product(){ EAN = 7340005404261,Price = 55 },
           new Product() {EAN = 7000112637937,Price = 65 }, 
            new Product(){ EAN = 8711000530085,Price = 40},
           new Product(){ EAN = 7310865004703, Price = 50 },
           new Product() { EAN = 55345112637937,Price = 65}
        };
        

        List<Product> products = new List<Product>();

        public async Task<List<Product>> FindListOfCampaignProducts( List<long> EAN)
        {
           
            foreach (var ean in EAN)
            {
                var campaignProds = prods.Where(a => a.EAN == ean).FirstOrDefault();
                products.Add(campaignProds);
            }
            return  await Task.FromResult(products);
        }

        public  ComboCampaign ListOfComboCampain()
        {
            ComboCampaign comboCampaign = new ComboCampaign
            {
                Products = new long[]
            {
                    5000112637922,
                    5000112637939,
                    7310865004703,
                    7340005404261,
                    7310532109090,
                    7611612222105
            },
                CampaignPrice = 30
            };

            return comboCampaign;
        }

        public VolumeCampaign ListOfVolumCampain()
        {
            VolumeCampaign volumeCampaign = new VolumeCampaign
            {
                VolumePrices = new VolumePrice[]
               {
                  new VolumePrice
                  {
                      EAN = 8711000530085,
                      Price = 85,
                      MinimumItems = 2
                  },
                  new VolumePrice
                  {
                      EAN = 7310865004703,
                      Price = 20,
                      MinimumItems = 2
                  },
               }
            };

            return volumeCampaign;
        }


    }
}
