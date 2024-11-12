# Organizador de especies

> *Prueba Intra-semestral de Programación - Curso 2022*

**NOTA**: *Antes de comenzar asegúrese de descompactar el archivo `species-organizer.zip` y abrir la solución `species-organizer.sln` en su editor. Asegúrese también de que su código compila, y la aplicación de consola ejecuta (debe lanzar una excepción). Recuerde que todo el código a evaluar debe ir en el archivo `Exam.cs` de la aplicación de consola `exam`.*

En este ejercicio vamos a implementar un sistema sencillo para organizar las especies de animales en un zoológico. De cada especie tendremos su nombre y la cantidad de especímenes en existencia en el zoológico que podrá ser aumentada o disminuida.

Además, cada especie pertenece a un grupo taxonómico, que a su vez puede pertenecer a otro grupo taxonómico más general, creándose así un árbol de grupos taxonómicos, donde en cualquier nivel puede haber especies concretas y/o otros grupos taxonómicos.

Por ejemplo:

```yaml
- Felidae
    - Felis
        - Catus (3)
        - Silvestris (2)
    - Panthera
        - Leo (4)
        - Tigris (1)
        - Onca (2)
- Canidae
    - Canis
        - Lupus familiaris (1)
        - Lupus (5)
        - Latrans (2)
    - Cuon
        - Alpinus (3)
        - Alpinus lupaster (1)
```

La funcionalidad principal del sistema de organización de especies se encuentra en la interfaz `ISpeciesOrganizer`.

```cs
interface ISpeciesOrganizer
{
    // Grupo taxonómico raíz
    ITaxonomicGroup Root { get; }

    // Navegar por los grupos taxonómicos y especies
    ITaxonomicGroup GetTaxonomicGroup(params string[] taxonomicGroups);
    ISpecies GetSpecies(string name, params string[] taxonomicGroups);

    // Buscar las especies que cumplen con una condición
    IEnumerable<ISpecies> FindAll(Filter<ISpecies> filter);
}
```

Como es usual, usted devolverá una instancia de su implementación de esta interfaz en el método estático `Exam.GetSpeciesOrganizer` de la clase `Exam` en el archivo `Exam.cs` de la aplicación de consola.

Veremos a continuación cada uno de los métodos que usted debe implementar.

## Grupos taxonómicos

Un grupo taxonómico se define mediante la interfaz `ITaxonomicGroup`. La interfaz `ITaxonomicGroup` se define así (veremos los métodos uno a uno).

```cs
interface ITaxonomicGroup
{
    string Name { get; }

    // Crear subgrupos taxonómicos
    ITaxonomicGroup CreateSubtaxonomicGroup(string name);

    // Crear o actualizar la cantidad de especimen de una especie
    void UpdateSpecimen(string name, int change);

    // Enumerar todos los subgrupos taxonómicos (en este nivel)
    IEnumerable<ITaxonomicGroup> SubtaxonomicGroups { get; }

    // Enumerar todas los especies (en este nivel)
    IEnumerable<ISpecies> Species { get; }

    // Grupo taxonómico padre
    ITaxonomicGroup Parent { get; }
}
```

Todo organizador de especies se crea con un grupo taxonómico raíz, cuyo nombre es el `string` vacío. Este es el grupo taxonómico que se devuelve en la propiedad `Root` de la interfaz `ISpeciesOrganizer`.

Para obtener un grupo taxonómico arbitrario, se puede usar el método `GetTaxonomicGroup` de la interfaz `ISpeciesOrganizer` que recibe un array de `string` con los nombres de los grupos taxonómicos intermedios.

Por ejemplo, para obtener el grupo taxonómico `"Felidae"` se invocaría a este método de la siguiente forma:

```cs
ISpeciesOrganizer organizer = Exam.GetSpeciesOrganizer();
ITaxonomicGroup felidae = organizer.GetTaxonomicGroup("Felidae");
```

En caso de no existir el grupo taxonómico pedido usted debe lanzar una excepción de tipo `ArgumentException`.

