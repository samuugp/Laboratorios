using System;

class Program
{
    static void Main()
    {
        int opcion, codigoTurno;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== SMARTPARK ===");
        Console.ResetColor();

        Console.Write("Ingrese su nombre (operador): ");
        string nombreOperador = Console.ReadLine();

        // VALIDAR CODIGO DE TURNO (4 dígitos)
        do
        {
            Console.Write("Ingrese su codigo de turno (4 dígitos): ");
            codigoTurno = int.Parse(Console.ReadLine());

            if (codigoTurno < 1000 || codigoTurno > 9999)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: el código debe tener 4 dígitos.");
                Console.ResetColor();
            }

        } while (codigoTurno < 1000 || codigoTurno > 9999);

        // VARIABLES
        int ticketsCreados = 0, ticketsCerrados = 0;
        int tiempoSimulado = 0, tiempoTotal = 0;
        int minutoEntrada = 0, tiempoActual = 0, minutosEstacionados = 0;
        int tipoVehiculo = 0, capacidadParqueo = 10, placa = 0;
        int espaciosOcupados = 0;
        int tarifa = 0, multa = 0;
        int ticketActivo = 0;

        double descuentoVIP = 0.0, montoFinal = 0.0, totalRecaudado = 0.0;

        do
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n===== MENÚ =====");
            Console.ResetColor();

            Console.WriteLine("1. Crear ticket");
            Console.WriteLine("2. Registrar salida");
            Console.WriteLine("3. Ver estado");
            Console.WriteLine("4. Simular tiempo");
            Console.WriteLine("5. Salir");

            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    if (ticketActivo == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: ya existe un ticket activo.");
                        Console.ResetColor();
                    }
                    else if (espaciosOcupados == capacidadParqueo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: parqueo lleno.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Ingrese placa (6-8 números): ");
                        placa = int.Parse(Console.ReadLine());

                        if (placa < 100000 || placa > 99999999)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: placa inválida.");
                            Console.ResetColor();
                        }
                        else
                        {
                            // Tipo vehículo
                            do
                            {
                                Console.Write("Tipo (1 Moto, 2 Auto, 3 Pickup): ");
                                tipoVehiculo = int.Parse(Console.ReadLine());

                                if (tipoVehiculo < 1 || tipoVehiculo > 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: opción inválida.");
                                    Console.ResetColor();
                                }

                            } while (tipoVehiculo < 1 || tipoVehiculo > 3);

                            Console.Write("Nombre cliente: ");
                            string nombreCliente = Console.ReadLine();

                            minutoEntrada = tiempoTotal;

                            ticketActivo = 1;
                            ticketsCreados++;
                            espaciosOcupados++;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ticket creado correctamente.");
                            Console.ResetColor();
                        }
                    }
                    break;

                case 2:
                    if (ticketActivo == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: no hay ticket activo.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Ingrese minutos estacionado: ");
                        tiempoActual = int.Parse(Console.ReadLine());

                        minutosEstacionados = tiempoActual;

                        if (minutosEstacionados <= 15)
                        {
                            montoFinal = 0;
                        }
                        else
                        {
                            int horas = minutosEstacionados / 60;

                            if (minutosEstacionados % 60 != 0)
                            {
                                horas++;
                            }

                            // TARIFA
                            if (tipoVehiculo == 1)
                                tarifa = 5 * horas;
                            else if (tipoVehiculo == 2)
                                tarifa = 10 * horas;
                            else
                                tarifa = 15 * horas;

                            // MULTA
                            if (minutosEstacionados > 360)
                                multa = 25;
                            else
                                multa = 0;

                            Console.Write("¿Cliente VIP? (1=Sí, 0=No): ");
                            int VIP = int.Parse(Console.ReadLine());

                            if (VIP == 1)
                                descuentoVIP = tarifa * 0.10;
                            else
                                descuentoVIP = 0;

                            montoFinal = tarifa + multa - descuentoVIP;
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Total a pagar: Q" + montoFinal);
                        Console.ResetColor();

                        totalRecaudado += montoFinal;
                        ticketsCerrados++;
                        ticketActivo = 0;
                        espaciosOcupados--;
                        tiempoTotal += minutosEstacionados;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Salida registrada.");
                        Console.ResetColor();
                    }
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n--- ESTADO ---");
                    Console.WriteLine("Capacidad: " + capacidadParqueo);
                    Console.WriteLine("Ocupados: " + espaciosOcupados);
                    Console.WriteLine("Disponibles: " + (capacidadParqueo - espaciosOcupados));
                    Console.WriteLine("Tiempo total: " + tiempoTotal);
                    Console.WriteLine("Recaudado: Q" + totalRecaudado);
                    Console.WriteLine("Tickets creados: " + ticketsCreados);
                    Console.WriteLine("Tickets cerrados: " + ticketsCerrados);
                    Console.ResetColor();
                    break;

                case 4:
                    do
                    {
                        Console.Write("Minutos a simular (1-1440): ");
                        tiempoSimulado = int.Parse(Console.ReadLine());

                        if (tiempoSimulado < 1 || tiempoSimulado > 1440)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: fuera de rango.");
                            Console.ResetColor();
                        }

                    } while (tiempoSimulado < 1 || tiempoSimulado > 1440);

                    tiempoTotal += tiempoSimulado;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tiempo actualizado: " + tiempoTotal);
                    Console.ResetColor();
                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n--- RESUMEN FINAL ---");
                    Console.WriteLine("Operador: " + nombreOperador);
                    Console.WriteLine("Total recaudado: Q" + totalRecaudado);
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: opción inválida.");
                    Console.ResetColor();
                    break;
            }

        } while (opcion != 5);
    }
}