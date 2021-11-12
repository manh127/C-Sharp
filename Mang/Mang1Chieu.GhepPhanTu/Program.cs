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
            // có thể thay đổi số lượng cũng như phần tử ở mảng a,b để kiểm tra kết quảA
            int[] a = { 1, 3, 5, 4 };
            int[] b = { 7, 8 };
            int[] d = { 9, 0 };
            Mang1Chieu mang1Chieu = new Mang1Chieu();
            //  var ketqua = mang1Chieu.Ghep2Mang1Chieu(a, b);
            // Display(ketqua);

            int[] c = { 100, 200 };

            var ketqua1 = new Mang1Chieu().GhepCacMang1Chieu(new int[][] { a, b, c, d });
            Display(ketqua1);

        }

        static void Display(int[][] inputs)
        {
            Console.WriteLine("-----------------");
            string s = "[";
            foreach (var i in inputs)
            {
                s += "[";
                foreach (var si in i)
                {
                    s += si.ToString() + ",\a ";
                    Console.WriteLine(si.ToString());
                }
                s += "]";
                Console.WriteLine("-----------------");
            }
            s += "]";
            Console.WriteLine(s);
            Console.WriteLine("-----------------\r\nPress [Enter] key to continue");
            Console.ReadLine();
        }
    }
    class Mang1Chieu
    {
        public int[][] Ghep2Mang1Chieu(int[] mang1, int[] mang2)
        {
            int i = 0;
            int[][] jagged_arr = new int[mang1.Length * mang2.Length][];
            foreach (var item in mang1)
            {
                foreach (var item_ in mang2)
                {
                    jagged_arr[i] = new int[] { item, item_ };
                    i += 1;
                }
            }
            return jagged_arr;
        }
        int[][] jagged_arr_ = new int[][] { };
        int[][] jagged_arr = new int[][] { };
        public int[][] GhepCacMang1Chieu(int[][] inputs)
        {
            int i = 1;
            if (inputs != null && inputs.Count() > 0)
            {
                foreach (var item in inputs)
                {
                    i = i * item.Length;
                }
            }


            int x = 0;
            if (inputs != null && inputs.Count() > 0)
            {
                this.jagged_arr_ = new int[inputs[0].Length * inputs[1].Length][];
                jagged_arr_ = Ghep2Mang1Chieu(inputs[0], inputs[1]);
                jagged_arr = new int[i][];
                for (int ikk = 2; ikk < inputs.Count(); ikk++)
                {
                    x = 0;
                    foreach (var item in this.jagged_arr_)
                    {

                        foreach (var itemi in inputs[ikk])
                        {
                            if (jagged_arr[x] == null)
                            {
                                this.jagged_arr[x] = item.Concat(new int[] { itemi }).ToArray();
                            }
                            else
                            {
                                this.jagged_arr[x] = this.jagged_arr[x].Concat(new int[] { itemi }).ToArray();
                            }
                            x += 1;
                        }
                    }
                }
            }
            return jagged_arr;
        }
    }
}