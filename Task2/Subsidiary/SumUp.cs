using System.Collections.Generic;
using System.Linq;

namespace Task2.Subsidiary
{
    public class SumUp : IComparer<int[]>
    {
        /// <summary>
        /// Sort the array in ascending amounts of rows
        /// </summary>
        /// <param name="array1">First sz array</param>
        /// <param name="array2">Second sz array</param>
        /// <returns>The difference between the sums of the rows of arrays</returns>

        public int Compare(int[] array1, int[] array2)
        {
            if (ReferenceEquals(array1, null))
                return 1;
            if (ReferenceEquals(array2, null))
                return -1;
            return array1.Sum() - array2.Sum();
        }
    }
}