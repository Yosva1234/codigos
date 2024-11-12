using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Formats.Asn1;
namespace Exam;


    public static class Tree
    {

           public static List <(string, double)> nodos =  new List<(string, double)>();

            public static double buscarvariable( string s)
            {
                double answer=int.MaxValue;

                for (int x = nodos.Count-1; x>=0; x--)
                {
                    if(nodos[x].Item1 == s) {answer = nodos[x].Item2; break; }
                }
                return answer;
            }


            public static void remove (string s)
            {
                int pos=-1;

                  for (int x = nodos.Count-1; x>=0; x--)
                {
                    if(nodos[x].Item1 == s) {pos = x; break; }
                }

                nodos.RemoveAt(pos);
            }

            public static void Addnodo (string s, double value)
            {
                nodos.Add((s,value));
            }

    }

public abstract class Expression
{
    public abstract double Evaluate();
}
public abstract class BinaryExpression : Expression
{
    public Expression Left;
    public Expression Right;

    protected BinaryExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
        
    }
}
#region Expresiones Binarias
public class Sum : BinaryExpression
{
    public Sum(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        return Left.Evaluate()+Right.Evaluate();
    }
}
public class Sub : BinaryExpression
{
    public Sub(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
       return Left.Evaluate()-Right.Evaluate();
    }
}
public class Mul : BinaryExpression
{
    public Mul(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        return Left.Evaluate()*Right.Evaluate();
    }
}
public class Div : BinaryExpression
{
    public Div(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        if(Right.Evaluate() == 0) throw new Exception("no se puede dividir por 0");
      
        return Left.Evaluate()/Right.Evaluate();
    }
}
public class Pow : BinaryExpression
{
    public Pow(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        return Math.Pow(Left.Evaluate(),Right.Evaluate());
    }
}
public class Log : BinaryExpression
{
    public Log(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
      if(Right.Evaluate()<=0)  throw new Exception("el exponente del logaritmo debe de ser positivo");
      return Math.Log(Right.Evaluate(),Left.Evaluate());
    }
}
#endregion

#region Otras Expresiones


public class Constant : Expression
{
    public double Value { get; }
    public Constant(double value)
    {
        Value = value;
    }
    public override double Evaluate()
    {
       return Value;
    }
}
public class Variable : Expression
{
    public string  VariableName { get; }
    public Variable(string variableName)
    {
        VariableName = variableName;
    }
    public override double Evaluate()
    {
            double answer = Tree.buscarvariable(VariableName);  

            if(answer == int.MaxValue){throw new Exception("intenta acceder a una variable que no existe"); }

            return answer;
    }
}
public class Let : Expression
{
    public static Dictionary<string, double> variables = new Dictionary<string, double>();
    public string Variable;
    public Expression Init;
    public Expression Exp;

    public Let(string variable, Expression init, Expression exp)
    {
        Variable = variable;
        Init = init;
        Exp = exp;
    }

    public override double Evaluate()
    {
        Tree.Addnodo(Variable,Init.Evaluate());
        double answer = Exp.Evaluate();
        Tree.remove(Variable);
        return  answer;
    }
}
#endregion