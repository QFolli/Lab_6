using System;
class SteepestDescent
{
    static double[] Gradient(double x1, double x2)
    {
        double gradX1 = 2 * x1 - x2 + 1;
        double gradX2 = 2 * x2 - x1 - 2;
        return new double[] { gradX1, gradX2 };
    }



    static double[] SteepestDescentMethod(double x1, double x2, double epsilon)
    {
        double[] currentPoint = { x1, x2 };
        double[] gradient = Gradient(x1, x2);
        double norm = Math.Sqrt(Math.Pow(gradient[0], 2) + Math.Pow(gradient[1], 2));

        while (norm >= epsilon)
        {
            double step = 0.0001;
            gradient = Gradient(currentPoint[0], currentPoint[1]);
            currentPoint[0] -= step * gradient[0];
            currentPoint[1] -= step * gradient[1];
            norm = Math.Sqrt(Math.Pow(gradient[0], 2) + Math.Pow(gradient[1], 2));
        }

        return currentPoint;
    }

    static void Main()
    {
        double[] startPoint = { 0, 0 };
        double epsilon = 0.01;
        double[] minPoint = SteepestDescentMethod(startPoint[0], startPoint[1], epsilon);
        Console.WriteLine("Минимум функции достигается в точке ({0}, {1})", minPoint[0], minPoint[1]);
    }
}