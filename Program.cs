using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{

    public class Program
    {
        class Meet {
            public Int32 dayHour;

            public Meet(Int32 dayHour) {
                this.dayHour = dayHour;
            }
        }

        static Predicate<Meet> createRangePredicate(Int32 start, Int32 end) {
            return meet => start <= meet.dayHour && meet.dayHour <= end;
        }

        static List<Int32> generateMeetings(List<Meet> meets, Int32 start, Int32 end) {
            Predicate<Meet> isInRange = createRangePredicate(start, end);

            return meets
                    .Where(meet => isInRange(meet))
                    .Select(meet => meet.dayHour)
                    .ToList();
        }

        public static void Main(string[] args)
        {
            List<Meet> meetings = new List<Meet>(){
                new Meet(8),
                new Meet(14),
                new Meet(20)
            };
            
           generateMeetings(meetings, 10, 23)
                .ForEach(hour => Console.WriteLine(hour));
        }
    }
}
