using System;

namespace Strings
{

    //cho xau s , so nguyen k nhap tu ban phim .In ra man hinh ki tu thu k trong xau s
    /*class Program
    {
        static void Main(string[] args)
        {
            String s = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(s[k - 1]);
        }
    }*/


    //Cho xau s va ki tu nhap tu ban phim , in ra so lan xuat hien ki tu trong xau s
    /* class Program
     {
         static void Main(string[] args)
         {
             string s = Console.ReadLine();
             char c = char.Parse(Console.ReadLine());
             int count = 0;
             for (int i = 0; i < s.Length; i++)
             {
                 if (s[i] == c)
                 {
                     count++;
                 }
             }
             Console.WriteLine(count);
         }
     }*/



    //Cho xau s va ki tu c , in ra vi tri dau tien ma ki tu c xuat hien trong xau s, k xuat hien trong xau s in ra -1

    /* class Program
     {
         static void Main(string[] args)
         {
             string s = Console.ReadLine();
             char c = char.Parse(Console.ReadLine());
             int count = -1;
             for (int i = 0; i < s.Length; i++)
             {
                 if (s[i] == c)
                 {
                     count = i;
                     break;
                 }
             }
             Console.WriteLine(count);
         }
     }*/



    //2 xau ki tu s1,s2 , Hien thi ra vi tri dau tien s2 xuat hien trong s1 - khong phan biet hoa thuong


    /*  class Program
      {
          static void Main(string[] args)
          {
              string s1 = Console.ReadLine();
              string s2 = Console.ReadLine();
              s1 = s1.ToLower();
              s2 = s2.ToLower();
              Console.WriteLine(s1.IndexOf(s2));

          }
      }*/


    //Cho xau s nhap tu ban phim , Hien thi nhung ki tu k phai la so trong xau s

    /* class Program
     {
         static void Main(string[] args)
         {
             string s = Console.ReadLine();
             for (char c = '0'; c <= 9; c++)
             {
                 s = s.Replace(c + "","");
             }
             Console.WriteLine(s);
         }

     }*/


    //cho xau s,Hien thi so cac ki tu in hoa trong xau s

    /*class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'A' && s[i] <= 'Z')
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }*/


    //Dao nguoc xau s

    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                Console.Write(s[i]);
            }
        }
    }
}
