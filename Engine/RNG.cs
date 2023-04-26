using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Engine
{
    public static class RNG
    {
        private static RNGCryptoServiceProvider _random = new RNGCryptoServiceProvider();
        public static int numberBetween(int minValue, int maxValue)
        {
            byte[] randomNumber = new byte[1];
            _random.GetBytes(randomNumber);
            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
            // using Math.Max, and substracting 0.00000000001,
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            //
            // add 1 to the range to allow for the rounding done with Math.Floor
            int range = maxValue - minValue + 1;
            double rdmValueInRange = Math.Floor(multiplier * range);
            return (int)(minValue + rdmValueInRange);
        }
    }
}
