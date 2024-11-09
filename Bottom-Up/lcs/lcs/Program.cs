using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lcs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "catcagat";
            string str2 = "cataga";
            string result = lcs(str1,str2);

            Console.WriteLine(result);

            Console.ReadLine();



        }


       

        
        public static string lcs(string str1, string str2)
        {
            int m = str1.Length;
            int n = str2.Length;

            int[,] dp = new int[m+1, n+1];

            for(int i = 1;i<=m;i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    if (str1[i-1] == str2[j-1])
                    {

                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {

                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }

            }

            int index = dp[m, n];
            char[] lcs = new char[index];

            int rp = m;
            int colp = n;
            
           while(rp>0 && colp > 0)
            {
                if (str1[rp-1] == str2[colp - 1])
                {
                    lcs[index-1] = str1[rp-1];
                    rp--;
                    colp--;
                    index--;
                }


                else if (dp[rp - 1, colp] > dp[rp, colp - 1])
                {
                    rp--;
                }

                else
                {

                    colp--;
                }



            }

           return new string(lcs);
          


        }
    }
}
