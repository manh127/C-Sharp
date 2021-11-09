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
        public int[][] Ghep2Mang1Chieu(int []mang1, int[] mang2)
        {
            //todo: làm code ở đây theo yêu cầu: gep từng phần tử mảng 1 với mảng 2 thành 1 mảng 2 chiều như sau:
            //vd: mang1={1,3,5} mang2={7,8}
            //thi ket qua la = [[1,7],[1,8],[3,7],[3,8],[5,7],[5,8]]
        }
    }
}
