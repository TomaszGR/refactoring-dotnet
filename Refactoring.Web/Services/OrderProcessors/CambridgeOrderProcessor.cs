using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class CambridgeOrderProcessor : OrderProcessor
   {
      private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
      private readonly IAdvertPrinter _advertPrinter;
      private readonly IDateTimeResolver _dateTimeResolver;

      public CambridgeOrderProcessor(IChamberOfCommerceApi chamberOfCommerceApi, IAdvertPrinter advertPrinter, IDateTimeResolver dateTimeResolver)
      {
         _chamberOfCommerceApi = chamberOfCommerceApi;
         _advertPrinter = advertPrinter;
         _dateTimeResolver = dateTimeResolver;
      }

      public override async Task<Order> PrintAdvertAndUpdateOrder(Order order)
      {
         var advert = new Advert
         {
            CreatedOn = DateTime.Now,
            Heading = "Cambridge Bakery",
            Content = "Custom Birthday and Wedding Cakes"
         };
         if (_dateTimeResolver.IsItTuesday())
         {
            var result = await _chamberOfCommerceApi.GetImageAndThumbnailDataFor("Middleton");
            advert.ImageUrl = result.ThumbnailUrl;
         }
         order.Advert = advert;
         _advertPrinter.Print(advert, false);
         order.Status = "Complete";

         return order;
      }
   }
}
