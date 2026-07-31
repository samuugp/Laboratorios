#include "pch.h"
#include <iostream>
#include <string>

using namespace std;


//              EJERCICIO 1

class MaterialBibliografico
{
protected:
    string titulo;
    string codigo;
    int anioPublicacion;
    bool disponible;

public:
    MaterialBibliografico(string t, string c, int anio)
    {
        titulo = t;
        codigo = c;
        anioPublicacion = anio;
        disponible = true;
    }

    void mostrarInformacion()
    {
        cout << "\nTitulo: " << titulo << endl;
        cout << "Codigo: " << codigo << endl;
        cout << "Anio de publicacion: " << anioPublicacion << endl;

        if (disponible)
            cout << "Disponible: Si" << endl;
        else
            cout << "Disponible: No" << endl;
    }

    void prestarMaterial()
    {
        if (disponible)
        {
            disponible = false;
            cout << "Prestamo realizado correctamente." << endl;
        }
        else
        {
            cout << "El material no esta disponible." << endl;
        }
    }

    void prestarMaterial(int diasPrestamo)
    {
        if (disponible)
        {
            disponible = false;
            cout << "Prestamo realizado por " << diasPrestamo << " dias." << endl;
        }
        else
        {
            cout << "El material no esta disponible." << endl;
        }
    }

    void devolverMaterial()
    {
        disponible = true;
        cout << "Material devuelto correctamente." << endl;
    }

    virtual void mostrarDetalle()
    {
        cout << "Material Bibliografico" << endl;
    }
};

class Libro : public MaterialBibliografico
{
private:
    string autor;
    int numeroPaginas;

public:
    Libro(string t, string c, int anio, string a, int paginas)
        : MaterialBibliografico(t, c, anio)
    {
        autor = a;
        numeroPaginas = paginas;
    }

    void mostrarDetalle() override
    {
        cout << "\n========== LIBRO ==========" << endl;
        mostrarInformacion();
        cout << "Autor: " << autor << endl;
        cout << "Numero de paginas: " << numeroPaginas << endl;
    }

    void calcularTiempoLectura()
    {
        int horas = numeroPaginas / 30;
        cout << "Tiempo aproximado de lectura: " << horas << " horas." << endl;
    }
};

class Revista : public MaterialBibliografico
{
private:
    int numeroEdicion;
    string categoria;

public:
    Revista(string t, string c, int anio, int edicion, string cat)
        : MaterialBibliografico(t, c, anio)
    {
        numeroEdicion = edicion;
        categoria = cat;
    }

    void mostrarDetalle() override
    {
        cout << "\n========== REVISTA ==========" << endl;
        mostrarInformacion();
        cout << "Numero de edicion: " << numeroEdicion << endl;
        cout << "Categoria: " << categoria << endl;
    }

    void mostrarCategoria()
    {
        cout << "Categoria: " << categoria << endl;
    }
};

void ejecutarEjercicio1()
{
    Libro libro1("C++ Basico", "L001", 2022, "Bjarne Stroustrup", 450);
    Libro libro2("Programacion", "L002", 2021, "Luis Perez", 320);

    Revista revista1("National Geographic", "R001", 2024, 12, "Ciencia");
    Revista revista2("PC World", "R002", 2023, 8, "Tecnologia");

    cout << "\n========================================";
    cout << "\n      SISTEMA DE BIBLIOTECA";
    cout << "\n========================================\n";

    cout << "\n----- INFORMACION GENERAL -----\n";
    libro1.mostrarInformacion();
    libro2.mostrarInformacion();
    revista1.mostrarInformacion();
    revista2.mostrarInformacion();

    cout << "\n----- PRESTAMOS -----\n";
    libro1.prestarMaterial();
    libro2.prestarMaterial(15);
    revista1.prestarMaterial();
    revista2.prestarMaterial(5);

    cout << "\n----- DETALLES -----\n";
    libro1.mostrarDetalle();
    libro2.mostrarDetalle();
    revista1.mostrarDetalle();
    revista2.mostrarDetalle();

    cout << "\n----- METODOS PROPIOS -----\n";
    libro1.calcularTiempoLectura();
    libro2.calcularTiempoLectura();
    revista1.mostrarCategoria();
    revista2.mostrarCategoria();

    cout << "\n----- DEVOLUCIONES -----\n";
    libro1.devolverMaterial();
    revista1.devolverMaterial();
}

//          EJERCICIO 2

class Transporte
{
protected:
    string codigo;
    string destino;
    int capacidad;
    int pasajerosRegistrados;
    double tarifaBase;

public:
    Transporte(string c, string d, int cap, double tarifa)
    {
        codigo = c;
        destino = d;
        capacidad = cap;
        pasajerosRegistrados = 0;
        tarifaBase = tarifa;
    }

