using FluentAssertions;
using Refactoring.Web.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Refactoring.Tests.Tests.Services.Helpers
{
   public class TestDealService
   {
      [Fact]
      public void GivenMoringDateTime_GenerateDeal_Returns_AmRate()
      {
         var sut = new DealService();
         var morinngTime = new DateTime(2020, 10, 10, 10, 10, 10);
         decimal amRate = sut.AmRate;

         var generatedDateRate = sut.GenerateDeal(morinngTime);

         generatedDateRate.Should().Be(amRate);
      }

      [Fact]
      public void GivenMoringDateTime_GenerateDeal_Returns_PmRate()
      {
         var sut = new DealService();
         var afternoonTime = new DateTime(2020, 10, 10, 22, 10, 10);
         decimal pmRate = DealService.PmRate;

         var generatedDateRate = sut.GenerateDeal(afternoonTime);

         generatedDateRate.Should().Be(pmRate);
      }

   }
}
