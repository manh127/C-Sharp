using System;

namespace Arrray
{

    //Nhap vao 10 so nguyen va hien thi 10 so vua nhap
    /*class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];

            for (int i = 0; i < 10; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write(a[i] + " ");
            }
        }
    }*/

    //Nhap mang n phan tu , hien thi ra so lon nhat

    /* class Program
     {
         static void Main(string[] args)
         {
             int n = int.Parse(Console.ReadLine());
             int[] arr = new int[n];

             for (int i = 0; i < n; i++)
             {
                 arr[i] = int.Parse(Console.ReadLine());
             }
             int MaxValue = arr[0];
             for (int i = 1; i < n; i++)
             {
                 if (arr[i] > MaxValue)
                 {
                     MaxValue = arr[i];
                 }
             }
             Console.WriteLine(MaxValue);
         }
     }*/


    //Nhap mang n phan tu , tinh tong phan tu dau tien va cuoi cung

    /*class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.Write(arr[n - 1] + arr[0]);
        }
    }*/

    //Nhap mang n phan tu . Hien thi cac so chan trong mang

    /*class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }*/


    //Nhap mang n phan tu va so nguyen k . Hien thi so phan tu co gia tri bang k

    /*class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int k = int.Parse(Console.ReadLine());
            int Count = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == k)
                {
                    Count++;
                }
            }
            Console.Write(Count);


        }
    }*/

    //Nhap mang n phan tu. Tinh tong cac so le lon hon 0

    /*class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int x = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0 && arr[i] % 2 != 0)
                {
                    x += arr[i];
                }
            }
            Console.WriteLine(x);
        }
    }*/


    //Nhap mang n phan tu . Hien thi cac so lon hon bang 0 va nho hon bang 10

    /* class Program
     {
         static void Main(string[] args)
         {
             int n = int.Parse(Console.ReadLine());
             int[] arr = new int[n];
             for (int i = 0; i < n; i++)
             {
                 arr[i] = int.Parse(Console.ReadLine());
             }
             for (int i = 0; i < n; i++)
             {
                 if (arr[i] >= 0 && arr[i] <= 10)
                 {
                     Console.Write(arr[i] + " ");
                 }
             }
         }
     }*/


    //Nhap mang n phan tu sap xep cac phan tu tang dan

    /* class Program
     {
         static void Main(string[] args)
         {
             int n = int.Parse(Console.ReadLine());
             int[] arr = new int[n];
             for (int i = 0; i < n; i++)
             {
                 arr[i] = int.Parse(Console.ReadLine());
             }
             for (int i = 0; i < n; i++)
             {
                 for (int j = i + 1; j < n; j++)
                 {
                     if (arr[i] > arr[j])
                     {
                         int Temp = arr[i];
                         arr[i] = arr[j];
                         arr[j] = Temp;
                     }
                 }
             }
             for (int i = 0; i < n; i++)
             {
                 Console.Write(arr[i] + " ");
             }
         }
     }*/


    //Nhap mang 2 chieu n hang m cot . Tinh tong cac phan tu trong mang

    /* class Program
     {
         static void Main(string[] args)
         {
             int n = int.Parse(Console.ReadLine());
             int m = int.Parse(Console.ReadLine());
             int[,] arr = new int[n, m];
             for (int i = 0; i < n; i++)
             {
                 for (int j = 0; j < m; j++)
                 {
                     arr[i, j] = int.Parse(Console.ReadLine());
                 }
             }
             int Sum = 0;
             for (int i = 0; i < n; i++)
             {
                 for (int j = 0; j < m; j++)
                 {
                     Sum +=arr[i,j];
                 }
             }
             Console.WriteLine(Sum);
         }
     }*/



    //Nhap mang 2 chieu n hang m cot . Tinh tong cac phan tu chia het cho 5


    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }
            int Sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] % 5 == 0)
                    {
                        Sum += arr[i, j];
                    }
                }
            }
            Console.WriteLine(Sum);
        }
    }
}
