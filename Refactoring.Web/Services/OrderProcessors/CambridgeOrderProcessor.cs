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

      public CambridgeOrderProcessor(IChamberOfCommerceApi chamberOfCommerceApi, IAdvertPrinter advertPrinter)
      {
         _chamberOfCommerceApi = chamberOfCommerceApi;
         _advertPrinter = advertPrinter;
      }

      public override async Task<Order> PrintAdvertAndUpdateOrder(Order order)
      {
         var advert = new Advert();
         advert.CreatedOn = DateTime.Now;
         advert.Heading = "Cambridge Bakery";
         advert.Content = "Custom Birthday and Wedding Cakes";
         if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
         {
            var result = await _chamberOfCommerceApi.GetFor("Middleton");
            advert.ImageUrl = result.ThumbnailUrl;
         }
         order.Advert = advert;
         _advertPrinter.Print(advert, false);
         order.Status = "Complete";

         return order;
      }
   }
}
