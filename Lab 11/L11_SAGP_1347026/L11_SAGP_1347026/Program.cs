using System;

class Program
{
    static void Main()
    {
        // EJERCICIO 1
        Console.WriteLine("\nEjercicio 1 - Validación de contraseña");

        int intentos = 0;
        bool esValida = false;

        while (intentos < 3 && !esValida)
        {
            Console.Write("Ingrese una contraseña: ");
            string clave = Console.ReadLine();

            bool tieneLongitud = clave.Length >= 8;
            bool tieneMayuscula = false;
            bool tieneNumero = false;
            bool tieneEspecial = false;

            for (int i = 0; i < clave.Length; i++)
            {
                char c = clave[i];

                if (char.IsUpper(c)) tieneMayuscula = true;
                if (char.IsDigit(c)) tieneNumero = true;
                if (!char.IsLetterOrDigit(c)) tieneEspecial = true;
            }

            if (tieneLongitud && tieneMayuscula && tieneNumero && tieneEspecial)
            {
                Console.WriteLine("Contraseña válida");
                esValida = true;
            }
            else
            {
                Console.Write("Inválida: ");
                if (!tieneLongitud) Console.Write("falta longitud (mínimo 8), ");
                if (!tieneMayuscula) Console.Write("falta mayúscula, ");
                if (!tieneNumero) Console.Write("falta número, ");
                if (!tieneEspecial) Console.Write("falta carácter especial, ");

                Console.WriteLine();
                intentos++;
            }
        }

        if (!esValida)
        {
            Console.WriteLine("Se agotaron los 3 intentos.");
        }

        // EJERCICIO 2
        Console.WriteLine("\n\nEjercicio 2 - Invertir texto");
        Console.Write("Ingrese una palabra o frase: ");
        string texto = Console.ReadLine();

        string invertido = "";

        for (int i = texto.Length - 1; i >= 0; i--)
        {
            invertido += texto[i];
        }

        Console.WriteLine("Texto invertido: " + invertido);

        // EJERCICIO 3
     
        Console.WriteLine("\nEjercicio 3 - Arreglo (suma, promedio, mayor, menor)");
        Console.Write("¿Cuántos números desea ingresar?: ");
        int cantidad = int.Parse(Console.ReadLine());

        int[] numeros = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write("Ingrese número " + (i + 1) + ": ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        int suma = 0;
        int mayor = numeros[0];
        int menor = numeros[0];

        for (int i = 0; i < numeros.Length; i++)
        {
            suma += numeros[i];

            if (numeros[i] > mayor) mayor = numeros[i];
            if (numeros[i] < menor) menor = numeros[i];
        }

        double promedio = (double)suma / cantidad;

        Console.WriteLine("Suma = " + suma);
        Console.WriteLine("Promedio = " + promedio);
        Console.WriteLine("Mayor = " + mayor);
        Console.WriteLine("Menor = " + menor);

        // EJERCICIO 4
      
        Console.WriteLine("\nEjercicio 4 - Buscar número");

        int[] arreglo = new int[8];

        for (int i = 0; i < 8; i++)
        {
            Console.Write("Ingrese número " + (i + 1) + ": ");
            arreglo[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Ingrese número a buscar: ");
        int buscado = int.Parse(Console.ReadLine());

        int posicion = -1;

        for (int i = 0; i < arreglo.Length; i++)
        {
            if (arreglo[i] == buscado)
            {
                posicion = i;
                break;
            }
        }

        if (posicion != -1)
        {
            Console.WriteLine("El número sí existe en la posición " + posicion);
        }
        else
        {
            Console.WriteLine("El número no existe en el arreglo");
        }

        // EJERCICIO 5
        Console.WriteLine("\nEjercicio 5 - Nombres en arreglo");

        string[] nombres = new string[5];

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Ingrese nombre " + (i + 1) + ": ");
            nombres[i] = Console.ReadLine();
        }

        int contador = 0;
        string nombreLargo = nombres[0];

        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].Length > 5)
            {
                contador++;
            }

            if (nombres[i].Length > nombreLargo.Length)
            {
                nombreLargo = nombres[i];
            }
        }

        Console.Write("Nombres ingresados: ");
        for (int i = 0; i < nombres.Length; i++)
        {
            Console.Write(nombres[i]);
            if (i < nombres.Length - 1) Console.Write(", ");
        }

        Console.WriteLine("\nMás de 5 letras: " + contador);
        Console.WriteLine("Nombre más largo: " + nombreLargo);
    }
}