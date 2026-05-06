using System;
class Program
{
    static void Main()
    {
        //Ejercicio 1
        Console.WriteLine("Ejercicio 1");
        Console.Write("Ingresa un número: ");
        int numeroUsuario = int.Parse(Console.ReadLine());

        while (numeroUsuario < 0)
        {
            Console.WriteLine("Numero incorrecto, intente nuevamente");
            numeroUsuario = int.Parse(Console.ReadLine());
        }

        int sumaFinal = CalcularSumaDigitos(numeroUsuario);
        Console.WriteLine("El resultado es: " + sumaFinal);

        //Ejercicio 2
        Console.WriteLine();
        Console.WriteLine("Ejercicio 2");
        Console.Write("Ingrese un número entero: ");
        int valorNumero = int.Parse(Console.ReadLine());
        Console.WriteLine("Número ingresado: " + valorNumero);
        string resultadoOperacion = ElevarCuadrado(ref valorNumero);
        Console.WriteLine("Número elevado al cuadrado: " + valorNumero);
        Console.WriteLine(resultadoOperacion);

        //Ejercicio 3
        Console.WriteLine();
        Console.WriteLine("Ejercicio 3");
        Console.Write("Ingrese el precio del producto: ");
        float precioProducto = float.Parse(Console.ReadLine());

        Console.Write("Ingrese el descuento del producto (Ejemplo: 0.25): ");
        float porcentajeDescuento = float.Parse(Console.ReadLine());
        while (porcentajeDescuento < 0.00 || porcentajeDescuento > 1.00)
        {
            Console.WriteLine("Coloca correctamente el descuento");
            porcentajeDescuento = float.Parse(Console.ReadLine());
        }

        Console.WriteLine("Antes --> Precio: " + precioProducto + " Descuento: " + porcentajeDescuento);
        float descuentoAplicado = AplicarDescuento(ref precioProducto, porcentajeDescuento);
        Console.WriteLine("Despues --> Precio: " + precioProducto + " Descuento: " + descuentoAplicado);

        //Ejercicio 4
        Console.WriteLine();
        Console.WriteLine("Ejercicio 4");
        Console.WriteLine("Ingrese las unidades de energia del jugador (Max:20): ");
        int nivelEnergia = int.Parse(Console.ReadLine());

        while (nivelEnergia > 20 || nivelEnergia < 1)
        {
            Console.WriteLine("Energia inválida, intente nuevamente");
            nivelEnergia = int.Parse(Console.ReadLine());
        }
        ReducirEnergia(ref nivelEnergia);
        Console.WriteLine("Energia restante: " + nivelEnergia);
        AumentarEnergia(ref nivelEnergia);
        Console.WriteLine("Energia recargada: " + nivelEnergia);
        string estadoEnergia = ObtenerEstadoEnergia(nivelEnergia);
        Console.WriteLine("Estado de la energia: " + estadoEnergia);
        char calificacion = CalcularNivelRendimiento(nivelEnergia);
        Console.WriteLine("Rendimiento: " + calificacion);
    }

    static string ObtenerEstadoEnergia(int energia)
    {
        string nivel;
        if (energia <= 20 && energia >= 15)
        {
            nivel = "Alta";
        }
        else
        {
            if (energia <= 14 && energia >= 8)
            {
                nivel = "Media";
            }
            else
            {
                nivel = "Baja";
            }
        }
        return nivel;
    }

    static int CalcularSumaDigitos(int valor)
    {
        int acumulador = 0;
        while (valor > 0)
        {
            acumulador += valor % 10;
            valor = valor / 10;
        }
        return acumulador;
    }

    static int AumentarEnergia(ref int energia)
    {
        energia += 6;
        if (energia > 20)
        {
            energia = 20;
        }
        return energia;
    }

    static float AplicarDescuento(ref float costo, float porcentaje)
    {
        float totalDescuento = costo * porcentaje;
        costo -= totalDescuento;
        return totalDescuento;
    }

    static char CalcularNivelRendimiento(int energia)
    {
        char resultado;
        if (energia == 20)
        {
            resultado = 'S';
        }
        else
        {
            if (energia <= 19 && energia >= 15)
            {
                resultado = 'A';
            }
            else if (energia <= 14 && energia >= 8)
            {
                resultado = 'B';
            }
            else
            {
                resultado = 'C';
            }
        }
        return resultado;
    }

    static string ElevarCuadrado(ref int dato)
    {
        dato = dato * dato;
        return "Operación Exitosa";
    }

    static int ReducirEnergia(ref int energia)
    {
        energia -= 4;
        if (energia < 0)
        {
            energia = 0;
        }
        return energia;
    }
}

