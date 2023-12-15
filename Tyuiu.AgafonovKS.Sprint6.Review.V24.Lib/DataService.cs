using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tyuiu.AgafonovKS.Sprint6.Review.V24.Lib
{
    public class DataService
    {
        public static int GetMatrix(int[,] array, int R, int k, int l)
        {
            if (k > l || R < 0 || R >= array.GetLength(0))
                throw new ArgumentException("Некорректные интервалы или значение R");

            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i != R || (j < k || j > l))
                    {
                        if (array[i, j] < 0)
                        {
                            sum += array[i, j];
                        }
                    }
                }
            }

            return sum;
        }
    }
}
