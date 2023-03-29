using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate
{
    public delegate string MyDelegate(string nm);
    public delegate int Mydelegate(int m,int n);

    public class User
    {
        public string GetName(string name)
        {
            return name.ToUpper();
        }
    }

    public class Calc
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
        public int Mul(int a, int b)
        {
            return a * b;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            User u1= new User();
            MyDelegate myDelegate = new MyDelegate(u1.GetName);
            string nm = myDelegate.Invoke("think quotient");
                Console.WriteLine(nm);

            Calc c1 = new Calc();
            Mydelegate mydelegate = new Mydelegate(c1.Add);
            mydelegate += new Mydelegate(c1.Sub);
            mydelegate += new Mydelegate(c1.Mul);

            Delegate [] list= mydelegate.GetInvocationList();

            foreach(Delegate item in list)
            {
                Console.WriteLine(item.Method);
                object result=item.DynamicInvoke(10, 25);
                Console.WriteLine(result.ToString());
            }
            

        }
    }
}
