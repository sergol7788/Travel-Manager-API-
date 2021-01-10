using Hotel.API.Extension;
using Hotel.API.SecretManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SearchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
         


        /// <summary>
        /// Method for object searching near geo-point
        /// </summary>
        /// <param name="latitude">search point latitude</param>
        /// <param name="longitude">search point longitude</param>
        /// <param name="searchItem">string representation of the search item. Default value: "hotel"</param>
        /// <param name="languageCode">Language code. Default value: "en-US"</param>
        /// <returns>Returns third party API result</returns>
        [HttpGet] 
        public  async Task<ActionResult>   SearchObjectsAtPoint(double latitude,
                                                              double longitude,
                                                              string searchItem = "hotel",
                                                              string languageCode = "en-US")
        {
             var secretKey = _configuration["HEREKEY"];
            

           
             var endpoint = String.Format(_configuration["SearchEndPoint"],
                                         latitude,
                                         longitude,
                                         searchItem,
                                         languageCode,
                                         secretKey);

           

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(endpoint);

                try
                {
                    var jsonString = await result.Content.ReadAsStringAsync();
                    return Content(jsonString);
                }
                catch 
                {

                   return NotFound();
                }
            }
            
           

        }
          

      
    }
}
