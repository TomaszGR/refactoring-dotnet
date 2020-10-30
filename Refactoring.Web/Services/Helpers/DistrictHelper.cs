using System.Collections.Generic;

namespace Refactoring.Web.Services.Helpers
{
   public class DistrictHelper
   {
      public static class District
      {
         //expression-bodied properties
         public static string Cambridge { get => "cambridge"; }
         public static string Middleton => "middleton";
         public static string County => "county";
         public static string Downtown => "downtown";

         private static int DowntownId => 42;
         private static int CountyId => 18;
         private static int MiddletonId => 23;
         private static int CambridgeId => 11;

         public static IEnumerable<string> StandardDistricts => new List<string> { Cambridge, Downtown, County, Middleton };

         public static int GetDistrictNumberByName(string district)
         {
            var districtLookup = new Dictionary<string, int>() {
                {Downtown,    DowntownId},
                {County,      CountyId},
                {Middleton,   MiddletonId},
                {Cambridge,   CambridgeId}
            };

            return districtLookup[district];
         }
      }
   }
}
