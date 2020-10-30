using FluentAssertions;
using Moq;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;
using Refactoring.Web.Services.Interfaces;
using Refactoring.Web.Services.OrderProcessors;
using System.Threading.Tasks;
using Xunit;

namespace Refactoring.Web.Tests.OrderProcessors
{
   public class TestCambridgeOrderProcessor
   {
      [Fact]
      public async void GivenDateTuesday_ImageUrl_Set_OnOrderAdvert()
      {
         //Arrange
         var testOrder = new Order()
         {
            Id = "foo"
         };

         var fakeChamberOfCommerceApi = new Mock<IChamberOfCommerceApi>();
         var fakeAdvertPrinter = new Mock<IAdvertPrinter>();
         var fakeDateTimeResolver = new Mock<IDateTimeResolver>();

         var fakeDataResult = new DataResult()
         {
            ThumbnailUrl = "http://foo.pl",
            Title = "Title boo"
         };

         fakeChamberOfCommerceApi
            .Setup(m => m.GetImageAndThumbnailDataFor(It.IsAny<string>()))
            .Returns(Task.FromResult(fakeDataResult));

         fakeDateTimeResolver.Setup(m => m.IsItTuesday()).Returns(true);

         var sut = new CambridgeOrderProcessor(
            fakeChamberOfCommerceApi.Object,
            fakeAdvertPrinter.Object,
            fakeDateTimeResolver.Object);

         //Act
         var result = await sut.PrintAdvertAndUpdateOrder(testOrder);

         //Assert
         result.Advert.ImageUrl.Should().Be(fakeDataResult.ThumbnailUrl);

      }
   }
}
