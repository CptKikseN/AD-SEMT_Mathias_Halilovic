using System;

namespace ADSEMT_Mini_Project
{
    class Program
    {
        static int[] testData = new int[] {-14, 20, 1, 17, 11, -15, 4, 3, 0, 12, -19, 7, 9, 4, 13, 16, 4, 13, 16, 4, -5};


         private static (int, int, int) CrossSubarray (int[] array, int low, int mid, int high)
        {
            int[] returnArray = new int[3];
            int leftSum = 0;
            int rightSum = 0;
            int sum = 0;
            int maxLeftIndex = 0;
            int maxRightIndex = 0;

            for(int i = mid; mid >= low; i--)
            {
                sum =+ array[i];

                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeftIndex = i;
                }
            }

            sum = 0;

            for (int i = mid+1; mid <= high; i++)
            {
                sum =+ array[i];

                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRightIndex = i;
                }
            }

            return (maxLeftIndex, maxRightIndex, leftSum + rightSum);
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine("[{0}]", string.Join(", ", testData));
        }
    }
}
