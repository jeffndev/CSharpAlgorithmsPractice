using System;
using System.Diagnostics;
using System.Linq;

namespace AlgPractice
{
    class MyQuickSort
    {
        public static void QuickSort(ref int[] arr, int N)
        {
            int piv = N > 0 ? arr[N - 1] : 0;
            if(N > 1)
            {
                int[] L = new int[N - 1];
                int curPosL = 0;
                int[] G = new int[N - 1];
                int curPosG = 0;
                for(int i = 0; i < N - 1; i++)
                {
                    if(arr[i] > piv)
                    {
                        G[curPosG++] = arr[i];
                    } else
                    {
                        L[curPosL++] = arr[i];
                    }
                }
                //recursion
                QuickSort(ref G, curPosG);
                QuickSort(ref L, curPosL);
                //merge
                int mergePos = 0;
                for(int i = 0; i < curPosL; i++)
                {
                    arr[i] = L[i];
                    mergePos++;
                }
                arr[mergePos++] = piv;
                for(int i = 0; i < curPosG; i++)
                {
                    arr[mergePos + i] = G[i];
                }
            }
        }

        public static void Test()
        {
            const int MAX_VALUE = 1000;
            const int MIN_VALUE = -MAX_VALUE;
            var rnd = new Random();
            int N = rnd.Next(10, 10000);
            int[] refArray = new int[N];
            int[] testArray = new int[N];
            //create a random array of ints
            for (int i = 0; i < N; i++) { testArray[i] = refArray[i] = rnd.Next(MIN_VALUE, MAX_VALUE); }
            //sort with QuickSort, compare to Array.Sort
            Stopwatch timer = Stopwatch.StartNew();
            Array.Sort<int>(refArray);
            timer.Stop();

            long cannedSortElapsed = timer.ElapsedTicks;

            timer.Restart();
            QuickSort(ref testArray, testArray.Length);
            timer.Stop();
            long mySortElapsed = timer.ElapsedTicks;
            var p = testArray.Zip(refArray, (l, r) => l.ToString() + "\t" + r.ToString());
            Console.WriteLine("Mine\tArray.Sorts");
            foreach (var l in p) Console.WriteLine(l);
            //do a member-wise compare, if any not equal, then the sort failed
            var check = refArray.Zip(testArray, (l, n) => l == n).Any( t => t == false);
            Console.WriteLine($"Compare checked out as: {!check}");
            Console.WriteLine($"Elapsed ticks Mine:\t{mySortElapsed}");
            Console.WriteLine($"Elapsed ticks Array:\t{cannedSortElapsed}");
            Console.ReadLine();
        }
    }
}
