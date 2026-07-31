#include <iostream>
#include <string>
#include <limits>

using namespace std;

//------------------ Funciones ------------------

void consultarSaldo(double saldo)
{
    cout << "\nSaldo actual: Q" << saldo << endl;
}

void agregarHistorial(string historial[], int& indice, string operacion)
{
    if (indice < 20)
    {
        historial[indice] = operacion;
        indice++;
    }
}

void depositar(double& saldo, string historial[], int& indice, int& totalDepositos)
{
    double monto;

    while (true)
    {
        cout << "\nIngrese el monto a depositar: Q";
        cin >> monto;

        if (cin.fail())
        {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Error. Debe ingresar un numero.\n";
        }
        else if (monto < 1)
        {
            cout << "El deposito minimo es Q1.00\n";
        }
        else
        {
            break;
        }
    }

    saldo += monto;
    totalDepositos++;

    agregarHistorial(historial, indice, "Deposito: Q" + to_string(monto));

    cout << "Deposito realizado correctamente.\n";
}

void retirar(double& saldo, string historial[], int& indice, int& totalRetiros)
{
    double monto;

    while (true)
    {
        cout << "\nIngrese el monto a retirar: Q";
        cin >> monto;

        if (cin.fail())
        {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Error. Debe ingresar un numero.\n";
        }
        else if (monto <= 0)
        {
            cout << "Monto invalido.\n";
        }
        else if (monto > saldo)
        {
            cout << "Saldo insuficiente.\n";
        }
        else
        {
            break;
        }
    }

    saldo -= monto;
    totalRetiros++;

    agregarHistorial(historial, indice, "Retiro: Q" + to_string(monto));

    cout << "Retiro realizado correctamente.\n";
}

void transferir(double& saldo, string historial[], int& indice, int& totalTransferencias)
{
    double monto;

    while (true)
    {
        cout << "\nIngrese el monto a transferir: Q";
        cin >> monto;

        if (cin.fail())
        {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Error. Debe ingresar un numero.\n";
        }
        else if (monto <= 0)
        {
            cout << "Monto invalido.\n";
        }
        else if (monto > saldo)
        {
            cout << "Saldo insuficiente.\n";
        }
        else
        {
            break;
        }
    }

    saldo -= monto;
    totalTransferencias++;

    agregarHistorial(historial, indice, "Transferencia: Q" + to_string(monto));

    cout << "Transferencia realizada correctamente.\n";
}

void mostrarHistorial(string historial[], int indice)
{
    cout << "\n===== HISTORIAL =====\n";

    if (indice == 0)
    {
        cout << "No hay operaciones registradas.\n";
    }
    else
    {
        for (int i = 0; i < indice; i++)
        {
            cout << i + 1 << ". " << historial[i] << endl;
        }
    }
}

//------------------ Programa Principal ------------------

int main()
{
    double saldo = 5000.00;

    string historial[20];
    int indiceHistorial = 0;

    int totalDepositos = 0;
    int totalRetiros = 0;
    int totalTransferencias = 0;

    int opcion;

    do
    {
        cout << "\n========== BANCO URL ==========\n";
        cout << "1. Consultar saldo\n";
        cout << "2. Depositar dinero\n";
        cout << "3. Retirar dinero\n";
        cout << "4. Transferir dinero\n";
        cout << "5. Ver historial de operaciones\n";
        cout << "6. Salir\n";
        cout << "Seleccione una opcion: ";

        cin >> opcion;

        while (cin.fail() || opcion < 1 || opcion > 6)
        {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');

            cout << "Opcion invalida. Ingrese una opcion entre 1 y 6: ";
            cin >> opcion;
        }

        switch (opcion)
        {
        case 1:
            consultarSaldo(saldo);
            break;

        case 2:
            depositar(saldo, historial, indiceHistorial, totalDepositos);
            break;

        case 3:
            retirar(saldo, historial, indiceHistorial, totalRetiros);
            break;

        case 4:
            transferir(saldo, historial, indiceHistorial, totalTransferencias);
            break;

        case 5:
            mostrarHistorial(historial, indiceHistorial);
            break;

        case 6:
            cout << "\nFinalizando programa...\n";
            break;
        }

    } while (opcion != 6);

    cout << "\n========== RESUMEN ==========\n";
    cout << "Saldo final: Q" << saldo << endl;
    cout << "Total de depositos: " << totalDepositos << endl;
    cout << "Total de retiros: " << totalRetiros << endl;
    cout << "Total de transferencias: " << totalTransferencias << endl;

    return 0;
}

