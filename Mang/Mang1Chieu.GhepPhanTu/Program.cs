using System;

namespace Mang1Chieu.GhepPhanTu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // có thể thay đổi số lượng cũng như phần tử ở mảng a,b để kiểm tra kết quả

            int[] a = { 1, 3, 5 };
            int[] b = { 7, 8 };

            var ketqua = new Mang1Chieu().Ghep2Mang1Chieu(a, b);

            foreach(var i in ketqua)
            {
                Console.WriteLine("----");
                foreach( var si in i)
                {
                    Console.Write(si);
                    Console.Write(", ");
                }
            }

            Console.ReadLine();
        }
    }

    class Mang1Chieu
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] a = { 1, 2, 3 };
                int[] b = { 6, 7, 8 };
                List<string> ketqua_ = new List<string>();
                foreach (var item in a)
                {
                    string kq;
                    foreach (var item_ in b)
                    {
                        kq = "[" + item.ToString() + "," + item_.ToString() + "]";
                        ketqua_.Add(kq);
                    }
                }
                foreach (var item1 in ketqua_)
                {
                    Console.WriteLine(item1.ToString());
                }

                Console.ReadLine();

            }

        }
    }
}
