using System;
using ExamenProgramacion;
using System.Collections;

namespace ExamenProgramacion
{
	public class Problema2
	{
		public static Arbol ColgarPor(Arbol a, int x)
		{
			ArrayList result=new ArrayList();
			result.Add(Buscado(a,x));
			ListaDeHijos(a,result,result[0]);
		}
		static void ListaDeHijos(Arbol a,
			ArrayList lista,Arbol arbol)
		{
			if(a.Equals(arbol))
			{ 
	              return;
			}
			foreach(Arbol b in a.Hijos)
			{
				lista.Add(b);
				ListaDeHijos(b,lista,arbol);
				lista.Remove(b);
			} 
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
