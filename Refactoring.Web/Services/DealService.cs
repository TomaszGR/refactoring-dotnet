using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;
using System;

namespace Refactoring.Web.Services
{
   public class DealService : IDealService
   {
      private readonly IRandomHelper _randomHelper;
      public DealService(IRandomHelper randomHelper)
      {
         _randomHelper = randomHelper;
      }

      private const decimal PmRate = 0.1M;
      private const decimal AmRate = 0.05M;

      public decimal GenerateDeal(DateTime dateTime)
      {
         return IsAfternoon(dateTime) ? PmRate : AmRate;
      }
      public string RandomLocalBusiness 
         => _randomHelper.GetRandomValueFromList(BusinessHelper.AllBusinesses);
      private bool IsAfternoon(DateTime dateTime) => dateTime.Hour > 12 && dateTime.Hour < 24;
   }
}