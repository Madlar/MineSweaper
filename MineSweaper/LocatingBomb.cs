using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweaper
{
    class LocatingBomb
    {
        private int[] num;
        private int total;
        private int bomb;

        public LocatingBomb(int total, int bomb)
        {
            num = new int[total];
            this.total = total;
            this.bomb = bomb;

            for (int i=0;i<total;i++)
            {
                num[i] = 0;
            }
        }

        public int[] Locating()
        {
            int x;
            Random rand = new Random();

            for(int i=0;i<bomb;i++)
            {
                do
                {
                    x = rand.Next(total - 1);
                } while (num[x] == -1);
                num[x] = -1;
            }
            return num;
        }
    }
}
