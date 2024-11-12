#include <bits/stdc++.h>

using namespace std;

 bool b = false;

void bus(int normal[], int ordenado[], int n, int i)
{  
     if(!b)
     {
    
    bool aux = true;

    for (int x = 0; x < n; x++)
    {
          cout << normal[x] << " ";
    }
    cout << endl;
    
       if(aux) b = aux;
       

    for (int x = i; x<n-3; x++)
    for (int y = x+2; y<n-1; y++)
    {
        swap(normal[x], normal[y]);
        swap(normal[x+1], normal[y+1]);

         bus(normal,ordenado,n,i+1);
        
        swap(normal[x], normal[y]);
        swap(normal[x+1], normal[y+1]);

         bus(normal,ordenado,n,i+1);
    }
     }

}

int main()
{

   int c; cin >> c;

   while(c--)
   {

     b = false;

       int n; cin >> n;

       int normal[n];
       int ordenado[n];

       for (int x =0; x<n; x++)
       {
       cin >> normal[x];
       ordenado[x] = normal[x];
       }

     sort(ordenado, ordenado+n);
     
      bus(normal, ordenado, n, 0);

      for (int x = 0; x< n ; x++) cout << ordenado[x] << " ";

      cout << endl;


 if(b) cout << "NO" << endl;
 else cout << "NO" << endl;
   }

}
