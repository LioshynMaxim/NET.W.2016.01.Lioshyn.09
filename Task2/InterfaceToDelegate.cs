using System;
using System.Collections.Generic;

namespace Task2
{
    public class InterfaceToDelegate
    {
        /// <summary>
        /// Public sorting function, then accept Interface.
        /// </summary>
        /// <param name="matrixInts">Array for sorting.</param>
        /// <param name="compareArg">Interface IComparer arrays</param>

        public static void Sort(int[][] matrixInts, IComparer<int[]> compareArg)
        {
            IComparer<int[]> arg = compareArg;

            if (arg == null)
                throw new ArgumentNullException();

            DelegateToInterface.CompareDelegate compare = arg.Compare;
            Sort(matrixInts, compare);
        }

        /// <summary>
        /// Public sorting function, then accept Delegate.
        /// </summary>
        /// <param name="matrixInts">Array for sorting.</param>
        /// <param name="delegateCompareArg">Delegate</param>

        private static void Sort(int[][] matrixInts, DelegateToInterface.CompareDelegate delegateCompareArg)
        {
            for (int i = 0; i < matrixInts.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrixInts.GetLength(0); j++)
                {
                    if (delegateCompareArg(matrixInts[i], matrixInts[j]) > 0)
                        Swap(ref matrixInts[i], ref matrixInts[j]);
                }
            }
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
    }
}