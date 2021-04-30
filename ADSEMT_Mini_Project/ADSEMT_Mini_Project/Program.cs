using System;

namespace ADSEMT_Mini_Project
{
    class Program
    {
         private static (int, int, int) CrossSubarray (int[] array, int low, int mid, int high)
        {
            int leftSum = Int32.MinValue;
            int rightSum = Int32.MinValue;
            int sum = 0;
            int maxLeftIndex = 0;
            int maxRightIndex = 0;

            for(int i = mid; i >= low; i--)
            {
                sum += array[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeftIndex = i;
                }
            }
            sum = 0;
            for (int i = mid+1; i <= high; i++)
            {
                sum += array[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRightIndex = i;
                }
            }
            return (maxLeftIndex, maxRightIndex, leftSum + rightSum);
        }

        private static (int, int, int) MaxSubarray(int[] array, int low, int high)
        {
            if (low == high)
            {
                return (low, high, array[low]);
            }
            int mid = (low + high) / 2;

            (int lowLeft, int highLeft, int leftSubSum) = MaxSubarray(array, low, mid);
            (int lowRight, int highRight, int rightSubSum) = MaxSubarray(array, mid + 1, high);
            (int lowCross, int highCross, int sumCross) = CrossSubarray(array, low, mid, high);

            int maxSum = Math.Max(leftSubSum, Math.Max(rightSubSum, sumCross));

            if (maxSum == leftSubSum)
            {
                return (lowLeft, highLeft, leftSubSum);
            }
            else if (maxSum == rightSubSum)
            {
                return (lowRight, highRight, rightSubSum);
            }
            else if (maxSum == sumCross)
            {
                return (lowCross, highCross, sumCross);
            }
            else return (0, 0, 0);
        }

        private static (int, int, int) KadaneAlgorithm(int[] array, int arraySize)
        {
            int maxSoFar = 0;
            int maxEnd = 0;
            int indexStart = 0;
            int indexEnd = 0;

            for (int i = 0; i < arraySize; i++)
            {
                maxEnd = maxEnd + array[i];
                if (maxEnd < 0)
                {
                    indexStart = i + 1;
                    maxEnd = 0;
                }
                else if (maxSoFar < maxEnd)
                {
                    indexEnd = i;
                    maxSoFar = maxEnd;
                }
            }
            return (indexStart, indexEnd, maxSoFar);
        }

        static void Main()
        {
            int[] testData = new int[1000]; // Change number to test different n

            Random randNum = new Random();
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = randNum.Next(-100, 100); // testData contains randomly generated numbers from -100 to 100
            }

            Console.WriteLine("Divide-and-conquer method (i, j, sum):"); // i and j denote the delimitation of the array
            Console.WriteLine("[{0}]", string.Join(", ", MaxSubarray(testData, 0, testData.Length - 1)));

            Console.WriteLine("Kanade's algorithm (i, j, sum):"); // i and j denote the delimitation of the array
            Console.WriteLine("[{0}]", string.Join(", ", KadaneAlgorithm(testData, testData.Length)));
        }
    }
}
