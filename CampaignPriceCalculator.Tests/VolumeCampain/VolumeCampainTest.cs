using BusinessLogics;
using Common.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignPriceCalculator.Tests.VolumeCampain
{
    public class VolumeCampainTest
    {
        FindCampaignEAN _findCampaignEAN = new FindCampaignEAN();

        [Fact]
        public async Task VolumeCampainForTworDifferentEAN()
        {
            List<long> ean1 = new List<long>() { 8711000530085, 7310865004703 };

            Assert.Equal(90, CampaignPriceCalculatorLogic.CalculateByVolumeCampaignPrice(_findCampaignEAN.ListOfVolumCampain(),await _findCampaignEAN.FindListOfCampaignProducts(ean1)));// No volume purchase
            
        }

        [Fact]
        public async Task VolumeCampainTwoSameEAN()
        {
            List<long> ean2 = new List<long>() { 8711000530085, 8711000530085 };            
            Assert.Equal(85, CampaignPriceCalculatorLogic.CalculateByVolumeCampaignPrice(_findCampaignEAN.ListOfVolumCampain(), await _findCampaignEAN.FindListOfCampaignProducts(ean2)));            
        }        

        [Fact]
        public async Task VolumeCampainFourSameEAN()
        {
            List<long> ean3 = new List<long>() { 8711000530085, 8711000530085, 8711000530085, 8711000530085 };
            Assert.Equal(85 * 2, CampaignPriceCalculatorLogic.CalculateByVolumeCampaignPrice(_findCampaignEAN.ListOfVolumCampain(), await _findCampaignEAN.FindListOfCampaignProducts(ean3)));
           
        }

        [Fact]
        public async Task VolumeCampainTwoSameandOneDifferentEAN()
        {
            List<long> ean5 = new List<long>() { 8711000530085, 8711000530085, 7310865004703 };
            Assert.Equal(135, CampaignPriceCalculatorLogic.CalculateByVolumeCampaignPrice(_findCampaignEAN.ListOfVolumCampain(), await _findCampaignEAN.FindListOfCampaignProducts(ean5)));
        }
    }
}
