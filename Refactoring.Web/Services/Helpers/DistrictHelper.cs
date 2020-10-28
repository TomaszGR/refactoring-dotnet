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
         public static string Cambridge { get => "Cambridge"; }
         public static string Downtown => "Downtown";
         public static string Country => "Country";
         public static string Czaple => "Czaple";

         public static IEnumerable<string> StandardDistricts => new List<string> { Cambridge, Downtown, Country, Czaple };
      }
   }
}
