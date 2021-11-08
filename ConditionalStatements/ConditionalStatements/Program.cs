using System;

namespace ConditionalStatements
{
    //Nhap so nguyen n , kiem tra chan ,le
    /*class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n % 2 == 0)
            {
                Console.WriteLine("n is an even number");
            }
            else
            {
                Console.WriteLine("n is an odd number");
            }
        }
    }*/


    //Nhap so nguyen n, hien thi cac thong tin tuong ung
    /* class Program
     {
         static void Main(string[] args)
         {
             int n = int.Parse(Console.ReadLine());
             if (n > 0)
             {
                 Console.WriteLine("n is a positive number");
             }
             else if (n < 0)
             {
                 Console.WriteLine("n is a negative number");
             }
             else
             {
                 Console.WriteLine("n is equal to 0");
             }
         }
     }*/

    //Nhap ban phim 2 so nguyen a,b va hien thi ra man hinh
    /* class Program
     {
         static void Main(string[] args)
         {
             int a = int.Parse(Console.ReadLine());
             int b = int.Parse(Console.ReadLine());
             if (a >= b)
             {
                 Console.WriteLine("a is greater than or equal to b");
             }
             else
             {
                 Console.WriteLine("a is smaller than b");
             }
         }
     }*/


    //Nhap ten 2 nguoi va so sanh
    /*class Program
    {
        static void Main(string[] args)
        {
            string NameA = Console.ReadLine();
            string NameB = Console.ReadLine();
            if (NameA == NameB)
            {
                Console.WriteLine("two people have the same name");
            }
            else
            {
                Console.WriteLine("two people don't have the same name");
            }
        }
    }*/


    //Nhap 2 so nguyen a,b so sanh voi 0 
    /* class Program
     {
         static void Main(string[] args)
         {
             int a = int.Parse(Console.ReadLine());
             int b = int.Parse(Console.ReadLine());
             if (a != 0 && b != 0)
             {
                 Console.WriteLine("a is not equal to 0 and b is not equal to 0");
             }
             else
             {
                 Console.WriteLine("a is equal to 0 or b is equal to 0");
             }
         }
     }*/


    //Nhap 3 so nguyen , hien thi so lon nhat
    /*class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            if (a >= b && a >= c)
            {
                Console.WriteLine(a);
            }
            else if (b >= c)
            {
                Console.WriteLine(b);
            }
            else
            {
                Console.WriteLine(c);
            }
        }
    }*/


    //Nhap so nguyen a va kiem tra co thuoc doan [10,100]
    /* class Program
     {
         static void Main(string[] args)
         {
             int a = int.Parse(Console.ReadLine());
             if (a >= 10 && a <= 100)
             {
                 Console.WriteLine(a + " is in the range [10, 100]");
             }
             else
             {
                 Console.WriteLine(a + " is not in the range [10, 100]");
             }
         }
     }*/


    //Nhap diem va kiem tra diem co hop le khong
    /* class Program
     {
         static void Main(string[] args)
         {
             int a = int.Parse(Console.ReadLine());
             if (a >= 0 && a <= 10)
             {
                 Console.WriteLine("The score is valid");
             }
             else
             {
                 Console.WriteLine("The score is not valid");
             }
         }
     }*/


    //nhap 3 so nguyen va kiem tra co phai tang dan , giam dan khong
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            if (a <= b && b <= c)
            {
                Console.WriteLine("increasing");
            }
            else if (a >= b && b >= c)
            {
                Console.WriteLine("decreasing");
            }
            else
            { Console.WriteLine("neither increasing nor decreasing order"); }
        }
    }
}
