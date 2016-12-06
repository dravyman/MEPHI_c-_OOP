using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            double xStart;
            double xFinish;
            double dx;
            double eps;
            int step = 0;
            Console.WriteLine("Введите x начальное");
            xStart = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите x конечное");
            xFinish = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите шаг");
            dx = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите погрешность");
            eps = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("{0,5}   {1,5}      {2,5}", "x", "y", "Steps");
            if (xStart > xFinish)
            {
                xStart = xStart + xFinish;
                xFinish = xStart - xFinish;
                xStart = xStart - xFinish;
            }
            for (double x = xStart; x <= xFinish; x += dx)
            {
                double y = taulr(x, eps, out step);
                Console.WriteLine("{0,5}   {1,5}    {2,5}", x, y, step);
            }
            Console.ReadKey();
        }

        private static double taulr(double x, double eps, out int i)
        {
            double res = 1;
            i = 1;
            double step = x;
            double fact = 1;
            double dy = step / (double)fact;
            while (dy > eps)
            {
                res = (i % 2 == 1) ? res - dy : res + dy;
                step *= x;
                i++;
                fact *= i;
                dy = step / (double)fact;
            }
            res = (i % 2 == 1) ? res - dy : res + dy;
            return res;
        }
    }
}
