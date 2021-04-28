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
                //Console.WriteLine(i);
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
            int mid;


            if (low == high)
            {
                return (low, high, array[low]);
            }

            mid = (low + high) / 2;

            Console.WriteLine(mid);

            (int lowLeft, int highLeft, int leftSubSum) = MaxSubarray(array, low, mid);
            (int lowRight, int highRight, int rightSubSum) = MaxSubarray(array, mid + 1, high);
            (int lowCross, int highCross, int sumCross) = CrossSubarray(array, low, mid, high);


            int maxSum = Math.Max(leftSubSum, Math.Max(rightSubSum, sumCross));

            if (maxSum == leftSubSum)
            {
                //Console.WriteLine("left");
                return (lowLeft, highLeft, leftSubSum);
            }

            else if (maxSum == rightSubSum)
            {
                //Console.WriteLine("right");
                return (lowRight, highRight, rightSubSum);
            }

            else if (maxSum == sumCross)
            {
                //Console.WriteLine("cross");
                return (lowCross, highCross, sumCross);
            }

            else
            {
                return (0, 0, 0);
            }

        }

        static void Main()
        {
            int[] testData = new int[] {7, 5, 19, 15, -6, -3, 0, 16, 1, -14};

            Console.WriteLine("[{0}]", string.Join(", ", MaxSubarray(testData, 0, testData.Length-1)));

            //Console.WriteLine("[{0}]", string.Join(", ", CrossSubarray(testData, 0, testData.Length/2, testData.Length-1)));
        }
    }
}
