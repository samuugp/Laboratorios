#include <iostream>
#include <string>

using namespace std;

//==============================
// INTERFAZ
//==============================
class IAsistencia
{
public:

    virtual void registrarEntrada() = 0;

    virtual void registrarSalida() = 0;

};

//==============================
// CLASE ABSTRACTA
//==============================
class Empleado
{
protected:

    string codigo;
    string nombre;
    int edad;
    string departamento;

    double salarioBase;

public:

    Empleado(string c, string n, int e, string d, double s)
    {
        codigo = c;
        nombre = n;
        edad = e;
        departamento = d;
        salarioBase = s;
    }

    virtual void mostrarInformacion() = 0;

    virtual double calcularSalario() = 0;

};
//====================================
// CLASE ADMINISTRATIVO
//====================================
class Administrativo : public Empleado, public IAsistencia
{
private:

    double bonoAdministrativo;

public:

    Administrativo()
        : Empleado("", "", 0, "", 0)
    {
        bonoAdministrativo = 0;
    }

    Administrativo(string c, string n, int e, string d,
        double salario, double bono)
        : Empleado(c, n, e, d, salario)
    {
        bonoAdministrativo = bono;
    }

    void mostrarInformacion()
    {
        cout << "\n===== EMPLEADO ADMINISTRATIVO =====\n";
        cout << "Codigo: " << codigo << endl;
        cout << "Nombre: " << nombre << endl;
        cout << "Edad: " << edad << endl;
        cout << "Departamento: " << departamento << endl;
        cout << "Salario Base: Q" << salarioBase << endl;
        cout << "Bono Administrativo: Q" << bonoAdministrativo << endl;
    }

    double calcularSalario()
    {
        return salarioBase + bonoAdministrativo;
    }

    void registrarEntrada()
    {
        cout << nombre << " registro su entrada correctamente.\n";
    }

    void registrarSalida()
    {
        cout << nombre << " registro su salida correctamente.\n";
    }
};
//====================================
// CLASE VENDEDOR
//====================================
class Vendedor : public Empleado, public IAsistencia
{
private:

    double ventas;
    double comision;

public:

    Vendedor()
        : Empleado("", "", 0, "", 0)
    {
        ventas = 0;
        comision = 0;
    }

    Vendedor(string c, string n, int e, string d,
        double salario, double v, double com)
        : Empleado(c, n, e, d, salario)
    {
        ventas = v;
        comision = com;
    }

    void mostrarInformacion()
    {
        cout << "\n===== EMPLEADO VENDEDOR =====\n";
        cout << "Codigo: " << codigo << endl;
        cout << "Nombre: " << nombre << endl;
        cout << "Edad: " << edad << endl;
        cout << "Departamento: " << departamento << endl;
        cout << "Salario Base: Q" << salarioBase << endl;
        cout << "Ventas: Q" << ventas << endl;
        cout << "Comision: " << comision << "%" << endl;
    }

    double calcularSalario()
    {
        return salarioBase + (ventas * comision / 100);
    }

    void registrarEntrada()
    {
        cout << nombre << " registro su entrada correctamente.\n";
    }

    void registrarSalida()
    {
        cout << nombre << " registro su salida correctamente.\n";
    }
};

//====================================
// CLASE OPERARIO
//====================================
class Operario : public Empleado, public IAsistencia
{
private:

    int horasExtras;
    double pagoHoraExtra;

public:

    Operario()
        : Empleado("", "", 0, "", 0)
    {
        horasExtras = 0;
        pagoHoraExtra = 0;
    }

    Operario(string c, string n, int e, string d,
        double salario, int horas, double pago)
        : Empleado(c, n, e, d, salario)
    {
        horasExtras = horas;
        pagoHoraExtra = pago;
    }

    void mostrarInformacion()
    {
        cout << "\n===== EMPLEADO OPERARIO =====\n";
        cout << "Codigo: " << codigo << endl;
        cout << "Nombre: " << nombre << endl;
        cout << "Edad: " << edad << endl;
        cout << "Departamento: " << departamento << endl;
        cout << "Salario Base: Q" << salarioBase << endl;
        cout << "Horas Extras: " << horasExtras << endl;
        cout << "Pago por Hora Extra: Q" << pagoHoraExtra << endl;
    }

    double calcularSalario()
    {
        return salarioBase + (horasExtras * pagoHoraExtra);
    }

    void registrarEntrada()
    {
        cout << nombre << " registro su entrada correctamente.\n";
    }

