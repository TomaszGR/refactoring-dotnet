using Refactoring.Web.DomainModels;

namespace Refactoring.Web.Services.Interfaces
{
   public interface IAdvertPrinter
   {
      void PrintCustom(Advert advert);
      void PrintDefault(Advert advert);

   }
}