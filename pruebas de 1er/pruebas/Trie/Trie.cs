using System.Text.RegularExpressions;

public class NodoTrie
{
    //Caracter que representa el nodo 
    public char Valor { get; private set; }

    //Representa si una palabra termina en este nodo 
    public bool FinDePalabra { get; set; }

    //Nodos Hijos 
    public List<NodoTrie> Hijos { get; private set; }

    //Indexer para acceder al nodo hijo que corresponda a ese caracter. 
    //De no existir devuelve null 
    public NodoTrie this[char valor]
    {
        get => Hijos.Where(x => x.Valor == valor).FirstOrDefault()!;
        set { }
    }

    //Constructor 
    public NodoTrie(char valor, bool finDePalabra = false, params NodoTrie[] hijos)
    {
        Valor = valor;
        FinDePalabra = finDePalabra;
        Hijos = hijos.ToList();
    }
}

public class Trie : ITrie
{
    public NodoTrie Raiz { get; private set; }

    public NodoTrie this[char valor]
    {
        get
        {
            var match = Raiz.Hijos.Where(x => x.Valor == valor).FirstOrDefault();
            return match!;
        }
    }

    public Trie()
    {
        Raiz = new NodoTrie('\0');
        CantidadDePalabras = 0;
    }

    public void AgregarPalabra(string palabra)
    {
        AddWord(Raiz, 0, palabra);
    }

    void AddWord(NodoTrie actual, int index, string word)
    {
        if (index == word.Length)
        {
            actual.FinDePalabra = true;
            CantidadDePalabras++;
            return;
        }
        var match = actual.Hijos.Where(x => x.Valor == word[index]).FirstOrDefault();

        if (match is null)
        {
            var child = new NodoTrie(word[index]);
            actual.Hijos.Add(child);
            System.Console.WriteLine($"Added node: {child.Valor}");
            AddWord(child, index + 1, word);
        }
        else AddWord(match, index + 1, word);
    }

    public string MayorPrefijoComun()
    {
        string longestCommonPrefix = string.Empty;
        string prefix = string.Empty;
        var collection = PalabrasConPrefijo("");
        if (collection.Count() != 0)
        {
            var first = collection.First();
            for (int i = 0; i < first.Length; i++)
            {
                if (HasPrefix(first[i], i, collection))
                    longestCommonPrefix += first[i];

                else
                {
                    System.Console.WriteLine($"LCP: {longestCommonPrefix}");
                    return longestCommonPrefix;
                }
            }
        }
        System.Console.WriteLine($"LCP: {longestCommonPrefix}");
        return longestCommonPrefix;
    }

    bool HasPrefix(char letter, int index, IEnumerable<string> collection)
    {
        foreach (var word in collection)
        {
            if (index >= word.Length)
                return false;

            if (!(word[index] == letter))
                return false;
        }

        return true;
    }

    public IEnumerable<string> PalabrasConPrefijo(string prefijo)
    {
        List<string> words = new List<string>();
        WordsWithPrefix(Raiz, 0, prefijo, words);
        return words;
    }
    void WordsWithPrefix(NodoTrie actual, int index, string prefix, List<string> words)
    {
        if (index == prefix.Length)
        {
            GetWords(actual, prefix, words);
        }
        else
        {
            var match = actual.Hijos.Where(x => x.Valor == prefix[index]).FirstOrDefault();
            if (match is null) return;
            else
            {
                WordsWithPrefix(match, index + 1, prefix, words);
            }
        }
    }

    void GetWords(NodoTrie actual, string word, List<string> words)
    {
        if (actual.Hijos.Count == 0 && actual.FinDePalabra)
        {
            words.Add(word);
            System.Console.WriteLine($"Added leaf {word}");
            return;
        }

        else if (actual.FinDePalabra && actual.Hijos.Count != 0)
        {
            words.Add(word);
            System.Console.WriteLine($"Added word {word}");

            foreach (var child in actual.Hijos)
            {
                GetWords(child, word + child.Valor, words);
            }

            return;
        }

        else
        {
            foreach (var child in actual.Hijos)
            {
                GetWords(child, word + child.Valor, words);
            }
        }
    }

    public bool Contiene(string palabra)
    {
        return Contains(Raiz, 0, palabra);
    }

    public bool Contains(NodoTrie actual, int index, string word)
    {
        var match = actual.Hijos.Where(x => x.Valor == word[index]).FirstOrDefault();
        if (match is null) return false;
        else if (match.FinDePalabra) return true;
        else
            return Contains(match, index + 1, word);
    }

    public void Vaciar()
    {
        Raiz.Hijos.Clear();
    }

    public int CantidadDePalabras { get; private set; }
}