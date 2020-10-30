using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using System;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class DowntownOrderProcessor
   {
      private readonly IAdvertPrinter _advertPrinter;

      public DowntownOrderProcessor(IAdvertPrinter advertPrinter)
      {
         _advertPrinter = advertPrinter;
      }

      public Order PrintAdvertAndUpdateOrder(Order order)
      {
         if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
         {
            _advertPrinter.Print(null, true);
         }
         var advert = new Advert
         {
            Heading = "Downtown Coffee Roasters",
            CreatedOn = DateTime.Now,
            Content = "Get a free coffee drink when you buy 1lb of coffee beans"
         };
         order.Advert = advert;
         _advertPrinter.Print(advert, false);

         return order;
      }
   }
}
