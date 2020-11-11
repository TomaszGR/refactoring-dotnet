using Refactoring.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.Helpers
{
   public class DateTimeResolver : IDateTimeResolver
   {
      public bool IsItTuesday()
      {
         return DateTime.Now.DayOfWeek == DayOfWeek.Tuesday;
      }

      public bool IsItWeekend()
      {
         var weekendDays = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday};
         return weekendDays.Contains(DateTime.Now.DayOfWeek);
      }

   }
}
