using System;
using System.Diagnostics;

namespace Task1
{
    public static class GreatestCommonDivisorDelegat
    {

        /// <summary>
        /// Delegate for function
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Integer number</returns>

        public delegate int AlgorithmDelegate(int a, int b);

        #region Auxiliary fynction

        /// <summary>
        /// The Euclidean algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="numbInts">Array of natural numbers</param>
        /// <returns>Greatest common divisor of any natural numbers</returns>

        public static int EuclidGCD(params int[] numbInts)
        {
            return CommonAlgorithm(EuclidAlgorithm, numbInts);
        }

        /// <summary>
        /// The Stein algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="numbInts">Array of natural numbers</param>
        /// <returns>Greatest common divisor of any natural numbers</returns>

        public static int SteinGCD(params int[] numbInts)
        {
            return CommonAlgorithm(SteinAlgorithm, numbInts);
        }

        #endregion
        
        #region EuclidAlgorithm

        /// <summary>
        /// The Euclidean algorithm calculates the greatest common divisor of two natural numbers a and b.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor of two natural numbers a and b</returns>

        private static int EuclidAlgorithm(int a, int b)
        {
            if (a < 0 || b < 0) throw new ArgumentOutOfRangeException();
            return b != 0 ? EuclidAlgorithm(b, a % b) : a;
        }

        #endregion

        #region SteinAlgorithm

        /// <summary>
        /// The SteinAlgorithm algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor of two natural numbers a and b</returns>
        private static int SteinAlgorithm(int a, int b)
        {
            if (a < 0 || b < 0) throw new ArgumentOutOfRangeException();
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * SteinAlgorithm(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return SteinAlgorithm(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return SteinAlgorithm(a, b / 2);
            return SteinAlgorithm(b, Math.Abs(a - b));
        }

        #endregion

        #region CommonAlgorithm

        /// <summary>
        /// The Euclidean or SteinAlgorithm algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="algorithmDelegate">Delegate algorithm</param>
        /// <param name="numbInts">Array of natural numbers</param>
        /// <returns>Greatest common divisor of any natural numbers</returns>

        private static int CommonAlgorithm(AlgorithmDelegate algorithmDelegate, params int[] numbInts)
        {
            int boof = algorithmDelegate(numbInts[0], numbInts[1]);
            for (int i = 2; i <= numbInts.Length - 1; i++)
            {
                boof = algorithmDelegate(boof, numbInts[i]);
            }
            return boof;
        }

        #endregion


        #region TimeFunction

        /// <summary>
        /// Time execution function
        /// </summary>
        /// <param name="algorithmDelegate">Delegate algorithm</param>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Time execution</returns>
        public static string ExecutionTimeOfAlgorithm(AlgorithmDelegate algorithmDelegate, int a, int b)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            algorithmDelegate(a, b);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            return $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
        }

        #endregion
    }
}
