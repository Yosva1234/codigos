# Zoológico

> *Examen Final de Programación - Curso 2022-2023*

**NOTA**: *Antes de comenzar asegúrese de descompactar el archivo `zoologgico.zip` y abrir la solución `zoologico.sln` en su editor. Asegúrese también de que su código compila, y la aplicación de consola ejecuta (debe lanzar una excepción). Recuerde que todo el código a evaluar debe ir en el archivo `Exam.cs`*

Recientemente ha llegado al Zoológico Nacional una importante donación de animales de distintas especies. Por esto, para los trabajadores del Zoológico Nacional se ha vuelto muy complejo mantener localizdos a cada uno de los animales con los que cuenta la instalación (no tener controlados los leones puede ser peligroso). Para resolver este problema solicitaron la ayuda de los estudiantes de `MATCOM`. 

La tarea consiste en mantener un registro, de la distribución de cada ejemplar según el área de la instalación en que se encuentre.

## Descripción del registro

El registro propuesto tendrá dos componentes fundamentales, las áreas y los animales. Las áreas corresponden a espacios delimitados dentro del zoológico para ubicar ciertos animales, estas se identificaran con un nombre. Dentro de un área determinada puede haber animales u otras áreas más específicas, según los requerimientos de las especies que contenga. Por ejemplo, dentro del área de los Reptiles, pueden diferenciarse un área para los caimanes y una para las serpientes. Cada animal será identificado con un nombre y se guardará además la información relativa a su edad y especie a la que pertenece.

De manera general el registro puede verse como un árbol, cuyas hojas son los animales y los nodos intermedios se corresponden con las áreas habilitadas en el zoológico. La raíz de este árbol será el área correspondiente a todo el zoológico, cuyo nombre es `Zoologico`

En su implementación, usted usará la definición de animal que se encuentra en el proyecto `zoologico`:

```cs
public interface IAnimal
{
    int Age { get; }
    string Name { get; }
    string Specie { get; }
}
```

La definición de área también tiene un nombre, y algunos métodos adcionales que usted debe implementar que veremos a continuación:

```cs
public interface IArea
{
    string Name { get; }
    // ...
    // otros métodos que veremos a continuación
}
```

El primer método que debe implementar es `RegisterAnimal()` que permite agregar en el registro a un animal en un área determinada:

```cs
public interface IArea
{
    // ...
    IAnimal RegisterAnimal(string name, int age, string specie);
    // ...
}
```

Este método devuelve una instancia de `IAnimal` que representa el animal agregado al registro, cuyos nombre y edad deben coincidir con los argumentos de entrada.

Otro método similar es `CreateArea` que crea una nueva área dentro del ára correspondiente:

```cs
public interface IArea
{
    // ...
    IArea CreateArea(string name);
    // ...
}
```

Si se agrega al registro un animal con el mismo nombre y edad que uno que ya se encontraba en el área correspondiente debe **lanzar una excepción**.

El registro creado debe ofrecer la posibilidad de enumerar las áreas o los animales existentes, que deben ser devueltos en orden alfabético.

```cs
public interface IArea
{
    // ...
    IEnumerable<IAnimal> GetAnimals();
    IEnumerable<IArea> GetAreas();
    // ...
}
```

Para los directivos del zoológico es importante tener una noción de la edad de los ejemplares en un área determinada, por lo que se agrega la funcionalidad `MeanAge`, que retorna el valor medio de la edad de los animales correspondientes a dicha área.

```cs
public interface IArea
{
    // ...
    int MeanAge();
}
```

Veamos ahora como se integran estas dos interfaces en el registro.

El registro se define en la interface `IRecord`, que usted debe implementar:

```cs
public interface IRecord
{
    // ... métodos que veremos a continuación
}
```

El registro constituye la herramienta a través de la que se mantiene el control de los ejemplares disponibles en el zoológico, así como las áreas disponibles, por lo que debe tener los métodos necesarior para localizar un área o un animal, según la **descripción** correspondiente.

```cs
public interface IRecord
{
    // ...
    IArea GetArea(string description);
    IAnimal GetAnimal(string description);
    IRecord GetRoot(string description);
    // ...
}
```

La descripción de un área o animal es un `string` que contiene todos los nombres desde la raíz del registro hasta el área o animal correspondiente, utilizando `/` como separador. Por ejemplo:

- `Zoologico/` representa la raíz del registro.
- `Zoologico/PraderaAfricana` representa el área del zoológico destinada a los animales africanos.
- `Zoologico/PraderaAfricana/Leones/LeonPepe` representa el animal identificado como `LeonPepe` que está en el área de los `Leones`, que es a su vez está dentro de `PraderaAfricana`, que a su vez es subárea del Zoológico.

El método `GetRoot` devuelve un nuevo **registro** cuya raíz es el área especificada en el método. Por lo tanto, es lo mismo decir:

```cs
var animal = rc.GetAnimal("Zoologico/PraderaAfricana/Leones/LeonPepe");
```

Que decir:

```cs
var rc2 = rc.GetRoot("Zoologico/PraderaAfricana");
var animal = rc2.GetAnimal("/Leones/LeonPepe");
```

