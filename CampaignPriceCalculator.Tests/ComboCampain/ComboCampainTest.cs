using BusinessLogics;
using Common.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignPriceCalculator.Tests.ComboCampain
{
    public class ComboCampainTest
    {
      
            FindCampaignEAN _findCampaignEAN = new FindCampaignEAN();
         

            [Fact]
            public async Task VolumeCampainForTworDifferentEAN()
            {
                List<long> ean1 = new List<long>() { 5000112637922, 5000112637939 };

                Assert.Equal(30, CampaignPriceCalculatorLogic.CalculateByComboCampaignPrice(_findCampaignEAN.ListOfComboCampain(), await _findCampaignEAN.FindListOfCampaignProducts(ean1)));// No volume purchase

            }

            [Fact]
            public async Task VolumeCampainThreeDifferenEAN()
            {
                List<long> ean2 = new List<long>() { 5000112637922, 5000112637939, 7310865004703 };
                Assert.Equal(80, CampaignPriceCalculatorLogic.CalculateByComboCampaignPrice(_findCampaignEAN.ListOfComboCampain(), await _findCampaignEAN.FindListOfCampaignProducts(ean2)));
            }

            [Fact]
            public async Task VolumeCampainFourdifferentEAN()
            {
                List<long> ean4 = new List<long>() { 5000112637922, 5000112637939, 7310865004703, 7340005404261 };
                Assert.Equal(60, CampaignPriceCalculatorLogic.CalculateByComboCampaignPrice(_findCampaignEAN.ListOfComboCampain(), await _findCampaignEAN.FindListOfCampaignProducts(ean4)));

            }

            [Fact]
            public async Task VolumeCampainFourDifferentAlsoNotCampainPriceEAN()
            {
                List<long> ean3 = new List<long>() { 5000112637922, 5000112637939, 7310865004703, 7000112637937 };
                Assert.Equal(145, CampaignPriceCalculatorLogic.CalculateByComboCampaignPrice(_findCampaignEAN.ListOfComboCampain(), await _findCampaignEAN.FindListOfCampaignProducts(ean3)));

            }
    }
}