Una vez que tenemos una referencia a un grupo táxonimco, es posible utilizarlo para crear nuevos subgrupos taxonómicos. Por ejemplo para crear un subgrupo taxonómico `Acinonyx` dentro del grupo taxonómico `Felidae`:

```cs
ITaxonomicGroup acinonyx = felidae.CreateSubtaxonomicGroup("Acinonyx");
```

Por supuesto, una vez que este grupo taxonómico ha sido creado, desde el organizador de especies original es posible obtener exactamente la misma referencia:

```cs
Debug.Assert(acinonyx == organizer.GetTaxonomicGroup("Felidae", "Acinonyx"));
```

La propiedad `Parent` en `ITaxonomicGroup` devuelve una referencia al grupo taxonómico padre. En el caso de ser el grupo taxonómico raíz, devuelve una referencia a sí mismo (nunca `null`).

## Especies

En cualquier grupo taxonómico, el método `UpdateSpecimen` aumenta (o disminuye) la cantidad de especímenes de cualquier especie.

Si una especie existe, su cantidad se modifica en el valor `change` que puede ser positivo o negativo. Si una especie no existe en ese grupo taxonómico, se crea automáticamente cuando se invoque este método con la cantidad pasada. Si se tiene una referencia a una especie, se debe mantener la misma referencia luego de cambiar su cantidad de especímenes.

```cs
ITaxonomicGroup felis = organizer.GetTaxonomicGroup("Felidae", "Felis")

ISpecies catus = organizer.GetSpecies("Catus", "Felidae", "Felis");

// Disminuye en 1 la cantidad de gatos
felis.UpdateSpecimen("Catus", -1);

// Crea una nueva especie
felis.UpdateSpecimen("Uncia", 10);

Debug.Assert(catus == organizer.GetSpecies("Catus", "Felidae", "Felis"));
```

Por supuesto ninguna especie puede bajar de `0` ni crearse con una cantidad negativa. En cualquiera de estos casos usted debe lanzar una excepción de tipo `ArgumentException`.

La propiedad `SubtaxonomicGroups` enumera todos los subgrupos taxonómicos que son hijos immediatos de este grupo taxonómico.

La propiedad `Species` enumera todas las especies **con cantidad mayor que cero** immediatamente en este grupo taxonómico. Esta propiedad devuelve instancias de la interfaz `ISpecies` que simplemente almacena el nombre y cantidad de especímenes, así como una referencia al grupo taxonómico al que pertenece:

```cs
interface ISpecies
{
    string Name { get; }
    int Count { get; set; }
    ITaxonomicGroup Parent { get; }
}
```

En la interfaz `ISpeciesOrganizer` el método `GetSpecies`, muy similar a `GetTaxonomicGroup`, devuelve directamente la especie correspondiente, dado su nombre y los grupos taxonómicos a los que pertenece. Por ejemplo:

```cs
ISpecies lupus = organizer.GetSpecies("Lupus", "Canis", "Canidae");
Debug.Assert(lupus.Count == 5);
```

## Filtrado de especies

El método `FindAll` de la interfaz `ISpeciesOrganizer` enumera todas las especies que cumplen con cierta condición, definida por el delegado `Filter`:

```cs
delegate bool Filter<T>(T item);
```

Por ejemplo, para encontrar todas las especies que tienen menos de 5 especímenes:

```cs
foreach(var specie in organizer.FindAll(s => s.Count < 5))
{
    // Verificando que efectivamente tiene menos de 5
    Debug.Assert(specie.Count > 0 && specie.Count < 5);
}
```

## Ejemplos de prueba

En la aplicación de consola encontrará un ejemplo de prueba muy similar a lo que hemos visto hasta ahora, que le permitirá verificar que los métodos básicos funcionan.

**NOTA**: El ejemplo de prueba es insuficiente para garantizar que su código está 100% correcto. En particular, los métodos de iteradores no se verifican. Es su responsabilidad adicionar tantos casos de prueba como considere necesario para garantizar la correctitud de su solución.

¡Éxitos a todos!
