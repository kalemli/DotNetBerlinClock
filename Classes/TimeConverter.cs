using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            string[] times = aTime.Split(':');
            int hours = int.Parse(times[0]);
            int minutes = int.Parse(times[1]);
            int seconds = int.Parse(times[2]);

            var clock = seconds % 2 == 0 ? "Y" : "O";

            // First row
            int _5hours = hours / 5;
            clock += Environment.NewLine +
                new string('R', _5hours) + new string('O', 4 - _5hours);

            // Second row
            int _1hours = hours % 5;
            clock += Environment.NewLine +
                new string('R', _1hours) + new string('O', 4 - _1hours);

            // Third row
            int _5minutes = minutes / 5;

            StringBuilder _3rdRow = new StringBuilder(
                new string('Y', _5minutes) + 
                new string('O', 11 - _5minutes));
            _3rdRow[2] = _3rdRow[2] == 'Y' ? 'R' : _3rdRow[2];
            _3rdRow[5] = _3rdRow[5] == 'Y' ? 'R' : _3rdRow[5];
            _3rdRow[8] = _3rdRow[8] == 'Y' ? 'R' : _3rdRow[8];
            clock += Environment.NewLine + _3rdRow;

            // Fourth row
            int _1minutes = minutes % 5;
            clock += Environment.NewLine +
                new string('Y', _1minutes) + new string('O', 4 - _1minutes);

            return clock.ToString();
        }
    }
}
