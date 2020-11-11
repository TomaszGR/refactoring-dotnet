using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class DowntownOrderProcessor : OrderProcessor
   {
      private readonly IAdvertPrinter _advertPrinter;
      private readonly IDateTimeResolver _dateTimeResolver;

      public DowntownOrderProcessor(IAdvertPrinter advertPrinter, IDateTimeResolver dateTimeResolver)
      {
         _advertPrinter = advertPrinter;
         _dateTimeResolver = dateTimeResolver;
      }

      public override async Task<Order> PrintAdvertAndUpdateOrder(Order order)
      {
         if (_dateTimeResolver.IsItWeekend())
         {
            _advertPrinter.PrintDefault(null);
         }
         var advert = new Advert
         {
            Heading = "Downtown Coffee Roasters",
            CreatedOn = DateTime.Now,
            Content = "Get a free coffee drink when you buy 1lb of coffee beans"
         };
         order.Advert = advert;
         _advertPrinter.PrintCustom(advert);

         return order;
      }
   }
}
