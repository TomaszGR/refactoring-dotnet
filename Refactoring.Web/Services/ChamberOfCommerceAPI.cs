using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Refactoring.Web.Services.Interfaces;
using static Refactoring.Web.Services.Helpers.DistrictHelper;

namespace Refactoring.Web.Services
{
   public class ChamberOfCommerceApi : IChamberOfCommerceApi
   {
      private readonly IConfiguration _config;

      public ChamberOfCommerceApi(IConfiguration config)
      {
         _config = config;
      }

      /// <summary>
      /// For the provided 'district' return the DataResult objest cintaining
      /// the id, thumbnail url, and title for the sistrict's image
      /// </summary>
      /// <param name="district"></param>
      /// <returns></returns>
      public async Task<DataResult> GetImageAndThumbnailDataFor(string district)
      {
         using var client = new HttpClient();
         var request = new HttpRequestMessage(HttpMethod.Get, BuidUrlForDistrict(district));
         var response = client.SendAsync(request);
         var data = await response.Result.Content.ReadAsStringAsync();
         var result = JsonConvert.DeserializeObject<DataResult>(data);
         return result;
      }

      private Uri BuidUrlForDistrict(string district)
      {
         var districtId = District.GetDistrictNumberByName(district);
         var urlBasePhoto = new Uri(_config.GetValue<string>("BasePhotoUrl"));
         return new Uri(urlBasePhoto + districtId.ToString());

      }
   }

   public struct DataResult {
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
    }
}