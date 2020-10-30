using System.Collections.Generic;

namespace Refactoring.Web.Services.Helpers
{
   public static class BusinessHelper
   {
      public static string Babershop => "Babershop";
      public static string Bakery => "Bakery";
      public static string ShoeStore => "Shoe Store";
      public static string PizzaPlace => "Pizza Place";
      public static string Diner => "Diner";
      public static string AutoRepair => "Auto Repair";
      public static string Pharmacy => "Pharmacy";
      public static string Grocery => "Grocery";

      public static HashSet<string> AllBusinesses => new HashSet<string>
      {
         Babershop,
         Bakery,
         ShoeStore,
         PizzaPlace,
         Diner,
         AutoRepair,
         Pharmacy,
         Grocery
      };

   }
}
