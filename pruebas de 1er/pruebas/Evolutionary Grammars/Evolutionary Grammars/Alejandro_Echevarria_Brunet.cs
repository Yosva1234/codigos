using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace MatCom.Examen;

public static class Solution
{
	public static List <(Tree, int)> niveles = new List<(Tree, int)>();
	public static Tree DeriveFromGrammar(Tree start, int iterations, Production[] productions, Func<int> sampler)
	{

	for (;iterations>0; iterations--)
	{
		niveles = new List<(Tree, int)>();

		Tree mutation = new Tree(start.Symbol);

		for(int x = 0; x<start.Children.Count; x++) mutation.Children.Add(start.Children[x]);

		dfsmutation(start,sampler,productions);

	}

	return start;
	}


   static void dfsrellenar (Tree nodo, int level)
   {
	niveles.Add((nodo,level));
	for(int x = 0; x<nodo.Children.Count; x++) dfsrellenar(nodo.Children[x],level+1);
   }

    public static void dfsmutation( Tree nodo, Func<int>sampler, Production[] productions )
	{

			for (int x = 0; x<nodo.Children.Count; x++)
			{
			   dfsmutation(nodo.Children[x],sampler,productions);
			}

			char [] c =  random(sampler(),productions,nodo.Symbol);

			for(int x = 0;x <c.Length; x++) if(verificationchildren(nodo.Children,c[x])) nodo.Children.Add(new Tree(c[x].ToString()));
		
			nodo.Symbol+=nodo.Symbol;
	}

	static bool verificationchildren(List <Tree> children, char c)
	{

		if(children.Count == 0) return true;

		if(children.ToArray().All(x => x.Symbol!=c.ToString())) return true;

		return false;
	}


	public static char[] random( int num, Production[] productions, string s)
	{
		int c = 0;
		for(int x = 0; x<productions.Length; x++)
		if(productions[x].Head == s) c++;

		if(c==0) return new char[0];

		num%=c;

		Console.WriteLine(num);

		for(int x = 0; x<productions.Length; x++)
		{
			if(productions[x].Head == s) num--;

			if(num==-1)
			{
				Console.WriteLine(productions[x].Body[0]);
				return productions[x].Body;
			}
		}
		return new char[0];
	}
  

}