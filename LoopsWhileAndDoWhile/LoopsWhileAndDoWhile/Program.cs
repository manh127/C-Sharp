using System;

namespace LoopsWhileAndDoWhile
{

    //Nhapso nguyen n va hien thi cac so chan tu n toi 100
    /* class Program
     {
         static void Main(string[] args)
         {
             int n = int.Parse(Console.ReadLine());
             while (n <= 100)
             {
                 if (n % 2 == 0)
                 {
                     Console.Write(n + " ");
                 }
                 n++;
             }
         }
     }*/


    //Nhap so nguyen n va hien thi cac uoc cua n

    /* class Program
     {
         static void Main(string[] args)
         {
             int n = int.Parse(Console.ReadLine());
             int i = 1;
             int x = 0;
             while (i <= n)
             {
                 if (n % i == 0)
                 {
                     x++;
                 }
                 i++;
             }
             Console.Write(x);
         }
     }*/

    //Nhap so nguyen duong a,b . tinh a^b

    /* class Program
     {
         static void Main(string[] args)
         {
             int a = int.Parse(Console.ReadLine());
             int b = int.Parse(Console.ReadLine());
             int x = 1;
             while (b > 0)
             {
                 x *= a;
                 b--;
             }
             Console.Write(x);
         }
     }*/


    // Nhapso nguyen a,b . Hien thi cac so chia het cho ca 3 va 5

    /*   class Program
       {
           static void Main(string[] args)
           {
               int a = int.Parse(Console.ReadLine());
               int b = int.Parse(Console.ReadLine());
               while (a <= b)
               {
                   if (a % 3 == 0 && a % 5 == 0)
                   {
                       Console.Write(a + " ");
                   }
                   a++;
               }
           }
       }*/



    //Break;

    /* class Program
     {
         static void Main(string[] args)
         {
             for (int i = 1; i <= 100; i++)
             {
                 if (i == 51)
                 {
                     break;
                 }
                 Console.Write(i + " ");
             }
         }
     }*/


    //Continue;

    /*    class Program {
            static void Main(string[] args) {
                for (int i = 1; i <= 100; i++) {
                    if(i%2==0)
                    {
                        continue;
                    }
                    Console.Write(i + " ");
                }
            }
        }*/


    //do-while

    /* class Program
     {
         static void Main(string[] args)
         {
             int i = 1;
             do
             {
                 Console.Write(i + " ");
                 i++;
             } while (i <= 5);
         }
     }*/


    //Hien thi ra man hinh cac so co so 0 ow cuoi tu 1-1000
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            do
            {
                if (i % 10 == 0)
                {
                    Console.Write(i + " ");
                }
                i++;
            } while (i <= 1000);
        }
    }
}
