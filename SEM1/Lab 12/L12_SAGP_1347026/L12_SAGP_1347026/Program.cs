using System;

class Program
{
    static void Main()
    {

        // =========================
        // EJERCICIO 1
        // =========================
        Console.WriteLine("\nEjercicio 1");

        int[,] m1 = new int[4, 4];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"Ingrese valor [{i},{j}]: ");
                m1[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int fila;
        do
        {
            Console.Write("Ingrese fila (0-3): ");
            fila = int.Parse(Console.ReadLine());
        } while (fila < 0 || fila > 3);

        int col;
        do
        {
            Console.Write("Ingrese columna (0-3): ");
            col = int.Parse(Console.ReadLine());
        } while (col < 0 || col > 3);

        int sumaFila = 0;
        for (int j = 0; j < 4; j++)
        {
            sumaFila += m1[fila, j];
        }

        int sumaCol = 0;
        for (int i = 0; i < 4; i++)
        {
            sumaCol += m1[i, col];
        }

        Console.WriteLine("Suma fila: " + sumaFila);
        Console.WriteLine("Suma columna: " + sumaCol);

        // =========================
        // EJERCICIO 2
        // =========================
        Console.WriteLine("\nEjercicio 2");

        float[,] m2 = new float[3, 5];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"Ingrese valor [{i},{j}]: ");
                m2[i, j] = float.Parse(Console.ReadLine());
            }
        }

        float mayor = m2[0, 0];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (m2[i, j] > mayor)
                    mayor = m2[i, j];
            }
        }

        Console.WriteLine("Mayor: " + mayor);

        // =========================
        // EJERCICIO 3
        // =========================
        Console.WriteLine("\nEjercicio 3");

        int[,] A = new int[3, 2];
        int[,] B = new int[2, 3];
        int[,] R = new int[3, 3];

        Console.WriteLine("Matriz A");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write($"[{i},{j}]: ");
                A[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Matriz B");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"[{i},{j}]: ");
                B[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                R[i, j] = 0;
                for (int k = 0; k < 2; k++)
                {
                    R[i, j] += A[i, k] * B[k, j];
                }
            }
        }

        Console.WriteLine("Resultado:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(R[i, j] + " ");
            }
            Console.WriteLine();
        }

        // =========================
        // EJERCICIO 4
        // =========================
        Console.WriteLine("\nEjercicio 4");

        int[,] m4 = new int[5, 5];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"[{i},{j}]: ");
                m4[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int sumaDP = 0;
        int sumaDS = 0;

        for (int i = 0; i < 5; i++)
        {
            sumaDP += m4[i, i];
            sumaDS += m4[i, 4 - i];
        }

        Console.WriteLine("Diagonal principal: " + sumaDP);
        Console.WriteLine("Diagonal secundaria: " + sumaDS);
    }
}