    void mostrarDatos()
    {
        cout << "\nCodigo: " << codigo << endl;
        cout << "Destino: " << destino << endl;
        cout << "Capacidad: " << capacidad << endl;
        cout << "Pasajeros registrados: " << pasajerosRegistrados << endl;
        cout << "Tarifa base: Q" << tarifaBase << endl;
    }

    void reservarAsiento()
    {
        if (pasajerosRegistrados < capacidad)
        {
            pasajerosRegistrados++;
            cout << "Reserva realizada." << endl;
        }
        else
        {
            cout << "No hay asientos disponibles." << endl;
        }
    }

    void reservarAsiento(int cantidad)
    {
        if (pasajerosRegistrados + cantidad <= capacidad)
        {
            pasajerosRegistrados += cantidad;
            cout << cantidad << " asientos reservados." << endl;
        }
        else
        {
            cout << "No hay suficientes asientos." << endl;
        }
    }

    void cancelarReserva(int cantidad)
    {
        if (cantidad <= pasajerosRegistrados)
        {
            pasajerosRegistrados -= cantidad;
            cout << "Reserva cancelada." << endl;
        }
        else
        {
            cout << "Cantidad invalida." << endl;
        }
    }

    virtual void iniciarViaje()
    {
        cout << "Iniciando viaje..." << endl;
    }

    virtual void calcularTarifa()
    {
        cout << "Tarifa: Q" << tarifaBase << endl;
    }
};

class BusTuristico : public Transporte
{
private:
    int cantidadFilas;

public:
    BusTuristico(string c, string d, int cap, double tarifa, int filas)
        : Transporte(c, d, cap, tarifa)
    {
        cantidadFilas = filas;
    }

    void iniciarViaje() override
    {
        cout << "El bus turistico inicia su recorrido hacia " << destino << "." << endl;
    }

    void mostrarDisponibilidad()
    {
        cout << "Asientos disponibles: " << capacidad - pasajerosRegistrados << endl;
    }

    void calcularTarifa() override
    {
        cout << "Tarifa Bus: Q" << tarifaBase + 25 << endl;
    }
};

class LanchaTuristica : public Transporte
{
private:
    string tipoMotor;

public:
    LanchaTuristica(string c, string d, int cap, double tarifa, string motor)
        : Transporte(c, d, cap, tarifa)
    {
        tipoMotor = motor;
    }

    void iniciarViaje() override
    {
        cout << "La lancha turistica inicia su recorrido hacia " << destino << "." << endl;
    }

    void mostrarDisponibilidad()
    {
        cout << "Lugares disponibles: " << capacidad - pasajerosRegistrados << endl;
    }

    void calcularTarifa() override
    {
        cout << "Tarifa Lancha: Q" << tarifaBase + 40 << endl;
    }
};

void ejecutarEjercicio2()
{
    BusTuristico bus1("B001", "Antigua Guatemala", 40, 75, 10);
    BusTuristico bus2("B002", "Panajachel", 35, 90, 9);

    LanchaTuristica lancha1("L001", "Rio Dulce", 20, 120, "Yamaha");
    LanchaTuristica lancha2("L002", "Lago Atitlan", 15, 150, "Suzuki");

    cout << "\n========================================";
    cout << "\n    TRANSPORTE TURISTICO ";
    cout << "\n========================================\n";

    cout << "\n========== INFORMACION ==========" << endl;
    bus1.mostrarDatos();
    bus2.mostrarDatos();
    lancha1.mostrarDatos();
    lancha2.mostrarDatos();

    cout << "\n========== RESERVAS ==========" << endl;
    bus1.reservarAsiento();
    bus2.reservarAsiento(5);
    lancha1.reservarAsiento();
    lancha2.reservarAsiento(3);

    cout << "\n========== DISPONIBILIDAD ==========" << endl;
    bus1.mostrarDisponibilidad();
    bus2.mostrarDisponibilidad();
    lancha1.mostrarDisponibilidad();
    lancha2.mostrarDisponibilidad();

    cout << "\n========== TARIFAS ==========" << endl;
    bus1.calcularTarifa();
    bus2.calcularTarifa();
    lancha1.calcularTarifa();
    lancha2.calcularTarifa();

    cout << "\n========== VIAJES ==========" << endl;
    bus1.iniciarViaje();
    bus2.iniciarViaje();
    lancha1.iniciarViaje();
    lancha2.iniciarViaje();

    cout << "\n========== CANCELAR RESERVAS ==========" << endl;
    bus2.cancelarReserva(2);
    lancha2.cancelarReserva(1);

    cout << "\n========== INFORMACION FINAL ==========" << endl;
    bus1.mostrarDatos();
    bus2.mostrarDatos();
    lancha1.mostrarDatos();
    lancha2.mostrarDatos();
}

//                     MAIN PRINCIPAL

int main()
{
    // Ejecuta el Ejercicio 1
    ejecutarEjercicio1();

    cout << "\n\n";

    // Ejecuta el Ejercicio 2
    ejecutarEjercicio2();

    return 0;
}