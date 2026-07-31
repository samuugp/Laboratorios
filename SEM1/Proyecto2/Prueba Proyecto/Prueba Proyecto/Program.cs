using System;

class Parcela
{
    // Atributos parcela 
    public string tipoCultivo = "Vacía";
    public int crecimientoActual = 0;
    public int crecimientoMax = 0;
    public bool regada = false;
}

class Program
{
    static void Main(string[] args)
    {
        // Variables de configuración inicial 
        double dinero = 0;
        double ingresos = 0;
        double egresos = 0;
        int empleados = 0;
        double sueldo = 0;
        int mesesTotalesSimular = 0;
        int mesesRestantes = 0;
        int filas = 0;
        int columnas = 0;

        // Variables del reporte Final 
        int totalRiegos = 0;
        int cosechasPapa = 0;
        int cosechasTomate = 0;
        int cosechasFresa = 0;
        int sembradasPapa = 0;
        int sembradasTomate = 0;
        int sembradasFresa = 0;

        Console.WriteLine("=== LA GRANJA ===");

        //Entrada de datos 
        dinero = LeerDoublePositivo("Ingrese cantidad de dinero inicial (Q): ");
        empleados = LeerIntPositivo("Ingrese número de empleados: ");
        sueldo = LeerDoublePositivo("Ingrese sueldo por empleado (Q): ");
        mesesTotalesSimular = LeerIntPositivo("Ingrese meses por simular: ");
        mesesRestantes = mesesTotalesSimular;
        filas = LeerIntPositivo("Ingrese cantidad de filas para las parcelas: ");
        columnas = LeerIntPositivo("Ingrese cantidad de columnas para las parcelas: ");

        // Inicio de parcelas 
        Parcela[,] granja = new Parcela[filas, columnas];
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                granja[i, j] = new Parcela();
            }
        }

        int opcion = 0;

        // Ciclo principal //Menú 
        do
        {
            Console.Clear();
            Console.WriteLine("===== GESTIÓN DE GRANJA (Dinero: Q " + dinero + "| Meses Restantes: " + mesesRestantes + ") =====");
            Console.WriteLine("1. Sembrar");
            Console.WriteLine("2. Regar Parcela");
            Console.WriteLine("3. Consultar Parcela");
            Console.WriteLine("4. Avanzar de mes");
            Console.WriteLine("5. Salir");
            opcion = LeerIntRango("Seleccione una opción: ", 1, 5);

            switch (opcion)
            {
                case 1: // SEMBRAR
                    Console.WriteLine("\n--- SEMBRAR ---");
                    int fSemb = LeerIntRango("Ingrese fila: ", 0, filas - 1);
                    int cSemb = LeerIntRango("Ingrese columna: ", 0, columnas - 1);

                    if (granja[fSemb, cSemb].tipoCultivo == "Vacía")
                    {
                        Console.WriteLine("Tipos de siembra disponibles:");
                        Console.WriteLine("1. Papa (2 meses / Cosecha: Q450)");
                        Console.WriteLine("2. Tomate (3 meses / Cosecha: Q650)");
                        Console.WriteLine("3. Fresa (4 meses / Cosecha: Q900)");
                        int tipo = LeerIntRango("Seleccione el cultivo: ", 1, 3);

                        if (tipo == 1)
                        {
                            granja[fSemb, cSemb].tipoCultivo = "Papa";
                            granja[fSemb, cSemb].crecimientoMax = 2;
                            sembradasPapa++;
                        }
                        else if (tipo == 2)
                        {
                            granja[fSemb, cSemb].tipoCultivo = "Tomate";
                            granja[fSemb, cSemb].crecimientoMax = 3;
                            sembradasTomate++;
                        }
                        else if (tipo == 3)
                        {
                            granja[fSemb, cSemb].tipoCultivo = "Fresa";
                            granja[fSemb, cSemb].crecimientoMax = 4;
                            sembradasFresa++;
                        }
                        Console.WriteLine("¡Se ha sembrado " + granja[fSemb, cSemb].tipoCultivo + " con éxito!");
                    }
                    else
                    {
                        Console.WriteLine("Error: La parcela ya tiene un cultivo asignado.");
                    }
                    break;

                case 2: // REGAR PARCELAS
                    Console.WriteLine("\n--- REGAR PARCELA ---");
                    int fReg = LeerIntRango("Ingrese fila: ", 0, filas - 1);
                    int cReg = LeerIntRango("Ingrese columna: ", 0, columnas - 1);

                    Parcela pSeleccionada = granja[fReg, cReg];

                    if (pSeleccionada.tipoCultivo == "Vacía") // Regla: Solo parcelas con siembra 
                    {
                        Console.WriteLine("Error: No se puede regar una parcela vacía.");
                    }
                    else if (pSeleccionada.regada) // Regla: Solo una vez al mes
                    {
                        Console.WriteLine("Error: Esta parcela ya fue regada en el mes actual.");
                    }
                    else if (dinero < 40)
                    {
                        Console.WriteLine("Error: No hay suficiente dinero para cubrir el costo de riego (Q40).");
                    }
                    else
                    {
                        dinero -= 40;
                        egresos += 40;
                        pSeleccionada.regada = true;
                        totalRiegos++;
                        Console.WriteLine("Parcela regada exitosamente. Costo: Q40.");
                    }
                    break;

                case 3: // CONSULTAR PARCELA 
                    Console.WriteLine("\n--- CONSULTAR PARCELA ---");
                    int fCon = LeerIntRango("Ingrese fila: ", 0, filas - 1);
                    int cCon = LeerIntRango("Ingrese columna: ", 0, columnas - 1);

                    Parcela pCon = granja[fCon, cCon];

                    if (pCon.tipoCultivo == "Vacía")
                    {
                        Console.WriteLine("Estado: La parcela se encuentra vacía y disponible para siembra.");
                    }
                    else
                    {
                        Console.WriteLine("• Tipo de siembra: " + pCon.tipoCultivo);
                        Console.WriteLine("• Estado de crecimiento: " + pCon.crecimientoActual + "/" + pCon.crecimientoMax + " meses");
                        Console.WriteLine("• Regada este mes: " + (pCon.regada ? "Si" : "No"));
                    }
                    break;

                case 4: // AVANZAR DE MES 
                    Console.WriteLine("\n--- AVANZANDO DE MES ---");
                    mesesRestantes--;

                    // 1. Pago de empleados
                    double costoPlanilla = empleados * sueldo;
                    dinero -= costoPlanilla;
                    egresos += costoPlanilla;
                    Console.WriteLine("[EGRESO] Se pagaron Q" + costoPlanilla + " en sueldos de empleados.");

                    // 2. Crecimiento y cosechas por parcela 
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            Parcela p = granja[i, j];

                            if (p.tipoCultivo != "Vacía")
                            {
                                // Regla de riego incrementado 
                                int crecimientoEsteMes = p.regada ? 2 : 1;
                                p.crecimientoActual += crecimientoEsteMes;

                                Console.WriteLine("Parcela [" + i + "," + j + "] (" + p.tipoCultivo + "): Crecimiento +" + crecimientoEsteMes + " meses.");

                                // Evalua si está lista para cosechar 
                                if (p.crecimientoActual >= p.crecimientoMax)
                                {
                                    double pagoCosecha = 0;
                                    if (p.tipoCultivo == "Papa") { pagoCosecha = 450; cosechasPapa++; }
                                    else if (p.tipoCultivo == "Tomate") { pagoCosecha = 650; cosechasTomate++; }
                                    else if (p.tipoCultivo == "Fresa") { pagoCosecha = 900; cosechasFresa++; }

                                    dinero += pagoCosecha;
                                    ingresos += pagoCosecha;
                                    Console.WriteLine("¡[COSECHA] Parcela [" + i + "," + j + "] lista! Se vendió " + p.tipoCultivo + " por Q" + pagoCosecha + ".");

                                    // Reiniciar parcela a vacía
                                    p.tipoCultivo = "Vacía";
                                    p.crecimientoActual = 0;
                                    p.crecimientoMax = 0;
                                    p.regada = false;
                                }
                                else
                                {
                                    // Reiniciar el riego para el siguiente mes 
                                    p.regada = false;
                                }
                            }
                        }
                    }
                    break;
            }

            if (opcion != 5)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }

            // El ciclo se detiene si el usuario sale, se acaba el tiempo o el dinero cae a 0 
        } while (opcion != 5 && dinero > 0 && mesesRestantes > 0);

        //  REPORTE FINAL  
        Console.Clear();
        Console.WriteLine("                 REPORTE FINAL                    ");
        Console.WriteLine("==================================================");
        Console.WriteLine("• Dinero final : Q " + dinero);
        Console.WriteLine("• Total de ingresos : Q " + ingresos);
        Console.WriteLine("• Total de egresos : Q " + egresos);
        Console.WriteLine("• Meses simulados : " + (mesesTotalesSimular - mesesRestantes));
        Console.WriteLine("• Cantidad de parcelas sembradas :");
        Console.WriteLine("  - Papas: " + sembradasPapa + "| Tomates: " + sembradasTomate + " | Fresas: " + sembradasFresa);
        Console.WriteLine("• Cantidad de cosechas realizadas con éxito:");
        Console.WriteLine("  - Papas: " + cosechasPapa + "| Tomates: " + cosechasTomate + " | Fresas: " + cosechasFresa);
        Console.WriteLine("• Cantidad total de riegos : " + totalRiegos);

        // Calcular parcelas vacías al final :)
        int vaciasFinal = 0;
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (granja[i, j].tipoCultivo == "Vacía") vaciasFinal++;
            }
        }
        Console.WriteLine("• Cantidad de parcelas vacías al finalizar: " + vaciasFinal);
        Console.WriteLine("==================================================");
        Console.WriteLine("Programa finalizado. Presione una tecla para cerrar.");
        Console.ReadKey();
    }

    // Métodos de validación 
    static int LeerIntPositivo(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor) && valor > 0)
                return valor;
            Console.WriteLine("Error: Ingrese un número entero mayor a 0.");
        }
    }

    static double LeerDoublePositivo(string mensaje)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                return valor;
            Console.WriteLine("Error: Ingrese un valor numérico válido (no negativo).");
        }
    }

    static int LeerIntRango(string mensaje, int min, int max)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor) && valor >= min && valor <= max)
                return valor;
            Console.WriteLine("Error: Debe ser un número entero entre" + min + "y" + max + ".");
        }
    }
}