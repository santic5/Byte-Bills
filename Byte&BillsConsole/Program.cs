using Byte_BillsSolution.Orders.Handler;
using Byte_BillsSolution.Reservation.Handler;
using CommandLine;
using System;

class Program
{
    private static ReservationsHandler reservations = new();
    private static OrdersHandler orders = new();

    static void Main(string[] args)
    {
        while (true)
        {
            //Console.Clear();
            Console.WriteLine(" ____________________________________________");
            Console.WriteLine("|                                            |");
            Console.WriteLine("|            Proyecto disponible en          |");
            Console.WriteLine("|         github.com/santic5/Byte-Bills      |");
            Console.WriteLine(" ____________________________________________");
            Console.WriteLine("|                                            |");
            Console.WriteLine("|            Byte&Bills Restaurante          |");
            Console.WriteLine("|                                            |");
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine("|                                            |");
            Console.WriteLine("|                Menu principal              |");
            Console.WriteLine("|             Ordenes   -   Reservas         |");
            Console.WriteLine("|                     Salir                  |");
            Console.WriteLine(" --------------------------------------------");
            string menu = Console.ReadLine()?.ToLower();

            if (menu == "salir")
            {
                Console.WriteLine("Saliendo del programa.");
                break;
            }

            switch (menu)
            {
                case "ordenes":
                    MostrarMenuOrdenes();
                    break;

                case "reservas":
                    MostrarMenuReservas();
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intenta con 'ordenes', 'reservas' o 'salir'.");
                    break;
            }
        }
    }

    static void MostrarMenuOrdenes()
    {
        while (true)
        {
            //Console.Clear();
            Console.WriteLine(" ------------------------------------------------------------");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("|                        Menu Ordenes                        |");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("|    Crear -t tipo | (Restaurante, Rappi, Delivery)          |");
            Console.WriteLine("|    Eliminar      | (Primero en cola)                       |");
            Console.WriteLine("|    Revisar -a/-f | (Todos/Primero)                         |");
            Console.WriteLine("|    Volver                                                  |");
            Console.WriteLine(" ------------------------------------------------------------");
            string[] ordenesArgs = Console.ReadLine()?.Split(' ');

            if (ordenesArgs.Length == 1 && ordenesArgs[0].ToLower() == "volver")
                break;

            Parser.Default.ParseArguments<OrdenCrearOptions, OrdenEliminarOptions, OrdenRevisarOptions>(ordenesArgs)
                .MapResult(
                    (OrdenCrearOptions opts) => CrearOrden(opts),
                    (OrdenEliminarOptions opts) => EliminarOrden(opts),
                    (OrdenRevisarOptions opts) => RevisarOrden(opts),
                    errs =>
                    {
                        Console.WriteLine("Comando no válido. Intenta de nuevo.");
                        return 1;
                    }
                );
        }
    }

    static void MostrarMenuReservas()
    {
        while (true)
        {
            //Console.Clear();
            Console.WriteLine(" ------------------------------------------------------------");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("|                       Menu Reservas                        |");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("|    Crear -i id -f fecha      | Fecha='00/00/0000 24:00'    |");
            Console.WriteLine("|    Verificar -i id -f fecha  | Fecha='00/00/0000 24:00'    |");
            Console.WriteLine("|    Eliminar -i id -f fecha   | Fecha='00/00/0000 24:00'    |");
            Console.WriteLine("|    Mostrar                   | (Todas las reservas)        |");
            Console.WriteLine("|    Cantidad                  | (Numero total de reservas)  |");
            Console.WriteLine("|    Purgar                    | (Elimina las reservas)      |");
            Console.WriteLine("|    Volver                                                  |");
            Console.WriteLine(" ------------------------------------------------------------");
            string[] reservasArgs = Console.ReadLine()?.Split(' ');

            if (reservasArgs.Length == 1 && reservasArgs[0].ToLower() == "volver")
                break;

            Parser.Default.ParseArguments<ReservaCrearOptions, ReservaVerificarOptions, ReservaEliminarOptions, ReservaMostrarOptions, ReservaCantidadOptions, ReservaPurgarOptions>(reservasArgs)
                .MapResult(
                    (ReservaCrearOptions opts) => CrearReserva(opts),
                    (ReservaVerificarOptions opts) => VerificarReserva(opts),
                    (ReservaEliminarOptions opts) => EliminarReserva(opts),
                    (ReservaMostrarOptions opts) => MostrarReservas(opts),
                    (ReservaCantidadOptions opts) => ContarReservas(opts),
                    (ReservaPurgarOptions opts) => PurgarReservas(opts),
                    errs =>
                    {
                        Console.WriteLine("Comando no válido. Intenta de nuevo.");
                        return 1;
                    }
                );
        }
    }

    static int CrearOrden(OrdenCrearOptions opts)
    {
        int aux = orders.Create(opts.Type);
        Console.WriteLine($"Creando orden del tipo: {opts.Type} con el N.{aux}");
        return 0;
    }

    static int EliminarOrden(OrdenEliminarOptions opts)
    {
        if (orders.Delete())
        {
            Console.WriteLine("Eliminando primera orden en la cola.");
            return 0;
        }
        Console.WriteLine("No hay ordenes para eliminar");
        return 0;
    }

    static int RevisarOrden(OrdenRevisarOptions opts)
    {
        Console.WriteLine(opts.All ? "Revisando todas las órdenes." : "Revisando primera orden abierta.");
        if (opts.All)
        {
            Console.WriteLine(orders.ReadFile());
            return 0;
        }
        if (!orders.IsEmpty())
        {
            Console.WriteLine(orders.Peek().ToString());
            return 0;
        }
        Console.WriteLine("No hay ordenes en el sistema.");
        return 0;
    }

    static int CrearReserva(ReservaCrearOptions opts)
    {
        Console.WriteLine($"Creando reserva con ID {opts.Id} para la fecha {opts.Fecha}.");
        reservations.Create(opts.Id, opts.Fecha);
        return 0;
    }

    static int VerificarReserva(ReservaVerificarOptions opts)
    {
        Console.WriteLine($"Verificando reserva con ID {opts.Id} para la fecha {opts.Fecha}.");
        if (reservations.Check(opts.Id, opts.Fecha))
        {
            Console.WriteLine("La reserva existe en el sistema!");
            return 0;
        }
        Console.WriteLine("La reserva no existe en el sistema.");
        return 0;
    }

    static int EliminarReserva(ReservaEliminarOptions opts)
    {
        Console.WriteLine($"Eliminando reserva con ID {opts.Id} para la fecha {opts.Fecha}.");
        reservations.Delete(opts.Id, opts.Fecha);
        return 0;
    }

    static int MostrarReservas(ReservaMostrarOptions opts)
    {
        Console.WriteLine("Mostrando todas las reservas.");
        if (reservations.GetLength() == 0)
        {
            Console.WriteLine("No hay reservas en el sistema");
            return 0;
        }
        Console.WriteLine(reservations.GetReservations());
        return 0;
    }

    static int ContarReservas(ReservaCantidadOptions opts)
    {
        Console.WriteLine("Mostrando cantidad de reservas.");
        Console.WriteLine("Cantida de reservas: " + reservations.GetLength());
        return 0;
    }

    static int PurgarReservas(ReservaPurgarOptions opts)
    {
        Console.WriteLine("Purgando todas las reservas.");
        reservations.Purge();
        return 0;
    }
}
