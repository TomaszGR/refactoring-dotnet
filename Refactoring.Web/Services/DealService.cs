using Refactoring.Web.Services.Interfaces;
using System;

namespace Refactoring.Web.Services
{
   public class DealService : IDealService
   {
      public static decimal PmRate => 0.1M;
      public decimal AmRate => 0.05M;

      public decimal GenerateDeal(DateTime dateTime)
      {
         return IsAfternoon(dateTime) ? PmRate : AmRate;
      }

      private bool IsAfternoon(DateTime dateTime) => dateTime.Hour > 12 && dateTime.Hour < 24;
   }
}