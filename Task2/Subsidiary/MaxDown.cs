using System.Collections.Generic;
using System.Linq;

namespace Task2.Subsidiary
{
    public class MaxDown : IComparer<int[]>
    {
        /// <summary>
        /// Sort the array in descending max elements in rows
        /// </summary>
        /// <param name="array1">First sz array</param>
        /// <param name="array2">Second sz array</param>
        /// <returns>The difference between the max elements in row</returns>
        public int Compare(int[] array1, int[] array2)
        {
            if (ReferenceEquals(array1, null))
                return 1;
            if (ReferenceEquals(array2, null))
                return -1;
            return array2.Max() - array1.Max();
        }
    }
}