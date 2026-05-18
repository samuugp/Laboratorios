using System; //No se usa punto y coma 
class Program
{
    static void Main()
    {
        string nombre; //No usar punto y coma //Error de sintaxis
        int edad;
        Console.WriteLine("Ingrese su nombre:");
        nombre= Console.ReadLine();
        Console.WriteLine("Ingrese su edad:");
        edad= int.Parse(Console.ReadLine());
    Console.WriteLine("Hola " + nombre);
        Console.WriteLine("Tienes " + edad + " años");
        if (edad >= 18)// se abrio con llaves el if 
            Console.WriteLine("Eres mayor de edad");
        else
            Console.WriteLine("Eres menor de edad");
        //Ejercicio 2
        double nota1, nota2, nota3, promedio;
        Console.WriteLine("Ingrese la primera nota:");
        nota1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la segunda nota:");
        nota2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la tercera nota:");
        nota3 = double.Parse(Console.ReadLine());
        promedio = (nota1 + nota2 + nota3) / 3; 
        //Divide la tercer nota entre 3 por la falta de parentesis (Jerarquia incorrecta )
        //Error logico // Se agregó el parentesis
        Console.WriteLine("El promedio es: " + promedio);
        if (promedio >= 61)
        {
            Console.WriteLine("El estudiante aprobó");
        }
        else
        {
            Console.WriteLine("El estudiante reprobó");
        }
        //Ejercicio 3
        int[] numeros = new int[5];
        int suma = 0;

        for (int i = 0; i <= 4; i++)
        {
            int numero;
            bool valido = false;
            while (!valido)
            {
                Console.WriteLine("Ingrese un número:");
                if (int.TryParse(Console.ReadLine(), out numero))
                {
                    numeros[i] = numero;
                    valido = true;
                }
                else
                {
                    Console.WriteLine("Entrada no valida, tiene que ser numero entero");
                }
            }
        }
        for (int i = 0; i <= 4; i++)
        {
            suma = suma + numeros[i];
        }

        Console.WriteLine("La suma total es: " + suma);
        //Da error porque el arreglo es de 5 pero cuenta desde cero, el ciclo debe ser hasta 4 
        //Ejercicio 4
        double baseRectangulo = 0, alturaRectangulo = 0;
        bool nValido = false;

        while (!nValido)
        {
            Console.WriteLine("Ingrese la base del rectángulo:");
            if (double.TryParse(Console.ReadLine(), out baseRectangulo))
            {
                if (baseRectangulo > 0)
                    nValido = true;
                else
                    Console.WriteLine("La base debe ser mayor a cero, intente de nuevo");
            }
            else
            {
                Console.WriteLine("Entrada inválida, ingrese un número");
            }
        }
        nValido = false;
        while (!nValido)
            {
                Console.WriteLine("Ingrese la altura del rectángulo:");
                if (double.TryParse(Console.ReadLine(), out alturaRectangulo))
                {
                    if (alturaRectangulo > 0)
                        nValido = true;
                    else
                        Console.WriteLine("La altura debe ser mayor a cero. Intente de nuevo.");
                }
                else
                {
                    Console.WriteLine("Entrada inválida, ingrese un número.");
                } // Ciclos de validación de que debe ser un numero y no texto, y que el numero debe ser mayo a cero
            

            double area = CalcularArea(baseRectangulo, alturaRectangulo);

        Console.WriteLine("El área es: " + area);

        if (area >= 100) // Esta mal, el programa pide que sea grande si es igual o mayor a 100 y está calculado de mayor a 100
        {
            Console.WriteLine("El área es grande");
        }
        else
        {
            Console.WriteLine("El área es pequeña");
        }
    }

    static double CalcularArea(double baseRectangulo, double alturaRectangulo)
    {
        double resultado = baseRectangulo * alturaRectangulo; //Error logico, es b*h
        return resultado;
    }
        //Ejercicio 5
        
        int[] edades = new int[5];
        suma = 0;
        int mayores = 0;
        promedio = 0;
        for (int i = 0; i < 5; i++)
        {
            int edads;
            bool valido = false;

            while (!valido)
            {
                Console.WriteLine("Ingrese la edad de la persona " + (i + 1) + ":");

                // Validación: entrada debe ser número entero
                if (int.TryParse(Console.ReadLine(), out edads))
                {
                    // Validación: la edad debe ser positiva
                    if (edads >= 0)
                    {
                        edades[i] = edads;
                        suma += edads;

                        if (edades[i] >= 18)
                        {
                            mayores++;
                        }
                        valido = true;
                    }
                    else
                    {
                        Console.WriteLine("La edad no puede ser negativa.");
                    }
                }
                else
                {
                    Console.WriteLine("Debe ser un número entero");
                }
            }
        }
        promedio = (double)suma / 5;

        Console.WriteLine("El promedio de edades es: " + promedio);
        Console.WriteLine("Cantidad de mayores de edad: " + mayores);

        // Análisis de la solución generada por IA:
        // Error 1: El ciclo empieza en 1 y llega hasta edades], debe ser hasta 4
        // Error 2: La condición para mayoreses >18, eso quita a los que tienen 18
        // Error 3:promedio divide en 5 y no esta en double
        // Limitación encontrada: La IA no agrego validaciones de entrada
        // Importancia de la validación humana: El código se ve bien pero no esta bien escrito, puede que porque falten instrucciones especificas,
        // por eso es bueno revisar saber lo que se esta haciendo, la ia esta para amplificar las cualidades que tenemos y hacer un trabajo mas eficiente, pero no que sea el
        // autor de nuestro trabajo, es mejor usarlo para verificar no solo el codigo hecho, sino que analice una variedad de casos que se puedan presentar y evitar errores futuros

    }
} // Faltó cerrar el Program en el 1


