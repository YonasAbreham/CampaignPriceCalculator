using BusinessLogics;
using Common.Products;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Service.Controllers
{
    [Route("api/[controller]")]

    public class CampainPriceCalculaterControlller : ControllerBase
    {
        FindCampaignEAN _findCampaignEAN = new FindCampaignEAN();

        [HttpPost("CalculateComboCampaigns")]
        public async Task< ActionResult> GetCalculateComboCampaignPrice([FromBody] List<long> EAN)
        {
            try
            {
                if ( EAN.Count() < 1)
                {
                    return BadRequest();
                }
                else
                {
                    var result = CampaignPriceCalculatorLogic.CalculateByComboCampaignPrice(_findCampaignEAN.ListOfComboCampain(),await _findCampaignEAN.FindListOfCampaignProducts(EAN));
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CalculateVolumeCampaigns")]
        public async Task<ActionResult> GetCalculateCampaignPrice([FromBody] List<long> EAN)
        {
            try
            {
                List<Product> products = new List<Product>();
                if (EAN.Count() < 1)
                {
                    return BadRequest();
                }
                else
                {
                    var result = CampaignPriceCalculatorLogic.CalculateByVolumeCampaignPrice(_findCampaignEAN.ListOfVolumCampain(), await _findCampaignEAN.FindListOfCampaignProducts(EAN));
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
