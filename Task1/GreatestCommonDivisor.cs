using System;
using System.Diagnostics;

namespace Task1
{
    public class GreatestCommonDivisor : IAlgorithm
    {
        #region Auxiliary fynction

        /// <summary>
        /// The Euclidean algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="numbInts">Array of natural numbers</param>
        /// <returns>Greatest common divisor of any natural numbers</returns>

        public int EuclidGCD(params int[] numbInts)
        {
            return CommonAlgorithm(new EuclideanAlgorithmInterface(), numbInts);
        }

        /// <summary>
        /// The Stein algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="numbInts">Array of natural numbers</param>
        /// <returns>Greatest common divisor of any natural numbers</returns>

        public int SteinGCD(params int[] numbInts)
        {
            return CommonAlgorithm(new SteinAlgorithmInterface(), numbInts);
        }

        #endregion


        #region CommonAlgorithm

        /// <summary>
        /// The Euclidean or Stein algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="algorithm">Name for algorithm</param>
        /// <param name="numbInts">Array of natural numbers</param>
        /// <returns>Greatest common divisor of any natural numbers</returns>
        private int CommonAlgorithm(IAlgorithm algorithm, params int[] numbInts)
        {
            int boof = algorithm.Algorithm(numbInts[0], numbInts[1]);
            for (int i = 2; i <= numbInts.Length - 1; i++)
            {
                boof = algorithm.Algorithm(boof, numbInts[i]);
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

        public string ExecutionTimeOfAlgorithm(IAlgorithm algorithm, int a, int b)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            algorithm.Algorithm(a, b);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            return $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
        }

        #endregion

        public int Algorithm(int a, int b)
        {
            throw new NotImplementedException();
        }

        
    }
    public class EuclideanAlgorithmInterface : IAlgorithm
    {
        /// <summary>
        /// The Euclidean algorithm calculates the greatest common divisor of two natural numbers a and b.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor of two natural numbers a and b</returns>

        public int Algorithm(int a, int b)
        {
            if (a < 0 || b < 0) throw new ArgumentOutOfRangeException();
            return b != 0 ? Algorithm(b, a % b) : a;
        }
    }

    public class SteinAlgorithmInterface : IAlgorithm
    {
        /// <summary>
        /// The Stein algorithm calculates the greatest common divisor of any natural numbers.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor of two natural numbers a and b</returns>

        public int Algorithm(int a, int b)
        {
            if (a < 0 || b < 0) throw new ArgumentOutOfRangeException();
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * Algorithm(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return Algorithm(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return Algorithm(a, b / 2);
            return Algorithm(b, Math.Abs(a - b));
        }
    }
}

