using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class MiddeltonOrderProcessor : OrderProcessor
   {
      private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
      private readonly IAdvertPrinter _advertPrinter;
      private readonly IDealService _dealService;
      private readonly IRandomHelper _randomHelper;

      public MiddeltonOrderProcessor(IChamberOfCommerceApi chamberOfCommerceApi
         , IAdvertPrinter advertPrinter
         , IDealService dealService
         , IRandomHelper randomHelper )
      {
         _chamberOfCommerceApi = chamberOfCommerceApi;
         _advertPrinter = advertPrinter;
         _dealService = dealService;
         _randomHelper = randomHelper;
      }

      public override async Task<Order> PrintAdvertAndUpdateOrder(Order order)
      {
         var deal = _dealService.GenerateDeal(DateTime.Now);
         //var biz = _dealService.RandomLocalBusiness;
         var biz = _randomHelper.GetRandomValueFromList(BusinessHelper.AllBusinesses);

         var result = await _chamberOfCommerceApi.GetImageAndThumbnailDataFor("Middleton");
         var advert = new Advert
         {
            CreatedOn = DateTime.Now,
            Heading = "Middleton " + biz,
            Content = "Get " + deal * 100 + "Percent off your next purchase!",
            ImageUrl = result.ThumbnailUrl
         };
         order.Advert = advert;
         _advertPrinter.PrintCustom(advert);
         order.Status = "Complete";

         return order;
      }
   }
}
