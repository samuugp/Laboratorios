using System;

    // EJERCICIO #1
    class Libro
    {
        // Atributos
        private string titulo;
        private string autor;
        private int anioPublicacion;
        private bool disponible;

        // Constructor
        public Libro(string titulo, string autor, int anioPublicacion, bool disponible)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anioPublicacion = anioPublicacion;
            this.disponible = disponible;
        }

        // Método información
        public void MostrarInformacion()
        {
            Console.WriteLine("Título: " + titulo);
            Console.WriteLine("Autor: " + autor);
            Console.WriteLine("Año de publicación: " + anioPublicacion);
            Console.WriteLine("Disponible: " + disponible);
            Console.WriteLine();
        }

        // Método prestar libro
        public void PrestarLibro()
        {
            if (disponible)
            {
                disponible = false;
                Console.WriteLine("El libro ha sido prestado.");
            }
            else
            {
                Console.WriteLine("El libro no está disponible.");
            }
        }

        // Método devolver libro
        public void DevolverLibro()
        {
            disponible = true;
            Console.WriteLine("El libro ha sido devuelto.");
        }
    }
    // EJERCICIO #2
    class Mascota
    {
        // Atributos
        private string nombre;
        private string especie;
        private int edad;
        private bool vacunado;

        // Constructor
        public Mascota(string nombre, string especie, int edad, bool vacunado)
        {
            this.nombre = nombre;
            this.especie = especie;
            this.edad = edad;
            this.vacunado = vacunado;
        }

        // Mostrar información
        public void MostrarInformacion()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Especie: " + especie);
            Console.WriteLine("Edad: " + edad);
            Console.WriteLine("Vacunado: " + vacunado);
            Console.WriteLine();
        }

        // Vacunar mascota
        public void Vacunar()
        {
            vacunado = true;
            Console.WriteLine(nombre + " ha sido vacunado.");
        }

        // Cumplir años
        public void CumplirAnios()
        {
            edad++;
            Console.WriteLine(nombre + " ahora tiene " + edad + " años.");
        }
    }

    // EJERCICIO #3
    class Estudiante
    {
        // Atributos
        private string nombre;
        private int edad;
        private string grado;
        private double[] notas;

        // Constructor
        public Estudiante(string nombre, int edad, string grado, double[] notas)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.grado = grado;
            this.notas = notas;
        }

        // Calcular promedio
        public double CalcularPromedio()
        {
            double suma = 0;

            for (int i = 0; i < notas.Length; i++)
            {
                suma += notas[i];
            }

            return suma / notas.Length;
        }

        // Mostrar información
        public void MostrarInformacion()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Edad: " + edad);
            Console.WriteLine("Grado: " + grado);

            Console.Write("Notas: ");
            for (int i = 0; i < notas.Length; i++)
            {
                Console.Write(notas[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Promedio: " + CalcularPromedio());
            Console.WriteLine();
        }

        // Aprobación
        public void Aprobar()
        {
            if (CalcularPromedio() >= 61)
            {
                Console.WriteLine(nombre + " APROBADO.");
            }
            else
            {
                Console.WriteLine(nombre + " REPROBADO.");
            }
        }

        // Nueva nota
        public void AgregarNota(double nuevaNota)
        {
            double[] nuevasNotas = new double[notas.Length + 1];

            for (int i = 0; i < notas.Length; i++)
            {
                nuevasNotas[i] = notas[i];
            }

            nuevasNotas[nuevasNotas.Length - 1] = nuevaNota;
            notas = nuevasNotas;

            Console.WriteLine("Nueva nota agregada: " + nuevaNota);
        }
    }

class  Program 
    {
        static void Main(string[] args)
        {
            // EJERCICIO 1

            Libro libro1 = new Libro("Cien años de soledad", "Gabriel García Márquez", 1967, true);
            Libro libro2 = new Libro("Don Quijote", "Miguel de Cervantes", 1605, true);

            libro1.MostrarInformacion();
            libro2.MostrarInformacion();

            libro1.PrestarLibro();
            libro1.MostrarInformacion();

            libro1.DevolverLibro();
            libro1.MostrarInformacion();

            // EJERCICIO 2

            Mascota mascota1 = new Mascota("Max", "Perro", 3, false);
            Mascota mascota2 = new Mascota("Michi", "Gato", 2, false);

            mascota1.MostrarInformacion();
            mascota2.MostrarInformacion();

            mascota1.Vacunar();
            mascota1.MostrarInformacion();

            mascota2.CumplirAnios();
            mascota2.MostrarInformacion();

            // EJERCICIO 3

            double[] notas1 = { 70, 80, 90 };
            double[] notas2 = { 50, 55, 60 };

            Estudiante estudiante1 = new Estudiante("Samuel", 18, "5to Bach", notas1);
            Estudiante estudiante2 = new Estudiante("Andrea", 17, "4to Bach", notas2);

            estudiante1.MostrarInformacion();
            estudiante1.Aprobar();

            Console.WriteLine();

            estudiante2.MostrarInformacion();
            estudiante2.Aprobar();

            Console.WriteLine();

            estudiante2.AgregarNota(85);

            Console.WriteLine("\nInformación actualizada:\n");

            estudiante2.MostrarInformacion();
            estudiante2.Aprobar();

            Console.ReadKey();
        }
    }
