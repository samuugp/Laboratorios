// See https://aka.ms/new-console-template for more information
using System;
using System;

class Program
{
    static void Main()
    {
        // Solicitar el nombre del estudiante
        Console.WriteLine("Ingrese el nombre del estudiante:");
        string nombre = Console.ReadLine();

        // Solicitar el nombre del curso
        Console.WriteLine("Ingrese el nombre del curso:");
        string curso = Console.ReadLine();

        // Mostrar los datos y un mensaje personalizado en diferentes líneas
        Console.WriteLine("\n--- DATOS DEL ESTUDIANTE ---");
        Console.WriteLine("Nombre del estudiante: " + nombre);
        Console.WriteLine("Curso: " + curso);
        Console.WriteLine("Mensaje: Bienvenido a tu nueva vida de estudioso y menos salidas con los cuates.");

        // Terminar el programa presionando una tecla
        Console.WriteLine("\nPresione una tecla para finalizar...");
        Console.ReadKey();
    }
}