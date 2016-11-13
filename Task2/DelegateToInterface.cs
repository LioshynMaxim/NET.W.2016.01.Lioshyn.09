using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class DelegateToInterface
    {

        /// <summary>
        /// Delegate for sorting with original signature.
        /// </summary>
        /// <param name="array1">First integer matrixInts.</param>
        /// <param name="array2">Second integer matrixInts.</param>
        /// <returns>Returns a value indicating whether one is less than, equal to, or greater than the other.</returns>
        public delegate int CompareDelegate(int[] array1, int[] array2);

        /// <summary>
        /// Private sorting function, then accept Interface.
        /// </summary>
        /// <param name="matrixInts">Array for sorting.</param>
        /// <param name="compareArg">Interface IComparer arrays</param>

        private static void Sort(int[][] matrixInts, IComparer<int[]> compareArg)
        {
            for (int i = 0; i < matrixInts.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrixInts.GetLength(0); j++)
                {
                    if (compareArg.Compare(matrixInts[i], matrixInts[j]) > 0)
                        Swap(ref matrixInts[i], ref matrixInts[j]);
                }
            }
        }

        /// <summary>
        /// Public sorting function, then accept Delegate.
        /// </summary>
        /// <param name="matrixInts">Array for sorting.</param>
        /// <param name="delegateCompareArg">Delegate</param>

        public static void Sort(int[][] matrixInts, CompareDelegate delegateCompareArg)
        {
            IComparer<int[]> compareArg = delegateCompareArg.Target as IComparer<int[]>;

            if (compareArg == null)
                throw new ArgumentNullException();

            Sort(matrixInts, compareArg);
        }

        /// <summary>
        /// Change settings
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        #region Other function

        /// <summary>
        /// Sorting an array of descending amounts lines
        /// </summary>
        /// <param name="array1">First sz array</param>
        /// <param name="array2">Second sz array</param>
        /// <returns>The difference between the sums of the rows of arrays</returns>

        public static int SumDown(int[] array1, int[] array2)
        {
            if (ReferenceEquals(array1, null))
                return 1;
            if (ReferenceEquals(array2, null))
                return -1;
            return array2.Sum() - array1.Sum();
        }

        #endregion
    }
}