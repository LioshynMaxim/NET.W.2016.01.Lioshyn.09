using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class GreatestCommonDivisor : IAlgorithm
    {
        #region Euclid

        /// <summary>
        /// The Euclidean algorithm calculates the greatest common divisor of two natural numbers a and b.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor of two natural numbers a and b</returns>


        public static int EuclideanAlgorithm(int a, int b)
        {
            if (a < 0 || b < 0) throw new ArgumentOutOfRangeException();
            return b != 0 ? EuclideanAlgorithm(b, a % b) : a;
        }

        /// <summary>
        /// The Euclidean algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="numbInts">Array of natural numbers</param>
        /// <returns>Greatest common divisor of any natural numbers</returns>
        public static int EuclideanAlgorithm(params int[] numbInts)
        {
            int boof = EuclideanAlgorithm(numbInts[0], numbInts[1]);
            for (int i = 2; i <= numbInts.Length - 1; i++)
            {
                boof = EuclideanAlgorithm(boof, numbInts[i]);
            }
            return boof;
        }

        #endregion


        #region SteinAlgorithm

        /// <summary>
        /// The Stein algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor of two natural numbers a and b</returns>

        public static int SteinAlgorithm(int a, int b)
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

        /// <summary>
        /// The Stein algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="numbInts">Array of natural numbers</param>
        /// <returns>Greatest common divisor of any natural numbers</returns>

        public static int SteinAlgorithm(params int[] numbInts)
        {
            int boof = SteinAlgorithm(numbInts[0], numbInts[1]);
            for (int i = 2; i <= numbInts.Length - 1; i++)
            {
                boof = SteinAlgorithm(boof, numbInts[i]);
            }
            return boof;
        }

        #endregion

        #region TimeFunction

        /// <summary>
        /// Time execution function
        /// </summary>
        /// <param name="algorithm">Interface for algorithm</param>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Time execution</returns>

        public static string ExecutionTimeOfAlgorithm(IAlgorithm algorithm, int a, int b)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            algorithm.Algorithm(a, b);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            return $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
        }

        #endregion

        public int Algorithm(params int[] numbInts)
        {
            throw new NotImplementedException();
        }
    }
}

