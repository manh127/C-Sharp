using System;

namespace LoopStatements
{

    //Nhap so nguyen n , hien thi cac so tu 1 toi n
    /*class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for
            (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");
            }
        }
    }*/


    //Nhap so nguyen a va b , hien thi cac so tu a toi b
    /*class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++)
            {
                Console.Write(i + " ");
            }
        }
    }*/


    //Nhap so nguyen n va hien thi cac so tu n ve -n
    /*class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = n; i >= -n; i--)
            {
                Console.Write(i + " ");
            }
        }
    }*/


    //Nhap vao so nguyen a,b va tinh tong cac so tu a den b
    /* class Program
     {
         static void Main(string[] args)
         {
             int a = int.Parse(Console.ReadLine());
             int b = int.Parse(Console.ReadLine());
             int x = 0;
             for (int i = a; i <= b; i++)
             {
                 x += i;
             }
             Console.Write(x);
         }
     }*/


    //Nhap vao ban phim so nguyen n va hien thi ra tong cac so le tu o toi n
    /* class Program
     {
         static void Main(string[] args)
         {
             int n = int.Parse(Console.ReadLine());
             int x = 0;
             for (int i = 0; i <= n; i++)
             {
                 if (i % 2 != 0)
                 {
                     x += i;
                 }
             }
             Console.Write(x);
         }
     }*/


    //Nhap vao so nguyen a,b va hien thi cac so chia het cho 3 tu a den b
    /* class Program
     {
         static void Main(string[] args)
         {
             int a = int.Parse(Console.ReadLine());
             int b = int.Parse(Console.ReadLine());
             int x = 0;
             for (int i = a; i <= b; i++)
             {
                 if (i % 3 == 0)
                 {
                     Console.Write(i + " ");
                 }
             }
         }
     }*/


    //Nhap so nguyen n va hien thi n!
    /*class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = 1;
            for (int i = 1; i <= n; i++)
            {
                x *= i;
            }
            Console.Write(x);
        }
    }*/


    //Nhap so nguyen va hien thi cac uoc cua n
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
