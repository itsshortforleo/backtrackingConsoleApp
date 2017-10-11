using System;

namespace backtrackingConsoleApp
{
    public class Program
    {
        int m = 10; // # of marbles
        int n = 3; // # of jars
        int c = 5; // max # of marbles per jar
        int[] marbles_used = new int[10]; // contains the required marbles to insert
        int[] marbles_remaining = new int[10]; // contains the remaining marbles
        // we set the initial index of marbles_remaining[] to m, which is the # of marbles
        // iteration is promising if m <= c*n
        // pass 1 as initial input

        static void Main(string[] args)
        {
            Program backgrackingDemo = new Program();

            backgrackingDemo.marbles_used[0] = backgrackingDemo.m;
            backgrackingDemo.marbles_remaining[0] = backgrackingDemo.m;



            //Console.WriteLine("Hello World!");


            backgrackingDemo.Build(1);
            Console.ReadKey();
        }



        public void Build(int k)
        { // k can be the instance of the marble
            // choose the lesser qty of marbles between c and marbles_remaining[k-1]
            // (c is the maximum # of marbles per jar)
            int marblesQuantity = Math.Min(c, marbles_remaining[k - 1]);
            while (marblesQuantity >= 0)
            { //more choices for x[k], the promising function
                marbles_used[k] = marblesQuantity;
                marbles_remaining[k] = marbles_remaining[k - 1] - marblesQuantity;

                if (k == n)
                {
                    if (marbles_remaining[k] == 0)
                    {
                        // k is the last component
                        // output x as a solution;
                        for (int i = 1; i < (n+1); i++)
                        {
                            Console.Write(marbles_used[i] + ",");
                        }
                        Console.WriteLine();
                        marblesQuantity = 0;
                    }
                }
                else if (marbles_remaining[k] <= c * (n - k))
                {
                    // x[1..k] satisfies the criterion function,  m <= c*n??
                    Build(k + 1);
                }


                marblesQuantity--;
            }
        }
    }
}
