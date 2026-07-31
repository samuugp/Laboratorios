#include "pch.h"

#include <iostream>
#include <string>
#include <vector>
#include <stdexcept>

using namespace std;

// ==========================================
// 1. LAS 3 EXCEPCIONES PEDIDAS EN LA RÚBRICA
// ==========================================
class ErrorCredenciales : public runtime_error {
public:
    ErrorCredenciales() : runtime_error("Usuario o clave incorrectos.") {}
};

class ErrorLibroNoDisponible : public runtime_error {
public:
    ErrorLibroNoDisponible(string msj) : runtime_error(msj) {}
};

class ErrorDevolucionTardia : public runtime_error {
public:
    ErrorDevolucionTardia() : runtime_error("¡Devolución fuera de plazo! Se ha registrado una sanción.") {}
};


// ==========================================
// 2. INTERFAZ / CLASE BASE DE USUARIO
// ==========================================
class Usuario {
protected:
    string usuario;
    string clave;
    int limiteLibros;
    vector<string> librosPrestados;
    vector<string> historial;

public:
    Usuario(string u, string c, int limite) {
        usuario = u;
        clave = c;
        limiteLibros = limite;
    }

    // Método 1: Verificar credenciales
    bool verificarCredenciales(string u, string c) {
        return (usuario == u && clave == c);
    }

    // Método 2: Prestar libro
    virtual void prestarLibro(string titulo) {
        if (librosPrestados.size() >= limiteLibros) {
            throw ErrorLibroNoDisponible("Alcanzaste tu límite de libros (" + to_string(limiteLibros) + " máximo).");
        }
        librosPrestados.push_back(titulo);
        historial.push_back("Prestado: " + titulo);
        cout << "-> Libro '" << titulo << "' prestado exitosamente.\n";
    }

    // Método 3: Devolver libro
    void devolverLibro(string titulo, bool fueraDePlazo) {
        bool encontrado = false;

        // Buscamos si el usuario realmente tiene ese libro
        for (size_t i = 0; i < librosPrestados.size(); i++) {
            if (librosPrestados[i] == titulo) {
                librosPrestados.erase(librosPrestados.begin() + i);
                encontrado = true;
                break;
            }
        }

        if (!encontrado) {
            cout << "-> No tienes prestado el libro '" << titulo << "'.\n";
            return;
        }

        if (fueraDePlazo) {
            historial.push_back("Devuelto: " + titulo + " (FUERA DE PLAZO)");
            throw ErrorDevolucionTardia();
        }
        else {
            historial.push_back("Devuelto: " + titulo);
            cout << "-> Libro '" << titulo << "' devuelto a tiempo.\n";
        }
    }

    // Método 4: Consultar historial
    void consultarHistorial() {
        cout << "\n--- HISTORIAL DE OPERACIONES ---\n";
        if (historial.size() == 0) {
            cout << "No tienes movimientos en el historial.\n";
        }
        else {
            for (size_t i = 0; i < historial.size(); i++) {
                cout << (i + 1) << ". " << historial[i] << "\n";
            }
        }
    }

    string getUsuario() {
        return usuario;
    }
};


// ==========================================
// 3. CLASES DERIVADAS (HERENCIA)
// ==========================================

// Usuario Regular (Máximo 2 libros)
class UsuarioRegular : public Usuario {
public:
    UsuarioRegular(string u, string c) : Usuario(u, c, 2) {}
};

// Usuario Premium (Máximo 5 libros + Mensaje especial)
class UsuarioPremium : public Usuario {
public:
    UsuarioPremium(string u, string c) : Usuario(u, c, 5) {}

    // Cambiamos un poco el préstamo para agregar el beneficio Premium
    void prestarLibro(string titulo) override {
        cout << "[BENEFICIO PREMIUM] Accediendo a catálogo exclusivo...\n";
        Usuario::prestarLibro(titulo);
    }
};


// ==========================================
// 4. PROGRAMA PRINCIPAL Y MENÚ
// ==========================================
int main() {
    // Creamos 2 usuarios para la simulación
    UsuarioRegular user1("juan", "123");
    UsuarioPremium user2("maria", "456");

    cout << "=== BIBLIOTECA DIGITAL ===\n";

    // --- AUTENTICACIÓN (3 INTENTOS) ---
    int intentos = 0;
    int tipoUsuario = 0; // 1 = Regular, 2 = Premium

    while (intentos < 3 && tipoUsuario == 0) {
        string u, c;
        cout << "\nUsuario: ";
        cin >> u;
        cout << "clave: ";
        cin >> c;

        try {
            if (user1.verificarCredenciales(u, c)) {
                tipoUsuario = 1;
                cout << "\n¡Bienvenido " << user1.getUsuario() << " (Usuario Regular)!\n";
            }
            else if (user2.verificarCredenciales(u, c)) {
                tipoUsuario = 2;
                cout << "\n¡Bienvenida " << user2.getUsuario() << " (Usuario Premium)!\n";
            }
            else {
                throw ErrorCredenciales();
            }
        }
        catch (const ErrorCredenciales& e) {
            intentos++;
            cout << "Error: " << e.what() << "\n";
            cout << "Intentos restantes: " << (3 - intentos) << "\n";
        }
    }

    if (tipoUsuario == 0) {
        cout << "\nDemasiados intentos fallidos. Sistema bloqueado.\n";
        return 0;
    }

    // --- MENÚ INTERACTIVO ---
    int opcion = 0;
    while (opcion != 4) {
        cout << "\n--- MENÚ PRINCIPAL ---\n";
        cout << "1. Prestar libro\n";
        cout << "2. Devolver libro\n";
        cout << "3. Consultar historial\n";
        cout << "4. Salir\n";
        cout << "Elija una opción: ";
        cin >> opcion;

        if (opcion == 1) {
            string libro;
            cout << "Nombre del libro a prestar: ";
            cin.ignore(); // Limpia el canal de entrada
            getline(cin, libro);

            try {
                if (tipoUsuario == 1) user1.prestarLibro(libro);
                if (tipoUsuario == 2) user2.prestarLibro(libro);
            }
            catch (const ErrorLibroNoDisponible& e) {
                cout << "[EXCEPCIÓN] " << e.what() << "\n";
            }

        }
        else if (opcion == 2) {
            string libro;
            char respuesta;
            cout << "Nombre del libro a devolver: ";
            cin.ignore();
            getline(cin, libro);
            cout << "¿Lo entrega con retraso? (s/n): ";
            cin >> respuesta;

            bool fueraDePlazo = (respuesta == 's' || respuesta == 'S');

            try {
                if (tipoUsuario == 1) user1.devolverLibro(libro, fueraDePlazo);
                if (tipoUsuario == 2) user2.devolverLibro(libro, fueraDePlazo);
            }
            catch (const ErrorDevolucionTardia& e) {
                cout << "[EXCEPCIÓN] " << e.what() << "\n";
            }

        }
        else if (opcion == 3) {
            if (tipoUsuario == 1) user1.consultarHistorial();
            if (tipoUsuario == 2) user2.consultarHistorial();

        }
        else if (opcion == 4) {
            cout << "¡Gracias por usar la biblioteca!\n";
        }
        else {
            cout << "Opción inválida. Intente de nuevo.\n";
        }
    }

    return 0;
}