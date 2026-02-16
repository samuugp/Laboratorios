using System;
class program{
    static void Main() {
        //Ejercicio 1
        String modelo = "Radiador springs";
        Console.WriteLine("El modelo de la nave es " + modelo);
        int carga = 225;
        Console.WriteLine("Capacidad de carga= " + carga);
        float Combustible = 40.3f;
        Console.WriteLine("Nivel de combustible= " + Combustible);
        bool salto = true;
        Console.WriteLine("Motor de salto activo: " + salto);

        //Ejercicio 2
        short sensoresActivos = 128;
        int registroProcesador = sensoresActivos;
        double PrecisionTotal = registroProcesador;

        Console.WriteLine("El procesador central tiene : " + PrecisionTotal);

        // Ejercicio #3

        Console.WriteLine();
        double energiaGenerada = 987.65f;
        int energialimitada = (int)energiaGenerada;
        Console.WriteLine("Energia generada de : " + energiaGenerada);
        Console.WriteLine("Energia limitada de: " + energialimitada);

        // Ejercicio # 4

        Console.WriteLine("Ingrese distancia al planeta mas cercano");
        string entradaRadar = Console.ReadLine();
        int distancia = int.Parse (entradaRadar);
        int distanciaFinal = distancia + 100;
        Console.WriteLine("La distancia final es: " + distanciaFinal);

        // Ejercicio 5

        Console.WriteLine();
        string señaloxigeno = "True";
        bool oxigenoBool = Convert.ToBoolean(señaloxigeno);
        string temperaturacabina = "22.8";
        double temCabi = Convert.ToDouble(temperaturacabina);
        Console.WriteLine("El oxigeno en la actualidad es: " + oxigenoBool);
        Console.WriteLine("La temperatura es: " + temCabi);

        // Ejercicio 6
        Console.WriteLine();
        double velocidadluz = 299792.458;
        string VelocidadString = velocidadluz.ToString("N3");
        Console.WriteLine("La velocidad es: " + VelocidadString);

        //Ejercicio 7
        Console.WriteLine("Coloque el Precio por Galón de Litio");
        string precioGalon = Console.ReadLine();
        double precio = Convert.ToDouble(precioGalon);

        double impuestoGaláctico = (precio) * 0.12;     
            double costoTotal =precio + impuestoGaláctico;
            Console.WriteLine("El costo final es: " + (int)costoTotal);
    }
}

