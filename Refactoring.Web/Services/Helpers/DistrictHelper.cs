using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

         public static IEnumerable<string> StandardDistricts => new List<string> { Cambridge, Downtown, County, Middleton };
      }
   }
}
