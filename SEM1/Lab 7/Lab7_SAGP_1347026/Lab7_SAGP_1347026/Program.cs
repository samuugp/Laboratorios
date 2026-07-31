using System;
using System.Drawing;
class Program
{
    static void Main()
    {
        //Ejercicio1
        //Entrada
        int numero;
        int contador = 0;
        int suma = 0;
        Console.WriteLine("Ingrese el número deseado");
        numero=int.Parse(Console.ReadLine());
        //Proceso y Salida
        while (numero <= 0)
        {
            Console.WriteLine("Ingrese un número positivo");
            numero = int.Parse(Console.ReadLine());

        }
        while (contador <= numero) 
        {
            suma = suma + contador;
            contador++;
        }
        float promedio = suma / numero;
        Console.WriteLine("La suma es " + suma);
        Console.WriteLine("El promedio es "+ promedio);

        //Ejercicio 2
        //Entrada
        double valores, resultado;
        int opciones;
        do
        {
            Console.Write("Elija una opción: ");
            Console.WriteLine("MENU DE CONVERSION");
            Console.WriteLine("1. Convertir Celsius a Fahrenheit");
            Console.WriteLine("2. Convertir Fahrenheit a Celsius");
            Console.WriteLine("3. Convertir Kilómetros a Millas");
            Console.WriteLine("4. Salir");
           opciones = int.Parse(Console.ReadLine());
            switch(opciones) {
                case 1:
                    Console.WriteLine("Ingrese grados Celsius:");
                    valores = double.Parse(Console.ReadLine());
                    resultado = (valores * 9 / 5) + 32;
                    Console.WriteLine("Su resultado es: " + resultado);
                    break;
                case 2: Console.WriteLine("Ingrese grados Fahrenheit");
                       valores= double.Parse(Console.ReadLine());
                    resultado = (valores - 32) * 5 / 9;
                    Console.WriteLine("Su resultado es: "+ resultado);
                    break;  
                    case 3: Console.WriteLine("Ingrese los kilometros");
                    valores= double.Parse(Console.ReadLine());
                    resultado = valores * 0.6;
                    Console.WriteLine("Su resultado es:" + resultado);
                    break;
                    case 4: Console.WriteLine("Adiós");
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
                  
            }
        } while (opciones != 4);
        // Ejercicio 3
        //Entrada
        Random random = new Random();
        int numeroSecreto = random.Next(1, 101);
        int numeror = 0;
        int intentos = 0;
        //proceso
        while (numeror != numeroSecreto)
        {
            Console.WriteLine("Ingrese un número entre 1 y 100:");
            numeror = int.Parse(Console.ReadLine());

            if (numeror < 1 || numeror > 100)
            {
                Console.WriteLine("Número fuera de rango");
            }
            else
            {
                intentos++;
                //Salida
                if (numeror < numeroSecreto)
                {
                    Console.WriteLine("Más alto");
                }
                else if (numeror > numeroSecreto)
                {
                    Console.WriteLine("Más bajo");
                }
                else
                {
                    Console.WriteLine("¡Correcto!");
                    Console.WriteLine("Intentos: " + intentos);
                }
            }
        }
        //Ejercicio 4
        int pin;
        int pinCorrecto = 1234;
        int intento = 0;
        //Entrada
        do
        {
            Console.WriteLine("Ingrese el PIN:");
            pin = int.Parse(Console.ReadLine());
            //proceso
            if (pin == pinCorrecto)
            {
                Console.WriteLine("Acceso concedido");
                break;
            }
            else
            {
                Console.WriteLine("PIN incorrecto");
            }

            intentos++;

        } while (intento < 3);
        //Salida
        if (intento == 3 && pin != pinCorrecto)
        {
            Console.WriteLine("Cuenta bloqueada");
        }
    }


    }