Además de identificar las áreas o animales de la institución, puede ser de interes para los trabajadores del zoológico chequear la información de los animales que cumplan con ciertas restricciones (por ejemplo, mayores que cierta edad o de una especie determinada). Para ello se implementa el método `Find`, que recibe un predicado (`predicate`), que enumera los ejemplares del registro que cumplen con la condición definida en el predicado. La enumeración se hace en **preorden** (primero los animales del área actual y luego recursivamente los de las subáreas), recorriendo las áreas y animales en orden alfabético.

```cs
public interface IRecord
{
    // ...
    IEnumerable<IAnimal> Find(Func<IAnimal,bool> predicate);
    // ...
}
```

Finalmente, el registro permite mover a otra área o retirar completamente áreas comlpetas o animales específicos dentro de un área. Para ello se utilizan los siguientes métodos:

```cs
public interface IRecord
{
    // ...
    void Move(string origin, string destination);
    void Remove(string description);
    // ...
}
```

En el caso de `Move`, el origen puede ser un animal o un área, y el destino siempre será un área. Si el origen es un área, se moverá el área, subáreas, y todos los animales de forma recursiva.
Note que siempre se mueve el origen para *dentro* del destino. O sea que si `origin` apunta a un área, tendremos entonces una nueva subárea dentro de `destination` con todo el contenido correspondiente.

Si al mover un área, ya existe otra con el mismo nombre en el destino, entonces los contenidos de ambas áreas **deben mezclarse recursivamente**. En caso de que existan animales con el mismo nombre, **siempre se reemplazará** el existente por el nuevo.

En el caso de `Remove` el argumento `description` puede ser un área o animal. En caso de ser un área, se elimina todo su contenido.

No es posible mover o eliminar la raíz `Zoologico/`. Si esto se intenta, usted debe lanzar una excepción.

## Implementando el Registro

Evidentemente, usted debe dar una implementación de `IRecord`, `IArea` e `IAnimal`. Las clases que implementan estas interfaces, y todo el código adicional que haga falta para su funcionamiento, deben estar en el archivo `exam/Exam.cs`, que será **el único archivo evaluado**.

Para evaluar su código, se ejecutará el método `CreateRecord` en la clase `Exam`. En este método usted debe simplemente devolver una instancia de su implementación de la interfaz `IRecord`.

Recuerde además implementar las propiedades `Nombre` y `Grupo` de la clase `Exam`.

En el proyecto `exam`, archivo `Program.cs`, que es una aplicación de consola, usted puede adicionar todo el código que considere necesario para probar su implementación. Ese código no será evaluado.

Para todos los llamados a todos los métodos que no sean correctos (por ejemplo, pedir información de un área o animal que no exista, mover la raíz u otro), usted puede lanzar una excepción correspondiente.

## Ejemplo

A continuación mostramos un ejemplo sencillo. El código de este ejemplo está en el método `Main` de la clase `Program`.

Empezamos por instanciar un registro nuevo:

```cs
var rc = Exam.CreateRecord();
```

Luego vamos a agregar dos áreas a la raíz (`Zoologico`). Para ello primero debemos obtener una referencia a la raíz, y luego llamar al método `CreateArea`:

```cs
var root = rc.GetArea("Zoologico/");
var prad = root.CreateArea("PraderaAfricana");
var rept = root.CreateArea("Reptiles");
```

Ahora podemos agregar algunos animales:

```cs
for (int i = 0; i < 10; i++)
    prad.CreateAnimal($"Leon{i}", 5,"León");
```

Dado que hay 10 leones de edad 5 en la pradera africana (`prad`), la edad media en dicha área será 5:

```cs
Debug.Assert(prad.MeanAge() == 5);
```

Hagamos lo propio con el área de los reptiles (`rept`):

```cs
rept.CreateAnimal("Cascabel", 8, "Serpiente");
rept.CreateAnimal("Python", 14, "Serpiente");
rept.CreateAnimal("Anaconda", 6, "Serpiente");
```
Verifiquemos que la serpiente más **útil** de todas está en el lugar esperado:

```cs
var pyt = rc.GetAnimal("Zoologico/Reptiles/Python");
Debug.Assert(pyt.Name == "Python");
```

Verificamos el método `Find` con dos expresiones lambda, una para identificar los leones, y otra para identificar animales mayores de 12 años:

```cs
// Verificando el método `Find` con los leones
foreach (var animal in rc.Find(animal => animal.Specie == "León"))
    Debug.Assert(animal.Specie == "León");

// Verificando el método `Find` con edad
foreach (var animal in rc.Find(animal => animal.Age > 12))
    Debug.Assert(animal.Age > 12);
```

Y finalmente vamos a mover los reptiles (`rept`) para dentro de la pradera afreicana (`prad`) y verificar que se realizó correctamente el movimiento:

```cs
rc.Move("Zoologico/Reptiles", "Zoologico/PraderaAfricana");
Debug.Assert(prad.MeanAge() == 6);
Debug.Assert(rc.GetArea("Zoologico/PraderaAfricana/Reptiles").Name ==
                "Reptiles");
```