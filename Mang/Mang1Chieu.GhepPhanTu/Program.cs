using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Mang1Chieu.GhepPhanTu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // có thể thay đổi số lượng cũng như phần tử ở mảng a,b để kiểm tra kết quả
            int[] a = { 1, 3, 5, 9,10};
            int[] b = { 7, 8 };
            var ketqua = new Mang1Chieu().Ghep2Mang1Chieu(a, b);
            string s = "[";
            foreach (var i in ketqua)
            {
                s += "[";
                Console.WriteLine("-----------------");
                foreach (var si in i)
                {
                    s += si.ToString() + ", ";
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

            List<int[]> jagged = new List<int[]>();
            foreach (var item in mang1)
            {
                foreach (var item_ in mang2)
                {
                    int[] arr = { item, item_ };
                    jagged.Add(arr);
                }
            }

            int[][] jagged_arr = new int[jagged.Count][];
            for (int i = 0; i < jagged.Count; i++)
            {
                int[] deviceIDS = jagged[i].ToArray();
                int a = jagged[i].ToArray().First();
                int b = jagged[i].ToArray().Last();

                jagged_arr[i] = new int[] { a, b };
            }
            return jagged_arr;
        }
    }
}