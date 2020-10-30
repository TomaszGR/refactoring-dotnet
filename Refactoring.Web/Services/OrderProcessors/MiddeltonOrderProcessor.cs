using Refactoring.Web.DomainModels;
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

      public MiddeltonOrderProcessor(IChamberOfCommerceApi chamberOfCommerceApi, IAdvertPrinter advertPrinter, IDealService dealService)
      {
         _chamberOfCommerceApi = chamberOfCommerceApi;
         _advertPrinter = advertPrinter;
         _dealService = dealService;
      }

      public override async Task<Order> PrintAdvertAndUpdateOrder(Order order)
      {
         var biz = _dealService.GetRandomLocalBusiness();
         var deal = _dealService.GenerateDeal(DateTime.Now);
         var result = await _chamberOfCommerceApi.GetImageAndThumbnailDataFor("Middleton");
         var advert = new Advert
         {
            CreatedOn = DateTime.Now,
            Heading = "Middleton " + biz,
            Content = "Get " + deal * 100 + "Percent off your next purchase!",
            ImageUrl = result.ThumbnailUrl
         };
         order.Advert = advert;
         _advertPrinter.Print(advert, false);
         order.Status = "Complete";

         return order;
      }
   }
}