    void registrarSalida()
    {
        cout << nombre << " registro su salida correctamente.\n";
    }
};
int main()
{
    Administrativo administrativos[10];
    Vendedor vendedores[10];
    Operario operarios[10];

    int cantAdmin = 0;
    int cantVend = 0;
    int cantOper = 0;

    int opcion;

    do
    {
        cout << "\n========= EMPRESA =========\n";
        cout << "1. Registrar empleado\n";
        cout << "2. Mostrar empleados\n";
        cout << "3. Registrar entrada\n";
        cout << "4. Registrar salida\n";
        cout << "5. Mostrar salarios\n";
        cout << "6. Mostrar total de planilla\n";
        cout << "7. Salir\n";
        cout << "Opcion: ";
        cin >> opcion;

        switch (opcion)
        {

            //==========================
            // REGISTRAR
            //==========================
        case 1:
        {
            int tipo;

            cout << "\n1. Administrativo\n";
            cout << "2. Vendedor\n";
            cout << "3. Operario\n";
            cout << "Tipo: ";
            cin >> tipo;

            string codigo;
            string nombre;
            string departamento;

            int edad;

            double salarioBase;

            cout << "Codigo: ";
            cin >> codigo;

            cin.ignore();

            cout << "Nombre: ";
            getline(cin, nombre);

            cout << "Edad: ";
            cin >> edad;

            cin.ignore();

            cout << "Departamento: ";
            getline(cin, departamento);

            cout << "Salario Base: ";
            cin >> salarioBase;

            if (tipo == 1)
            {
                double bono;

                cout << "Bono Administrativo: ";
                cin >> bono;

                administrativos[cantAdmin] =
                    Administrativo(codigo, nombre, edad,
                        departamento, salarioBase, bono);

                cantAdmin++;
            }

            else if (tipo == 2)
            {
                double ventas;
                double comision;

                cout << "Ventas del mes: ";
                cin >> ventas;

                cout << "Porcentaje de comision: ";
                cin >> comision;

                vendedores[cantVend] =
                    Vendedor(codigo, nombre, edad,
                        departamento, salarioBase,
                        ventas, comision);

                cantVend++;
            }

            else if (tipo == 3)
            {
                int horas;
                double pago;

                cout << "Horas Extras: ";
                cin >> horas;

                cout << "Pago por Hora Extra: ";
                cin >> pago;

                operarios[cantOper] =
                    Operario(codigo, nombre, edad,
                        departamento, salarioBase,
                        horas, pago);

                cantOper++;
            }

            break;
        }

        //==========================
        // MOSTRAR
        //==========================
        case 2:

            cout << "\n===== ADMINISTRATIVOS =====\n";

            for (int i = 0;i < cantAdmin;i++)
                administrativos[i].mostrarInformacion();

            cout << "\n===== VENDEDORES =====\n";

            for (int i = 0;i < cantVend;i++)
                vendedores[i].mostrarInformacion();

            cout << "\n===== OPERARIOS =====\n";

            for (int i = 0;i < cantOper;i++)
                operarios[i].mostrarInformacion();

            break;

            //==========================
            // ENTRADA
            //==========================
        case 3:

            for (int i = 0;i < cantAdmin;i++)
                administrativos[i].registrarEntrada();

            for (int i = 0;i < cantVend;i++)
                vendedores[i].registrarEntrada();

            for (int i = 0;i < cantOper;i++)
                operarios[i].registrarEntrada();

            break;

            //==========================
            // SALIDA
            //==========================
        case 4:

            for (int i = 0;i < cantAdmin;i++)
                administrativos[i].registrarSalida();

            for (int i = 0;i < cantVend;i++)
                vendedores[i].registrarSalida();

            for (int i = 0;i < cantOper;i++)
                operarios[i].registrarSalida();

            break;

            //==========================
            // SALARIOS
            //==========================
        case 5:

            cout << "\n===== SALARIOS =====\n";

            for (int i = 0;i < cantAdmin;i++)
                cout << "Administrativo "
                << i + 1
                << ": Q"
                << administrativos[i].calcularSalario()
                << endl;

            for (int i = 0;i < cantVend;i++)
                cout << "Vendedor "
                << i + 1
                << ": Q"
                << vendedores[i].calcularSalario()
                << endl;

            for (int i = 0;i < cantOper;i++)
                cout << "Operario "
                << i + 1
                << ": Q"
                << operarios[i].calcularSalario()
                << endl;

            break;

            //==========================
            // PLANILLA
            //==========================
        case 6:
        {
            double total = 0;

            for (int i = 0;i < cantAdmin;i++)
                total += administrativos[i].calcularSalario();

            for (int i = 0;i < cantVend;i++)
                total += vendedores[i].calcularSalario();

            for (int i = 0;i < cantOper;i++)
                total += operarios[i].calcularSalario();

            cout << "\nTOTAL PLANILLA: Q"
                << total
                << endl;

            break;
        }

        case 7:

            cout << "\nPrograma Finalizado.\n";

            break;

        default:

            cout << "\nOpcion incorrecta.\n";

        }

    } while (opcion != 7);

    return 0;
}