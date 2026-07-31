using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hola, bienvenido");

        Console.WriteLine("Ingrese número de usuario:");
        int Usuario = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese PIN:");
        int PIN = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese Token:");
        int token = int.Parse(Console.ReadLine());

        Console.WriteLine("Modo seguro (1 = Sí, 0 = No):");
        int Modoseguro = int.Parse(Console.ReadLine());

        if (Usuario == 2026)
            Console.WriteLine("Usuario reconocido.");
        else
            Console.WriteLine("Usuario no reconocido.");

        if (PIN == 1234)
            Console.WriteLine("PIN correcto.");
        else
            Console.WriteLine("PIN incorrecto.");

        if (token == 777)
            Console.WriteLine("Token válido.");
        else
            Console.WriteLine("Token inválido.");
        if (Modoseguro == 1)
            Console.WriteLine("Modo seguro activado: se aplican reglas extra.");
        else
            Console.WriteLine("Modo seguro desactivado.");
        if (Usuario == 2026 && PIN == 1234 && token == 777)
            Console.WriteLine("Acceso total concedido.");
        else
            Console.WriteLine("Acceso denegado.");

        if (Modoseguro == 1)
        {
            if (token >= 700)
                Console.WriteLine("Regla extra aprobada.");
            else
                Console.WriteLine("Regla extra fallida.");

            // Ejercicio 2
            Console.WriteLine("Ingrese su PIN:");
            int Pin = int.Parse(Console.ReadLine());

            if (Pin >= 1000 && Pin <= 9999)
                Console.WriteLine("PIN de 4 dígitos: OK.");
            else
                Console.WriteLine("PIN inválido: debe tener 4 dígitos.");

            if (Pin % 2 == 0)
                Console.WriteLine("PIN par.");
            else
                Console.WriteLine("PIN impar.");

            if (Pin % 5 == 0)
                Console.WriteLine("Múltiplo de 5.");
            else
                Console.WriteLine("No es múltiplo de 5.");

            if ((PIN >= 1000 && Pin <= 9999) && (Pin % 2 == 0) && !(Pin % 5 == 0))
                Console.WriteLine("PIN aceptado por política.");
            else
                Console.WriteLine("PIN rechazado por política.");
            // Ejercicio 3
            Console.WriteLine("Ingrese código de activación:");
            int codigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese edad:");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("¿Aceptó términos? (1 = Sí, 0 = No):");
            int terminos = int.Parse(Console.ReadLine());

            Console.WriteLine("¿Activó 2FA? (1 = Sí, 0 = No):");
            int dosFA = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese puntaje (0 a 100):");
            int puntaje = int.Parse(Console.ReadLine());

            // a) Código
            if (codigo == 2026)
                Console.WriteLine("Código correcto.");
            else
                Console.WriteLine("Código incorrecto.");

            // b) Edad
            if (edad >= 18)
                Console.WriteLine("Edad válida.");
            else
                Console.WriteLine("Edad no válida.");

            // c) Términos
            if (terminos == 1)
                Console.WriteLine("Términos aceptados.");
            else
                Console.WriteLine("Debe aceptar términos.");

            // d) 2FA
            if (dosFA == 1)
                Console.WriteLine("2FA activado.");
            else
                Console.WriteLine("2FA no activado.");

            // e) Puntaje
            if (puntaje >= 70)
                Console.WriteLine("Puntaje suficiente.");
            else
                Console.WriteLine("Puntaje insuficiente.");

            // f) Activación final
            if (codigo == 2026 && edad >= 18 && terminos == 1 && dosFA == 1 && puntaje >= 70)
                Console.WriteLine("Cuenta activada exitosamente.");
            else
                Console.WriteLine("Cuenta NO activada.");
            // Ejercicio 4
            Console.WriteLine("Ingrese nota previa (0 a 100):");
            int nota = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese minutos de llegada tarde:");
            int minutosTarde = int.Parse(Console.ReadLine());

            Console.WriteLine("¿Tiene solvencia de pagos? (1 = Sí, 0 = No):");
            int solvencia = int.Parse(Console.ReadLine());

            Console.WriteLine("¿Trae identificación física? (1 = Sí, 0 = No):");
            int identificacion = int.Parse(Console.ReadLine());

            Console.WriteLine("¿Trae calculadora permitida? (1 = Sí, 0 = No):");
            int calculadora = int.Parse(Console.ReadLine());

            // a) Requisito académico
            if (nota >= 61)
                Console.WriteLine("Requisito académico aprobado.");
            else
                Console.WriteLine("Requisito académico NO aprobado.");

            // b) Llegada
            if (minutosTarde <= 10)
                Console.WriteLine("Hora válida.");
            else
                Console.WriteLine("Llegada tarde: fuera de tiempo.");

            // c) Solvencia
            if (solvencia == 1)
                Console.WriteLine("Solvencia validada.");
            else
                Console.WriteLine("Sin solvencia.");

            // d) Identificación
            if (identificacion == 1)
                Console.WriteLine("Identificación validada.");
            else
                Console.WriteLine("Sin identificación.");

            // e) Calculadora
            if (calculadora == 1)
                Console.WriteLine("Calculadora permitida: OK.");
            else
                Console.WriteLine("Sin calculadora permitida.");

            // f) Acceso final usando operadores lógicos
            if (nota >= 61 && minutosTarde <= 10 && solvencia == 1 && identificacion == 1)
                Console.WriteLine("Acceso a sala de examen concedido.");
            else
                Console.WriteLine("Acceso denegado.");

            // g) Advertencia por llegada tarde
            if (minutosTarde > 0 && minutosTarde <= 10)
                Console.WriteLine("Advertencia: llegó tarde, pero aún puede ingresar.");
            Console.ReadKey();

        }
    }
}
