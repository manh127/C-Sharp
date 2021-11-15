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
            int[] a = { 1, 3 };
            int[] b = { 7, 8 };
            int[] d = { 9, 0 };
            Mang1Chieu mang1Chieu = new Mang1Chieu();
            //  var ketqua = mang1Chieu.Ghep2Mang1Chieu(a, b);
            // Display(ketqua);

            int[] c = { 100, 200 };

            var ketqua1 = new Mang1Chieu().GhepCacMang1Chieu(new int[][] { a, b, c});
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

        public int[][] GhepJagedAnd1Chieu(int[][] inputs, int[] mang2)
        {
            int jaggedLenth = 1;
            if (inputs != null && inputs.Count() > 0)
            {
                foreach (var item in inputs)
                {
                    jaggedLenth = jaggedLenth * item.Length;
                }
            }
            int[][] jagged_arr = new int[jaggedLenth][];

            foreach (var i2 in mang2)
            {
                foreach(var j in inputs)
                {
                    foreach( var itm in j)
                    {

                    }
                }
            }
            
        }


        int[][] jagged_arr_ = new int[][] { };
        int[][] jagged_arr = new int[][] { };
        public int[][] GhepCacMang1Chieu(int[][] inputs)
        {
            //Dictionary<int, int[]> indexMappingInputs = new Dictionary<int, int[]>();

            if (inputs.Length <= 1) return inputs;

            int jaggedLenth = 1;
            if (inputs != null && inputs.Count() > 0)
            {
                foreach (var item in inputs)
                {
                    jaggedLenth = jaggedLenth * item.Length;
                }
            }


            int[][] jagged_arr = new int[jaggedLenth][];
            int[][] temp = new int[0][];

            for (var i =0;i< jaggedLenth-2; i++)
            {
                if(i==0)
                {
                    temp = Ghep2Mang1Chieu(inputs[i], inputs[i + 1]);
                }
                else
                {
                    temp = GhepJagedAnd1Chieu(temp, inputs[i + 2]);
                }
            }

            
          
            return jagged_arr;
        }
    }
}