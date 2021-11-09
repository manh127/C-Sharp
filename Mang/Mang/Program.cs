using System;

namespace Mang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so phan tu cua mang master: ");
            int N = int.Parse(Console.ReadLine());

            string [][] Jagged = new string[N][];
            for (int i = 0; i < N; i++)
            {
                Console.Write("Nhap so phan tu cua mang slave: ", i);
                int No = int.Parse(Console.ReadLine());
                Jagged[i] = new string[No];
                for (int j = 0; j < No; j++)
                {
                    Console.Write("Nhap Jagged[{0}][{1}] = ", i, j);
                    Jagged[i][j] = Console.ReadLine().ToString();
                }
            }

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Mang Jagged [{0}][] vua nhap la: ", N);

            for (int i = 0; i < Jagged.Length; i++)
            {
                for (int j = 0; j < Jagged[i].Length; j++)
                {
                    Console.Write("\t" + Jagged[i][j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}