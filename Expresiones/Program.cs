using System.Diagnostics;
using Exam;
namespace Main;

public static class Program
{
    static void Main(string[] args)
    {

        long ci = 02060868084;
        string cis = ci.ToString();
        System.Console.WriteLine(cis);
        double test = 0;
        double result = 0;

    //     var exp1 = new Sum(new Constant(3), new Constant(5));
    //     test = 5 + 3;
    //     result = exp1.Evaluate();
    //     Debug.Assert(result == test);

    //      var exp2 = new Mul(new Constant(2),new Sum(new Constant(5), new Constant(7)));
    //      test = 2 * (5 + 7);
    //      result = exp2.Evaluate();
    //      Debug.Assert(result == test);

    //      var exp3 = new Pow(new Constant(3), new Log(new Constant(2), new Constant(10)));
    //      test = Math.Pow(3, Math.Log(10,2));
    //      result = exp3.Evaluate();
    //      Debug.Assert(result == test);

    //      var exp4 = new Let("x", new Sum(new Constant(2), new Constant(5)), new Sum(new Constant(3), new Variable("x")));
    //      int x = 2 + 5;
    //      test = 3 + x;
    //      result = exp4.Evaluate();
    //      Debug.Assert(result == test);

    //      var exp5 = new Let("x", 
    //      new Constant(5), new Mul(new Variable("x"), new Let("x", 
    //      new Constant(8), new Sum(new Constant(3), new Variable("x")))));
    //      test = 55;
    //      result = exp5.Evaluate();
    //      Debug.Assert(result == test);
        


        var exp7 = new Let("x", new Constant(4),new Sum(new Let ("y", new Variable("x"), new Variable("y")),new Variable("x")));
        Console.WriteLine(exp7.Evaluate());
    }
}