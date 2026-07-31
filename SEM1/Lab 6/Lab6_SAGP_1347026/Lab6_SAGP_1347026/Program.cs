using System;
class Program
{
    static void Main()
    {
        int vehiculo;
        Console.WriteLine("Indique su tipo de vehiculo: 1=Bicicleta 2=Motocicleta 3=Auto 4=Camión 5=Autobus");
        vehiculo = int.Parse(Console.ReadLine());   
        switch(vehiculo)
        {
            case 1: Console.WriteLine("Vehiculo No motorizado");
                break;
                case 2: Console.WriteLine("Vehiculo Ligero");
                break;
                case 3: Console.WriteLine("Vehiculo Mediano");
                break;
                case 4: Console.WriteLine("Vehiculo Pesado");
                break;
                case 5: Console.WriteLine("Transporte Público");
                break;
                default: Console.WriteLine("Vehiculo no identificado");
                break;

        }
        //Ejercicio 2
        int tarjeta;
        Console.WriteLine("Indique su tipo de tarjeta BI");
        tarjeta = int.Parse(Console.ReadLine());
        switch(tarjeta) {
                case 1: Console.WriteLine("Su nuevo limite de crédito es del 25%");
                break;  
                case 2: Console.WriteLine("Su nuevo limite de crédito es del 35%");
                break;
                case 3: Console.WriteLine("Su nuevo límite de crédito es del 40%");
                break;
            default: Console.WriteLine("Su nuevo límite es del 50%");
                break;
    }
        //Ejercicio 3
    
              Console.WriteLine("Ingrese su puntuación (0.0, 0.4 o 0.6):");
        double puntos = double.Parse(Console.ReadLine());

        string nivel = "";
        if (puntos == 0.0)
        {
            nivel = "Inaceptable";
        }
        else 
            if (puntos == 0.4)
        {
            nivel = "Aceptable";
        }
        else 
                if (puntos >= 0.6)
        {
            nivel = "Meritorio";
        }
        else
        {
            nivel = "No válido";
        }
        double dinero = 2400 * puntos;
        if (nivel == "No válido")
        {
            Console.WriteLine("Esa puntuación no existe en la tabla.");
        }
        else
        {
            Console.WriteLine("Nivel: " + nivel);
            Console.WriteLine("Dinero recibido: " + dinero + "€");
            //Ejercicio 4
            Console.WriteLine("Bienvenido a la pizzería Bella Napoli.");
        Console.WriteLine("¿Qué tipo de pizza desea? \n1 = Vegetariana \n2 = No vegetariana");
        int tipo = int.Parse(Console.ReadLine());

        string ingredienteElegido = "";
        string tipoPizza = "";

        switch (tipo)
        {
            case 1:
                tipoPizza = "Vegetariana";
                Console.WriteLine("Ingredientes vegetarianos: \n1 = Pimiento \n2 = Tofu");
                Console.Write("Elija un ingrediente: ");
                int opcionVeg = int.Parse(Console.ReadLine());

     
                switch (opcionVeg)
                {
                    case 1: ingredienteElegido = "Pimiento"; break;
                    case 2: ingredienteElegido = "Tofu"; break;
                    default: ingredienteElegido = "Ninguno"; break;
                }
                break;

            case 2:
                tipoPizza = "No vegetariana";
                Console.WriteLine("Ingredientes no vegetarianos: \n1 = Peperoni \n2 = Jamón \n3 = Salmón");
                Console.Write("Elija un ingrediente: ");
                int opcionNoVeg = int.Parse(Console.ReadLine());

                switch (opcionNoVeg)
                {
                    case 1: ingredienteElegido = "Peperoni"; break;
                    case 2: ingredienteElegido = "Jamón"; break;
                    case 3: ingredienteElegido = "Salmón"; break;
                    default: ingredienteElegido = "No válido"; break;
                }
                break;

            default:
                Console.WriteLine("Opción de pizza no válida.");
              break;
        }
        Console.WriteLine("RESUMEN DE SU PEDIDO ");
        Console.WriteLine("Tipo de pizza: " + tipoPizza);
        Console.WriteLine("Ingredientes: Tomate, Mozzarella y " + ingredienteElegido);
    }
}
}


