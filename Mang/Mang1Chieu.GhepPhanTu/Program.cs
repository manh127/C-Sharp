using System;
using System.Collections.Generic;

namespace Mang1Chieu.GhepPhanTu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // có thể thay đổi số lượng cũng như phần tử ở mảng a,b để kiểm tra kết quả

            int[] a = { 1, 3, 5 ,4};
            int[] b = { 7, 8 };

            var ketqua = new Mang1Chieu().Ghep2Mang1Chieu(a, b);

            string s = "[";
            foreach (var i in ketqua)
            {
                s += "[";
                Console.WriteLine("-----------------");
                foreach (var si in i)
                {
                    s += si.ToString()+", ";
                    Console.WriteLine(si.ToString());
                }
                Console.WriteLine("-----------------");
                s += "]";
            }
            s += "]";

            Console.WriteLine(s);
            Console.ReadLine();
        }
    }

    class Mang1Chieu
    {
        public int[][] Ghep2Mang1Chieu(int[] mang1, int[] mang2)
        {
            //https://www.c-sharpcorner.com/UploadFile/puranindia/jagged-arrays-in-C-Sharp-net/
        }
    }
}
        

