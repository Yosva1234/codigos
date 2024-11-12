using System;
using ExamenProgramacion;
namespace ArbolPrueba
{
	
	class Class1
	{
		
		[STAThread]
		static void Main(string[] args)
		{
			Arbol a=new Arbol(1);
			a.Hijos.Add(new Arbol(2));
			a.Hijos.Add(new Arbol(3));
			a.Hijos.Add(new Arbol(4));
			Arbol b=new Arbol(5);
			b.Hijos.Add(new Arbol(6));
			b.Hijos.Add(new Arbol(7));
			a.Hijos.Add(b);
			Console.WriteLine(Buscado(a,7));
			Console.ReadLine();
		}
		public static Arbol Buscado(Arbol arbol, int values)
		{
			if(arbol.Valor==values)return arbol;
			else
			{
				Arbol res=null;
				foreach(Arbol a in arbol.Hijos)
				{
					res=Buscado(a,values);
				}
				if(res!=null)return res;
				else return null;
			}
		}
	}
}
